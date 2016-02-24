using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Functional;
namespace CurryTest
{
    [TestFixture]
    public class CurryTest
    {
        private class TestClass
        {
            public TestClass(int integer, string s, bool b)
            {
                Integer = integer;
                String = s;
                Bool = b;
            }


            public int Integer { get; }
            public string String { get; }
            public bool Bool { get; }
        }
        private int Add(int x, int y)
        {
            return x + y;
        }
        private string NumberOrstring(int a,string b,bool c)
        {
            return c ? a.ToString() : b;
        }
        [Test]
        public void CurryFromTwoArgs()
        {
            var func = Tools.Curry<int,int,int>(Add);
            Assert.AreEqual(8,func(3)(5));
        }
        [Test]
        public void CurryFromThreeArgs()
        {
            var func = Tools.Curry<int, string, bool,string>(NumberOrstring);
            Assert.AreEqual("3", func(3)("yo")(true));
            Assert.AreEqual("yo", func(3)("yo")(false));
        }
        [Test]
        public void CurryAsExtensionMethod()
        {
            Func<int, string, bool, string> norstring = NumberOrstring;
            var func=norstring.Curry();
            Assert.AreEqual("3", func(3)("yo")(true));
            Assert.AreEqual("yo", func(3)("yo")(false));
}
        [Test]
        public void Partial()
        {
            var add5 = Tools.Partial<int, int, int>(Add,5);
            Assert.AreEqual(8, add5(3));

        }
        [Test]
        public void PartialConstructor()
        {
            Func<int,string,bool,TestClass>constructor = (x, y, z) => new TestClass(x, y, z);
            Assert.AreEqual(3, constructor.Partial(3)("w",true).Integer);

        }
        [Test]
        public void PartialAsExtension()
        {
            Func<int, int, int> adder = Add;
            var add5 = adder.Partial(5);
            Assert.AreEqual(8, add5(3));

        }
    }
}
