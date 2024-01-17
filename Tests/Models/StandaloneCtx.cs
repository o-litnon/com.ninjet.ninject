namespace Ninject.Tests
{
    public class StandaloneCtx : IDecoratedCtx
    {
        [Inject]
        public ICtx _original { get; set; }
        public string DecoratedName => _original.Name;
    }
}