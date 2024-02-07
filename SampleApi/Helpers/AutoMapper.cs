using AutoMapper;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.Extensions.Logging;

namespace ApplicationLayer.Helpers
{
	public class MapperProfile:Profile
	{
		public MapperProfile()
		{
			CreateMap<UnitTypeDto, UnitType>()
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

			CreateMap<UnitType, UnitTypeDto>();
		}
	}
}
