using ClassLibrary;

namespace Cs8613WithCovariantReturnType
{
    class TestClass : IBaseInterface
    {
        private int id;

        public TestClass(int id)
            => this.id = id;

        public override string ToString()
            => id.ToString();
    }
}
