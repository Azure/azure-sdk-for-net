// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Microsoft.Azure.Search.Models;
    using System;
    using System.Linq;
    using System.Reflection;
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
            var aAlias = TestEnum.A;    // Resolve compiler warning
            Assert.True(TestEnum.A.Equals(TestEnum.A));
            Assert.True(TestEnum.A.Equals((object)TestEnum.A));
            Assert.True(aAlias == TestEnum.A);
            Assert.False(aAlias != TestEnum.A);

            Assert.False(TestEnum.A.Equals(TestEnum.B));
            Assert.False(TestEnum.A.Equals((object)TestEnum.B));
            Assert.False(TestEnum.A == TestEnum.B);
            Assert.True(TestEnum.A != TestEnum.B);

            Assert.False(TestEnum.A.Equals(TestEnum.Create("c")));
            Assert.False(TestEnum.A.Equals((object)TestEnum.Create("c")));
            Assert.False(TestEnum.A == TestEnum.Create("c"));
            Assert.True(TestEnum.A != TestEnum.Create("c"));

            Assert.True(TestEnum.Create("a").Equals(TestEnum.A));
            Assert.True(TestEnum.Create("a").Equals((object)TestEnum.A));
            Assert.True(TestEnum.Create("a") == TestEnum.A);
            Assert.False(TestEnum.Create("a") != TestEnum.A);

            Assert.True(TestEnum.Special(TestEnum.A).Equals(TestEnum.Special(TestEnum.A)));
            Assert.True(TestEnum.Special(TestEnum.A).Equals((object)TestEnum.Special(TestEnum.A)));
            Assert.True(TestEnum.Special(TestEnum.A) == TestEnum.Special(TestEnum.A));
            Assert.False(TestEnum.Special(TestEnum.A) != TestEnum.Special(TestEnum.A));

            Assert.False(TestEnum.Special(TestEnum.A).Equals(TestEnum.Special(TestEnum.B)));
            Assert.False(TestEnum.Special(TestEnum.A).Equals((object)TestEnum.Special(TestEnum.B)));
            Assert.False(TestEnum.Special(TestEnum.A) == TestEnum.Special(TestEnum.B));
            Assert.True(TestEnum.Special(TestEnum.A) != TestEnum.Special(TestEnum.B));
        }

        [Fact]
        public void CannotCompareDifferentEnumsForEquality()
        {
            Assert.False(TestEnum.A.Equals(TestEnum2.A));
            Assert.False(TestEnum.A.Equals((object)TestEnum2.A));
        }

        [Fact]
        public void CanCreateNonObsoleteTypeFromValue()
        {
            TestEnumWithObsolete notObsolete = TestEnumWithObsolete.Create("NotObsolete");
            Assert.Same(TestEnumWithObsolete.NotObsolete, notObsolete);
        }

        [Fact]
        public void CannotCreateObsoleteTypeFromValue()
        {
            // this should result in a new TestEnumWithObsolete instance being created
            TestEnumWithObsolete obsolete = TestEnumWithObsolete.Create("Obsolete");
#pragma warning disable CS0612 // Type or member is obsolete
            Assert.NotSame(TestEnumWithObsolete.Obsolete, obsolete);
#pragma warning restore CS0612 // Type or member is obsolete
        }

        private class TestEnum : ExtensibleEnum<TestEnum>
        {
            public static readonly TestEnum A = new TestEnum("a");

            public static readonly TestEnum B = new TestEnum("b");

            private TestEnum(string name) : base(name) {}

            public static TestEnum Create(string name) => Lookup(name) ?? new TestEnum(name);

            public static TestEnum Special(TestEnum baseEnum) => Create($"Special({baseEnum})");
        }

        private class TestEnum2 : ExtensibleEnum<TestEnum2>
        {
            public static readonly TestEnum2 A = new TestEnum2("a");

            private TestEnum2(string name) : base(name) { }

            public static TestEnum2 Create(string name) => Lookup(name) ?? new TestEnum2(name);
        }

        private class TestEnumWithObsolete : ExtensibleEnum<TestEnumWithObsolete>
        {
            public static readonly TestEnumWithObsolete NotObsolete = new TestEnumWithObsolete("NotObsolete");

            [Obsolete]
            public static readonly TestEnumWithObsolete Obsolete = new TestEnumWithObsolete("NotObsolete");

            [Obsolete]
            public static readonly TestEnumWithObsolete Obsolete2 = new TestEnumWithObsolete("Obsolete");

            private TestEnumWithObsolete(string name) : base(name) { }

            public static TestEnumWithObsolete Create(string name) => Lookup(name) ?? new TestEnumWithObsolete(name);
        }
    }
}
