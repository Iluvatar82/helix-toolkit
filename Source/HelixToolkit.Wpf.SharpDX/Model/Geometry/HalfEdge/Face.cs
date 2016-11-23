using System;
using System.Collections.Generic;
using System.Linq;

namespace HelixToolkit.Wpf.SharpDX
{
    /// <summary>
    /// A Face in the HalfEdge Data-Structure.
    /// </summary>
    public class Face
    {
        #region Variables and Properties
        /// <summary>
        /// The Face Traits.
        /// </summary>
        public FaceTraits Traits;
        /// <summary>
        /// The HalfEdge of the Face.
        /// </summary>
        private HalfEdge mHalfEdge;
        /// <summary>
        /// Accessor for the HalfEdge of the Face.
        /// </summary>
        public HalfEdge HalfEdge
        {
            get { return mHalfEdge; }
            set { mHalfEdge = value; }
        }
        /// <summary>
        /// The Mesh.
        /// </summary>
        public Mesh Mesh { get { return this.mHalfEdge.Mesh; } }
        /// <summary>
        /// The Index of the Face.
        /// </summary>
        private int mIndex;
        /// <summary>
        /// Accessor for the Index of the Face.
        /// </summary>
        public int Index
        {
            get { return mIndex; }
            set { mIndex = value; }
        }
        /// <summary>
        /// Indicates if the Face is Part of the Boundary.
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
        /// All Vertices defining this Face.
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
        /// All HalfEdges defining this Face.
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
        /// All Edges that are adjacent to this Face.
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
        /// All Faces that are "directly" adjacent to this Face.
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
        /// Count of the Vertices.
        /// </summary>
        /// <returns>Number of Vertices.</returns>
        public int VertexCount { get { return this.Vertices.Count(); } }
        /// <summary>
        /// Count of the HalfEdges.
        /// </summary>
        /// <returns>Number of HalfEdges.</returns>
        public int HalfEdgeCount { get { return this.HalfEdges.Count(); } }
        /// <summary>
        /// Count of the Edges.
        /// </summary>
        /// <returns>Number of Edges.</returns>
        public int EdgeCount { get { return this.Edges.Count(); } }
        /// <summary>
        /// Count of the adjacent Faces.
        /// </summary>
        /// <returns>Number of adjacent Faces.</returns>
        public int FaceCount { get { return this.Faces.Count(); } }
        #endregion Iterators and Counts


        #region Constructors
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Face() { }
        /// <summary>
        /// Constructor with FaceTraits.
        /// </summary>
        /// <param name="traits">The FaceTraits.</param>
        public Face(FaceTraits traits)
        {
            this.Traits = traits;
        }
        #endregion Constructors


        #region Functions
        /// <summary>
        /// Finds the Edge connecting this Face and the adjacent Face.
        /// </summary>
        /// <param name="face">The adjacent Face.</param>
        /// <returns>The Edge between this Face and the adjacent Face.</returns>
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
        /// Finds the HalfEdge of this Face pointing to the Vertex.
        /// </summary>
        /// <param name="vertex">The Vertex of the Face.</param>
        /// <returns>The HalfEdge of the Face pointing to the Vertex.</returns>
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