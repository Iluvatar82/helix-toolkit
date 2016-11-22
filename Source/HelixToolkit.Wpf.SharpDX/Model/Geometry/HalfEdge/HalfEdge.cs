using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelixToolkit.Wpf.SharpDX
{
    public class HalfEdge
    {
        #region Variables and Properties
        /// <summary>
        /// 
        /// </summary>
        private Vertex mFrom;
        /// <summary>
        /// 
        /// </summary>
        public Vertex From
        {
            get { return mFrom; }
            set { mFrom = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private Vertex mTo;
        /// <summary>
        /// 
        /// </summary>
        public Vertex To
        {
            get { return mTo; }
            set { mTo = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private HalfEdge mPrevious;
        /// <summary>
        /// 
        /// </summary>
        public HalfEdge Previous
        {
            get { return mPrevious; }
            set { mPrevious = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private HalfEdge mNext;
        /// <summary>
        /// 
        /// </summary>
        public HalfEdge Next
        {
            get { return mNext; }
            set { mNext = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private HalfEdge mOpposite;
        /// <summary>
        /// 
        /// </summary>
        public HalfEdge Opposite
        {
            get { return mOpposite; }
            set { mOpposite = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private Edge mEdge;
        /// <summary>
        /// 
        /// </summary>
        public Edge Edge
        {
            get { return mEdge; }
            set { mEdge = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private Face mFace;
        /// <summary>
        /// 
        /// </summary>
        public Face Face
        {
            get { return mFace; }
            set { mFace = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Mesh Mesh { get { return this.To.Mesh; } }
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
        public bool OnBoundary { get { return this.mFace == null; } }
        #endregion Variables and Properties


        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public HalfEdge() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        public HalfEdge(Vertex to, Vertex from)
        {
            this.mTo = to;
            this.mFrom = from;
        }
        #endregion Constructors
    }
}
