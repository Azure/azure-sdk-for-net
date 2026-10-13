// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System.Linq;

namespace Azure.Generator.Tests.Visitors
{
    public class ClientApiVersionVisitorTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SubClientFactoryUsesApiVersionDefault(bool cached)
        {
            var visitor = new TestClientApiVersionVisitor();
            var endpoint = InputFactory.EndpointParameter("endpoint", InputPrimitiveType.String, isRequired: true, isEndpoint: true);
            var parentVersion = InputFactory.MethodParameter("apiVersion", InputPrimitiveType.String, isApiVersion: true);
            var parent = InputFactory.Client("TestClient", parameters: [endpoint, parentVersion]);
            var childVersion = InputFactory.MethodParameter("apiVersion", InputPrimitiveType.String,
                isApiVersion: true, defaultValue: InputFactory.Constant.String("2022-10-01"));
            var tenant = InputFactory.PathParameter("tenant", InputPrimitiveType.String,
                isRequired: true, scope: InputParameterScope.Client);
            var child = InputFactory.Client("LegacyClient", parent: parent,
                parameters: cached ? [endpoint, childVersion] : [endpoint, childVersion, tenant]);
            MockHelpers.LoadMockGenerator(clients: () => [parent, child], visitors: () => [visitor]);
            var library = AzureClientGenerator.Instance.OutputLibrary;

            visitor.InvokeVisitLibrary(library);

            var provider = library.TypeProviders.OfType<ClientProvider>().Single(c => c.Name == "TestClient");
            var factory = provider.Methods.Single(m => m.Signature.Name == "GetLegacyClient");
            var body = factory.BodyStatements!.ToDisplayString();
            StringAssert.Contains("Pipeline, _endpoint, \"2022-10-01\"", body);
            StringAssert.DoesNotContain("_apiVersion", body);
            Assert.AreEqual(cached ? 0 : 1, factory.Signature.Parameters.Count);
            if (cached)
            {
                StringAssert.Contains("CompareExchange", body);
            }
            else
            {
                StringAssert.Contains("tenant", body);
                StringAssert.DoesNotContain("CompareExchange", body);
            }
        }

        [TestCase(true, null)]
        [TestCase(false, "2022-10-01")]
        public void SubClientWithoutApiVersionDefaultPreservesParentVersion(bool isApiVersion, string? defaultValue)
        {
            var visitor = new TestClientApiVersionVisitor();
            var endpoint = InputFactory.EndpointParameter("endpoint", InputPrimitiveType.String, isRequired: true, isEndpoint: true);
            var apiVersion = InputFactory.MethodParameter("apiVersion", InputPrimitiveType.String, isApiVersion: true);
            var parent = InputFactory.Client("TestClient", parameters: [endpoint, apiVersion]);
            var child = InputFactory.Client("ChildClient", parent: parent, parameters:
            [
                endpoint, apiVersion,
                InputFactory.MethodParameter("other", InputPrimitiveType.String, isApiVersion: isApiVersion,
                    defaultValue: defaultValue == null ? null : InputFactory.Constant.String(defaultValue))
            ]);
            MockHelpers.LoadMockGenerator(clients: () => [parent, child], visitors: () => [visitor]);
            var library = AzureClientGenerator.Instance.OutputLibrary;
            var provider = library.TypeProviders.OfType<ClientProvider>().Single(c => c.Name == "TestClient");
            var factory = provider.Methods.Single(m => m.Signature.Name == "GetChildClient");
            var originalBody = factory.BodyStatements!.ToDisplayString();

            visitor.InvokeVisitLibrary(library);

            Assert.AreEqual(originalBody, factory.BodyStatements!.ToDisplayString());
            StringAssert.Contains("_apiVersion", originalBody);
        }

        private class TestClientApiVersionVisitor : ClientApiVersionVisitor
        {
            public void InvokeVisitLibrary(OutputLibrary library) => VisitLibrary(library);
        }
    }
}
