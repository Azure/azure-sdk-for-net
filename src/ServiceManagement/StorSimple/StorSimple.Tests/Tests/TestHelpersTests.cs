using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorSimple.Tests.Utilities;
using Xunit;

namespace StorSimple.Tests.Tests
{
    /// <summary>
    /// Tests for helper methods
    /// </summary>
    public class TestHelpersTests
    {
        // Classes for testing CanCopyProperties 
        class TestClassBase
        {
            public string dummyString { get; set; }
            public int dummyInt { get; set; }
            public List<int> dummyList { get; set; }
        }
        // Classes for testing CanCopyProperties 
        class TestClass1 : TestClassBase
        {
            public double mismatchingTypeProperty { get; set; }
            public int exclusivePropertyTestClass1 { get; set; }
        }
        // Classes for testing CanCopyProperties 
        class TestClass2 : TestClassBase
        {
            public int mismatchingTypeProperty { get; set; }
            public int exclusivePropertyTestClass2 { get; set; }
        }

        [Fact]
        public void CanCopyProperties()
        {
            var t1Obj = new TestClass1 { dummyInt = 0, dummyList = new List<int> { 1, 2 }, dummyString = "str", exclusivePropertyTestClass1=4, mismatchingTypeProperty=3.2 };
            var t2Obj = new TestClass2 { exclusivePropertyTestClass2 = 3, mismatchingTypeProperty=5 };
            Helpers.CopyProperties(t1Obj, t2Obj);
            Assert.Equal(t1Obj.dummyInt, t2Obj.dummyInt);
            Assert.Equal(t1Obj.dummyString, t2Obj.dummyString);
            Assert.Equal(t1Obj.dummyList, t2Obj.dummyList);
            Assert.Equal(t2Obj.exclusivePropertyTestClass2, 3);
            Assert.Equal(t2Obj.mismatchingTypeProperty, 5);
        }
    }
}
