using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;


namespace Assignment7
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();

            // Disable AutoMapper v4.2.x warnings
#pragma warning disable CS0618

            Mapper.CreateMap<Models.Smartphone, Controllers.SmartphoneBase>();
            Mapper.CreateMap<Controllers.SmartphoneBase, Controllers.SmartphoneWithLink>()
                .ForMember(dest => dest.LinkId, opt => opt.MapFrom(src => src.Id));


            Mapper.CreateMap<Controllers.SmartphoneAdd, Models.Smartphone>();            
            

#pragma warning restore CS0618
        }
    }
}