using System;

namespace Ninject
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class NinjectComponentAttribute : Attribute
    {
        public Type[] ComponentInterfaces { get; set; } = null;
        public bool Singleton { get; set; } = true;
        public NinjectComponentAttribute(bool singleton = true, params Type[] types) : this(types)
        {
            this.Singleton = singleton;
        }
        public NinjectComponentAttribute(params Type[] types)
        {
            ComponentInterfaces = types;
        }
    }
}
