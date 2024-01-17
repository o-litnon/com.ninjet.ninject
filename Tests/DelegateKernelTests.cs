using NUnit.Framework;

namespace Ninject.Tests
{
    public class DelegateKernelTests : KernelTestBase
    {
        [SetUp]
        public void Setup()
        {
            kernel = LazyKernel.Create(builder =>
            {
                builder.Bind<IDecoratedCtx>().To<DecoratedCtx>().InSingletonScope();
                builder.Bind<ICtx>().To<TestCtx>().InSingletonScope();
            });
        }
    }
}