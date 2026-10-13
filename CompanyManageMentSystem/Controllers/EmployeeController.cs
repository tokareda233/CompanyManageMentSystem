using AutoMapper;
using CompanyManageMentSystem.DTOs.Department;
using CompanyManageMentSystem.DTOs.Employee;
using CompanyManageMentSystem.Models;
using CompanyManageMentSystem.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManageMentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(CreateEmployeeDTO dto)
        {

            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            var dep = _mapper.Map<Employee>(dto);
             _unit.Employee.Add(dep);

            _unit.SaveAsync();
            return Created();

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var debs = await _unit.Employee.GetAll();

            var dto = _mapper.Map<List<GetEmployeeDTO>>(debs);
            return Ok(dto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var deb = await _unit.Employee.GetById(id);

            var dto = _mapper.Map<GetEmployeeDTO>(deb);
            return Ok(dto);

        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, CreateEmployeeDTO dto)
        {
            var dep = await _unit.Employee.GetById(id);
            if (dep == null || !ModelState.IsValid) { return BadRequest(); }

            _mapper.Map(dto, dep);
            _unit.Employee.Update(dep);
            _unit.Save();

            return Ok();

        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var dep = await _unit.Employee.GetById(id);
            if (dep == null) { return BadRequest(); }

            _unit.Employee.Delete(dep);
            _unit.Save();
            return NoContent();
        }


        [HttpGet("Search")]
        public async Task<IActionResult> SearchByName(string Name)
        {
            var emps=await _unit.Employee.SearchByName(Name);
            var dto=_mapper.Map<List<GetEmployeeDTO>>(emps);

            return Ok(dto);
        }

        [HttpGet("by-department/{departmentid}")]
        public async Task<IActionResult> GetByDepartMentId(int departmentid)
        {
            var emps=await _unit.Employee.GetEmplyeesByDepartmentid(departmentid);

            var dto = _mapper.Map<List<GetEmployeeDTO>>(emps);

            return Ok(dto);

        }


    }
}
