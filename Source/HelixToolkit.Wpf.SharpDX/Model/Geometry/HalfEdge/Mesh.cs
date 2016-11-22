using HelixToolkit.Wpf.SharpDX;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelixToolkit.Wpf.SharpDX
{
    public partial class Mesh
    {
        #region Variables and Properties
        /// <summary>
        /// 
        /// </summary>
        public MeshTraits Traits;
        /// <summary>
        /// 
        /// </summary>
        private List<Vertex> mVertices;
        /// <summary>
        /// 
        /// </summary>
        public VertexCollection Vertices;
        /// <summary>
        /// 
        /// </summary>
        private List<HalfEdge> mHalfEdges;
        /// <summary>
        /// 
        /// </summary>
        public HalfEdgeCollection HalfEdges;
        /// <summary>
        /// 
        /// </summary>
        private List<Edge> mEdges;
        /// <summary>
        /// 
        /// </summary>
        public EdgeCollection Edges;
        /// <summary>
        /// 
        /// </summary>
        private List<Face> mFaces;
        /// <summary>
        /// 
        /// </summary>
        public FaceCollection Faces;
        /// <summary>
        /// 
        /// </summary>
        public bool TrianglesOnly;
        #endregion Variables and Properties


        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Mesh() {
            this.Traits = new SharpDX.MeshTraits();
            this.Vertices = new VertexCollection(this);
            this.HalfEdges = new HalfEdgeCollection(this);
            this.Edges = new EdgeCollection(this);
            this.Faces = new FaceCollection(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="geom"></param>
        public Mesh(MeshGeometry3D geom)
            :this()
        {
            createMesh(geom.Positions, geom.Indices, geom.Normals, geom.TextureCoordinates);
        }
        #endregion Constructors


        #region Functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="triangleIndices"></param>
        /// <param name="normals"></param>
        /// <param name="texcoords"></param>
        private void createMesh(IList<Vector3> positions, IList<int> triangleIndices, IList<Vector3> normals = null, IList<Vector2> texcoords = null)
        {
            if (normals != null)
            {
                if (normals.Count != positions.Count)
                    throw new ArgumentException("Normals do not fit the point set.");
            }
            if (texcoords != null)
            {
                if (texcoords.Count != positions.Count)
                    throw new ArgumentException("Texcoords do not fit the point set.");
            }

            int startVertex = this.mVertices.Count;

            for (int i = 0; i < positions.Count; i++)
            {
                var vert = new VertexTraits(positions[i]);
                if (normals != null)
                    vert.Normal = normals[i];
                if (texcoords != null)
                    vert.TextureCoordinate = texcoords[i];

                this.Vertices.Add(vert);
            }

            for (int i = 0; i < triangleIndices.Count; i += 3)
            {
                var tri = new[]
                {
                    this.Vertices[startVertex+triangleIndices[i]],
                    this.Vertices[startVertex+triangleIndices[i+1]],
                    this.Vertices[startVertex+triangleIndices[i+2]],
                };
                this.Faces.Add(tri);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        protected void AppendToEdgeList(Edge edge)
        {
            edge.Index = mEdges.Count;
            mEdges.Add(edge);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="face"></param>
        protected void AppendToFaceList(Face face)
        {
            face.Index = mFaces.Count;
            mFaces.Add(face);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="halfEdge"></param>
        protected void AppendToHalfedgeList(HalfEdge halfEdge)
        {
            halfEdge.Index = mHalfEdges.Count;
            mHalfEdges.Add(halfEdge);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertex"></param>
        protected void AppendToVertexList(Vertex vertex)
        {
            vertex.Index = mVertices.Count;
            vertex.Mesh = this;
            mVertices.Add(vertex);
        }
        #endregion Functions
    }
}
