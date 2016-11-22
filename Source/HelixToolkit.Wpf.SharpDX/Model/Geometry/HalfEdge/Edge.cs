using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelixToolkit.Wpf.SharpDX
{
    public class Edge
    {
        #region Variables and Properties
        /// <summary>
        /// 
        /// </summary>
        public Vertex Vertex_0 { get { return mHalfEdge.From; } }
        /// <summary>
        /// 
        /// </summary>
        public Vertex Vertex_1 { get { return mHalfEdge.To; } }
        /// <summary>
        /// 
        /// </summary>
        private HalfEdge mHalfEdge;
        /// <summary>
        /// 
        /// </summary>
        public HalfEdge HalfEdge_0
        {
            get { return mHalfEdge; }
            set { mHalfEdge = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public HalfEdge HalfEdge_1
        {
            get { return mHalfEdge.Opposite; }
            set { mHalfEdge.Opposite = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Face Face_0 { get { return this.mHalfEdge.Face; } }
        /// <summary>
        /// 
        /// </summary>
        public Face Face_1 { get { return this.mHalfEdge.Opposite.Face; } }
        /// <summary>
        /// 
        /// </summary>
        public Mesh Mesh { get { return this.HalfEdge_0.Mesh; } }
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
        #endregion Variables and Properties


        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Edge() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="half"></param>
        public Edge(HalfEdge half)
        {
            this.mHalfEdge = half;
        }
        #endregion Constructors


        #region Functions
        #endregion Functions
    }
}
