﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelixToolkit.Wpf
{
    using System;
    using System.Collections.Generic;

#if SHARPDX
    using global::SharpDX;
    using Vector3D = global::SharpDX.Vector3;
    using Point3D = global::SharpDX.Vector3;
    using DoubleOrSingle = System.Single;
    using System.Linq;
#else
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;
    using DoubleOrSingle = System.Double;
#endif
    /// <summary>
    /// Functions for the Shared Projects to simplify the Code
    /// </summary>
    internal static class SharedFunctions
    {
        /// <summary>
        /// Cross Product of two Vectors
        /// </summary>
        /// <param name="first">First Vector</param>
        /// <param name="second">Second Vector</param>
        /// <returns>Cross Product of the two Vectors</returns>
        public static Vector3D CrossProduct(Vector3D first, Vector3D second)
        {
#if SHARPDX
            return Vector3.Cross(first, second);
#else
            return Vector3D.CrossProduct(first, second);
#endif
        }
        /// <summary>
        /// Dot Product of two Vectors
        /// </summary>
        /// <param name="first">First Vector</param>
        /// <param name="second">Second Vector</param>
        /// <returns>Dot Product of the two Vectors</returns>
        public static DoubleOrSingle DotProduct(Vector3D first, Vector3D second)
        {
            return first.X * second.X + first.Y * second.Y + first.Z * second.Z;
        }
        /// <summary>
        /// Get the squared Length of the Vector.
        /// </summary>
        /// <param name="vector">The Vector</param>
        /// <returns>Squared Length of the Vector.</returns>
        public static DoubleOrSingle LengthSquared(Vector3D vector)
        {
            return vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z;
        }
        /// <summary>
        /// Get the Length of the Vector.
        /// </summary>
        /// <param name="vector">The Vector</param>
        /// <returns>Length of the Vector.</returns>
        public static DoubleOrSingle Length(Vector3D vector)
        {
            return (DoubleOrSingle)Math.Sqrt(LengthSquared(vector));
        }
        /// <summary>
        /// Convert a Vector to a System.Windows.Media.Media3D.Point3D.
        /// </summary>
        /// <param name="vector">The Vector.</param>
        /// <returns>The System.Windows.Media.Media3D.Point3D</returns>
        public static System.Windows.Media.Media3D.Point3D ToPoint3D(Vector3D vector)
        {
            return new System.Windows.Media.Media3D.Point3D(vector.X, vector.Y, vector.Z);
        }
        /// <summary>
        /// Convert a Vector to a System.Windows.Media.Media3D.Vector3D.
        /// </summary>
        /// <param name="vector">The Vector.</param>
        /// <returns>The System.Windows.Media.Media3D.Vector3D</returns>
        public static System.Windows.Media.Media3D.Vector3D ToVector3D(Vector3D vector)
        {
            return new System.Windows.Media.Media3D.Vector3D(vector.X, vector.Y, vector.Z);
        }
#if SHARPDX
        /// <summary>
        /// Convert a System.Windows.Media.Media3D.Vector3D to a Point3D.
        /// </summary>
        /// <param name="vector">The System.Windows.Media.Media3D.Vector3D.</param>
        /// <returns>The Point3D.</returns>
        public static Point3D ToPoint3D(System.Windows.Media.Media3D.Vector3D vector)
        {
            return new Point3D((DoubleOrSingle)vector.X, (DoubleOrSingle)vector.Y, (DoubleOrSingle)vector.Z);
        }
        /// <summary>
        /// Convert a System.Windows.Media.Media3D.Vector3D to a Vector3D.
        /// </summary>
        /// <param name="vector">The System.Windows.Media.Media3D.Vector3D.</param>
        /// <returns>The Vector3D.</returns>
        public static Vector3D ToVector3D(System.Windows.Media.Media3D.Vector3D vector)
        {
            return new Vector3D((DoubleOrSingle)vector.X, (DoubleOrSingle)vector.Y, (DoubleOrSingle)vector.Z);
        }
        /// <summary>
        /// Convert a Vector3Collection to a System.Windows.Media.Media3D.Vector3DCollection.
        /// </summary>
        /// <param name="collection">The Vector3Collection.</param>
        /// <returns>The System.Windows.Media.Media3D.Vector3DCollection</returns>
        public static System.Windows.Media.Media3D.Vector3DCollection ToVector3DCollection(SharpDX.Core.Vector3Collection collection)
        {
            return new System.Windows.Media.Media3D.Vector3DCollection(collection.Select(v => ToVector3D(v)));
        }
        /// <summary>
        /// Convert a Vector3Collection to a System.Windows.Media.Media3D.Point3DCollection.
        /// </summary>
        /// <param name="collection">The Vector3Collection.</param>
        /// <returns>The System.Windows.Media.Media3D.Point3DCollection</returns>
        public static System.Windows.Media.Media3D.Point3DCollection ToPoint3DCollection(SharpDX.Core.Vector3Collection collection)
        {
            return new System.Windows.Media.Media3D.Point3DCollection(collection.Select(v => ToPoint3D(v)));
        }
        /// <summary>
        /// Convert a Vector2Collection to a System.Windows.Media.Media3D.PointCollection.
        /// </summary>
        /// <param name="collection">The Vector2Collection.</param>
        /// <returns>The System.Windows.Media.Media3D.PointCollection</returns>
        public static System.Windows.Media.PointCollection ToPointCollection(SharpDX.Core.Vector2Collection collection)
        {
            return new System.Windows.Media.PointCollection(collection.Select(v => new System.Windows.Point(v.X, v.Y)));
        }
        /// <summary>
        /// Convert an IntCollection to a System.Windows.Media.Int32Collection.
        /// </summary>
        /// <param name="collection">The IntCollection.</param>
        /// <returns>The System.Windows.Media.Int32Collection.</returns>
        public static System.Windows.Media.Int32Collection ToInt32Collection(SharpDX.Core.IntCollection collection)
        {
            return new System.Windows.Media.Int32Collection(collection);
        }
        /// <summary>
        /// Create a System.Windows.Media.Media3D.MeshGeometry3D from a MeshGeometry.
        /// </summary>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static System.Windows.Media.Media3D.MeshGeometry3D ToMeshGeometry3D(SharpDX.MeshGeometry3D mesh)
        {
            return new System.Windows.Media.Media3D.MeshGeometry3D()
            {
                Normals = ToVector3DCollection(mesh.Normals),
                Positions = ToPoint3DCollection(mesh.Positions),
                TextureCoordinates = ToPointCollection(mesh.TextureCoordinates),
                TriangleIndices = ToInt32Collection(mesh.TriangleIndices)
            };
        }
        /// <summary>
        /// Finds the intersection between the plane and a line.
        /// </summary>
        /// <param name="la">
        /// The first point defining the line.
        /// </param>
        /// <param name="lb">
        /// The second point defining the line.
        /// </param>
        /// <returns>
        /// The intersection point.
        /// </returns>
        public static Point3D? LineIntersection(this Plane plane, Point3D la, Point3D lb)
        {
            // http://en.wikipedia.org/wiki/Line-plane_intersection
            var l = lb - la;
            var pos = plane.Normal * plane.D;
            var a = DotProduct(pos - la, plane.Normal);
            var b = DotProduct(l, plane.Normal);
            if (a.Equals(0) && b.Equals(0))
            {
                return null;
            }

            if (b.Equals(0))
            {
                return null;
            }

            return la + ((a / b) * l);
        }
#endif
    }
}