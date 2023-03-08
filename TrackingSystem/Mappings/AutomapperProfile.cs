using AutoMapper;
using TrackingSystem.Models;
using TrackingSystem.ViewModels;

namespace TrackingSystem.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CandidateVM, Candidate>();
            CreateMap<Candidate, CandidateVM>();
        }
    }
}
