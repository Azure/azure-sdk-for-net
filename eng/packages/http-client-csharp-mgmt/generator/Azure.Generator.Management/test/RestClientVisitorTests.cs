// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests
{
    internal class RestClientVisitorTests
    {
        [Test]
        public void RestClientInitializesServicePackageUserAgent()
        {
            var client = InputFactory.Client(
                "TestClient",
                crossLanguageDefinitionId: "Samples.TestClient",
                decorators: []);
            var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client]);
            var provider = plugin.Object.TypeFactory.CreateClient(client)!;

            var visited = new TestRestClientVisitor().InvokeVisitType(provider)!;
            var code = new TypeProviderWriter(visited).Write().Content;

            Assert.That(code, Does.Contain("private readonly global::Azure.Core.TelemetryDetails _userAgent;"));
            Assert.That(code, Does.Contain("string applicationId"));
            Assert.That(code, Does.Contain("_userAgent = new global::Azure.Core.TelemetryDetails(typeof(global::Samples.TestClient).Assembly, applicationId);"));
        }

        private sealed class TestRestClientVisitor : RestClientVisitor
        {
            public TypeProvider? InvokeVisitType(TypeProvider type)
            {
                return base.VisitType(type);
            }
        }
    }
}
