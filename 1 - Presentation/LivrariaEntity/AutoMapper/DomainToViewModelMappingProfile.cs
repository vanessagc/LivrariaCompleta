using AutoMapper;
using LivrariaEntity.ViewModels;
using LivrariaMvc.Domain.Models;

namespace LivrariaEntity.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        // Não realizar este override na versão 4.x e superiores

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<Livraria, LivrariaViewModel>();
        }

    }
}