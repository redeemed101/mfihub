
using AutoMapper;
using MFIHub.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFIHub.Server.Mapping
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {

            CreateMap<Topic, Shared.Models.Topic>();

        }
    }
}
