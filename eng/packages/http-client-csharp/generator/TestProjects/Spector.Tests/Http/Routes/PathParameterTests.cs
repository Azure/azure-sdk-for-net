// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Routes;

namespace TestProjects.Spector.Tests.Http.Routes
{
    public class PathParameterTests : SpectorTestBase
    {
        [SpectorTest]
        public Task InInterface() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetInInterfaceClient().FixedAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Fixed() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).FixedAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PathAnnotationOnly() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient().AnnotationOnlyAsync("a");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PathExplicit() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient().ExplicitAsync("a");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PathTemplateOnly() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient().TemplateOnlyAsync("a");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ReservedAnnotation() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersReservedExpansionClient()
                .AnnotationAsync("foo/bar baz");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ReservedTemplate() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersReservedExpansionClient()
                .TemplateAsync("foo/bar baz");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Explicit() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient().ExplicitAsync("a");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionExplodeArray() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionExplodeClient()
                .ArrayAsync(["a, b"]);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionArray() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionStandardClient()
                .ArrayAsync(["a", "b"]);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionExplodePrimitive() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionExplodeClient()
                .PrimitiveAsync("a");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionPrimitive() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionExplodeClient()
                .PrimitiveAsync("a");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionExplodeRecord() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionExplodeClient()
                .RecordAsync(new Dictionary<string, int> {{"a", 1}, {"b", 2}});
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionRecord() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionStandardClient()
                .RecordAsync(new Dictionary<string, int> {{"a", 1}, {"b", 2}});
            Assert.AreEqual(204, response.Status);
        });
    }
}