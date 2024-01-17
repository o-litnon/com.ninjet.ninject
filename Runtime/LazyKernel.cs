using Ninject.Syntax;
using System;
using System.Linq;
using System.Reflection;

namespace Ninject
{
    public class LazyKernel : StandardKernel
    {
        /// <summary>
        /// Retrieves all classes attributed with 'NinjectComponent' and injectes them into the returned Kernel
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns>StandardKernel</returns>
        public static IKernel Create(params Assembly[] assemblies)
        {
            return Create(builder =>
            {
                var components = assemblies
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(type => !type.IsInterface && type.GetCustomAttribute<NinjectComponentAttribute>() is not null);

                foreach (var component in components)
                {
                    var attribute = component.GetCustomAttribute<NinjectComponentAttribute>();
                    var binder = attribute.ComponentInterfaces is not null
                        ? builder.Bind(attribute.ComponentInterfaces).To(component)
                        : builder.Bind(component).ToSelf();

                    if (attribute.Singleton)
                        binder.InSingletonScope();
                }
            });
        }

        public static IKernel Create(Action<IBindingRoot> load) => new StandardKernel(DelegateModule.Create(load));
    }
}