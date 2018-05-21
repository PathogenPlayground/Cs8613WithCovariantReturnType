using ClassLibrary;
using System.Collections;
using System.Collections.Generic;

namespace Cs8613WithCovariantReturnType
{
    class TestClassCollection : ITestClassCollection
    {
        private List<TestClass?> collection = new List<TestClass?>();

        public TestClassCollection()
        {
            collection.Add(new TestClass(0));
            collection.Add(new TestClass(1));
            collection.Add(null);
            collection.Add(new TestClass(2));
        }

        // warning CS8613: Nullability of reference types in return type doesn't match implicitly implemented member 'IEnumerator<IBaseInterface> IEnumerable<IBaseInterface>.GetEnumerator()'.
        public IEnumerator<IBaseInterface?> GetEnumerator()
            => collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => collection.GetEnumerator();
    }
}
