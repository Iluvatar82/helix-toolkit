using SharpDX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelixToolkit.Wpf.SharpDX
{
    public partial class Mesh
    {
        /// <summary>
        /// 
        /// </summary>
        public class VertexCollection : IEnumerable<Vertex>
        {
            #region Variables and Properties
            /// <summary>
            /// 
            /// </summary>
            readonly Mesh mMesh;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public Vertex this[int index]
            {
                get { return mMesh.mVertices[index]; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int Count
            {
                get { return mMesh.mVertices.Count; }
            }
            #endregion Variables and Properties


            #region Constructors
            /// <summary>
            /// 
            /// </summary>
            /// <param name="mesh"></param>
            public VertexCollection(Mesh mesh)
            {
                this.mMesh = mesh;
            }
            #endregion


            #region Iterators
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public IEnumerator<Vertex> GetEnumerator()
            {
                foreach (var vert in mMesh.mVertices)
                {
                    yield return vert;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion


            #region Functions
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public Vertex Add()
            {
                Vertex vert = new Vertex();
                mMesh.AppendToVertexList(vert);
                return vert;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="vertexTraits"></param>
            /// <returns></returns>
            public Vertex Add(VertexTraits vTraits)
            {
                Vertex vert = new Vertex(vTraits);
                mMesh.AppendToVertexList(vert);
                return vert;
            }
            #endregion Functions
        }
        /// <summary>
        /// 
        /// </summary>
        public class HalfEdgeCollection : IEnumerable<HalfEdge>
        {
            #region Variables and Properties
            /// <summary>
            /// 
            /// </summary>
            readonly Mesh mMesh;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public HalfEdge this[int index]
            {
                get { return mMesh.mHalfEdges[index]; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int Count
            {
                get { return mMesh.mHalfEdges.Count; }
            }
            #endregion Variables and Properties


            #region Constructors
            /// <summary>
            /// 
            /// </summary>
            /// <param name="mesh"></param>
            public HalfEdgeCollection(Mesh mesh)
            {
                this.mMesh = mesh;
            }
            #endregion


            #region Iterators
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public IEnumerator<HalfEdge> GetEnumerator()
            {
                foreach (var half in mMesh.mHalfEdges)
                {
                    yield return half;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public class EdgeCollection : IEnumerable<Edge>
        {
            #region Variables and Properties
            /// <summary>
            /// 
            /// </summary>
            readonly Mesh mMesh;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public Edge this[int index]
            {
                get { return mMesh.mEdges[index]; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int Count
            {
                get { return mMesh.mEdges.Count; }
            }
            #endregion Variables and Properties


            #region Constructors
            /// <summary>
            /// 
            /// </summary>
            /// <param name="mesh"></param>
            public EdgeCollection(Mesh mesh)
            {
                this.mMesh = mesh;
            }
            #endregion


            #region Iterators
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public IEnumerator<Edge> GetEnumerator()
            {
                foreach (var edge in mMesh.mEdges)
                {
                    yield return edge;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public class FaceCollection : IEnumerable<Face>
        {
            #region Variables and Properties
            /// <summary>
            /// 
            /// </summary>
            readonly Mesh mMesh;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public Face this[int index]
            {
                get { return mMesh.mFaces[index]; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int Count
            {
                get { return mMesh.mFaces.Count; }
            }
            #endregion Variables and Properties


            #region Constructors
            /// <summary>
            /// 
            /// </summary>
            /// <param name="mesh"></param>
            public FaceCollection(Mesh mesh)
            {
                this.mMesh = mesh;
            }
            #endregion


            #region Iterators
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public IEnumerator<Face> GetEnumerator()
            {
                foreach (var face in mMesh.mFaces)
                {
                    yield return face;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion


            #region Functions
            /// <summary>
            /// 
            /// </summary>
            /// <param name="vertices"></param>
            /// <returns></returns>
            public Face Add(params Vertex[] vertices)
            {
                return Add(default(FaceTraits), vertices);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="traits"></param>
            /// <param name="vertices"></param>
            /// <returns></returns>
            public Face Add(FaceTraits traits, params Vertex[] vertices)
            {
                if (mMesh.TrianglesOnly)
                {
                    return AddTriangles(traits, vertices)[0];
                }
                else
                {
                    return CreateFace(traits, vertices);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="vertices"></param>
            /// <returns></returns>
            public Face[] AddTriangles(params Vertex[] vertices)
            {
                return AddTriangles(default(FaceTraits), vertices);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="traits"></param>
            /// <param name="vertices"></param>
            /// <returns></returns>
            public Face[] AddTriangles(FaceTraits traits, params Vertex[] vertices)
            {
                int n = vertices.Length;
                if (n < 3)
                {
                    throw new ArgumentException("Cannot create a polygon with fewer than three vertices.");
                }

                Face[] addedFaces = new Face[n - 2];
                for (int i = 0; i < n - 2; ++i)
                {
                    addedFaces[i] = CreateFace(traits, vertices[0], vertices[i + 1], vertices[i + 2]);
                }

                return addedFaces;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="traits"></param>
            /// <param name="vertices"></param>
            /// <returns></returns>
            private Face CreateFace(FaceTraits traits, params Vertex[] vertices)
            {
                int numVerts = vertices.Length;
                if (numVerts < 3)
                {
                    throw new ArgumentException("Cannot create a polygon with fewer than three vertices.");
                }

                Edge edge;
                Face face;
                HalfEdge[] faceHalfedges = new HalfEdge[numVerts];
                bool[] isNewEdge = new bool[numVerts];
                var isUsedVertex = new bool[numVerts];
                for (int i = 0; i < numVerts; ++i)
                {
                    int j = (i + 1) % numVerts;
                    if (vertices[i] == null)
                    {
                        throw new ArgumentNullException("Can't add a null vertex to a face.");
                    }
                    if (!vertices[i].OnBoundary)
                    {
                        throw new ArgumentException("Can't add an edge to a vertex on the interior of a mesh.");
                    }

                    faceHalfedges[i] = vertices[i].FindHalfedgeTo(vertices[j]);
                    isNewEdge[i] = (faceHalfedges[i] == null);
                    isUsedVertex[i] = (vertices[i].HalfEdge != null);

                    if (!isNewEdge[i] && !faceHalfedges[i].OnBoundary)
                    {
                        throw new ArgumentException("Can't add more than two faces to an edge.");
                    }
                }

                // Create a new Face
                face = new Face(traits);
                mMesh.AppendToFaceList(face);

                for (int i = 0; i < numVerts; ++i)
                {
                    int j = (i + 1) % numVerts;
                    if (isNewEdge[i])
                    {
                        edge = new Edge();
                        mMesh.AppendToEdgeList(edge);

                        faceHalfedges[i] = new HalfEdge();
                        mMesh.AppendToHalfedgeList(faceHalfedges[i]);

                        faceHalfedges[i].Opposite = new HalfEdge();
                        mMesh.AppendToHalfedgeList(faceHalfedges[i].Opposite);

                        faceHalfedges[i].Opposite.Opposite = faceHalfedges[i];

                        edge.HalfEdge_0 = faceHalfedges[i];

                        faceHalfedges[i].Edge = edge;
                        faceHalfedges[i].Opposite.Edge = edge;

                        faceHalfedges[i].To = vertices[j];
                        faceHalfedges[i].Opposite.To = vertices[i];

                        if (vertices[i].HalfEdge == null)
                        {
                            vertices[i].HalfEdge = faceHalfedges[i];
                        }
                    }
                    if (faceHalfedges[i].Face != null)
                    {
                        throw new ArgumentException("An inner halfedge already has a face assigned to it.");
                    }

                    faceHalfedges[i].Face = face;
                }

                for (int i = 0; i < numVerts; ++i)
                {
                    int j = (i + 1) % numVerts;
                    if (isNewEdge[i] && isNewEdge[j] && isUsedVertex[j])
                    {
                        HalfEdge closeHalfedge = null;

                        foreach (var half in vertices[j].HalfEdges)
                        {
                            if (half.Face == null)
                            {
                                closeHalfedge = half;
                                break;
                            }
                        }

                        var openHalfedge = closeHalfedge.Previous;

                        faceHalfedges[i].Opposite.Previous = openHalfedge;
                        openHalfedge.Next = faceHalfedges[i].Opposite;
                        faceHalfedges[j].Opposite.Next = closeHalfedge;
                        closeHalfedge.Previous = faceHalfedges[j].Opposite;
                    }
                    else if (isNewEdge[i] && isNewEdge[j])
                    {
                        faceHalfedges[i].Opposite.Previous = faceHalfedges[j].Opposite;
                        faceHalfedges[j].Opposite.Next = faceHalfedges[i].Opposite;
                    }
                    else if (isNewEdge[i] && !isNewEdge[j])
                    {
                        faceHalfedges[i].Opposite.Previous = faceHalfedges[j].Previous;
                        faceHalfedges[j].Previous.Next = faceHalfedges[i].Opposite;
                    }
                    else if (!isNewEdge[i] && isNewEdge[j])
                    {
                        faceHalfedges[i].Next.Previous = faceHalfedges[j].Opposite;
                        faceHalfedges[j].Opposite.Next = faceHalfedges[i].Next;
                    }
                    else if (!isNewEdge[i] && !isNewEdge[j] && faceHalfedges[i].Next != faceHalfedges[j])
                    {
                        var closeHalfedge = faceHalfedges[i].Opposite;

                        do
                        {
                            closeHalfedge = closeHalfedge.Previous.Opposite;
                        }
                        while (closeHalfedge.Face != null && closeHalfedge != faceHalfedges[j] && closeHalfedge != faceHalfedges[i].Opposite);

                        if (closeHalfedge == faceHalfedges[j] || closeHalfedge == faceHalfedges[i].Opposite)
                        {
                            throw new ArgumentException("Unable to find an opening to relink an existing face.");
                        }

                        var openHalfedge = closeHalfedge.Previous;

                        openHalfedge.Next = faceHalfedges[i].Next;
                        faceHalfedges[i].Next.Previous = openHalfedge;

                        faceHalfedges[j].Previous.Next = closeHalfedge;
                        closeHalfedge.Previous = faceHalfedges[j].Previous;
                    }

                    faceHalfedges[i].Next = faceHalfedges[j];
                    faceHalfedges[j].Previous = faceHalfedges[i];
                }

                face.HalfEdge = faceHalfedges[0];

                return face;
            }
        }
        #endregion Functions
    }
}