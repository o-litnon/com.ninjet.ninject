using NUnit.Framework;

namespace Ninject.Tests
{
    public abstract class KernelTestBase
    {
        protected IKernel kernel { get; set; }

        [Test]
        public void CanRetrieveA_SimpleClass_Successfully()
        {
            var test = kernel.Get<ICtx>();

            Assert.IsNotNull(test);
            Assert.AreEqual(ICtx.ExpectedName, test.Name);
        }

        [Test]
        public void CanRetrieveA_ComplexClass_Successfully()
        {
            var test = kernel.Get<IDecoratedCtx>();

            Assert.IsNotNull(test);
            Assert.AreEqual(ICtx.ExpectedName, test.DecoratedName);
        }
    }
}