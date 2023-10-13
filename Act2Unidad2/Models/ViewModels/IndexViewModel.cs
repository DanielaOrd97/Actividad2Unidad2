﻿namespace Act2Unidad2.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<RazasModel> ListaRazas { get; set; } = null!;
        public IEnumerable<char> Abecedario { get; set; } = null!;
    }

    public class RazasModel
    {
        public int IdRaza { get; set; }
        public string NombreRaza { get; set; } = null!;
    }

}
