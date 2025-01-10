using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    public class ProveedorDto
    {
      
            public ObjectId Id { get; set; } // Este es el identificador único de MongoDB

            public string Nit { get; set; }

           
            public string RazonSocial { get; set; }

            
            public string Direccion { get; set; }

            
            public string Ciudad { get; set; }

            
            public string Departamento { get; set; }

            
            public string Correo { get; set; }

            public int Activo { get; set; } = 1;

            public DateTime FechaCreacion { get; set; } = DateTime.Now;

            
            public string NombreContacto { get; set; }

            
            public string CorreoContacto { get; set; }
            public bool IsSucess { get; set; }
            public string Message { get; set; }
 
    }
}
