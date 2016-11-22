using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelixToolkit.Wpf.SharpDX
{
    public class Vertex
    {
        #region Variables and Properties
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Position;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Normal;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Tangent;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 BiTangent;
        /// <summary>
        /// 
        /// </summary>
        public Vector2 TextureCoordinate;
        /// <summary>
        /// 
        /// </summary>
        private HalfEdge mHalfEdge;
        /// <summary>
        /// 
        /// </summary>
        public HalfEdge HalfEdge
        {
            get { return mHalfEdge; }
            set { mHalfEdge = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private Mesh mMesh;
        /// <summary>
        /// 
        /// </summary>
        public Mesh Mesh
        {
            get { return mMesh; }
            set { mMesh = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int mIndex;
        /// <summary>
        /// 
        /// </summary>
        public int Index
        {
            get { return mIndex; }
            set { mIndex = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool OnBoundary
        {
            get
            {
                if (this.mHalfEdge == null)
                {
                    return true;
                }

                foreach (var half in this.HalfEdges)
                {
                    if (half.OnBoundary)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        #endregion Variables and Properties


        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        internal Vertex() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <param name="tangent"></param>
        /// <param name="bitangent"></param>
        /// <param name="coords"></param>
        internal Vertex(Vector3 position, Vector3 normal, Vector3 tangent, Vector3 bitangent, Vector2 coords)
        {
            this.Position = position;
            this.Normal = normal;
            this.Tangent = tangent;
            this.BiTangent = bitangent;
            this.TextureCoordinate = coords;
        }
        #endregion Constructors


        #region Iterators and Counts
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Vertex> Vertices
        {
            get
            {
                foreach (var half in this.HalfEdges)
                {
                    yield return half.To;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<HalfEdge> HalfEdges
        {
            get
            {
                var half = this.HalfEdge;
                if (half != null)
                {
                    do
                    {
                        yield return half;
                        // CW manner
                        // half = half.Opposite.Next;
                        // CCW manner
                        half = half.Previous.Opposite;
                    }
                    while (half != this.HalfEdge);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Edge> Edges
        {
            get
            {
                foreach (var half in HalfEdges)
                {
                    yield return half.Edge;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Face> Faces
        {
            get
            {
                foreach (var half in HalfEdges)
                {
                    if (half.Face != null)
                    {
                        yield return half.Face;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int VertexCount { get { return this.Vertices.Count(); } }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int HalfEdgeCount { get { return this.HalfEdges.Count(); } }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int EdgeCount { get { return this.Edges.Count(); } }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int FaceCount { get { return this.Faces.Count(); } }
        #endregion Iterators and Counts


        #region Functions
        #endregion Functions
    }
}
