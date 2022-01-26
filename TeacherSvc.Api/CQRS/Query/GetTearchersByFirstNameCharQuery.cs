using MediatR;
using System.Collections.Generic;
using TeacherSvc.Api.DTO;

namespace TeacherSvc.Api.CQRS.Query
{
    public class GetTearchersByFirstNameCharQuery : IRequest<List<TeacherDto>>
    {
        public string FirstNameChar { get; set;}
    }
}
