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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Fixed() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).FixedAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task PathAnnotationOnly() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient().AnnotationOnlyAsync("a");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task PathExplicit() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient().ExplicitAsync("a");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task PathTemplateOnly() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient().TemplateOnlyAsync("a");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ReservedAnnotation() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersReservedExpansionClient()
                .AnnotationAsync("foo/bar baz");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ReservedTemplate() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersReservedExpansionClient()
                .TemplateAsync("foo/bar baz");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Explicit() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient().ExplicitAsync("a");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionExplodeArray() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionExplodeClient()
                .ArrayAsync(["a, b"]);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionArray() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionStandardClient()
                .ArrayAsync(["a", "b"]);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionExplodePrimitive() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionExplodeClient()
                .PrimitiveAsync("a");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionPrimitive() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionExplodeClient()
                .PrimitiveAsync("a");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionExplodeRecord() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionExplodeClient()
                .RecordAsync(new Dictionary<string, int> {{"a", 1}, {"b", 2}});
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/5561")]
        public Task LabelExpansionRecord() => Test(async (host) =>
        {
            var response = await new RoutesClient(host, null).GetPathParametersClient()
                .GetPathParametersLabelExpansionClient()
                .GetPathParametersLabelExpansionStandardClient()
                .RecordAsync(new Dictionary<string, int> {{"a", 1}, {"b", 2}});
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}