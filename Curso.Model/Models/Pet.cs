// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Curso.Model.Models
{
    public partial class Pet
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdRaca { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Sexo { get; set; }
    }
}