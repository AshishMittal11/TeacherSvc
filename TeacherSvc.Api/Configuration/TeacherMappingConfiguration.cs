using Mapster;
using System;
using TeacherSvc.Api.DTO;
using TeacherSvc.Api.Models;

namespace TeacherSvc.Api.Configuration
{
    public static class TeacherMappingConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<TeacherDto, Teacher>
                .NewConfig()
                .Map(dest => dest.CreatedOn, src => DateTimeOffset.UtcNow)
                .Map(dest => dest.ModifiedOn, src => DateTimeOffset.UtcNow);
        }
    }
}
