// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Encode.Numeric;
using Encode.Numeric._Property;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Encode.Numeric
{
    public class EncodeNumericTests : SpectorTestBase
    {
        [SpectorTest]
        public Task EncodeNumericPropertySafeintAsString() => Test(async (host) =>
        {
            var response = await new NumericClient(host, null).GetPropertyClient().SafeintAsStringAsync(new SafeintAsStringProperty(10000000000));
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Value, Is.EqualTo(10000000000));
            });
        });

        [SpectorTest]
        public Task EncodeNumericPropertyUint32AsStringOptional() => Test(async (host) =>
        {
            var response = await new NumericClient(host, null).GetPropertyClient().Uint32AsStringOptionalAsync(new Uint32AsStringProperty()
            {
                Value = "1"
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Value, Is.EqualTo("1"));
            });
        });

        [SpectorTest]
        public Task EncodeNumericPropertyUint8AsString() => Test(async (host) =>
        {
            var response = await new NumericClient(host, null).GetPropertyClient().Uint8AsStringAsync(new Uint8AsStringProperty(255));
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Value, Is.EqualTo(255));
            });
        });
    }
}
