using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Servicio.DTO
{
    public class AutenticationDto
    {
        public string Token { get; set; }
        public string Nombre { get; set; }

        public int cedula { get; set; }
        public string usuario { get; set; }
        public int bloqueado { get; set; }

        public int IdRol { get; set; }
        public string DescRol {get; set;}

        public int RegCodigo { get; set; }
        public string DescRegional;
        public string Messages { get; set; }

        public int idUser { get; set; }
        public bool IsSuccess { get ; set; }    

        public int Validado { get; set; } 
        public int Activo { get; set; }
        public string  DesActivo { get; set; }

        public string CorreoElectronico { get; set; }    

      
        
    }
}
