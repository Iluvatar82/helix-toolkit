﻿/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/
using System;
using System.Runtime.CompilerServices;
#if NETFX_CORE
namespace HelixToolkit.UWP
#else
namespace HelixToolkit.Wpf.SharpDX
#endif
{
    /// <summary>
    /// Used for render ordering. Order is the same as render type defined.
    /// </summary>
    public enum RenderType
    {
        None, Light, PreProc, Opaque, Particle, Transparent, PostProc, ScreenSpaced
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MSAALevel
    {
        Disable = 0, Maximum = 1, Two = 2, Four = 4, Eight = 8
    }
    /// <summary>
    /// 
    /// </summary>
    public enum FXAALevel
    {
        None = 0, Low = 1, Medium = 2, High = 3, Ultra = 4
    }
    /// <summary>
    /// 
    /// </summary>
    public enum LightType
    {
        Ambient = 0, Directional = 1, Point = 2, Spot = 3, ThreePoint = 4, None = 5
    }

    /// <summary>
    /// 
    /// </summary>
    public enum PointFigure
    {
        Rect,
        Ellipse,
        Cross,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum MeshTopologyEnum
    {
        PNTriangles,
        PNQuads
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum ShaderStage
    {
        None = 0,
        Vertex = 1,
        Hull = 1 << 2,
        Domain = 1 << 3,
        Geometry = 1 << 4,
        Pixel = 1 << 5,
        Compute = 1 << 6
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum StateType
    {
        None = 0,
        RasterState = 1,
        DepthStencilState = 1 << 2,
        BlendState = 1 << 3
    }

    [Flags]
    public enum RenderDetail
    {
        None = 0,
        FPS = 1,
        Statistics = 2,
        TriangleInfo = 4,
        Camera = 8,
    }

    /// <summary>
    /// OIT weight mode.
    /// <para>Please refer to http://jcgt.org/published/0002/02/09/ </para>
    /// <para>Linear0: eq7; Linear1: eq8; Linear2: eq9; NonLinear: eq10</para>
    /// </summary>
    /// <value>
    /// The oit weight mode.
    /// </value>
    public enum OITWeightMode
    {
        Linear0 = 0,
        Linear1 = 1,
        Linear2 = 2,
        NonLinear = 3
    }
    /// <summary>
    /// 
    /// </summary>
    public struct EnumHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFlag(ShaderStage option, ShaderStage flag)
        {
            return (option & flag) != 0;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFlag(StateType option, StateType flag)
        {
            return (option & flag) != 0;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFlag(RenderDetail option, RenderDetail flag)
        {
            return (option & flag) != 0;
        }
    }
}