using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelixToolkit.Wpf.SharpDX
{
    public class Mesh
    {
        #region Variables and Properties
        /// <summary>
        /// 
        /// </summary>
        private BoundingBox mBoundingBox;
        /// <summary>
        /// 
        /// </summary>
        public BoundingBox BoundingBox
        {
            get { return mBoundingBox; }
            set { mBoundingBox = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool HasNormals;
        /// <summary>
        /// 
        /// </summary>
        public bool HasTextureCoordinates;
        /// <summary>
        /// 
        /// </summary>
        public bool HasTangents;
        /// <summary>
        /// 
        /// </summary>
        private List<Vertex> mVertices;
        /// <summary>
        /// 
        /// </summary>
        public List<Vertex> Vertices
        {
            get { return mVertices; }
            set { mVertices = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private List<HalfEdge> mHalfEdges;
        /// <summary>
        /// 
        /// </summary>
        public List<HalfEdge> HalfEdges
        {
            get { return mHalfEdges; }
            set { mHalfEdges = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private List<Edge> mEdges;
        /// <summary>
        /// 
        /// </summary>
        public List<Edge> Edges
        {
            get { return mEdges; }
            set { mEdges = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private List<Face> mFaces;
        /// <summary>
        /// 
        /// </summary>
        public List<Face> Faces
        {
            get { return mFaces; }
            set { mFaces = value; }
        }
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
            this.Vertices = new List<Vertex>();
            this.HalfEdges = new List<HalfEdge>();
            this.Edges = new List<Edge>();
            this.Faces = new List<Face>();
        }
        #endregion Constructors


        #region Functions

        #endregion Functions

    }
}
