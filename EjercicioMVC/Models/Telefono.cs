//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EjercicioMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Telefono
    {
        public int idTelefono { get; set; }
        public string cliente { get; set; }
        public string tipoTelefono { get; set; }
    
        public virtual Cliente Cliente1 { get; set; }
    }
}