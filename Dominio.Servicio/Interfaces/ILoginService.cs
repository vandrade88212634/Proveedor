﻿using Dominio.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.Servicios.Interfaces
{
    public  interface ILoginService
    {

        Task<AutenticationDto> autentication(AutenticaDto autenticado);
      
    }
}
