// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ResponseTests
    {
        [Test]
        public void ValueIsAccessible()
        {
            var response = new Response<TestPayload>(response: null, new TestPayload("test_name"));
            TestPayload value = response.Value;

            Assert.IsNotNull(value);
            Assert.AreEqual("test_name", value.Name);
        }

        [Test]
        public void ValueObtainedFromCast()
        {
            var response = new Response<TestPayload>(response: null, new TestPayload("test_name"));
            TestPayload value = response;

            Assert.IsNotNull(value);
            Assert.AreEqual("test_name", value.Name);
        }

        [Test]
        public void ValueThrowsIfUnspecified()
        {
            var response = new Response<TestPayload>(response: null);
            Assert.Throws<ResourceModifiedException>(() => { TestPayload value = response.Value; });
        }

        [Test]
        public void ValueThrowsFromCastIfUnspecified()
        {
            var response = new Response<TestPayload>(response: null);
            Assert.Throws<ResourceModifiedException>(() => { TestPayload value = response; });
        }

        internal class TestPayload
        {
            public string Name { get; }

            public TestPayload(string name)
            {
                Name = name;
            }
        }
    }

}
