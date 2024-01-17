using Ninject.Modules;
using Ninject.Syntax;
using System;

namespace Ninject
{
    public class DelegateModule : NinjectModule
    {
        private Action<IBindingRoot> _load;

        public static NinjectModule Create(Action<IBindingRoot> load) => new DelegateModule(load);
        public DelegateModule(Action<IBindingRoot> load)
        {
            _load = load;
        }

        public override void Load()
        {
            _load(this);
        }
    }
}