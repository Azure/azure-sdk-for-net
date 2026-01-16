// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using _Type.Scalar;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Scalar
{
    public class ScalarTests : SpectorTestBase
    {
        [SpectorTest]
        public Task StringGet() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetStringClient().GetAsync();
            Assert.That(response.Value, Is.EqualTo("test"));
        });
        [SpectorTest]
        public Task StringPut() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetStringClient().PutAsync("test");
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task BooleanGet() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetBooleanClient().GetAsync();
            Assert.That(response.Value, Is.EqualTo(true));
        });
        [SpectorTest]
        public Task BooleanPut() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetBooleanClient().PutAsync(true);
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task UnknownGet() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetUnknownClient().GetAsync();
            Assert.That(response.Value.ToObjectFromJson<string>(), Is.EqualTo("test"));
        });
        [SpectorTest]
        public Task UnknownPut() => Test(async (host) =>
        {
            var body = BinaryData.FromString("\"test\"");
            var response = await new ScalarClient(host, null).GetUnknownClient().PutAsync(body);
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task DecimalTypeResponseBody() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetDecimalTypeClient().ResponseBodyAsync();
            Assert.That(response.Value, Is.EqualTo(0.33333m));
        });
        [SpectorTest]
        public Task DecimalTypeRequestBody() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetDecimalTypeClient().RequestBodyAsync(0.33333m);
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task DecimalTypeRequestParameter() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetDecimalTypeClient().RequestParameterAsync(0.33333m);
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task Decimal128TypeResponseBody() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetDecimal128TypeClient().ResponseBodyAsync();
            Assert.That(response.Value, Is.EqualTo(0.33333m));
        });
        [SpectorTest]
        public Task Decimal128TypeRequestBody() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetDecimal128TypeClient().RequestBodyAsync(0.33333m);
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task Decimal128TypeRequestParameter() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetDecimal128TypeClient().RequestParameterAsync(0.33333m);
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task DecimalVerifyPrepareVerify() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetDecimalVerifyClient().PrepareVerifyAsync();
            Assert.That(response.Value[0], Is.EqualTo(0.1m));
            Assert.That(response.Value[1], Is.EqualTo(0.1m));
            Assert.That(response.Value[2], Is.EqualTo(0.1m));
        });
        [SpectorTest]
        public Task DecimalVerifyVerify() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetDecimalVerifyClient().VerifyAsync(0.3m);
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task Decimal128VerifyPrepareVerify() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetDecimal128VerifyClient().PrepareVerifyAsync();
            Assert.That(response.Value[0], Is.EqualTo(0.1m));
            Assert.That(response.Value[1], Is.EqualTo(0.1m));
            Assert.That(response.Value[2], Is.EqualTo(0.1m));
        });
        [SpectorTest]
        public Task Decimal128VerifyVerify() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetDecimal128VerifyClient().VerifyAsync(0.3m);
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}
