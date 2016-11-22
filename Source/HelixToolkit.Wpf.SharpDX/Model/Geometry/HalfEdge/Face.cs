using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelixToolkit.Wpf.SharpDX
{
    public class Face
    {
        #region Variables and Properties
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Normal;
        /// <summary>
        /// 
        /// </summary>
        public float Area;
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
        public Mesh Mesh { get { return this.mHalfEdge.Mesh; } }
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
                foreach (var half in this.HalfEdges)
                {
                    if (half.Opposite.OnBoundary)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        #endregion Variables and Properties


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
                        half = half.Next;
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
                        yield return half.Opposite.Face;
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


        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Face() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="half"></param>
        public Face(HalfEdge half)
        {
            this.mHalfEdge = half;
        }
        #endregion Constructors


        #region Functions
        #endregion Functions
    }
}
