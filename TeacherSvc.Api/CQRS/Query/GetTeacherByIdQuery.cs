using MediatR;
using TeacherSvc.Api.DTO;

namespace TeacherSvc.Api.CQRS.Query
{
    public class GetTeacherByIdQuery : IRequest<TeacherDto>
    {
        public int TeacherId { get; set; }
    }
}
