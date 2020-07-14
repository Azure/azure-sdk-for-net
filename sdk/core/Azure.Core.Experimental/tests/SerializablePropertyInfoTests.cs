// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class SerializablePropertyInfoTests
    {
        [TestCaseSource(nameof(GetTypes), new object[] { false })]
        public bool IsCollection(Type propertyType)
        {
            TestSerializablePropertyInfo sut = new TestSerializablePropertyInfo(propertyType);
            return sut.IsCollection;
        }

        [TestCaseSource(nameof(GetTypes), new object[] { true })]
        public Type CollectionElementType(Type propertyType)
        {
            TestSerializablePropertyInfo sut = new TestSerializablePropertyInfo(propertyType);
            return sut.CollectionElementType;
        }

        private static IEnumerable<TestCaseData> GetTypes(bool expectsType)
        {
            TestCaseData Expects(TestCaseData data, Type expectedType) =>
                expectsType ? data.Returns(expectedType) : data.Returns(expectedType != null);

            return new[]
            {
                Expects(new TestCaseData(typeof(string[])), typeof(string)),
                Expects(new TestCaseData(typeof(IList<string>)), typeof(string)),
                Expects(new TestCaseData(typeof(List<string>)), typeof(string)),
                Expects(new TestCaseData(typeof(IDictionary<string, Type>)), typeof(KeyValuePair<string, Type>)),
                Expects(new TestCaseData(typeof(Dictionary<string, Type>)), typeof(KeyValuePair<string, Type>)),
                Expects(new TestCaseData(typeof(ArrayList)), typeof(object)),
                Expects(new TestCaseData(typeof(string)), null),
            };
        }

        private class TestSerializablePropertyInfo : SerializablePropertyInfo
        {
            public TestSerializablePropertyInfo(Type propertyType)
            {
                PropertyType = propertyType;
            }

            public override Type PropertyType { get; }

            public override string PropertyName => "Test";

            public override string SerializedName => "test";
        }
    }
}
