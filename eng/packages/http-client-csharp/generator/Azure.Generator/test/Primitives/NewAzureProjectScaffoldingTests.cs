// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Azure.Generator.Tests.Primitives
{
    public class NewAzureProjectScaffoldingTests
    {
        private static readonly string[] OperationSharedFiles =
        [
            "RawRequestUriBuilder.cs",
            "TypeFormatters.cs",
            "RequestHeaderExtensions.cs",
            "AppContextSwitchHelper.cs",
            "ClientDiagnostics.cs",
            "DiagnosticScopeFactory.cs",
            "DiagnosticScope.cs",
            "HttpMessageSanitizer.cs",
            "TrimmingAttribute.cs"
        ];

        private static readonly string[] LongRunningSharedFiles =
        [
            "AsyncLockWithValue.cs",
            "FixedDelayWithNoJitterStrategy.cs",
            "HttpPipelineExtensions.cs",
            "IOperationSource.cs",
            "NextLinkOperationImplementation.cs",
            "OperationFinalStateVia.cs",
            "OperationInternal.cs",
            "OperationInternalBase.cs",
            "OperationInternalOfT.cs",
            "OperationPoller.cs",
            "ProtocolOperation.cs",
            "ProtocolOperationHelpers.cs",
            "SequentialDelayStrategy.cs",
            "TaskExtensions.cs",
            "VoidValue.cs"
        ];

        [SetUp]
        public void SetUp()
        {
            MockHelpers.LoadMockGenerator();
        }

        [Test]
        public void SourceProjectContainsAzureMetadataAndDependencies()
        {
            var project = GetSourceProject();
            var properties = project.Root!.Element("PropertyGroup")!;

            Assert.Multiple(() =>
            {
                Assert.That(project.Root.Attribute("Sdk")?.Value, Is.EqualTo("Microsoft.NET.Sdk"));
                Assert.That(properties.Element("AssemblyTitle")?.Value, Is.EqualTo("SDK Code Generation Samples"));
                Assert.That(properties.Element("Version")?.Value, Is.EqualTo("1.0.0-beta.1"));
                Assert.That(properties.Element("PackageTags")?.Value, Is.EqualTo("Samples"));
                Assert.That(properties.Element("GenerateDocumentationFile")?.Value, Is.EqualTo("true"));
                Assert.That(project.Descendants("PackageReference").Select(p => p.Attribute("Include")?.Value),
                    Is.EquivalentTo(new[] { "Azure.Core" }));
            });
        }

        [TestCase(false)]
        [TestCase(true)]
        public void EmptyProjectOnlyIncludesExperimentalAttribute(bool hasClient)
        {
            MockHelpers.LoadMockGenerator(clients: () => hasClient ? [InputFactory.Client("EmptyClient")] : []);

            AssertCompileIncludes("ExperimentalAttribute.cs");
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ApiKeyPolicyIsOnlyIncludedForApiKeyAuthentication(bool hasApiKey)
        {
            MockHelpers.LoadMockGenerator(apiKeyAuth: hasApiKey ? () => new InputApiKeyAuth("api-key", null) : null);

            AssertCompileIncludes(hasApiKey
                ? ["ExperimentalAttribute.cs", "AzureKeyCredentialPolicy.cs"]
                : ["ExperimentalAttribute.cs"]);
        }

        [TestCase("basic", false)]
        [TestCase("basic", true)]
        [TestCase("paging", false)]
        [TestCase("paging", true)]
        [TestCase("longRunning", false)]
        [TestCase("longRunning", true)]
        [TestCase("longRunningPaging", false)]
        [TestCase("longRunningPaging", true)]
        public void OperationsIncludeRequiredSharedSources(string kind, bool nested)
        {
            var operation = InputFactory.Operation("Get");
            InputServiceMethod method = kind switch
            {
                "paging" => InputFactory.PagingServiceMethod("Get", operation),
                "longRunning" => InputFactory.LongRunningServiceMethod("Get", operation),
                "longRunningPaging" => new InputLongRunningPagingServiceMethod(
                    "Get", "public", [], null, null, operation, [],
                    InputFactory.ServiceMethodResponse(null, null), null, false, true, true, string.Empty,
                    InputFactory.LongRunningServiceMetadata(1, InputFactory.OperationResponse(), null),
                    InputFactory.PagingMetadata([], null, null)),
                _ => InputFactory.BasicServiceMethod("Get", operation)
            };
            LoadClient(method, nested);

            AssertCompileIncludes([
                "ExperimentalAttribute.cs",
                .. OperationSharedFiles,
                .. kind.StartsWith("longRunning") ? LongRunningSharedFiles : []
            ]);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void StreamingResponseIncludesPipelineResponseAndClientModelDependency(bool nested)
        {
            var streamingType = new InputStreamingType("Events", string.Empty, InputPrimitiveType.String,
                ["text/event-stream"], "sse", null, null);
            var method = InputFactory.BasicServiceMethod("Get", InputFactory.Operation("Get"),
                response: InputFactory.ServiceMethodResponse(streamingType, null));
            LoadClient(method, nested);

            AssertCompileIncludes(["ExperimentalAttribute.cs", .. OperationSharedFiles, "AzurePipelineResponse.cs"]);
            Assert.That(GetSourceProject().Descendants("PackageReference").Select(p => p.Attribute("Include")?.Value),
                Is.EquivalentTo(new[] { "Azure.Core", "System.ClientModel" }));
        }

        [TestCase(204, false, true)]
        [TestCase(200, false, false)]
        [TestCase(404, true, false)]
        public void OptionalResponseBodyOnlyIncludesHelperForDistinctSuccessStatusCodes(
            int emptyStatusCode, bool isErrorResponse, bool expectedHelper)
        {
            var emptyResponse = new InputOperationResponse([emptyStatusCode], null, [], isErrorResponse, [], null);
            var operation = InputFactory.Operation("Get", responses:
            [
                InputFactory.OperationResponse([200], InputPrimitiveType.String),
                emptyResponse
            ]);
            LoadClient(InputFactory.BasicServiceMethod("Get", operation), nested: true);

            AssertCompileIncludes([
                "ExperimentalAttribute.cs",
                .. OperationSharedFiles,
                .. expectedHelper ? new[] { "NoValueResponseOfT.cs" } : []
            ]);
        }

        [Test]
        public void ResponsesWithoutBodiesDoNotIncludeOptionalResponseHelper()
        {
            var operation = InputFactory.Operation("Get", responses:
            [
                InputFactory.OperationResponse([200]),
                InputFactory.OperationResponse([204])
            ]);
            LoadClient(InputFactory.BasicServiceMethod("Get", operation));

            AssertCompileIncludes(["ExperimentalAttribute.cs", .. OperationSharedFiles]);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void MultipartIncludesTaskExtensionsExactlyOnce(bool hasLongRunningOperation)
        {
            var operation = InputFactory.Operation("Upload", requestMediaTypes: ["multipart/form-data"]);
            var multipartMethod = InputFactory.BasicServiceMethod("Upload", operation);
            List<InputServiceMethod> methods = [multipartMethod];
            if (hasLongRunningOperation)
            {
                methods.Add(InputFactory.LongRunningServiceMethod("Create", InputFactory.Operation("Create")));
            }
            MockHelpers.LoadMockGenerator(clients: () => [InputFactory.Client("TestClient", methods: methods)]);

            AssertCompileIncludes([
                "ExperimentalAttribute.cs",
                .. OperationSharedFiles,
                .. hasLongRunningOperation ? LongRunningSharedFiles : ["TaskExtensions.cs"]
            ]);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void XmlHelpersAreOnlyIncludedForXmlModels(bool hasXmlModel)
        {
            var model = InputFactory.Model("TestModel",
                usage: InputModelTypeUsage.Input | (hasXmlModel ? InputModelTypeUsage.Xml : InputModelTypeUsage.Json));
            MockHelpers.LoadMockGenerator(inputModels: () => [model]);

            AssertCompileIncludes(hasXmlModel
                ? ["ExperimentalAttribute.cs", "IXmlSerializable.cs", "XmlWriterContent.cs"]
                : ["ExperimentalAttribute.cs"]);
        }

        private static void LoadClient(InputServiceMethod method, bool nested = false)
        {
            var root = InputFactory.Client("RootClient", methods: nested ? [] : [method]);
            if (nested)
            {
                var child = InputFactory.Client("ChildClient", parent: root);
                InputFactory.Client("GrandchildClient", methods: [method], parent: child);
            }
            MockHelpers.LoadMockGenerator(clients: () => [root]);
        }

        private static XDocument GetSourceProject()
            => XDocument.Parse(new TestableNewAzureProjectScaffolding().SourceProjectFileContent());

        private static void AssertCompileIncludes(params string[] expectedFiles)
        {
            var includes = GetSourceProject().Descendants("Compile").ToArray();
            Assert.Multiple(() =>
            {
                Assert.That(includes.Select(i => i.Attribute("Include")?.Value),
                    Is.EquivalentTo(expectedFiles.Select(file => $"$(AzureCoreSharedSources){file}")));
                Assert.That(includes.Select(i => i.Attribute("LinkBase")?.Value), Is.All.EqualTo("Shared/Core"));
            });
        }

        private class TestableNewAzureProjectScaffolding : NewAzureProjectScaffolding
        {
            public string SourceProjectFileContent() => GetSourceProjectFileContent();
        }
    }
}
