using AutoMapper;
using ExamenYache.Models;
using ExamenYache.Models.Dto;
using ExamenYache.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ExamenYache.Controllers
{
    [Route("api/Frutas")]
    [ApiController]
    public class FrutasController : Controller
    {
        private readonly IFrutaRepository _frutasRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnviorenment;

        public FrutasController(IFrutaRepository ftRepo, IMapper mapper, IWebHostEnvironment env)
        {
            _frutasRepository = ftRepo; 
            _mapper = mapper;   
            _hostEnviorenment = env;
        }


        [HttpGet("GetFrutasPaginas")]
        public IActionResult GetFrutas(int Skip)
        {
            var listaFrutas = _frutasRepository.GetFrutas(Skip);
            var listaFruasDto = new List<FrutaDto>();
            foreach (var item in listaFrutas)
            {
                listaFruasDto.Add(_mapper.Map<FrutaDto>(item));
            }
            return Ok(listaFruasDto);
        }

        [HttpGet]
        public IActionResult GetFrutas()
        {
            var listaFrutas = _frutasRepository.GetFrutas();
            var listaFruasDto = new List<FrutaDto>();
            foreach (var item in listaFrutas)
            {
                listaFruasDto.Add(_mapper.Map<FrutaDto>(item));
            }
            return Ok(listaFruasDto);
        }

        [HttpGet("{FrutaClave}", Name = "GetFruta")]
        public IActionResult GetFruta(string FrutaClave)
        {
            if(String.IsNullOrEmpty(FrutaClave))
                return BadRequest();
            var itemFruta = _frutasRepository.GetFruta(FrutaClave);
            if(itemFruta == null)
                return NotFound();
            var itemFrutaDto = _mapper.Map<FrutaDto>(itemFruta);
            return Ok(itemFrutaDto);
        }
        
        [HttpPost]
        public IActionResult CrearFruta([FromForm] FrutaCrearDto FrutaDto)
        {
            if (FrutaDto == null)
                return BadRequest(ModelState);
            if (_frutasRepository.ExisteFruta(FrutaDto.Nombre))
            {
                ModelState.AddModelError("", "Fruta ya existe");
                return StatusCode(404, ModelState);
            }

            var Fruta = _mapper.Map<Fruta>(FrutaDto);
            Fruta.FechaRegistro = DateTime.Now;
            Fruta.FechaModificacion = DateTime.Now;
            Fruta.Estatus = true;

            if (!_frutasRepository.CrearFruta(Fruta))
            {
                ModelState.AddModelError("", $"Error al guardar la fruta {Fruta.Nombre}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetFruta", new { FrutaClave = Fruta.Clave}, Fruta);
        }

        [HttpPatch("{FrutaClave}", Name = "ActualizarFruta")]
        public IActionResult ActualizarFruta(string FrutaClave, [FromBody] FrutaDto frutaDto)
        {
            if (frutaDto == null || string.IsNullOrEmpty(FrutaClave))
                return BadRequest(ModelState);

            var Fruta = _mapper.Map<Fruta>(frutaDto);
            Fruta.FechaModificacion = DateTime.Now;
            if (!_frutasRepository.ActualizarFruta(Fruta))
            {
                ModelState.TryAddModelError("", $"Ocurrio un erro al actualizar la fruta {frutaDto.Nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
