// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Azure.Generator.Management.Visitors;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class CollectionResultNamingTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public void RegularPageableHelperHasCompactName(bool isAsync)
        {
            var (plugin, client, methods, itemType) = CreateScenario();
            var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);
            var expectedName = $"ManagementGroupChildResourceData{(isAsync ? "Async" : "")}CollectionResultOfT";

            Assert.That(helper.Name, Is.EqualTo(expectedName));
            Assert.That(helper.RelativeFilePath, Is.EqualTo(Path.Combine("src", "Generated", "CollectionResults", $"{expectedName}.cs")));
            Assert.That(helper.Constructors.Single().Signature.Type.Name, Is.EqualTo(expectedName));
            Assert.That(helper.Methods.Any(m => m.Signature.Name == (isAsync ? "GetNextResponseAsync" : "GetNextResponse")), Is.True);

            const string projectPath = "eng/packages/http-client-csharp-mgmt/generator/TestProjects/Spector/http/azure/resource-manager/management-group";
            Assert.That(49 + Path.Combine(projectPath, helper.RelativeFilePath).Length, Is.LessThanOrEqualTo(260));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void DistinctOperationsReturningSameItemHaveUniqueNames(bool isAsync)
        {
            var (plugin, client, methods, itemType) = CreateScenario(operationCount: 3);
            var suffix = isAsync ? "Async" : "";
            var helpers = methods.Select(method => plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, method, itemType, isAsync)).ToArray();

            Assert.That(helpers.Select(h => h.Name), Is.EqualTo(new[]
            {
                $"ManagementGroupChildResourceData{suffix}CollectionResultOfT",
                $"ManagementGroupChildResourceData{suffix}0CollectionResultOfT",
                $"ManagementGroupChildResourceData{suffix}1CollectionResultOfT"
            }));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void RebuiltHelperForSameOperationKeepsItsName(bool isAsync)
        {
            var (plugin, client, methods, itemType) = CreateScenario();
            var first = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);
            var rebuilt = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);

            Assert.That(rebuilt.Name, Is.EqualTo(first.Name));
            Assert.That(rebuilt.RelativeFilePath, Is.EqualTo(first.RelativeFilePath));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ItemModelRenameDoesNotAllocateAnotherHelperName(bool isAsync)
        {
            var (plugin, client, methods, itemType) = CreateScenario();
            var first = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);
            var expectedName = first.Name;
            plugin.TypeFactory.CSharpTypeMap[itemType]!.Update(name: "RenamedChildResourceData");

            var rebuilt = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);

            Assert.That(rebuilt.Name, Is.EqualTo(expectedName));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void RegularAndArrayHelpersShareCollisionTracking(bool isAsync)
        {
            var (plugin, client, methods, itemType) = CreateScenario();
            var baseName = $"ManagementGroupChildResourceData{(isAsync ? "Async" : "")}";
            plugin.OutputLibrary.GetUniqueCollectionResultName(baseName);

            var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);

            Assert.That(helper.Name, Is.EqualTo($"{baseName}0CollectionResultOfT"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SameOperationOnDifferentClientsHasUniqueHelpers(bool isAsync)
        {
            var (plugin, client, methods, itemType) = CreateScenario();
            var otherClient = plugin.TypeFactory.CreateClient(InputFactory.Client("OtherChildResources", methods: methods))!;
            var first = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);
            var second = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(otherClient, methods[0], itemType, isAsync);

            Assert.That(second.Name, Is.EqualTo($"ManagementGroupChildResourceData{(isAsync ? "Async" : "")}0CollectionResultOfT"));
            Assert.That(second.Name, Is.Not.EqualTo(first.Name));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void VisitorRestoresCompactNameAfterProviderReset(bool isAsync)
        {
            var (plugin, client, methods, itemType) = CreateScenario();
            var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);
            var expectedName = helper.Name;
            var expectedPath = helper.RelativeFilePath;

            // The upstream match-conditions visitor resets collection results after they are created.
            helper.Reset();
            new TestNameVisitor().Apply(helper);

            Assert.That(helper.Name, Is.EqualTo(expectedName));
            Assert.That(helper.RelativeFilePath, Is.EqualTo(expectedPath));
            Assert.That(helper.Constructors.Single().Signature.Type.Name, Is.EqualTo(expectedName));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void RenamedHelperDocumentationUsesAllocatedName(bool isAsync)
        {
            var (plugin, client, methods, itemType) = CreateScenario();
            var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);
            var expectedName = helper.Name;
            helper.Reset();
            // Simulate an upstream visitor inspecting methods before management renaming runs.
            _ = helper.Methods;
            new TestNameVisitor().Apply(helper);
            var asPages = helper.Methods.Single(m => m.Signature.Name == "AsPages");

            Assert.That(asPages.XmlDocs.Summary!.Lines.Single().ToString(), Does.Contain(expectedName));
            Assert.That(asPages.XmlDocs.Returns!.Lines.Single().ToString(), Does.Contain(expectedName));
        }

        private class TestNameVisitor : NameVisitor
        {
            public TypeProvider? Apply(TypeProvider type) => VisitType(type);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void NonGenericHelperHasCompactName(bool isAsync)
        {
            var (plugin, client, methods, _) = CreateScenario();
            var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], null, isAsync);

            Assert.That(helper.Name, Is.EqualTo($"BinaryData{(isAsync ? "Async" : "")}CollectionResult"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ExplicitHelperCustomizationIsPreserved(bool isAsync)
        {
            var suffix = isAsync ? "Async" : "";
            var source = $$"""
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    internal class CodeGenTypeAttribute : System.Attribute
                    {
                        public CodeGenTypeAttribute(string name) { }
                    }
                }
                namespace Samples
                {
                    [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("ManagementGroupChildResourcesGetByManagementGroup{{suffix}}CollectionResultOfT")]
                    internal partial class CustomizedChildren{{suffix}}CollectionResultOfT
                    {
                        internal string CustomMember => "preserved";
                    }
                }
                """;
            var (plugin, client, methods, itemType) = CreateScenario(customizationSources: [source]);
            var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);

            Assert.That(helper.Name, Is.EqualTo($"CustomizedChildren{suffix}CollectionResultOfT"));
            Assert.That(helper.CustomCodeView, Is.Not.Null);
            Assert.That(helper.CustomCodeView!.Properties.Select(p => p.Name), Does.Contain("CustomMember"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void HandwrittenHelperReferencesKeepExistingIdentity(bool isAsync)
        {
            var expectedName = $"ManagementGroupChildResourcesGetByManagementGroup{(isAsync ? "Async" : "")}CollectionResultOfT";
            var source = $$"""
                namespace Samples
                {
                    internal class PagingCustomization
                    {
                        internal object Create() => new {{expectedName}}(null, null, null);
                    }
                }
                """;
            var (plugin, client, methods, itemType) = CreateScenario(customizationSources: [source]);
            var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);

            Assert.That(helper.Name, Is.EqualTo(expectedName));
            Assert.That(helper.CustomCodeView, Is.Null, "A reference is not a partial type customization");
            Assert.That(helper.RelativeFilePath, Is.EqualTo(Path.Combine("src", "Generated", "CollectionResults", $"{expectedName}.cs")));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void CustomizedHelperNameParticipatesInCollisionTracking(bool isAsync)
        {
            var suffix = isAsync ? "Async" : "";
            var source = $$"""
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    internal class CodeGenTypeAttribute : System.Attribute
                    {
                        public CodeGenTypeAttribute(string name) { }
                    }
                }
                namespace Samples
                {
                    [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("ManagementGroupChildResourcesGetByManagementGroup{{suffix}}CollectionResultOfT")]
                    internal partial class ManagementGroupChildResourceData{{suffix}}CollectionResultOfT { }
                }
                """;
            var (plugin, client, methods, itemType) = CreateScenario(operationCount: 2, customizationSources: [source]);
            var customized = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);
            var generated = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[1], itemType, isAsync);

            Assert.That(customized.Name, Is.EqualTo($"ManagementGroupChildResourceData{suffix}CollectionResultOfT"));
            Assert.That(generated.Name, Is.EqualTo($"ManagementGroupChildResourceData{suffix}0CollectionResultOfT"));
        }

        private static (ManagementClientGenerator Plugin, ClientProvider Client, InputPagingServiceMethod[] Methods, CSharpType ItemType) CreateScenario(int operationCount = 1, IEnumerable<string>? customizationSources = null)
        {
            var item = InputFactory.Model("ManagementGroupChildResourceData", usage: InputModelTypeUsage.Output);
            var page = InputFactory.Model("ChildResourceListResult", usage: InputModelTypeUsage.Output, properties:
            [
                InputFactory.Property("value", InputFactory.Array(item)),
                InputFactory.Property("nextLink", InputPrimitiveType.String)
            ]);
            var methods = Enumerable.Range(0, operationCount).Select(index =>
            {
                var operation = InputFactory.Operation(
                    index == 0 ? "GetByManagementGroup" : $"GetByManagementGroup{index}",
                    responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: page)]);
                return InputFactory.PagingServiceMethod(operation.Name, operation,
                    pagingMetadata: InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body));
            }).ToArray();
            var inputClient = InputFactory.Client("ManagementGroupChildResources", methods: methods);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                clients: () => [inputClient], inputModels: () => [item, page], customizationSources: customizationSources).Object;
            var client = plugin.TypeFactory.CreateClient(inputClient)!;
            var itemType = plugin.TypeFactory.CreateCSharpType(item)!;
            return (plugin, client, methods, itemType);
        }
    }
}
