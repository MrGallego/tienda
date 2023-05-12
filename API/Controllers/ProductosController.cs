using API.Dtos;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Consultar todos los productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductoListDto>>> Get()
        {
            IEnumerable<Producto> productos = await _unitOfWork.Productos.GetAllAsync();
            return _mapper.Map<List<ProductoListDto>>(productos);
        }

        /// <summary>
        /// Consultar producto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProductoDto>> Get(int id)
        {
            Producto producto = await _unitOfWork.Productos.GetByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return _mapper.Map<ProductoDto>(producto);
        }

        /// <summary>
        /// Crear producto
        /// </summary>
        /// <param name="productoAddUpdateDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Create(ProductoAddUpdateDto productoAddUpdateDto)
        {
            var producto = _mapper.Map<Producto>(productoAddUpdateDto);

            if (!string.IsNullOrEmpty(productoAddUpdateDto.Imagen))
            {
                var base64 = await ConvertImageToBase64Async(productoAddUpdateDto.Imagen);
                producto.Imagen = base64;
            }

            _unitOfWork.Productos.Add(producto);
            await _unitOfWork.SaveAsync();
            if (producto == null) {
                return BadRequest();
            }
            productoAddUpdateDto.Id = producto.Id;
            return CreatedAtAction(nameof(Create), new { id = productoAddUpdateDto.Id }, productoAddUpdateDto);
        }
        private async Task<string> ConvertImageToBase64Async(string imagePath)
        {
            var bytes = await System.IO.File.ReadAllBytesAsync(imagePath);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Modificar producto por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productoAddUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoAddUpdateDto>> Put(int id, [FromBody] ProductoAddUpdateDto productoAddUpdateDto)
        {
            if (productoAddUpdateDto == null)
            {
                return NotFound();
            }
            var producto = _mapper.Map<Producto>(productoAddUpdateDto);
            _unitOfWork.Productos.Update(producto);
            await _unitOfWork.SaveAsync();

            return productoAddUpdateDto;
        }


        /// <summary>
        /// Eliminar producto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

    }
}
