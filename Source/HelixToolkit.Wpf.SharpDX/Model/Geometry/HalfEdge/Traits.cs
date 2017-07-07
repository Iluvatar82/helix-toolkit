using SharpDX;

namespace HelixToolkit.Wpf.SharpDX
{
    /// <summary>
    /// Traits for the Vertices.
    /// </summary>
    public struct VertexTraits
    {
        #region Variables and Properties
        /// <summary>
        /// Vertex Position.
        /// </summary>
        public Vector3 Position;
        /// <summary>
        /// Vertex Normal.
        /// </summary>
        public Vector3 Normal;
        /// <summary>
        /// Vertex Tangent.
        /// </summary>
        public Vector3 Tangent;
        /// <summary>
        /// Vertex BiTangent.
        /// </summary>
        public Vector3 BiTangent;
        /// <summary>
        /// Vertex TextureCoordinate.
        /// </summary>
        public Vector2 TextureCoordinate;
        #endregion Variables and Properties


        #region Constructors
        /// <summary>
        /// Constructor with three Position Values.
        /// Calls the other Constructor.
        /// </summary>
        /// <param name="x">The X-Value of the Vertex Position.</param>
        /// <param name="y">The Y-Value of the Vertex Position.</param>
        /// <param name="z">The Z-Value of the Vertex Position.</param>
        public VertexTraits(float x, float y, float z)
            :this(new Vector3(x, y, z))
        { }
        /// <summary>
        /// Constructor with the Position Value.
        /// </summary>
        /// <param name="position">Position of the Vertex.</param>
        public VertexTraits(Vector3 position)
        {
            // Set Vertex Position
            this.Position = position;
            // Initialize the other Values with their default Values
            this.Normal = default(Vector3);
            this.Tangent = default(Vector3);
            this.BiTangent = default(Vector3);
            this.TextureCoordinate = default(Vector2);
        }
        #endregion Constructors
    }
    /// <summary>
    /// Traits for the Faces.
    /// </summary>
    public struct FaceTraits
    {
        #region Variables and Properties
        /// <summary>
        /// Face Normal.
        /// </summary>
        public Vector3 Normal;
        /// <summary>
        /// Face Area.
        /// </summary>
        public float Area;
        #endregion Variables and Properties
    }
    /// <summary>
    /// Mesh Traits.
    /// </summary>
    public struct MeshTraits
    {
        #region Variables and Properties
        /// <summary>
        /// Mesh Bounding Box.
        /// </summary>
        public BoundingBox BoundingBox;
        /// <summary>
        /// Indicates if the Mesh has Normals.
        /// </summary>
        public bool HasNormals;
        /// <summary>
        /// Indicates if the Mesh has TextureCoordinates.
        /// </summary>
        public bool HasTextureCoordinates;
        /// <summary>
        /// Indicates if the Mesh has Tangents (and BiTangents).
        /// </summary>
        public bool HasTangents;
        #endregion Variables and Properties
    }
}