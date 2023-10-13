namespace Act2Unidad2.Models.ViewModels
{
	public class RazaViewModel
	{
        public int IdRaza { get; set; }
        public string NombreRaza { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string OtrosNombres { get; set; } = null!;
        public string PaisDeOrigen { get; set; } = null!;
        public float PesoMin { get; set; }
        public float PesoMax { get; set; }
        public float AlturaMin { get; set; }
        public float AlturaMax { get; set; }
        public int EsperanzaDeVida { get; set; }
        public int NivelEnergia { get; set; }
        public int Entrenamiento { get; set; }
        public int EjercicioObligatorio { get; set; }
        public int AmistadDesconocidos { get; set; }
        public int AmistadPerros { get; set; }
        public int Cepillado { get; set; }
        public string Patas { get; set; } = null!;
        public string Cola { get; set; } = null!;
        public string Hocico { get; set; } = null!;
        public string Pelo { get; set; } = null!;
        public string Color { get; set; } = null!;
        public IEnumerable<AzarModel> ListaAzar = null!;

    }

    public class AzarModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

    }

}
