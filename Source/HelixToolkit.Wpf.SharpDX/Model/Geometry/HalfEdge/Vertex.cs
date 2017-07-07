using System;
using System.Collections.Generic;
using System.Linq;

namespace HelixToolkit.Wpf.SharpDX
{
    /// <summary>
    /// A Vertex in the HalfEdge Data-Structure.
    /// </summary>
    public class Vertex
    {
        #region Variables and Properties
        /// <summary>
        /// The Vertex Traits.
        /// </summary>
        public VertexTraits Traits;
        /// <summary>
        /// The Vertex' HalfEdge.
        /// </summary>
        private HalfEdge mHalfEdge;
        /// <summary>
        /// Accessor for the Vertex' HalfEdge.
        /// </summary>
        public HalfEdge HalfEdge
        {
            get { return mHalfEdge; }
            set { mHalfEdge = value; }
        }
        /// <summary>
        /// The Mesh.
        /// </summary>
        private Mesh mMesh;
        /// <summary>
        /// Accessor to the Mesh.
        /// </summary>
        public Mesh Mesh
        {
            get { return mMesh; }
            set { mMesh = value; }
        }
        /// <summary>
        /// The Index of the Vertex.
        /// </summary>
        private int mIndex;
        /// <summary>
        /// Accessor to the Index of the Vertex.
        /// </summary>
        public int Index
        {
            get { return mIndex; }
            set { mIndex = value; }
        }
        /// <summary>
        /// Indicates if the Vertex is Part of the Boundary.
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


        #region Iterators and Counts
        /// <summary>
        /// All Vertices in the 1-Ring Neighborhood,
        /// i.e. all Vertices that are directly connected to this Vertex.
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
        /// All HalfEdges that originate in this Vertex,
        /// i.e. all "outgoing" HalfEdges in CCW Manner
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
        /// All Edges that are connected to this Vertex.
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
        /// All Faces that are adjacent to this Vertex.
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
        /// Count of the neighboring Vertices.
        /// </summary>
        /// <returns>Number of Vertices.</returns>
        public int VertexCount { get { return this.Vertices.Count(); } }
        /// <summary>
        /// Count of the adjacent HalfEdges.
        /// </summary>
        /// <returns>Number of Halfedges.</returns>
        public int HalfEdgeCount { get { return this.HalfEdges.Count(); } }
        /// <summary>
        /// Count of the adjacent Edges.
        /// </summary>
        /// <returns>Number of Edges.</returns>
        public int EdgeCount { get { return this.Edges.Count(); } }
        /// <summary>
        /// Count of the adjacent Faces.
        /// </summary>
        /// <returns>Number of Faces.</returns>
        public int FaceCount { get { return this.Faces.Count(); } }
        #endregion Iterators and Counts


        #region Constructors
        /// <summary>
        /// Default Constructor.
        /// </summary>
        internal Vertex() { }
        /// <summary>
        /// Constructor with VertexTraits.
        /// </summary>
        /// <param name="traits"></param>
        internal Vertex(VertexTraits traits)
        {
            this.Traits = traits;
        }
        #endregion Constructors


        #region Functions
        /// <summary>
        /// Find Edge to the other Vertex, if there exists one.
        /// </summary>
        /// <param name="vertex">The other Vertex.</param>
        /// <returns>The Vertex-Connecting Edge.</returns>
        public Edge FindEdgeTo(Vertex vertex)
        {
            foreach (var half in this.HalfEdges)
            {
                if (half.To == vertex)
                {
                    return half.Edge;
                }
            }
            return null;
        }
        /// <summary>
        /// Find HalfEdge to the other Vertex, if there exists one.
        /// </summary>
        /// <param name="vertex">The other Vertex.</param>
        /// <returns>The Vertex-Connecting HalfEdge.</returns>
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
        /// Find HalfEdge of the specified Face.
        /// </summary>
        /// <param name="face">The Face.</param>
        /// <returns>The HalfEdge of the Face.</returns>
        public HalfEdge FindHalfedgeTo(Face face)
        {
            foreach (var half in this.HalfEdges)
            {
                if (half.Face == face)
                {
                    return half;
                }
            }
            return null;
        }
        /// <summary>
        /// Get the indexed Vertex.
        /// </summary>
        /// <param name="index">The Vertex-Index.</param>
        /// <returns>The Vertex.</returns>
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
        /// <summary>
        /// Get the indexed HalfEdge.
        /// </summary>
        /// <param name="index">The HalfEdge-Index.</param>
        /// <returns>The HalfEdge.</returns>
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
        /// Get the indexed Edge.
        /// </summary>
        /// <param name="index">The Edge-Index.</param>
        /// <returns>The Edge.</returns>
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
        /// Get the indexed Face.
        /// </summary>
        /// <param name="index">The Face-Index.</param>
        /// <returns>The Face.</returns>
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
        #endregion Functions
    }
}