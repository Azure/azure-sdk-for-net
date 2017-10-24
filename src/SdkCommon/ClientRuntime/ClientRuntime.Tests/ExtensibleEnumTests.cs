// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Rest.ClientRuntime.Tests.Resources;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests
{
    [Collection("ExtensibleEnums Tests")]
    public class ExtensibleEnumTests
    {
        [Fact]
        public void ExtensibleEnumsTests()
        {
            // Serialization test
            var serializeSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            var movieTic = new MovieTicket() { Day = DaysOfWeekExtensibleEnum.Friday, MovieName = "ABC", Price = 13.50 };
            var serialObj = JsonConvert.SerializeObject(movieTic);
            Assert.NotNull(serialObj);
            Assert.True(serialObj.Contains("Friday"));

            // Deserialization test
            var serializedMovieTic = "{\"Price\":11.5,\"Day\":\"Weekday\",\"MovieName\":\"DEF\"}";
            var deserializeSettings = new JsonSerializerSettings() {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                NullValueHandling = NullValueHandling.Ignore
            };
            var deserialized = JsonConvert.DeserializeObject<MovieTicket>(serializedMovieTic);
            Assert.Equal(deserialized.Price, 11.50);
            Assert.Equal(deserialized.MovieName, "DEF");
            Assert.Equal(deserialized.Day, (DaysOfWeekExtensibleEnum)"Weekday");

            var day1 = DaysOfWeekExtensibleEnum.Saturday;
            DaysOfWeekExtensibleEnum day2 = "Monday";
            Assert.False(day1 == DaysOfWeekExtensibleEnum.Monday);

            DaysOfWeekExtensibleEnum day3 = "Weekday";
            DaysOfWeekExtensibleEnum day4 = "Weekday";
            Assert.True(day4 == day3);
        }

        [Fact]
        public void CanConvertEnumToString()
        {
            Assert.Equal("a", TestEnum.A.ToString());
            Assert.Equal("b", TestEnum.B.ToString());
            Assert.Equal("b", ((TestEnum)"b").ToString());
            Assert.Equal("c", ((TestEnum)"c").ToString());

            Assert.Equal("a", TestEnum.A.ToString());
            Assert.Equal("b", TestEnum.B.ToString());
            Assert.Equal("c", ((TestEnum)"c").ToString());
        }

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

            Assert.False(TestEnum.A.Equals((TestEnum)"c"));
            Assert.False(TestEnum.A.Equals((object)(TestEnum)"c"));
            Assert.False(TestEnum.A == (TestEnum)"c");
            Assert.True(TestEnum.A != (TestEnum)"c");

            Assert.True(((TestEnum)"a").Equals(TestEnum.A));
            Assert.True(((TestEnum)"a").Equals((object)TestEnum.A));
            Assert.True(((TestEnum)"a") == TestEnum.A);
            Assert.False(((TestEnum)"a") != TestEnum.A);

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
            Assert.False(TestEnum.A.Equals((TestEnum2)"A"));
            Assert.False(TestEnum.A.Equals((TestEnum2)"A"));
        }

        private class TestEnum : ExtensibleEnum<TestEnum, string>
        {

            private TestEnum(string value):base(value)
            {
            }

            public static implicit operator TestEnum(string value) => _valueMap.GetOrAdd(value, (v)=>new TestEnum(v));

            public static readonly TestEnum A = "a";
            public static readonly TestEnum B = "b";
            public static TestEnum Special(TestEnum baseEnum) => $"Special({baseEnum})";
        }

        private class TestEnum2 : ExtensibleEnum<TestEnum2, string>
        {
            public static implicit operator TestEnum2(string value) => _valueMap.GetOrAdd(value, (v) => new TestEnum2(v));

            private TestEnum2(string name) : base(name) { }
            
        }

    }
}