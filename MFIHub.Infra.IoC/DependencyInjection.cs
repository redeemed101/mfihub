using CommonLibraries.Application.Services;
using CommonLibraries.Domain.Repositories;
using MFIHub.Application.DTOs;
using MFIHub.Infra.Data.Context;
using MFIHub.Infra.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFIHub.Infra.IoC
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IRepository<Topic, MFIHubContext>, Repository<Topic, MFIHubContext>>();

            services.AddTransient<IService<Topic, TopicDto, MFIHubContext>, Service<Topic, TopicDto, MFIHubContext>>();
            services.AddDbContext<MFIHubContext>(
                   opts => opts.UseMySQL(Configuration["ConnectionString:MFIDB"]));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<MFIHubContext>();
        }
    }
}
