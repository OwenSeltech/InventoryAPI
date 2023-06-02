using AutoMapper;
using InventoryAPI.DTOs;
using InventoryAPI.Entities;

namespace InventoryAPI.Helpers
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<ProductRequestDto, Product>()
				.ForMember(x => x.DateAdded, opt => opt.MapFrom(src => DateTime.Now));

		}
	}
}
