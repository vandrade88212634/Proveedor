

using Infraestructura.Entity.Entities;

using Microsoft.AspNetCore.Authorization;




namespace Proveedor.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorRepository _proveedorRepository;

        public ProveedorController(ProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }


        /// <summary>
        /// Crear Proveedor
        /// </summary>
        /// <param name="proveedor">Objeto datos del proveedor</param>
        /// <returns>Proveedor creado</returns>

        [HttpPost]
        public async Task<IActionResult> Create(ProveedorEntity proveedor)
        {
            await _proveedorRepository.CreateAsync(proveedor);
            return CreatedAtAction(nameof(GetById), new { id = proveedor.Id.ToString() }, proveedor);
        }



        /// <summary>
        /// Lista los  Proveedores
        /// </summary>
        /// <returns>Lista de Proveedores</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _proveedorRepository.GetAllAsync();
            return Ok(proveedores);
        }

        /// <summary>
        ///Lista proveedor por id
        /// </summary>
        /// <param name="id">Id del proveedor</param>
        /// <returns>Proveedor consultado</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var proveedor = await _proveedorRepository.GetByIdAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }


        /// <summary>
        /// Editar Proveedor
        /// </summary>
        /// <param name="id">Id Del proveedor a Modificar</param>
        /// <returns>Proveedor Editado</returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProveedorEntity proveedor)
        {
            var existingProveedor = await _proveedorRepository.GetByIdAsync(id);
            if (existingProveedor == null)
            {
                return NotFound();
            }

            proveedor.Id = existingProveedor.Id; // Mantén el mismo ID
            await _proveedorRepository.UpdateAsync(id, proveedor);
            return NoContent();
        }


        /// <summary>
        /// Elimina  Proveedor
        /// </summary>
        /// <param name="proveedor">Objeto datos del proveedor</param>
        /// <returns>Proveedor Eliminado</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProveedor = await _proveedorRepository.GetByIdAsync(id);
            if (existingProveedor == null)
            {
                return NotFound();
            }

            await _proveedorRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

