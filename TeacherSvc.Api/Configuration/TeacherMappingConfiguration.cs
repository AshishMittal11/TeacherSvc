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

            TypeAdapterConfig<Teacher, TeacherDto>
                .NewConfig()
                .Map(dest => dest.CreatedOn, src => src.CreatedOn.ToString("MM/dd/yyyy"))
                .Map(dest => dest.ModifiedOn, src => src.ModifiedOn.ToString("MM/dd/yyyy"));

            TypeAdapterConfig<QualificationDto, Qualification>
                .NewConfig()
                .Map(dest => dest.CreatedOn, src => DateTimeOffset.UtcNow)
                .Map(dest => dest.ModifiedOn, src => DateTimeOffset.UtcNow);

            TypeAdapterConfig<Qualification, QualificationDto>
                .NewConfig()
                .Map(dest => dest.CreatedOn, src => src.CreatedOn.ToString("MM/dd/yyyy"))
                .Map(dest => dest.ModifiedOn, src => src.ModifiedOn.ToString("MM/dd/yyyy"));
        }
    }
}
