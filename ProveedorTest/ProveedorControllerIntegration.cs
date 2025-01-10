using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using MyProject;
using Microsoft.VisualStudio.TestPlatform.TestHost; // Asegúrate de importar tu proyecto principal

namespace MyProject.IntegrationTests
{
    public class ProveedorControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public ProveedorControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetProveedores_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/api/proveedores");

            // Assert
            response.EnsureSuccessStatusCode(); // Asegura que la respuesta sea 2xx
        }

        [Fact]
        public async Task GetProveedorById_ReturnsCorrectItem()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await _client.GetAsync($"/api/proveedores/{id}");

            // Assert
            response.EnsureSuccessStatusCode(); // Asegura que la respuesta sea 2xx
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Proveedor", content); // Verifica que el contenido contiene "Proveedor"
        }

        // Puedes agregar más pruebas aquí...
    }
}

