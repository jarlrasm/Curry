using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Functional;
namespace CurryTest
{
    [TestFixture]
    public class CurryTest
    {
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
        public void PartialAsExtension()
        {
            Func<int, int, int> adder = Add;
            var add5 = adder.Partial(5);
            Assert.AreEqual(8, add5(3));

        }
    }
}
