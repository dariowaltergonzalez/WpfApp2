using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.Entities;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Usuarios> myLista = new List<Usuarios>();


        public MainWindow()
        {
            InitializeComponent();

            Refresh();

        }

        private void Refresh() 
        {
            using (PruebasContext _context = new PruebasContext())
            {
                myLista = [.. _context.Usuarios];
            }

            listaUsuarios.ItemsSource = myLista;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            PruebasContext db = new PruebasContext();

            Usuarios usu = new Usuarios();
            usu.Usuario = txtUsuario.Text;
            usu.Pass = txtPass.Text;
            usu.Sucursal = Convert.ToInt16(cboSucursal.Text);
            usu.Activo = chkActivo.IsChecked;
            usu.Usuariobloqueado = chkBloqueado.IsChecked;


            db.Usuarios.Add(usu);
            db.SaveChanges();

            Refresh();

        }
    }
}