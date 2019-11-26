// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Microsoft.Azure.Search.Common;
    using Microsoft.Azure.Search.Serialization;
    using Models;
    using Newtonsoft.Json;
    using Xunit;

    public sealed class ExtensibleEnumConverterTests
    {
        [Fact]
        public void CanSerializeKnownValue()
        {
            const string ExpectedJson = @"{""ID"":1,""Test"":""One""}";

            var model = new Model() { ID = 1, Test = TestEnum.One };
            string actualJson = JsonConvert.SerializeObject(model);

            Assert.Equal(ExpectedJson, actualJson);
        }

        [Fact]
        public void CanSerializeUnknownValue()
        {
            const string ExpectedJson = @"{""ID"":1,""Test"":""unknown""}";

            var model = new Model() { ID = 1, Test = "unknown" };
            string actualJson = JsonConvert.SerializeObject(model);

            Assert.Equal(ExpectedJson, actualJson);
        }

        [Fact]
        public void CanSerializeNullValue()
        {
            const string ExpectedJson = @"{""ID"":1,""Test"":null}";

            var model = new Model() { ID = 1, Test = null };
            string actualJson = JsonConvert.SerializeObject(model);

            Assert.Equal(ExpectedJson, actualJson);
        }

        [Fact]
        public void CanDeserializeKnownValue()
        {
            const string Json = @"{""ID"":2,""Test"":""Two""}";

            var expectedModel = new Model() { ID = 2, Test = TestEnum.Two };
            Model actualModel = JsonConvert.DeserializeObject<Model>(Json);

            Assert.Equal(expectedModel.ID, actualModel.ID);
            Assert.Equal(expectedModel.Test, actualModel.Test);
        }

        [Fact]
        public void CanDeserializeUnknownValue()
        {
            const string Json = @"{""ID"":0,""Test"":""unknown""}";

            var expectedModel = new Model() { ID = 0, Test = "unknown" };
            Model actualModel = JsonConvert.DeserializeObject<Model>(Json);

            Assert.Equal(expectedModel.ID, actualModel.ID);
            Assert.Equal(expectedModel.Test, actualModel.Test);
        }

        [Fact]
        public void CanDeserializeNullValue()
        {
            const string Json = @"{""ID"":0,""Test"":null}";

            var expectedModel = new Model() { ID = 0, Test = null };
            Model actualModel = JsonConvert.DeserializeObject<Model>(Json);

            Assert.Equal(expectedModel.ID, actualModel.ID);
            Assert.Null(actualModel.Test);
        }

        private class Model
        {
            public int ID { get; set; }

            public TestEnum? Test { get; set; }
        }

        [JsonConverter(typeof(ExtensibleEnumConverter<TestEnum>))]
        private struct TestEnum : IEquatable<TestEnum>
        {
            private readonly string _value;

            public static readonly TestEnum One = new TestEnum("One");

            public static readonly TestEnum Two = new TestEnum("Two");

            public static readonly TestEnum Three = new TestEnum("Three");

            private TestEnum(string name)
            {
                Throw.IfArgumentNull(name, nameof(name));
                _value = name;
            }

            public static implicit operator TestEnum(string name) => new TestEnum(name);

            public static bool operator ==(TestEnum lhs, TestEnum rhs) => Equals(lhs, rhs);

            public static bool operator !=(TestEnum lhs, TestEnum rhs) => !Equals(lhs, rhs);

            public bool Equals(TestEnum other) => _value == other._value;

            public override bool Equals(object obj) => obj is TestEnum ? Equals((TestEnum)obj) : false;

            public override int GetHashCode() => _value.GetHashCode();

            public override string ToString() => _value;
        }
    }
}
