using AssignmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssingmentController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllEmployees")]
        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            try
            {
               employees = new EmployeeModel().get_all();
                if(employees.Count > 0)
                {
                    return employees;

                }
                else
                {
                }
            }
            catch (Exception)
            {

            }


            return employees;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public EmployeeModel GetEmployee(int id)
        {
            EmployeeModel employee = new EmployeeModel();
            try
            {
                employee = new EmployeeModel().get_emp(id);
                if (employee!=null)
                {
                    return employee;

                }
                else
                {
                }
            }
            catch (Exception)
            {

            }


            return employee;
        }
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(EmployeeModel employee)
        {
            Data data = new Data();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                if (employeeModel.add_employee(employee))
                {
                    return StatusCode(201,"Employee Updated");
                }
            }
            catch (Exception)
            {

            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletEmployee(int id)
        {
            Data data = new Data();
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                if (employeeModel.delete_employee(id))
                {
                    return StatusCode(200,"Employee Deleted");
                }
            }
            catch (Exception)
            {

            }

            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(EmployeeModel employee)
        {
            Data data = new Data();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                if (employeeModel.update_employee(employee))
                {
                    return StatusCode(201,"Updated Success Fully");
                }
            }
            catch (Exception)
            {

            }

            return Ok();
        }

    }
}
