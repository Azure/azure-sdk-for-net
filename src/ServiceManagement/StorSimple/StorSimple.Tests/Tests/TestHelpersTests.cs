// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
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
