using AutoMapper;
using CompanyManageMentSystem.DTOs.Department;
using CompanyManageMentSystem.Models;
using CompanyManageMentSystem.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManageMentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpPost]
        public  IActionResult Add(CreateDepartmentDTO dto) {

            if (dto == null||!ModelState.IsValid) { return BadRequest(); }
        
            var dep=_mapper.Map<Department>(dto);
             _unit.Departments.Add(dep);

            _unit.Save();
            return Created();
        
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var debs=await _unit.Departments.GetAll();

            var dto=_mapper.Map<List<GetDepartmentDTO>>(debs);
            return Ok(dto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var deb = await _unit.Departments.GetById(id);

            var dto = _mapper.Map<GetDepartmentDTO>(deb);
            return Ok(dto);

        }


        [HttpPut]
        public async Task<IActionResult> Update(int id,CreateDepartmentDTO dto)
        {
            var dep = await _unit.Departments.GetById(id);
            if(dep == null||!ModelState.IsValid) {return BadRequest();}

            _mapper.Map(dto, dep);
            _unit.Departments.Update(dep);
            _unit.Save();
           
            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var dep = await _unit.Departments.GetById(id);
            if (dep == null ) { return BadRequest(); }

            _unit.Departments.Delete(dep);
            _unit.Save();
            return NoContent();
        }

    }
}
