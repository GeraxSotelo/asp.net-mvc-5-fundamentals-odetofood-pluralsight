using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace OdeToFood.Web
{
    //register in Global.asax.cs
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            //from Global.asax.cs
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //register api controllers
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            //register type InMemoryRestaurantData and use it whenever someone asks for an object that implements IRestaurantData
            builder.RegisterType<InMemoryRestaurantData>().As<IRestaurantData>().SingleInstance();

            //create an Autofac container from the container builder to tell the MVC5 framework to use this container whenever it needs to resolve dependencies
            var container = builder.Build();
            //set container as the dependency resolver throughout the running of this MVC5 application
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}