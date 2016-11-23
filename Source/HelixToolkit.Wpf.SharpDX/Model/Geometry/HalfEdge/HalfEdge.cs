namespace HelixToolkit.Wpf.SharpDX
{
    public class HalfEdge
    {
        #region Variables and Properties
        /// <summary>
        /// The Start-Vertex.
        /// </summary>
        private Vertex mFrom;
        /// <summary>
        /// Accessor for the Start-Vertex.
        /// </summary>
        public Vertex From
        {
            get { return mFrom; }
            set { mFrom = value; }
        }
        /// <summary>
        /// The End-Vertex.
        /// </summary>
        private Vertex mTo;
        /// <summary>
        /// Accessor for the End-Vertex.
        /// </summary>
        public Vertex To
        {
            get { return mTo; }
            set { mTo = value; }
        }
        /// <summary>
        /// The previous HalfEdge (regarding the HalfeEdge's Face).
        /// </summary>
        private HalfEdge mPrevious;
        /// <summary>
        /// Accessor for the previous HalfEdge.
        /// </summary>
        public HalfEdge Previous
        {
            get { return mPrevious; }
            set { mPrevious = value; }
        }
        /// <summary>
        /// The next HalfEdge (regarding the HalfeEdge's Face).
        /// </summary>
        private HalfEdge mNext;
        /// <summary>
        /// Accessor for the next HalfEdge.
        /// </summary>
        public HalfEdge Next
        {
            get { return mNext; }
            set { mNext = value; }
        }
        /// <summary>
        /// The opposite HalfEdge,
        /// i.e. the HalfEdge with reversed "From" and "To" Vertices.
        /// </summary>
        private HalfEdge mOpposite;
        /// <summary>
        /// Accessor for the opposite HalfEdge.
        /// </summary>
        public HalfEdge Opposite
        {
            get { return mOpposite; }
            set { mOpposite = value; }
        }
        /// <summary>
        /// The Edge.
        /// </summary>
        private Edge mEdge;
        /// <summary>
        /// Accessor for the Edge.
        /// </summary>
        public Edge Edge
        {
            get { return mEdge; }
            set { mEdge = value; }
        }
        /// <summary>
        /// The Face.
        /// </summary>
        private Face mFace;
        /// <summary>
        /// Accessor for the Face.
        /// </summary>
        public Face Face
        {
            get { return mFace; }
            set { mFace = value; }
        }
        /// <summary>
        /// The Mesh.
        /// </summary>
        public Mesh Mesh { get { return this.To.Mesh; } }
        /// <summary>
        /// The Index of the HalfEdge.
        /// </summary>
        private int mIndex;
        /// <summary>
        /// Accessor for the Index of the HalfEdge.
        /// </summary>
        public int Index
        {
            get { return mIndex; }
            set { mIndex = value; }
        }
        /// <summary>
        /// Indicates if the HalfEdge is Part of the Boundary.
        /// </summary>
        public bool OnBoundary { get { return this.mFace == null; } }
        #endregion Variables and Properties


        #region Constructors
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public HalfEdge() { }
        /// <summary>
        /// Constructor with From an To Vertices specified.
        /// </summary>
        /// <param name="to">To Vertex.</param>
        /// <param name="from">From Vertex.</param>
        public HalfEdge(Vertex to, Vertex from)
        {
            this.mTo = to;
            this.mFrom = from;
        }
        #endregion Constructors
    }
}