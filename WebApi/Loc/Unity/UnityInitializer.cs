using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Repository;
using WebApi.Services;

namespace WebApi.Loc.Unity
{
    public static class UnityInitializer
    {
        public static void Initialize(HttpConfiguration config)
        {
            var container = new UnityContainer();

            // Registers          
            container.RegisterType<ApplicationContext>(new HierarchicalLifetimeManager());
            container.RegisterType (typeof(IRepository<>), typeof(EFRepository<>));
            container.RegisterType<IRequestService, RequestService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}