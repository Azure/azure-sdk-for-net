// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Type.Union;
using Azure.Generator.Tests.Common;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Union
{
    internal class UnionTests : SpectorTestBase
    {
        [SpectorTest]
        public Task GetStringsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringsOnlyClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prop, Is.EqualTo(GetResponseProp.B));
        });

        [SpectorTest]
        public Task SendStringsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringsOnlyClient().SendAsync(GetResponseProp.B);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetStringExtensibleOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringExtensibleClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prop, Is.EqualTo(new GetResponseProp1("custom")));
        });

        [SpectorTest]
        public Task SendStringExtensibleOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringExtensibleClient().SendAsync(new GetResponseProp1("custom"));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetStringExtensibleNamedOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringExtensibleNamedClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prop, Is.EqualTo(new StringExtensibleNamedUnion("custom")));
        });

        [SpectorTest]
        public Task SendStringExtensibleNamedOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringExtensibleNamedClient().SendAsync(new StringExtensibleNamedUnion("custom"));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetIntsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetIntsOnlyClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prop, Is.EqualTo(GetResponseProp2._2));
        });

        [SpectorTest]
        public Task SendIntsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetIntsOnlyClient().SendAsync(GetResponseProp2._2);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetFloatsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetFloatsOnlyClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prop, Is.EqualTo(GetResponseProp3._22));
        });

        [SpectorTest]
        public Task SendFloatsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetFloatsOnlyClient().SendAsync(GetResponseProp3._22);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetModelsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetModelsOnlyClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
        });

        [SpectorTest]
        public Task SendModelsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetModelsOnlyClient().SendAsync(ModelReaderWriter.Write(new Cat("test")));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetEnumsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetEnumsOnlyClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prop.Lr, Is.EqualTo(EnumsOnlyCasesLr.Right));
            Assert.That(response.Value.Prop.Ud, Is.EqualTo(EnumsOnlyCasesUd.Up));
        });

        [SpectorTest]
        public Task SendEnumsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetEnumsOnlyClient().SendAsync(new EnumsOnlyCases(EnumsOnlyCasesLr.Right, EnumsOnlyCasesUd.Up));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetStringAndArray() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringAndArrayClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            AssertEqual(BinaryData.FromObjectAsJson("test"), response.Value.Prop.String);
            AssertEqual(BinaryData.FromObjectAsJson(new List<string>() { "test1", "test2" }), response.Value.Prop.Array);
        });

        [SpectorTest]
        public Task SendStringAndArray() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringAndArrayClient().SendAsync(new StringAndArrayCases(BinaryData.FromObjectAsJson("test"),
                BinaryData.FromObjectAsJson(new List<string>() { "test1", "test2" })));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetMixedLiterals() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetMixedLiteralsClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            AssertEqual(BinaryData.FromObjectAsJson("a"), response.Value.Prop.StringLiteral);
            AssertEqual(BinaryData.FromObjectAsJson(2), response.Value.Prop.IntLiteral);
            AssertEqual(BinaryData.FromObjectAsJson(3.3), response.Value.Prop.FloatLiteral);
            AssertEqual(BinaryData.FromObjectAsJson(true), response.Value.Prop.BooleanLiteral);
        });

        [SpectorTest]
        public Task SendMixedLiteralsOnlyOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetMixedLiteralsClient().SendAsync(new MixedLiteralsCases(BinaryData.FromObjectAsJson("a"),
                BinaryData.FromObjectAsJson(2),
                BinaryData.FromObjectAsJson(3.3),
                BinaryData.FromObjectAsJson(true)));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetMixedTypes() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetMixedTypesClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            AssertEqual(BinaryData.FromObjectAsJson(new { name = "test" }), response.Value.Prop.Model);
            AssertEqual(BinaryData.FromObjectAsJson("a"), response.Value.Prop.Literal);
            AssertEqual(BinaryData.FromObjectAsJson(2), response.Value.Prop.Int);
            AssertEqual(BinaryData.FromObjectAsJson(true), response.Value.Prop.Boolean);
        });

        [SpectorTest]
        public Task SendMixedTypesOnlyOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetMixedTypesClient().SendAsync(new MixedTypesCases(
                ModelReaderWriter.Write(new Cat("test")),
                BinaryData.FromObjectAsJson("a"),
                BinaryData.FromObjectAsJson(2),
                BinaryData.FromObjectAsJson(true),
                new[]
                {
                    ModelReaderWriter.Write(new Cat("test")),
                    BinaryData.FromObjectAsJson("a"),
                    BinaryData.FromObjectAsJson(2),
                    BinaryData.FromObjectAsJson(true)
                }));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        private static void AssertEqual(BinaryData source, BinaryData target)
        {
            BinaryDataAssert.AreEqual(source, target);
        }
    }
}
