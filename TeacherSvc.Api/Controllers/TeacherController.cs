﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherSvc.Api.CQRS.Command;
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

        [HttpGet("view/{firstNameChar}")]
        [ProducesResponseType(200, Type = typeof(List<TeacherDto>))]
        public async Task<List<TeacherDto>> GetTeachersByFirstNameChar(string firstNameChar)
        {
            var teachers = await this._mediator.Send(new GetTearchersByFirstNameCharQuery { FirstNameChar = firstNameChar }).ConfigureAwait(false);
            return teachers;
        }

        // GET api/<TeacherController>/5
        [HttpGet("view/{id}")]
        public async Task<TeacherDto> GetTeacherById(int id)
        {
            var teacher = await this._mediator.Send(new GetTeacherByIdQuery { TeacherId = id }).ConfigureAwait(false);
            return teacher;
        }

        // POST api/<TeacherController>
        [HttpPost("register")]
        public async Task<bool> Post([FromBody] TeacherDto value)
        {
            bool status = await this._mediator.Send(new TeacherRegisterCommand { Teacher = value }).ConfigureAwait(false);
            return status;
        }

        //// PUT api/<TeacherController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status = await this._mediator.Send(new DeleteTeacherCommand { Id = id }).ConfigureAwait(false);
            return status;
        }
    }
}
