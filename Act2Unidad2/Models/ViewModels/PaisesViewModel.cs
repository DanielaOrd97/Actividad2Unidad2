namespace Act2Unidad2.Models.ViewModels
{
    public class PaisesViewModel
    {
        public string NombrePais { get; set; } = null!;
        //public int IdRaza { get; set; }
        //public string NombreRaza { get; set; } = null!;
        public IEnumerable<RazasModel1> ListaRazasP { get; set; } = null!;
    }
    public class RazasModel1
    {
        public int IdRaza { get; set; }
        public string NombreRaza { get; set; } = null!;
    }
}
