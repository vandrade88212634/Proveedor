using Moq;
using Proveedor.Controllers;
using Infraestructura.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace ProveedorTest.ControladoresTest
{
    public class ProveedorControllerTests
    {
        private readonly Mock<ProveedorRepository> _mockRepository;
        private readonly ProveedorController _controller;

        public ProveedorControllerTests()
        {
            _mockRepository = new Mock<ProveedorRepository>();
            _controller = new ProveedorController(_mockRepository.Object);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedAtAction_WhenProveedorIsCreated()
        {
            // Arrange
            var proveedor = new ProveedorEntity { Id = 1, Nit = "123", RazonSocial = "Proveedor Test", Direccion = "Test Address" };

            _mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<ProveedorEntity>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(proveedor);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetById", actionResult.ActionName);
            Assert.Equal(proveedor.Id.ToString(), actionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkResult_WhenProveedoresExist()
        {
            // Arrange
            var proveedores = new[]
            {
                new ProveedorEntity { Id = 1, Nit = "123", RazonSocial = "Proveedor Test", Direccion = "Test Address",Ciudad = "Floridablanca",Departamento = "Santander",Correo ="pruebade correo",Activo= 1, CorreoContacto="xxx",FechaCreacion= DateTime.Now , NombreContacto = "xxx" },
                new ProveedorEntity { Id = 2, Nit = "456", RazonSocial = "Proveedor 2", Direccion = "Test Address 2" ,Ciudad = "Floridablanca",Departamento = "Santander",Correo ="pruebade correo",Activo= 1, CorreoContacto="xxx",FechaCreacion= DateTime.Now , NombreContacto = "xxx"}
            };

            _mockRepository.Setup(repo => repo.GetAllAsync());

            // Act
            var result = await _controller.GetAll();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<ProveedorEntity[]>(actionResult.Value);
            Assert.Equal(2, returnValue.Length);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkResult_WhenProveedorExists()
        {
            // Arrange
            var proveedor = new ProveedorEntity { Id = 1, Nit = "123", RazonSocial = "Proveedor Test", Direccion = "Test Address",Ciudad = "Floridablanca",Departamento = "Santander",Correo ="pruebade correo",Activo= 1, CorreoContacto="xxx",FechaCreacion= DateTime.Now , NombreContacto = "xxx"};

            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(proveedor);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ProveedorEntity>(actionResult.Value);
            Assert.Equal(proveedor.Id, returnValue.Id);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenProveedorDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((ProveedorEntity)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Update_ShouldReturnNoContent_WhenProveedorIsUpdated()
        {
            // Arrange
            var proveedor = new ProveedorEntity { Id = 1, Nit = "123", RazonSocial = "Proveedor Test", Direccion = "Test Address" };
            var updatedProveedor = new ProveedorEntity { Id = 1, Nit = "123", RazonSocial = "Proveedor Updated", Direccion = "Updated Address" };

            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(proveedor);
            _mockRepository.Setup(repo => repo.UpdateAsync(1, updatedProveedor)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(1, updatedProveedor);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_ShouldReturnNotFound_WhenProveedorDoesNotExist()
        {
            // Arrange
            var updatedProveedor = new ProveedorEntity { Id = 1, Nit = "123", RazonSocial = "Proveedor Updated", Direccion = "Updated Address" };

            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((ProveedorEntity)null);

            // Act
            var result = await _controller.Update(1, updatedProveedor);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenProveedorIsDeleted()
        {
            // Arrange
            var proveedor = new ProveedorEntity { Id = 1, Nit = "123", RazonSocial = "Proveedor Test", Direccion = "Test Address" };

            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(proveedor);
            _mockRepository.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnNotFound_WhenProveedorDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((ProveedorEntity)null);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}

