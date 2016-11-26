using HelixToolkit.Wpf.SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HalfEdgeMeshDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// The ViewModel
        /// </summary>
        MainViewModel mViewModel;

        public MainWindow()
        {
            InitializeComponent();

            // Setup the ViewModel
            mViewModel = new MainViewModel();
            this.DataContext = mViewModel;

            mViewModel.ModelTransform = new TranslateTransform3D(0, 0, 5);
            createObject();
        }
        /// <summary>
        /// Create the HalfEdge Object and display it including all Boundary Edges.
        /// </summary>
        private void createObject()
        {
            // Create the Objects
            var mb = new MeshBuilder();
            mb.AddClosedCube();
            mb.AddClosedCube(new SharpDX.Vector3(2, 0, 0), SharpDX.Vector3.UnitZ, SharpDX.Vector3.UnitY,
                1.75f, BoxFaces.All & ~BoxFaces.Front & ~BoxFaces.Back);
            mb.AddClosedCube(new SharpDX.Vector3(-2, 0, 0), SharpDX.Vector3.UnitZ, SharpDX.Vector3.UnitY,
                1.75f, BoxFaces.All & ~BoxFaces.Front & ~BoxFaces.Bottom & ~BoxFaces.Right);
            mb.AddTorus(2, .5, 64, 64);
            mb.AddPyramid(new SharpDX.Vector3(0, 0, -2), new SharpDX.Vector3(0, 0, -1),
                new SharpDX.Vector3(0, 1, 0), 1, 2);

            baseMesh.Geometry = mb.ToMesh();
            baseMesh.Material = mViewModel.Material;

            // Use the Object to create the HalfEdge Mesh
            var heBaseMesh = new Mesh((HelixToolkit.Wpf.SharpDX.MeshGeometry3D)baseMesh.Geometry);
            // Set the Geometry of the BoundaryLines
            baseMeshBoundaries.Geometry = heBaseMesh.GetBoundaryGeometry();
        }
    }
}