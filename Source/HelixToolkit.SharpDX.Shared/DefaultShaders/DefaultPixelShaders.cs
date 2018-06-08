﻿/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/

#if !NETFX_CORE
namespace HelixToolkit.Wpf.SharpDX.Shaders
#else
namespace HelixToolkit.UWP.Shaders
#endif
{
    using Helper;
    /// <summary>
    /// 
    /// </summary>
    public static class DefaultPSShaderByteCodes
    {
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSMeshBinnPhong
        {
            get
            {
                return UWPShaderBytePool.Read("psMeshBlinnPhong");

            }
        }
        /// <summary>
        /// Gets the ps mesh binn phong order independent transparent shader.
        /// </summary>
        /// <value>
        /// The ps mesh binn phong order independent transparent shader.
        /// </value>
        public static byte[] PSMeshBinnPhongOIT
        {
            get
            {
                return UWPShaderBytePool.Read("psMeshBlinnPhongOIT");

            }
        }
        /// <summary>
        /// Gets the ps mesh binn phong oit quad.
        /// </summary>
        /// <value>
        /// The ps mesh binn phong oit quad.
        /// </value>
        public static byte[] PSMeshBinnPhongOITQuad
        {
            get
            {
                return UWPShaderBytePool.Read("psMeshBlinnPhongOITQuad");

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSMeshVertColor
        {
            get
            {
                return UWPShaderBytePool.Read("psColor");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSMeshVertPosition
        {
            get
            {
                return UWPShaderBytePool.Read("psPositions");

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSMeshNormal
        {
            get
            {
                return UWPShaderBytePool.Read("psNormals");

            }
        }

        public static byte[] PSMeshDiffuseMap
        {
            get
            {
                return UWPShaderBytePool.Read("psDiffuseMap");

            }
        }

        public static byte[] PSMeshViewCube
        {
            get
            {
                return UWPShaderBytePool.Read("psViewCube");

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSShadow
        {
            get
            {
                return UWPShaderBytePool.Read("psShadow");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSPoint
        {
            get
            {
                return UWPShaderBytePool.Read("psPoint");

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSLine
        {
            get
            {
                return UWPShaderBytePool.Read("psLine");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSLineColor
        {
            get
            {
                return UWPShaderBytePool.Read("psLineColor");

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSBillboardText
        {
            get
            {
                return UWPShaderBytePool.Read("psBillboardText");
            }
        }
        /// <summary>
        /// Gets the ps billboard text order independent transparent shader.
        /// </summary>
        /// <value>
        /// The ps billboard text order independent transparent shader.
        /// </value>
        public static byte[] PSBillboardTextOIT
        {
            get
            {
                return UWPShaderBytePool.Read("psBillboardTextOIT");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSMeshXRay
        {
            get
            {
                return UWPShaderBytePool.Read("psMeshXRay");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSMeshClipPlaneBackface
        {
            get
            {
                return UWPShaderBytePool.Read("psMeshClipPlaneBackface");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSMeshClipPlaneQuad
        {
            get
            {
                return UWPShaderBytePool.Read("psMeshClipPlaneQuad");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSParticle
        {
            get
            {
                return UWPShaderBytePool.Read("psParticle");
            }
        }
        /// <summary>
        /// Gets the ps particle order independent transparent shader.
        /// </summary>
        public static byte[] PSParticleOIT
        {
            get
            {
                return UWPShaderBytePool.Read("psParticleOIT");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSSkybox
        {
            get
            {
                return UWPShaderBytePool.Read("psSkybox");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSMeshWireframe
        {
            get
            {
                return UWPShaderBytePool.Read("psWireframe");
            }
        }
        /// <summary>
        /// Gets the ps mesh wireframe oit.
        /// </summary>
        /// <value>
        /// The ps mesh wireframe oit.
        /// </value>
        public static byte[] PSMeshWireframeOIT
        {
            get
            {
                return UWPShaderBytePool.Read("psWireframeOIT");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSDepthStencilTestOnly
        {
            get
            {
                return UWPShaderBytePool.Read("psDepthStencilOnly");
            }
        }
        /// <summary>
        /// Gets the ps mesh outline screen quad.
        /// </summary>
        /// <value>
        /// The ps mesh outline screen quad.
        /// </value>
        public static byte[] PSEffectOutlineScreenQuad
        {
            get
            {
                return UWPShaderBytePool.Read("psEffectOutlineQuad");
            }
        }
        /// <summary>
        /// Gets the ps effect full screen blur vertical.
        /// </summary>
        /// <value>
        /// The ps effect full screen blur vertical.
        /// </value>
        public static byte[] PSEffectFullScreenBlurVertical
        {
            get
            {
                return UWPShaderBytePool.Read("psEffectGaussianBlurVertical");
            }
        }

        /// <summary>
        /// Gets the ps effect full screen blur horizontal.
        /// </summary>
        /// <value>
        /// The ps effect full screen blur horizontal.
        /// </value>
        public static byte[] PSEffectFullScreenBlurHorizontal
        {
            get
            {
                return UWPShaderBytePool.Read("psEffectGaussianBlurHorizontal");
            }
        }

        /// <summary>
        /// Gets the ps mesh border highlight
        /// </summary>
        /// <value>
        /// The ps mesh mesh border highlight
        /// </value>
        public static byte[] PSEffectMeshBorderHighlight
        {
            get
            {
                return UWPShaderBytePool.Read("psEffectMeshBorderHighlight");
            }
        }
        /// <summary>
        /// Gets the ps mesh outline screen quad stencil.
        /// </summary>
        /// <value>
        /// The ps mesh outline screen quad stencil.
        /// </value>
        public static byte[] PSEffectOutlineScreenQuadStencil
        {
            get
            {
                return UWPShaderBytePool.Read("psEffectOutlineQuadStencil");
            }
        }
        /// <summary>
        /// Gets the ps mesh outline quad final.
        /// </summary>
        /// <value>
        /// The ps mesh outline quad final.
        /// </value>
        public static byte[] PSEffectOutlineQuadFinal
        {
            get
            {
                return UWPShaderBytePool.Read("psEffectOutlineQualFinal");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        public static byte[] PSEffectMeshXRay
        {
            get
            {
                return UWPShaderBytePool.Read("psEffectMeshXRay");
            }
        }
        /// <summary>
        /// Gets the ps effect bloom extract.
        /// </summary>
        /// <value>
        /// The ps effect bloom extract.
        /// </value>
        public static byte[] PSEffectBloomExtract
        {
            get
            {
                return UWPShaderBytePool.Read("psEffectBloomExtract");
            }
        }
        /// <summary>
        /// Gets the ps effect bloom vertical blur.
        /// </summary>
        /// <value>
        /// The ps effect bloom vertical blur.
        /// </value>
        public static byte[] PSEffectBloomVerticalBlur
        {
            get
            {
                return UWPShaderBytePool.Read("psEffectBloomBlurVertical");
            }
        }
        /// <summary>
        /// Gets the ps effect bloom horizontal blur.
        /// </summary>
        /// <value>
        /// The ps effect bloom horizontal blur.
        /// </value>
        public static byte[] PSEffectBloomHorizontalBlur
        {
            get
            {
                return UWPShaderBytePool.Read("psEffectBloomBlurHorizontal");
            }
        }
        /// <summary>
        /// Gets the ps effect bloom combine.
        /// </summary>
        /// <value>
        /// The ps effect bloom combine.
        /// </value>
        public static byte[] PSEffectBloomCombine
        {
            get
            {
                return UWPShaderBytePool.Read("psEffectBloomCombine");
            }
        }
        /// <summary>
        /// Gets the ps effect fxaa.
        /// </summary>
        /// <value>
        /// The ps effect fxaa.
        /// </value>
        public static byte[] PSEffectFXAA
        {
            get
            {
                return UWPShaderBytePool.Read("psFXAA");
            }
        }
#if !NETFX_CORE
        /// <summary>
        /// 
        /// </summary>
        public static byte[] PSScreenDup
        {
            get
            {

                return Properties.Resources.psScreenDup;
            }
        }
#endif
    }


    /// <summary>
    /// Default Pixel Shaders
    /// </summary>
    public static class DefaultPSShaderDescriptions
    {
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshBlinnPhong = new ShaderDescription(nameof(PSMeshBlinnPhong), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshBinnPhong);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshBlinnPhongOIT = new ShaderDescription(nameof(PSMeshBlinnPhongOIT), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshBinnPhongOIT);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshBlinnPhongOITQuad = new ShaderDescription(nameof(PSMeshBlinnPhongOITQuad), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshBinnPhongOITQuad);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshVertColor = new ShaderDescription(nameof(PSMeshVertColor), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshVertColor);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshVertNormal = new ShaderDescription(nameof(PSMeshVertNormal), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshNormal);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshVertPosition = new ShaderDescription(nameof(PSMeshVertPosition), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshVertPosition);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshDiffuseMap = new ShaderDescription(nameof(PSMeshDiffuseMap), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshDiffuseMap);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshViewCube = new ShaderDescription(nameof(PSMeshViewCube), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshViewCube);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSPoint = new ShaderDescription(nameof(PSPoint), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSPoint);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSLine = new ShaderDescription(nameof(PSLine), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSLine);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSLineColor = new ShaderDescription(nameof(PSLineColor), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSLineColor);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSBillboardText = new ShaderDescription(nameof(PSBillboardText), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSBillboardText);
        /// <summary>
        /// The ps billboard text oit
        /// </summary>
        public static ShaderDescription PSBillboardTextOIT = new ShaderDescription(nameof(PSBillboardTextOIT), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSBillboardTextOIT);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshXRay = new ShaderDescription(nameof(PSMeshXRay), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshXRay);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSShadow = new ShaderDescription(nameof(PSShadow), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSShadow);
        #region Mesh Clipping
        /// <summary>
        /// /
        /// </summary>
        public static ShaderDescription PSMeshClipBackface = new ShaderDescription(nameof(PSMeshClipBackface), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshClipPlaneBackface);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshClipScreenQuad = new ShaderDescription(nameof(PSMeshClipScreenQuad), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshClipPlaneQuad);
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSParticle = new ShaderDescription(nameof(PSParticle), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSParticle);

        /// <summary>
        /// The ps particle oit
        /// </summary>
        public static ShaderDescription PSParticleOIT = new ShaderDescription(nameof(PSParticleOIT), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSParticleOIT);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSSkybox = new ShaderDescription(nameof(PSSkybox), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSSkybox);

        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshWireframe = new ShaderDescription(nameof(PSMeshWireframe), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshWireframe);
        /// <summary>
        /// 
        /// </summary>
        public static ShaderDescription PSMeshWireframeOIT = new ShaderDescription(nameof(PSMeshWireframeOIT), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSMeshWireframeOIT);
        /// <summary>
        /// The ps depth stencil only
        /// </summary>
        public static ShaderDescription PSDepthStencilOnly = new ShaderDescription(nameof(PSDepthStencilOnly), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSDepthStencilTestOnly);

        /// <summary>
        ///
        /// </summary>
        public static ShaderDescription PSMeshOutlineScreenQuad = new ShaderDescription(nameof(PSMeshOutlineScreenQuad), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectOutlineScreenQuad);

        /// <summary>
        ///
        /// </summary>
        public static ShaderDescription PSEffectFullScreenBlurVertical = new ShaderDescription(nameof(PSEffectFullScreenBlurVertical), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectFullScreenBlurVertical);
        /// <summary>
        ///
        /// </summary>
        public static ShaderDescription PSEffectFullScreenBlurHorizontal = new ShaderDescription(nameof(PSEffectFullScreenBlurHorizontal), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectFullScreenBlurHorizontal);
        /// <summary>
        ///
        /// </summary>
        public static ShaderDescription PSEffectMeshBorderHighlight = new ShaderDescription(nameof(PSEffectMeshBorderHighlight), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectMeshBorderHighlight);
        /// <summary>
        ///
        /// </summary>
        public static ShaderDescription PSMeshOutlineQuadStencil = new ShaderDescription(nameof(PSMeshOutlineQuadStencil), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectOutlineScreenQuadStencil);

        /// <summary>
        ///
        /// </summary>
        public static ShaderDescription PSMeshOutlineQuadFinal = new ShaderDescription(nameof(PSMeshOutlineQuadFinal), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectOutlineQuadFinal);

        /// <summary>
        ///
        /// </summary>
        public static ShaderDescription PSEffectMeshXRay = new ShaderDescription(nameof(PSEffectMeshXRay), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectMeshXRay);

        /// <summary>
        ///
        /// </summary>
        public static ShaderDescription PSEffectBloomExtract = new ShaderDescription(nameof(PSEffectBloomExtract), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectBloomExtract);
        /// <summary>
        /// The ps effect bloom vertical blur
        /// </summary>
        public static ShaderDescription PSEffectBloomVerticalBlur = new ShaderDescription(nameof(PSEffectBloomVerticalBlur), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectBloomVerticalBlur);
        /// <summary>
        /// The ps effect bloom horizontal blur
        /// </summary>
        public static ShaderDescription PSEffectBloomHorizontalBlur = new ShaderDescription(nameof(PSEffectBloomHorizontalBlur), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectBloomHorizontalBlur);

        /// <summary>
        /// The ps effect bloom combine
        /// </summary>
        public static ShaderDescription PSEffectBloomCombine = new ShaderDescription(nameof(PSEffectBloomCombine), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectBloomCombine);

        /// <summary>
        /// The ps effect FXAA
        /// </summary>
        public static ShaderDescription PSEffectFXAA = new ShaderDescription(nameof(PSEffectFXAA), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSEffectFXAA);
#if !NETFX_CORE
        /// <summary>
        /// The ps screen dup
        /// </summary>
        public static ShaderDescription PSScreenDup = new ShaderDescription(nameof(PSScreenDup), ShaderStage.Pixel, new ShaderReflector(),
            DefaultPSShaderByteCodes.PSScreenDup);
#endif
    }
}
