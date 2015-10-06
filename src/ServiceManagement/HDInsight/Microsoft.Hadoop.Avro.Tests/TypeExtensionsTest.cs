// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

namespace Microsoft.Hadoop.Avro.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TypeExtensionsTest
    {
        [TestMethod]
        public void CanBeKnownTypeOfTest()
        {
            // Object itself could not be known type of any type
            Assert.IsFalse(typeof(object).CanBeKnownTypeOf(typeof(int)));
            Assert.IsTrue(typeof(int).CanBeKnownTypeOf(typeof(object)));
            Assert.IsFalse(typeof(object).CanBeKnownTypeOf(typeof(object)));

            Assert.IsTrue(typeof(List<int>).CanBeKnownTypeOf(typeof(IEnumerable<int>)));
            Assert.IsTrue(typeof(Collection<int>).CanBeKnownTypeOf(typeof(IEnumerable<int>)));
            Assert.IsTrue(typeof(int[]).CanBeKnownTypeOf(typeof(IEnumerable<int>)));

            Assert.IsFalse(typeof(IEnumerable<int>).CanBeKnownTypeOf(typeof(IEnumerable<int>)));
            Assert.IsFalse(typeof(IEnumerable<int>).CanBeKnownTypeOf(typeof(IEnumerable<string>)));
            Assert.IsFalse(typeof(IEnumerable<int>).CanBeKnownTypeOf(typeof(IEnumerable<Guid>)));
            Assert.IsFalse(typeof(IEnumerable<int>).CanBeKnownTypeOf(typeof(IEnumerable<IListClass>)));
            Assert.IsFalse(typeof(IList<Guid>).CanBeKnownTypeOf(typeof(int[])));
            Assert.IsFalse(typeof(int).CanBeKnownTypeOf(typeof(Guid)));
            Assert.IsFalse(typeof(IList<int>).CanBeKnownTypeOf(typeof(IList<Guid>)));

            Assert.IsFalse(typeof(int[]).CanBeKnownTypeOf(typeof(IList<IListClass>)));
            Assert.IsFalse(typeof(int[]).CanBeKnownTypeOf(typeof(IList<Guid>)));
        }

        [TestMethod]
        public void GenericIsAssignableTest()
        {
            Assert.IsFalse(typeof(int[]).GenericIsAssignable(typeof(IDictionary<int, Guid>)));
            Assert.IsFalse(typeof(IList<int>).GenericIsAssignable(typeof(IDictionary<int, Guid>)));
            Assert.IsFalse(typeof(IDictionary<int, Guid>).GenericIsAssignable(typeof(IList<int>)));
        }
    }
}
