using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    [ExcludeFromCodeCoverage]
    public  class AutenticaDto
    {
        public string user { get; set; }
        public string password { get; set; }

    }
}
