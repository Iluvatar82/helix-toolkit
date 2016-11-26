using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelixToolkit.Wpf.SharpDX
{
    /// <summary>
    /// The complete Mesh in the HalfEdge Data-Structure.
    /// </summary>
    public partial class Mesh
    {
        #region Variables and Properties
        /// <summary>
        /// The Mesh Traits.
        /// </summary>
        public MeshTraits Traits;
        /// <summary>
        /// The List of Vertices in this Mesh.
        /// </summary>
        private List<Vertex> mVertices;
        /// <summary>
        /// The List of Vertices in this Mesh (used to handle e.g. Add-Operations).
        /// </summary>
        public VertexCollection Vertices;
        /// <summary>
        /// The List of HalfEdges in this Mesh.
        /// </summary>
        private List<HalfEdge> mHalfEdges;
        /// <summary>
        /// The List of HalfEdges in this Mesh (used to handle e.g. Add-Operations).
        /// </summary>
        public HalfEdgeCollection HalfEdges;
        /// <summary>
        /// The List of Edges in this Mesh.
        /// </summary>
        private List<Edge> mEdges;
        /// <summary>
        /// The List of Edges in this Mesh (used to handle e.g. Add-Operations).
        /// </summary>
        public EdgeCollection Edges;
        /// <summary>
        /// The List of Faces in this Mesh.
        /// </summary>
        private List<Face> mFaces;
        /// <summary>
        /// The List of Faces in this Mesh (used to handle e.g. Add-Operations).
        /// </summary>
        public FaceCollection Faces;
        /// <summary>
        /// Indicates if only Triangles should be allowed in the Mesh.
        /// </summary>
        public bool TrianglesOnly;
        #endregion Variables and Properties


        #region Constructors
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Mesh() {
            // Initialize the Traits and the Collections.
            this.Traits = new MeshTraits();
            this.mVertices = new List<Vertex>();
            this.mHalfEdges = new List<HalfEdge>();
            this.mEdges = new List<Edge>();
            this.mFaces = new List<Face>();
            this.Vertices = new VertexCollection(this);
            this.HalfEdges = new HalfEdgeCollection(this);
            this.Edges = new EdgeCollection(this);
            this.Faces = new FaceCollection(this);
            this.TrianglesOnly = true;
        }
        /// <summary>
        /// Constructor from a MeshGeometry3D.
        /// </summary>
        /// <param name="geom">The MeshGeometry3D.</param>
        public Mesh(MeshGeometry3D geom)
            :this()
        {
            // Directly create the HalfEdge mesh from the Geometry
            CreateMesh(geom.Positions, geom.Indices, geom.Normals, geom.TextureCoordinates);
        }
        #endregion Constructors


        #region Functions
        /// <summary>
        /// Create the actual Mesh with all Faces.
        /// </summary>
        /// <param name="positions">The Vertex Positions.</param>
        /// <param name="triangleIndices">The Triangle Indices.</param>
        /// <param name="normals">The Vertex Normals.</param>
        /// <param name="texcoords">The Vertex TextureCoordinates.</param>
        private void CreateMesh(IList<Vector3> positions, IList<int> triangleIndices, IList<Vector3> normals = null, IList<Vector2> texcoords = null)
        {
            // Check Normal Count
            if (normals != null)
            {
                if (normals.Count != positions.Count)
                    throw new ArgumentException("Normals do not fit the point set.");
            }
            // Check textureCoordinate Count
            if (texcoords != null)
            {
                if (texcoords.Count != positions.Count)
                    throw new ArgumentException("Texcoords do not fit the point set.");
            }
            // The first Vertex of the Additions
            int startVertex = this.mVertices.Count;
            
            // Adding the Vertices
            for (int i = 0; i < positions.Count; i++)
            {
                // Create the VertexTraits and use them to create the actual Vertex of the Mesh
                var vert = new VertexTraits(positions[i]);
                if (normals != null)
                    vert.Normal = normals[i];
                if (texcoords != null)
                    vert.TextureCoordinate = texcoords[i];
                this.Vertices.Add(vert);
            }

            // Adding the Faces and Face-Indices
            for (int i = 0; i < triangleIndices.Count; i += 3)
            {
                var tri = new[]
                {
                    this.Vertices[startVertex + triangleIndices[i]],
                    this.Vertices[startVertex + triangleIndices[i+1]],
                    this.Vertices[startVertex + triangleIndices[i+2]],
                };
                // Try to add the new Triangle (TODO: catch fix)
                try
                {
                    this.Faces.Add(tri);
                }
                catch(Exception e)
                { }
            }
        }
        /// <summary>
        /// Append an Edge to the Edges-List.
        /// </summary>
        /// <param name="edge">The Edge to append.</param>
        protected void AppendToEdgeList(Edge edge)
        {
            edge.Index = mEdges.Count;
            mEdges.Add(edge);
        }
        /// <summary>
        /// Append a Face to the Faces-List.
        /// </summary>
        /// <param name="face">The Face to append.</param>
        protected void AppendToFaceList(Face face)
        {
            face.Index = mFaces.Count;
            mFaces.Add(face);
        }
        /// <summary>
        /// Append a HalfEdge to the HalfEdge-List.
        /// </summary>
        /// <param name="halfEdge">The HalfEdge to append.</param>
        protected void AppendToHalfedgeList(HalfEdge halfEdge)
        {
            halfEdge.Index = mHalfEdges.Count;
            mHalfEdges.Add(halfEdge);
        }
        /// <summary>
        /// Append a Vertex to the Vertex-List.
        /// </summary>
        /// <param name="vertex">The Vertex to append.</param>
        protected void AppendToVertexList(Vertex vertex)
        {
            vertex.Index = mVertices.Count;
            vertex.Mesh = this;
            mVertices.Add(vertex);
        }
        /// <summary>
        /// List of Boundaries as represented by their Vertex Index.
        /// </summary>
        /// <returns>The List of Boundaries.</returns>
        public List<List<int>> GetBoundaryIndices()
        {
            // The List
            var indices = new List<List<int>>();
            var processedEdges = new HashSet<Edge>();
            
            // Check all Edges
            foreach (var edge in mEdges)
            {
                // If the Edge is not on the Boundary or previously handles, skip it
                if (!edge.OnBoundary || processedEdges.Contains(edge))
                    continue;
                // Get the Boundary HalfEdge
                var halfEdgeBoundary = edge.HalfEdge_0.OnBoundary ? edge.HalfEdge_0 : edge.HalfEdge_1;
                var firstHalf = halfEdgeBoundary;
                var boundaryList = new List<int>();
                // Loop through all HalfEdges and add the Indices and Edges
                do
                {
                    boundaryList.Add(halfEdgeBoundary.From.Index);
                    processedEdges.Add(halfEdgeBoundary.Edge);
                    halfEdgeBoundary = halfEdgeBoundary.Next;
                }
                while (halfEdgeBoundary != firstHalf);
                
                // Add the found Boundary Indices
                indices.Add(boundaryList);
            }

            return indices;
        }
        /// <summary>
        /// Create a LineGeometry3D Object from all Boundary Edges.
        /// </summary>
        /// <returns>The LineGeometry3D</returns>
        public LineGeometry3D GetBoundaryGeometry()
        {
            // Use all Boundary Indices to get the Boundary Lines
            var boundaryIndices = GetBoundaryIndices();
            var lineIndices = new List<int>();
            var linePositions = new List<Vector3>();
            foreach (var boundary in boundaryIndices)
            {
                var start = linePositions.Count;
                for (int i = 0; i < boundary.Count; i++)
                {
                    var j = (i + 1) % boundary.Count;
                    lineIndices.Add(i + start);
                    lineIndices.Add(j + start);
                    linePositions.Add(Vertices[boundary[i]].Traits.Position);
                }
            }
            return new LineGeometry3D()
            {
                Positions = new Core.Vector3Collection(linePositions),
                Indices = new Core.IntCollection(lineIndices)
            };
        }
        /// <summary>
        /// Try to close the Mesh by merging all close Boundary Points together.
        /// </summary>
        /// <param name="eps">The allowed maximum Distance to merge Vertices of the Boundary.</param>
        public void TryClose(float eps = 0.0001f)
        {
            /*var boundaryPoints = this.mVertices.Where(v => v.OnBoundary).ToList();
            var mapping = new Dictionary<int, int>();
            for (int i = 0; i < boundaryPoints.Count; i++)
            {
                for (int j = i + 1; j < boundaryPoints.Count; j++)
                {
                    if (mapping.ContainsKey(j))
                    {
                        continue;
                    }

                    var l2 = SharedFunctions.LengthSquared(boundaryPoints[i].Traits.Position - boundaryPoints[j].Traits.Position);
                    if (l2 < eps)
                    {
                        mapping.Add(j, i);
                    }
                }
            }*/



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="faceIndex"></param>
        public void RemoveFace(int faceIndex)
        {
            this.Faces.Remove(this.mFaces[faceIndex]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertexIndex"></param>
        public void RemoveVertex(int vertexIndex)
        {
            this.Faces.Remove(this.mVertices[vertexIndex].Faces.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edgeIndex"></param>
        public void RemoveEdge(int edgeIndex)
        {
            if (!this.mEdges[edgeIndex].OnBoundary)
            {
                this.Faces.Remove(this.mEdges[edgeIndex].Face_0, this.mEdges[edgeIndex].Face_1);
            }
            else
            {
                this.Faces.Remove(this.mEdges[edgeIndex].HalfEdge_0.OnBoundary ? this.mEdges[edgeIndex].Face_1 : this.mEdges[edgeIndex].Face_0);
            }
        }
        #endregion Functions
    }
}