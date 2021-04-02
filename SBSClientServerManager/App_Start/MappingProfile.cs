using AutoMapper;
using SBSClientServerManager.Models;
using SBSClientServerManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SBSClientServerManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Client, ClientFormViewModel>();
            Mapper.CreateMap<ClientFormViewModel, Client>();

            Mapper.CreateMap<Client, ClientViewModel>();
            Mapper.CreateMap<ClientViewModel, Client>();

           
            Mapper.CreateMap<Server, ServerFormViewModel>();
            Mapper.CreateMap<ServerFormViewModel, Server>();

            Mapper.CreateMap<Server, ServerViewModel>();
            Mapper.CreateMap<ServerViewModel, Server>();

            Mapper.CreateMap<VPN, VpnFormViewModel>();
            Mapper.CreateMap<VpnFormViewModel, VPN>();


            Mapper.CreateMap<VPN, VpnViewModel>();
            Mapper.CreateMap<VpnViewModel, VPN>();

            Mapper.CreateMap<SqlServer, SqlServerViewModel>();
            Mapper.CreateMap<SqlServerViewModel, SqlServer>();

            Mapper.CreateMap<SqlServer, SqlServerFormViewModel>();
            Mapper.CreateMap<SqlServerFormViewModel, SqlServer>();


        }
    }
}