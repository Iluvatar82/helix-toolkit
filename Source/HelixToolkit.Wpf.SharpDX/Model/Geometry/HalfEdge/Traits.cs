using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelixToolkit.Wpf.SharpDX
{
    /// <summary>
    /// 
    /// </summary>
    public struct VertexTraits
    {
        #region Variables and Properties
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Position;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Normal;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Tangent;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 BiTangent;
        /// <summary>
        /// 
        /// </summary>
        public Vector2 TextureCoordinate;
        #endregion Variables and Properties


        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public VertexTraits(float x, float y, float z)
            :this(new Vector3(x, y, z))
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public VertexTraits(Vector3 position)
        {
            this.Position = position;
            this.Normal = default(Vector3);
            this.Tangent = default(Vector3);
            this.BiTangent = default(Vector3);
            this.TextureCoordinate = default(Vector2);
        }
        #endregion Constructors
    }
    /// <summary>
    /// 
    /// </summary>
    public struct FaceTraits
    {
        #region Variables and Properties
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Normal;
        /// <summary>
        /// 
        /// </summary>
        public float Area;
        #endregion Variables and Properties
    }
    /// <summary>
    /// 
    /// </summary>
    public struct MeshTraits
    {
        #region Variables and Properties
        /// <summary>
        /// 
        /// </summary>
        public BoundingBox BoundingBox;
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
        #endregion Variables and Properties
    }
}
