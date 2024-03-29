﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejercicio.Models.Entidades
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int idUsuario { get; set; }
       
        public string nomUsuario { get; set; } = null!;

        public string? URLFotoPerfil { get; set; }

        public string correo { get; set; }

        public string password { get; set; }
    }
}
