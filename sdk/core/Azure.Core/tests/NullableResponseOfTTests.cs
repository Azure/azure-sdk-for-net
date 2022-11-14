// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class NullableResponseOfTTests
    {
        [Test]
        public void ThrowsWhenValueIsAccessedWithNoValue()
        {
            var target = new TestValueResponse<string>(new MockResponse(200));
            Assert.Throws<Exception>(() => { var val = target.Value; });
            Assert.That(target.ToString(), Does.Contain("<null>"));
        }

        [Test]
        public void DoesNotThrowWhenValueIsAccessedWithValue()
        {
            var target = new TestValueResponse<string>(new MockResponse(200), "test");
            Assert.AreEqual("test", target.Value);
            Assert.That(target.ToString(), Does.Not.Contain("<null>"));
            Assert.That(target.ToString(), Does.Contain("test"));
        }

        private class TestValueResponse<T> : NullableResponse<T>
        {
            private readonly bool _hasValue;
            private readonly T _value;
            private readonly Response _response;

            public TestValueResponse(Response response, T value)
            {
                _response = response;
                _value = value;
                _hasValue = true;
            }

            public TestValueResponse(Response response)
            {
                _response = response;
                _value = default;
                _hasValue = false;
            }
            public override bool HasValue => _hasValue;

            public override T Value => _hasValue ? _value : throw new Exception("has no value");

            public override Response GetRawResponse() => _response;
        }
    }
}
