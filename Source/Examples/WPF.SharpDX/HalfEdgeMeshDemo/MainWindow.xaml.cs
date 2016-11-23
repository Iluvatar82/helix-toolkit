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

            createObject();
        }

        private void createObject()
        {
            var mb = new MeshBuilder();
            mb.AddCube();
            baseMesh.Geometry = mb.ToMesh();
            baseMesh.Material = mViewModel.Material;
            baseMesh.Transform = new TranslateTransform3D(0, 0, 5);

            var heBaseMesh = new Mesh((HelixToolkit.Wpf.SharpDX.MeshGeometry3D)baseMesh.Geometry);

        }
    }
}
