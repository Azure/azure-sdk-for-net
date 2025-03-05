// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class CollectionBuilderTests
    {
        private static readonly FailBuilder s_failBuilder = new FailBuilder();

        [Test]
        public void AssertItem_Fails()
        {
            var ex = Assert.Throws<ArgumentException>(s_failBuilder.FailAssertItem);
            Assert.IsNotNull(ex);
            Assert.AreEqual("item", ex!.ParamName);
            Assert.AreEqual("item must be type Int32 (Parameter 'item')", ex.Message);
        }

        [Test]
        public void AssertKey_Fails()
        {
            var ex = Assert.Throws<ArgumentNullException>(s_failBuilder.FailAssertKey);
            Assert.IsNotNull(ex);
            Assert.AreEqual("key", ex!.ParamName);
        }

        private class FailBuilder : CollectionBuilder
        {
            protected internal override void AddItem(object item, string? key = null) => throw new NotImplementedException();
            protected internal override object GetBuilder() => throw new NotImplementedException();
            protected internal override object? CreateElement() => throw new NotImplementedException();

            public void FailAssertItem()
            {
                AssertItem<int>("x");
            }

            public void FailAssertKey()
            {
                AssertKey(null);
            }
        }
    }
}
