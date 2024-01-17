using System;

namespace Ninject.Tests
{
    public interface IDecoratedCtx
    {
        public string DecoratedName { get; }
    }
    [NinjectComponent(typeof(IDecoratedCtx))]
    public class DecoratedCtx : IDecoratedCtx
    {
        private ICtx _original;

        public DecoratedCtx(ICtx original)
        {
            _original = original;
        }
        public string DecoratedName => _original.Name;
    }
}