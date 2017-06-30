// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Fluent.Tests
{
    public class ExapandableEnum
    {
        public class ExpandableStringEnumFoo : ExpandableStringEnum<ExpandableStringEnumFoo>
        {
            public static readonly ExpandableStringEnumFoo Foo1 = Parse("value1");
            public static readonly ExpandableStringEnumFoo Foo2 = Parse("value2");
        }

        public class ExpandableStringEnumBar : ExpandableStringEnum<ExpandableStringEnumBar>
        {
            public static readonly ExpandableStringEnumBar Bar1 = Parse("value1");
            public static readonly ExpandableStringEnumBar Bar2 = Parse("value3");
        }

        [Fact]
        public void ExpandableEnums()
        {
            ExpandableStringEnumFoo foo = ExpandableStringEnumFoo.Foo1;
            Assert.True(ExpandableStringEnumFoo.Foo1 == foo);

            Assert.True(ExpandableStringEnumFoo.Foo1 == ExpandableStringEnumFoo.Parse(ExpandableStringEnumFoo.Foo1.ToString()));
            Assert.True(ExpandableStringEnumFoo.Foo1 != ExpandableStringEnumFoo.Parse(ExpandableStringEnumFoo.Foo2.ToString()));
            Assert.True(ExpandableStringEnumBar.Bar1 == ExpandableStringEnumBar.Parse(ExpandableStringEnumBar.Bar1.ToString()));
            Assert.True(ExpandableStringEnumBar.Bar1 != ExpandableStringEnumBar.Parse(ExpandableStringEnumBar.Bar2.ToString()));
        }
    }
}
