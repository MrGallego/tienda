using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            IEnumerable<Producto> productos = await _unitOfWork.Productos.GetAllAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Producto>>> Get(int id)
        {
            Producto producto = await _unitOfWork.Productos.GetByIdAsync(id);
            return Ok(producto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Create(Producto producto)
        {
            _unitOfWork.Productos.Add(producto);
            _unitOfWork.Save();
            if (producto == null) {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Create), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Put(int id, [FromBody] Producto producto)
        {
            if (producto == null)
            {
                return NotFound();
            }
            _unitOfWork.Productos.Update(producto);
            _unitOfWork.Save();

            return producto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            _unitOfWork.Productos.Remove(producto);
            _unitOfWork.Save();

            return NoContent();
        }

    }
}
