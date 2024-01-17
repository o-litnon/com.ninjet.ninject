using System.Linq;
using System.Reflection;

namespace Ninject
{
    public static class BindingExtensions
    {
        public static T Bind<T>(this T self, IKernel kernel) where T : class
        {
            var properties = self
                .GetType()
                .GetProperties(BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance)
                .Where(d => d.GetCustomAttribute<InjectAttribute>() is not null);

            foreach (var property in properties)
                property.SetValue(self, kernel.Get(property.PropertyType));

            return self;
        }
    }
}