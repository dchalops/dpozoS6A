using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using dpozoS6A.Models;
using Newtonsoft.Json;

namespace dpozoS6A.Views;

public partial class vEstudiante : ContentPage
{
	private const string URL = "http://192.168.10.111/uisrael/post.php";
	private HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;

    public vEstudiante()
	{
		InitializeComponent();
		mostrar();
	}

	public async void mostrar()
	{
		var content = await cliente.GetStringAsync(URL);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(mostrarEst);
        listaEstudiantes.ItemsSource = estud;
	}
}