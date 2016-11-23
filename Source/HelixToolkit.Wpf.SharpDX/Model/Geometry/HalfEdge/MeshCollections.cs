using System;
using System.Collections;
using System.Collections.Generic;

namespace HelixToolkit.Wpf.SharpDX
{
    /// <summary>
    /// The complete Mesh in the HalfEdge Data-Structure.
    /// </summary>
    public partial class Mesh
    {
        // Nestes Collection Classes are used because of the easy access to the Mesh's Objects.

        /// <summary>
        /// Collection of Vertices.
        /// </summary>
        public class VertexCollection : IEnumerable<Vertex>
        {
            #region Variables and Properties
            /// <summary>
            /// The Mesh.
            /// </summary>
            readonly Mesh mMesh;
            /// <summary>
            /// Indexer for the Vertices.
            /// </summary>
            /// <param name="index">The Vertex-Index.</param>
            /// <returns>Vertex at the specified Index in the Collection.</returns>
            public Vertex this[int index]
            {
                get { return mMesh.mVertices[index]; }
            }
            /// <summary>
            /// The Count of Vertices in the Collection.
            /// </summary>
            public int Count
            {
                get { return mMesh.mVertices.Count; }
            }
            #endregion Variables and Properties


            #region Constructors
            /// <summary>
            /// Constructor with a Mesh.
            /// </summary>
            /// <param name="mesh">The Mesh.</param>
            public VertexCollection(Mesh mesh)
            {
                this.mMesh = mesh;
            }
            #endregion


            #region Iterators
            /// <summary>
            /// Get the Enumerator.
            /// </summary>
            /// <returns>The Enumerator.</returns>
            public IEnumerator<Vertex> GetEnumerator()
            {
                foreach (var vert in mMesh.mVertices)
                {
                    yield return vert;
                }
            }
            /// <summary>
            /// Get the Enumerator.
            /// </summary>
            /// <returns>The Enumerator.</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion


            #region Functions
            /// <summary>
            /// Add a new Vertex to the Mesh (and Mesh's Vertex-List).
            /// </summary>
            /// <returns>The newly created Vertex.</returns>
            public Vertex Add()
            {
                // Add default Vertex and return it
                Vertex vert = new Vertex();
                mMesh.AppendToVertexList(vert);
                return vert;
            }
            /// <summary>
            /// Add a new Vertex with specified Traits to the Mesh (and Mesh's Vertex-List).
            /// </summary>
            /// <param name="vertexTraits">The Vertextraits to use.</param>
            /// <returns>The newly created Vertex.</returns>
            public Vertex Add(VertexTraits vTraits)
            {
                // Add Vertex with specified VertexTraits and return it
                Vertex vert = new Vertex(vTraits);
                mMesh.AppendToVertexList(vert);
                return vert;
            }
            #endregion Functions
        }
        /// <summary>
        /// Collection of HalfEdges.
        /// </summary>
        public class HalfEdgeCollection : IEnumerable<HalfEdge>
        {
            #region Variables and Properties
            /// <summary>
            /// The Mesh.
            /// </summary>
            readonly Mesh mMesh;
            /// <summary>
            /// Indexer for the HalfEdges.
            /// </summary>
            /// <param name="index">The HalfEdge-Index.</param>
            /// <returns>HalfEdge at the specified Index in the Collection.</returns>
            public HalfEdge this[int index]
            {
                get { return mMesh.mHalfEdges[index]; }
            }
            /// <summary>
            /// The Count of HalfEdges in the Collection.
            /// </summary>
            public int Count
            {
                get { return mMesh.mHalfEdges.Count; }
            }
            #endregion Variables and Properties


            #region Constructors
            /// <summary>
            /// Constructor with a Mesh.
            /// </summary>
            /// <param name="mesh">The Mesh.</param>
            public HalfEdgeCollection(Mesh mesh)
            {
                this.mMesh = mesh;
            }
            #endregion


            #region Iterators
            /// <summary>
            /// Get the Enumerator.
            /// </summary>
            /// <returns>The Enumerator.</returns>
            public IEnumerator<HalfEdge> GetEnumerator()
            {
                foreach (var half in mMesh.mHalfEdges)
                {
                    yield return half;
                }
            }
            /// <summary>
            /// Get the Enumerator.
            /// </summary>
            /// <returns>The Enumerator.</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion
        }
        /// <summary>
        /// Collection of Edges.
        /// </summary>
        public class EdgeCollection : IEnumerable<Edge>
        {
            #region Variables and Properties
            /// <summary>
            /// The Mesh.
            /// </summary>
            readonly Mesh mMesh;
            /// <summary>
            /// Indexer for the Edges.
            /// </summary>
            /// <param name="index">The Edge-Index.</param>
            /// <returns>Edge at the specified Index in the Collection.</returns>
            public Edge this[int index]
            {
                get { return mMesh.mEdges[index]; }
            }
            /// <summary>
            /// The Count of Edges in the Collection.
            /// </summary>
            public int Count
            {
                get { return mMesh.mEdges.Count; }
            }
            #endregion Variables and Properties


            #region Constructors
            /// <summary>
            /// Constructor with a Mesh.
            /// </summary>
            /// <param name="mesh">The Mesh.</param>
            public EdgeCollection(Mesh mesh)
            {
                this.mMesh = mesh;
            }
            #endregion


            #region Iterators
            /// <summary>
            /// Get the Enumerator.
            /// </summary>
            /// <returns>The Enumerator.</returns>
            public IEnumerator<Edge> GetEnumerator()
            {
                foreach (var edge in mMesh.mEdges)
                {
                    yield return edge;
                }
            }
            /// <summary>
            /// Get the Enumerator.
            /// </summary>
            /// <returns>The Enumerator.</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion
        }
        /// <summary>
        /// Collection of Faces.
        /// </summary>
        public class FaceCollection : IEnumerable<Face>
        {
            #region Variables and Properties
            /// <summary>
            /// The Mesh.
            /// </summary>
            readonly Mesh mMesh;
            /// <summary>
            /// Indexer for the Faces.
            /// </summary>
            /// <param name="index">The Face-Index.</param>
            /// <returns>Face at the specified Index in the Collection.</returns>
            public Face this[int index]
            {
                get { return mMesh.mFaces[index]; }
            }
            /// <summary>
            /// The Count of Faces in the Collection.
            /// </summary>
            public int Count
            {
                get { return mMesh.mFaces.Count; }
            }
            #endregion Variables and Properties


            #region Constructors
            /// <summary>
            /// Constructor with a Mesh.
            /// </summary>
            /// <param name="mesh">The Mesh.</param>
            public FaceCollection(Mesh mesh)
            {
                this.mMesh = mesh;
            }
            #endregion


            #region Iterators
            /// <summary>
            /// Get the Enumerator.
            /// </summary>
            /// <returns>The Enumerator.</returns>
            public IEnumerator<Face> GetEnumerator()
            {
                foreach (var face in mMesh.mFaces)
                {
                    yield return face;
                }
            }
            /// <summary>
            /// Get the Enumerator.
            /// </summary>
            /// <returns>The Enumerator.</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion


            #region Functions
            /// <summary>
            /// Add a new Face to the Mesh (and Mesh's Face-List).
            /// </summary>
            /// <param name="vertices">The Vertices of the Face.</param>
            /// <returns>The newly created Face.</returns>
            public Face Add(params Vertex[] vertices)
            {
                // Create default FaceTraits and call other Version of the Function
                return Add(default(FaceTraits), vertices);
            }
            /// <summary>
            /// Add a new Face to the Mesh (and Mesh's Face-List).
            /// </summary>
            /// <param name="traits">The FaceTraits.</param>
            /// <param name="vertices">The Vertices of the Face.</param>
            /// <returns>The newly created Face.</returns>
            public Face Add(FaceTraits traits, params Vertex[] vertices)
            {
                // TODO: use Triangulator
                // If we only want Triangles in the Mesh
                if (mMesh.TrianglesOnly)
                {
                    return AddTriangles(traits, vertices)[0];
                }
                // If all kinds of Faces are allowed
                else
                {
                    return CreateFace(traits, vertices);
                }
            }
            /// <summary>
            /// Add new Triangles to the Mesh (and Mesh's Face-List).
            /// </summary>
            /// <param name="vertices">The Vertices to use.</param>
            /// <returns>The newly created Faces.</returns>
            public Face[] AddTriangles(params Vertex[] vertices)
            {
                // Create default FaceTraits and call other Version of the Function
                return AddTriangles(default(FaceTraits), vertices);
            }
            /// <summary>
            /// Add new Triangles to the Mesh (and Mesh's Face-List).
            /// </summary>
            /// <param name="traits">The FaceTraits.</param>
            /// <param name="vertices">The Vertices of the Face.</param>
            /// <returns>The newly created Faces.</returns>
            public Face[] AddTriangles(FaceTraits traits, params Vertex[] vertices)
            {
                // Check the Number of provided Vertices
                int numVertices = vertices.Length;
                if (numVertices < 3)
                {
                    throw new ArgumentException("Cannot create a polygon with fewer than three vertices.");
                }

                // A Triangle-Fan is created if more than three Vertices are specified
                // TODO: use Triangulator
                Face[] addedFaces = new Face[numVertices - 2];
                for (int i = 0; i < numVertices - 2; ++i)
                {
                    addedFaces[i] = CreateFace(traits, vertices[0], vertices[i + 1], vertices[i + 2]);
                }

                return addedFaces;
            }
            /// <summary>
            /// The actual Face Creation for the Mesh.
            /// </summary>
            /// <param name="traits">The FaceTraits.</param>
            /// <param name="vertices">The Vertices of the Face to add.</param>
            /// <returns>The newly created Face.</returns>
            private Face CreateFace(FaceTraits traits, params Vertex[] vertices)
            {
                // Check the Number of Vertices
                int numVerts = vertices.Length;
                if (numVerts < 3)
                {
                    throw new ArgumentException("Cannot create a polygon with fewer than three vertices.");
                }

                // Helper for the Vertices of the new Face
                Edge edge;
                Face face;
                // Helper for the Vertices of the new Face
                HalfEdge[] faceHalfedges = new HalfEdge[numVerts];
                bool[] isNewEdge = new bool[numVerts];
                var isUsedVertex = new bool[numVerts];

                // For each Vertex check if we need to create new HalfEdges / Edges
                for (int i = 0; i < numVerts; ++i)
                {
                    // The next Vertex of the Face
                    int j = (i + 1) % numVerts;
                    if (vertices[i] == null)
                    {
                        throw new ArgumentNullException("Can't add a null vertex to a face.");
                    }
                    if (!vertices[i].OnBoundary)
                    {
                        throw new ArgumentException("Can't add an edge to a vertex on the interior of a mesh.");
                    }

                    // Find the connecting HalfEdge between current and next Vertex if it exists
                    faceHalfedges[i] = vertices[i].FindHalfedgeTo(vertices[j]);
                    isNewEdge[i] = (faceHalfedges[i] == null);
                    isUsedVertex[i] = (vertices[i].HalfEdge != null);

                    if (!isNewEdge[i] && !faceHalfedges[i].OnBoundary)
                    {
                        throw new ArgumentException("Can't add more than two faces to an edge.");
                    }
                }

                // Create a new Face and add it to the Faces-List of the Mesh
                face = new Face(traits);
                mMesh.AppendToFaceList(face);

                // For each Vertex add new HalfEdges / Edges if needed
                for (int i = 0; i < numVerts; ++i)
                {
                    // The next Vertex
                    int j = (i + 1) % numVerts;

                    // If we need to create a new HalfEdge / Edge for the Vertex
                    if (isNewEdge[i])
                    {
                        // Create a new Edge and add it to the Edges-List of the Mesh
                        edge = new Edge();
                        mMesh.AppendToEdgeList(edge);

                        // Create a new Halfedge and add it to the Edges-List of the Mesh
                        faceHalfedges[i] = new HalfEdge();
                        mMesh.AppendToHalfedgeList(faceHalfedges[i]);

                        // Create a new opposite Halfedge and add it to the Edges-List of the Mesh
                        faceHalfedges[i].Opposite = new HalfEdge();
                        mMesh.AppendToHalfedgeList(faceHalfedges[i].Opposite);

                        // Also set the opposite's Opposite to the first new created HalfEdge
                        faceHalfedges[i].Opposite.Opposite = faceHalfedges[i];
                        
                        // ...and the first Halfedge of the new Edge
                        edge.HalfEdge_0 = faceHalfedges[i];

                        // Set the Halfedge's edge to the new Edge
                        faceHalfedges[i].Edge = edge;
                        faceHalfedges[i].Opposite.Edge = edge;

                        // Set the To-Vertex for the new HalfEdges to be the next Vertex
                        faceHalfedges[i].To = vertices[j];
                        faceHalfedges[i].Opposite.To = vertices[i];

                        // If not set Previously set the Vertex' HalfEdge
                        if (vertices[i].HalfEdge == null)
                        {
                            vertices[i].HalfEdge = faceHalfedges[i];
                        }
                    }
                    // Error checking
                    if (faceHalfedges[i].Face != null)
                    {
                        throw new ArgumentException("An inner halfedge already has a face assigned to it.");
                    }

                    // Set the Face of the Halfedge to be the new Face
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