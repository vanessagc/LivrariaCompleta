using AutoMapper;
using LivrariaEntity.ViewModels;
using LivrariaMvc.Domain.Models;

namespace LivrariaEntity.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        protected override void Configure()
        {
            CreateMap<LivrariaViewModel, Livraria>();
        }
    }
}