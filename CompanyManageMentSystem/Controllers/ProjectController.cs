using AutoMapper;
using CompanyManageMentSystem.DTOs.Department;
using CompanyManageMentSystem.DTOs.Project;
using CompanyManageMentSystem.Models;
using CompanyManageMentSystem.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManageMentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ProjectController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add(CreateProjectDTO dto)
        {

            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            var dep = _mapper.Map<Project>(dto);
             _unit.Projects.Add(dep);

            _unit.SaveAsync();
            return Created();

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var debs = await _unit.Projects.GetAll();

            var dto = _mapper.Map<List<GetprojectDTO>>(debs);
            return Ok(dto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var deb = await _unit.Projects.GetById(id);

            var dto = _mapper.Map<GetprojectDTO>(deb);
            return Ok(dto);

        }


        [HttpPut]
        public async Task<IActionResult> Update(int id, CreateProjectDTO dto)
        {
            var dep = await _unit.Projects.GetById(id);
            if (dep == null || !ModelState.IsValid) { return BadRequest(); }

            _mapper.Map(dto, dep);
            _unit.Projects.Update(dep);
            _unit.Save();

            return Ok();

        }

    }
}
