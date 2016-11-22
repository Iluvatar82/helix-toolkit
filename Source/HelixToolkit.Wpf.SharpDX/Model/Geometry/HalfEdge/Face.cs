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
        public FaceTraits Traits;
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
        /// <param name="traits"></param>
        public Face(FaceTraits traits)
        {
            this.Traits = traits;
        }
        #endregion Constructors


        #region Functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public Edge FindEdgeTo(Face face)
        {
            foreach (var half in this.HalfEdges)
            {
                if (half.Opposite.Face == face)
                {
                    return half.Edge;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public HalfEdge FindHalfedgeTo(Vertex vertex)
        {
            foreach (var half in this.HalfEdges)
            {
                if (half.To == vertex)
                {
                    return half;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Edge GetEdge(int index)
        {
            int count = 0;
            foreach (var edge in this.Edges)
            {
                if (count == index)
                {
                    return edge;
                }
                ++count;
            }
            throw new ArgumentOutOfRangeException("index");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Face GetFace(int index)
        {
            int count = 0;
            foreach (var face in this.Faces)
            {
                if (count == index)
                {
                    return face;
                }
                ++count;
            }
            throw new ArgumentOutOfRangeException("index");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public HalfEdge GetHalfedge(int index)
        {
            int count = 0;
            foreach (var half in this.HalfEdges)
            {
                if (count == index)
                {
                    return half;
                }
                ++count;
            }
            throw new ArgumentOutOfRangeException("index");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vertex GetVertex(int index)
        {
            int count = 0;
            foreach (var vert in this.Vertices)
            {
                if (count == index)
                {
                    return vert;
                }
                ++count;
            }
            throw new ArgumentOutOfRangeException("index");
        }
        #endregion Functions
    }
}
