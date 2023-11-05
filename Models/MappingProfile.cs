using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace TESTASP_DCPR.Models
{
    public class MappingProfile:Profile
    {
        

            public MappingProfile(){
          //  CreateMap<Contravention, DGI>().ReverseMap();
            CreateMap<Agents, UserInput>().ReverseMap();
            CreateMap<Agents, LoginModel>().ReverseMap();
        }




    } 
}