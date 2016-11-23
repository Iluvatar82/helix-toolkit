using SharpDX;
using System;
using System.Collections.Generic;

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
                this.Faces.Add(tri);
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
        #endregion Functions
    }
}