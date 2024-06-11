using AutoMapper;
using VehicleService.Models;
using VehicleService.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerViewModel>().ReverseMap();
        CreateMap<Vehicle, VehicleViewModel>().ReverseMap();
        CreateMap<ServiceRecord, ServiceRecordViewModel>().ReverseMap();
        CreateMap<Mechanic, MechanicViewModel>().ReverseMap();
    }
}