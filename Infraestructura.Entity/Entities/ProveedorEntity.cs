using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Infraestructura.Entity.Entities
{
    public class ProveedorEntity
    {
        [BsonId]
        public int Id { get; set; } // Este es el identificador único de MongoDB

        [BsonElement("nit")]
        [BsonRequired]
       
        public string Nit { get; set; }

        [BsonElement("razon_social")]
        [BsonRequired]
       
        public string RazonSocial { get; set; }

        [BsonElement("direccion")]
        [BsonRequired]
       
        public string Direccion { get; set; }

        [BsonElement("ciudad")]
        [BsonRequired]
        
        public string Ciudad { get; set; }

        [BsonElement("departamento")]
        [BsonRequired]
       
        public string Departamento { get; set; }

        [BsonElement("correo")]
        [BsonRequired]
       
        public string Correo { get; set; }

        [BsonElement("activo")]
        public int Activo { get; set; } = 1;

        [BsonElement("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [BsonElement("nombre_contacto")]
        [BsonRequired]
        
        public string NombreContacto { get; set; }

        [BsonElement("correo_contacto")]
        [BsonRequired]
        
        public string CorreoContacto { get; set; }
    }
}
