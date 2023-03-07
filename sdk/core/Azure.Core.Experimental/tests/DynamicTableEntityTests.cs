// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Dynamic;
using Azure.Data.Tables;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class DynamicTableEntityTests
    {
        [Test]
        public void CanGetIntProperty()
        {
            TableEntity te = new TableEntity
            {
                { "Foo", 1 }
            };
            dynamic dte = new DynamicTableEntity(te);

            Assert.IsTrue(dte.Foo == 1);
        }

        [Test]
        public void CanSetIntProperty()
        {
            TableEntity te = new TableEntity();
            dynamic dte = new DynamicTableEntity(te);
            dte.Foo = 1;

            Assert.IsTrue(dte.Foo == 1);
        }

        [Test]
        public void CanGetNestedProperty()
        {
            TableEntity te = new TableEntity
            {
                { "Foo",
                    new TableEntity
                    {
                        { "Bar", 1 }
                    }
                }
            };

            dynamic dte = new DynamicTableEntity(te);

            Assert.IsTrue(dte.Foo.Bar == 1);
        }
    }
}
