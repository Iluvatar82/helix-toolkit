
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Helix Toolkit">
//   Copyright (c) 2014 Helix Toolkit contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HalfEdgeMeshDemo
{
    using DemoCore;
    using HelixToolkit.Wpf.SharpDX;
    using SharpDX;
    using System;
    using Point3D = System.Windows.Media.Media3D.Point3D;
    using Transform3D = System.Windows.Media.Media3D.Transform3D;
    using TranslateTransform3D = System.Windows.Media.Media3D.TranslateTransform3D;
    using Vector3D = System.Windows.Media.Media3D.Vector3D;

    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Thickness of the Lines of the Grid
        /// </summary>
        public double LineThickness { get; set; }
        /// <summary>
        /// Thickness of the Lines of the Triangulated Polygon
        /// </summary>
        public double BoundaryThickness { get; set; }
        /// <summary>
        /// The Grid
        /// </summary>
        public LineGeometry3D Grid { get; private set; }
        /// <summary>
        /// Color of the Gridlines
        /// </summary>
        public SharpDX.Color GridColor { get; private set; }
        /// <summary>
        /// Color of the Triangle Lines
        /// </summary>
        public SharpDX.Color BoundaryColor { get; private set; }
        /// <summary>
        /// Transform of the Grid
        /// </summary>
        public Transform3D GridTransform { get; private set; }
        /// <summary>
        /// Direction of the directional Light
        /// </summary>
        public Vector3 DirectionalLightDirection { get; private set; }
        /// <summary>
        /// Direction of the directional Light2
        /// </summary>
        public Vector3 DirectionalLight2Direction { get; private set; }
        /// <summary>
        /// Direction of the directional Light3
        /// </summary>
        public Vector3 DirectionalLight3Direction { get; private set; }
        /// <summary>
        /// Color of the directional Light
        /// </summary>
        public Color4 DirectionalLightColor { get; private set; }
        /// <summary>
        /// Color of the ambient Light
        /// </summary>
        public Color4 AmbientLightColor { get; private set; }
        /// <summary>
        /// The Polygon-Material
        /// </summary>
        private PhongMaterial mMaterial;
        /// <summary>
        /// Accessor to the Polygon-Material
        /// </summary>
        public PhongMaterial Material
        {
            get
            {
                return mMaterial;
            }
            set
            {
                mMaterial = value;
                OnPropertyChanged("Material");
            }
        }
        /// <summary>
        /// Transform of the Polygon
        /// </summary>
        public Transform3D ModelTransform { get; set; }
        /// <summary>
        /// Draw the Triangles or not
        /// </summary>
        private Boolean mShowBoundaries;
        /// <summary>
        /// Accessor to the Boolean
        /// </summary>
        public Boolean ShowBoundaries {
            get
            {
                return mShowBoundaries;
            }
            set
            {
                mShowBoundaries = value;
                OnPropertyChanged("ShowTriangleLines");
            }
        }
        /// <summary>
        /// The Geometry for the Triangle Lines
        /// </summary>
        public HelixToolkit.Wpf.SharpDX.LineGeometry3D LineGeometry;

        /// <summary>
        /// Constructor of the MainViewModel
        /// Sets up allProperties
        /// </summary>
        public MainViewModel()
        {
            // Render Setup
            RenderTechniquesManager = new DefaultRenderTechniquesManager();
            RenderTechnique = RenderTechniquesManager.RenderTechniques[DefaultRenderTechniqueNames.Blinn];
            EffectsManager = new DefaultEffectsManager(RenderTechniquesManager);
            // Window Setup
            this.Title = "Polygon Triangulation Demo";
            this.SubTitle = null;

            // Camera Setup
            this.Camera = new PerspectiveCamera { Position = new Point3D(0, 5, 9), LookDirection = new Vector3D(0, -5, -4), UpDirection = new Vector3D(0, 1, 0) };
            
            // Lines Setup
            this.LineThickness = 1;
            this.BoundaryThickness = 1;
            this.ShowBoundaries = true;

            // Lighting Setup
            this.AmbientLightColor = new Color4(.2f, .2f, .2f, 1.0f);
            this.DirectionalLightColor = new Color4(.6f, .6f, .6f, 1);
            this.DirectionalLightDirection = new Vector3(-1, -1, -1);
            this.DirectionalLight2Direction = new Vector3(-1, 1, 1);
            this.DirectionalLight3Direction = new Vector3(1, -1, 1);

            // Model Transformations
            this.ModelTransform = new TranslateTransform3D(0, 0, 0);
            
            // Model Materials and Colors
            this.Material = PhongMaterials.PolishedBronze;
            this.BoundaryColor = SharpDX.Color.Red;

            // Grid Setup
            this.Grid = LineBuilder.GenerateGrid(Vector3.UnitY, -5, 5, 0, 10);
            this.GridColor = SharpDX.Color.DarkGray;
            this.GridTransform = new TranslateTransform3D(0, -0.01, 0);
        }
    }
}