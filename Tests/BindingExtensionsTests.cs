using NUnit.Framework;

namespace Ninject.Tests
{
    public class BindingExtensionsTests : KernelTestBase
    {
        [SetUp]
        public void Setup()
        {
            kernel = LazyKernel.Create(builder =>
            {
                builder.Bind<IDecoratedCtx>().ToMethod(d =>
                {
                    return new StandaloneCtx().Bind(d.Kernel);
                }).InSingletonScope();

                builder.Bind<ICtx>().To<TestCtx>().InSingletonScope();
            });
        }
    }
}