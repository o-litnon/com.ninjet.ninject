using System;

namespace Ninject.Tests
{
    public interface ICtx
    {
        public string Name { get; }
        public static string ExpectedName = Guid.NewGuid().ToString();
    }
    [NinjectComponent(typeof(ICtx))]
    public class TestCtx : ICtx
    {
        public string Name => ICtx.ExpectedName;
    }
}