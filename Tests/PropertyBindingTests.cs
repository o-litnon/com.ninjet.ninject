using NUnit.Framework;

namespace Ninject.Tests
{
    public class PropertyBindingTests : KernelTestBase
    {
        [SetUp]
        public void Setup()
        {
            kernel = LazyKernel.Create(builder =>
            {
                builder.Bind<IDecoratedCtx>().To<StandaloneCtx>().InSingletonScope();
                builder.Bind<ICtx>().To<TestCtx>().InSingletonScope();
            });
        }
    }
}