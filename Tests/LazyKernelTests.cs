using NUnit.Framework;
using System;

namespace Ninject.Tests
{
    using System;
    public class LazyKernelTest : KernelTestBase
    {
        [SetUp]
        public void Setup()
        {
            kernel = LazyKernel.Create(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}