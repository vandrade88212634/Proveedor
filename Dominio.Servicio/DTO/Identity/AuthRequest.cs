﻿namespace Dominio.Servicio.DTO.Identity
{
    public class AuthRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}