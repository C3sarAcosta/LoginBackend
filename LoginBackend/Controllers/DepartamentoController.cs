using AutoMapper;
using LoginBackend.Dtos;
using LoginBackend.Models;
using LoginBackend20243S.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DepartamentoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CrearDepartamento(DepartamentoSinIdDTO departamentoSinIdDTO)
        {
            var deptoExiste = await context.Departamentos.FirstOrDefaultAsync(x => x.Nombre == departamentoSinIdDTO.Nombre);

            if(deptoExiste != null)
            {
                return BadRequest("Ya existe un departamento con ese nombre");
            }

            var departamento = mapper.Map<Departamento>(departamentoSinIdDTO);
            context.Departamentos.Add(departamento);
            await context.SaveChangesAsync();

            return Ok(departamento);
        }

        [HttpGet("{Id:int}", Name = "ObtenerDepartamento|")]
        public async Task<ActionResult<Departamento>> ObtenerDepartamento(int Id)
        {
            var departamento = await context.Departamentos.FirstOrDefaultAsync(x => x.Id == Id);
            if (departamento == null)
            {
                return NotFound();
            }
            var departamentoDTO = mapper.Map<DepartamentoConIdDTO>(departamento);

            return Ok(departamentoDTO);
        }
    }
}
