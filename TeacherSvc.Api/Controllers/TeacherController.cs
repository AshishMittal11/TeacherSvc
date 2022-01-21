using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherSvc.Api.CQRS.Query;
using TeacherSvc.Api.DTO;

namespace TeacherSvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("view")]
        public async Task<List<TeacherDto>> GetAllTeachers()
        {
            var teachers = await this._mediator.Send(new GetAllTeachersQuery()).ConfigureAwait(false);
            return teachers;  
        }

        // GET api/<TeacherController>/5
        [HttpGet("view/{id}")]
        public async Task<TeacherDto> GetTeacherById(int id)
        {
            var teacher = await this._mediator.Send(new GetTeacherByIdQuery { TeacherId = id }).ConfigureAwait(false);
            return teacher;
        }

        //// POST api/<TeacherController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<TeacherController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TeacherController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
