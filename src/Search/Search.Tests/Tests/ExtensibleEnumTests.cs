// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Microsoft.Azure.Search.Models;
    using Xunit;

    public class ExtensibleEnumTests
    {
        [Fact]
        public void CanConvertEnumToString()
        {
            Assert.Equal("a", TestEnum.A.ToString());
            Assert.Equal("b", TestEnum.B.ToString());
            Assert.Equal("c", TestEnum.Create("c").ToString());

            Assert.Equal("a", (string)TestEnum.A);
            Assert.Equal("b", (string)TestEnum.B);
            Assert.Equal("c", (string)TestEnum.Create("c"));
        }

        [Fact]
        public void CanGetHashCode()
        {
            TestEnum.A.GetHashCode();
        }

        [Fact]
        public void CanCompareForEquality()
        {
            Assert.True(TestEnum.A.Equals(TestEnum.A));
            Assert.False(TestEnum.A.Equals(TestEnum.B));
            Assert.False(TestEnum.A.Equals(TestEnum.Create("c")));
            Assert.True(TestEnum.Create("a").Equals(TestEnum.A));

            Assert.True(TestEnum.A.Equals((object)TestEnum.A));
            Assert.False(TestEnum.A.Equals((object)TestEnum.B));
            Assert.False(TestEnum.A.Equals((object)TestEnum.Create("c")));
            Assert.True(TestEnum.Create("a").Equals((object)TestEnum.A));
        }

        private class TestEnum : ExtensibleEnum<TestEnum>
        {
            public static readonly TestEnum A = new TestEnum("a");

            public static readonly TestEnum B = new TestEnum("b");

            private TestEnum(string name) : base(name) {}

            public static TestEnum Create(string name) => Lookup(name) ?? new TestEnum(name);
        }
    }
}
