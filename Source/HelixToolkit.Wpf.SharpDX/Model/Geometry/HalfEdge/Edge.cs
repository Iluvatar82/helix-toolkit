namespace HelixToolkit.Wpf.SharpDX
{
    public class Edge
    {
        #region Variables and Properties
        /// <summary>
        /// One Vertex of the Edge (in no specific Order).
        /// </summary>
        public Vertex Vertex_0 { get { return mHalfEdge.From; } }
        /// <summary>
        /// Other Vertex of the Edge (in no specific Order).
        /// </summary>
        public Vertex Vertex_1 { get { return mHalfEdge.To; } }
        /// <summary>
        /// One HalfEdge of the Edge (in no specific Order).
        /// </summary>
        private HalfEdge mHalfEdge;
        /// <summary>
        /// Accessor to one HalfEdge of the Edge (in no specific Order).
        /// </summary>
        public HalfEdge HalfEdge_0
        {
            get { return mHalfEdge; }
            set { mHalfEdge = value; }
        }
        /// <summary>
        /// Accessor to the other HalfEdge of the Edge (in no specific Order).
        /// </summary>
        public HalfEdge HalfEdge_1
        {
            get { return mHalfEdge.Opposite; }
            set { mHalfEdge.Opposite = value; }
        }
        /// <summary>
        /// One Face neighboring the Edge (in no specific Order).
        /// </summary>
        public Face Face_0 { get { return this.mHalfEdge.Face; } }
        /// <summary>
        /// Other Face neighboring the Edge (in no specific Order).
        /// </summary>
        public Face Face_1 { get { return this.mHalfEdge.Opposite.Face; } }
        /// <summary>
        /// The Mesh.
        /// </summary>
        public Mesh Mesh { get { return this.HalfEdge_0.Mesh; } }
        /// <summary>
        /// The Index of the Edge.
        /// </summary>
        private int mIndex;
        /// <summary>
        /// Accessor for the Index of the Edge.
        /// </summary>
        public int Index
        {
            get { return mIndex; }
            set { mIndex = value; }
        }
        /// <summary>
        /// Indicates if the Edge is Part of the Boundary.
        /// </summary>
        public bool OnBoundary { get { return this.HalfEdge_0.OnBoundary || this.HalfEdge_1.OnBoundary; } }
        #endregion Variables and Properties


        #region Constructors
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Edge() { }
        /// <summary>
        /// Constructor with a HalfEdge.
        /// </summary>
        /// <param name="half">The HalfEdge.</param>
        public Edge(HalfEdge half)
        {
            this.mHalfEdge = half;
        }
        #endregion Constructors
    }
}