using MediatR;
using System.Collections.Generic;
using TeacherSvc.Api.DTO;

namespace TeacherSvc.Api.CQRS.Query
{
    public class GetAllTeachersQuery : IRequest<List<TeacherDto>>
    {
    }
}
