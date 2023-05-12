using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TiendasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Consultar todas la tiendas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TiendaListDto>>> Get()
        {
            IEnumerable<Tienda> tiendas = await _unitOfWork.Tiendas.GetAllAsync();
            return _mapper.Map<List<TiendaListDto>>(tiendas);
        }

        /// <summary>
        /// Consultar tienda por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TiendaDto>> Get(int id)
        {
            Tienda tienda = await _unitOfWork.Tiendas.GetByIdAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }
            return _mapper.Map<TiendaDto>(tienda);
        }
        /// <summary>
        /// Crear tienda
        /// </summary>
        /// <param name="tiendaAddUpdateDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tienda>> Create(TiendaAddUpdateDto tiendaAddUpdateDto)
        {
            var tienda = _mapper.Map<Tienda>(tiendaAddUpdateDto);
            _unitOfWork.Tiendas.Add(tienda);
            await _unitOfWork.SaveAsync();
            if (tienda == null)
            {
                return BadRequest();
            }
            tiendaAddUpdateDto.Id = tienda.Id;
            return CreatedAtAction(nameof(Create), new { id = tiendaAddUpdateDto.Id }, tiendaAddUpdateDto);
        }

        /// <summary>
        /// Modificar tienda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tiendaAddUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TiendaAddUpdateDto>> Put(int id, [FromBody] TiendaAddUpdateDto tiendaAddUpdateDto)
        {
            if (tiendaAddUpdateDto == null)
            {
                return NotFound();
            }
            var tienda = _mapper.Map<Tienda>(tiendaAddUpdateDto);
            _unitOfWork.Tiendas.Update(tienda);
            await _unitOfWork.SaveAsync();

            return tiendaAddUpdateDto;
        }

        /// <summary>
        /// Eliminar tienda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var tienda = await _unitOfWork.Tiendas.GetByIdAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }
            _unitOfWork.Tiendas.Remove(tienda);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
