using AutoMapper;
using CompanyManageMentSystem.DTOs.Department;
using CompanyManageMentSystem.DTOs.EmployeeProject;
using CompanyManageMentSystem.Models;
using CompanyManageMentSystem.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManageMentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public EmployeeProjectController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(CreateEmployeeProjectDTO dto)
        {

            if (dto == null || !ModelState.IsValid) { return BadRequest(); }
            var employee=_unit.Employee.GetById(dto.EmployeeId);
            if (employee == null) { return NotFound(); }

            var project=_unit.Projects.GetById(dto.ProjectId);
            if (project == null) { return NotFound(); }

            var dep = _mapper.Map<EmployeeProject>(dto);
            _unit.EmployeeProject.Add(dep);

            _unit.SaveAsync();
            return Created();

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var debs = await _unit.EmployeeProject.GetAll();

            var dto = _mapper.Map<List<GetEmployeeProjectDTO>>(debs);
            return Ok(dto);

        }

        [HttpGet("by-employee/{employeeid}")]
        public async Task<IActionResult> GetByEmployeeId(int employeeid) { 
        
            var emps=await _unit.EmployeeProject.GetEmployeeProjectsByEmployeeId(employeeid);
            var  dto=_mapper.Map<GetEmployeeProjectDTO>(emps);

            return Ok(dto);
        }
    }
}
