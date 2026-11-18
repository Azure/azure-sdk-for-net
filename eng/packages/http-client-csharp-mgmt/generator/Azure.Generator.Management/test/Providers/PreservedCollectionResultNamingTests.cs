// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class PreservedCollectionResultNamingTests
    {
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void CustomizedHelperIdentityIsReservedBeforeEitherCreationOrder(bool isAsync, bool customizedFirst)
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
                    [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("ChildrenGetCustomized{{suffix}}CollectionResultOfT")]
                    internal partial class ChildData{{suffix}}CollectionResultOfT
                    {
                        internal string CustomMember => "preserved";
                    }
                }
                """;
            var (plugin, client, methods, itemType) = CreateScenario("ChildData", source);
            var (ordinary, customized) = CreateHelpers(plugin, client, methods, itemType, isAsync, customizedFirst);

            Assert.That(ordinary.Name, Is.Not.EqualTo(customized.Name), "Distinct operations must not emit duplicate helper types");
            Assert.That(ordinary.RelativeFilePath, Is.Not.EqualTo(customized.RelativeFilePath));
            Assert.That(ordinary.CustomCodeView, Is.Null, "The ordinary helper must not acquire the other operation's partial customization");
            Assert.That(ordinary.Name, Is.EqualTo($"ChildData{suffix}0CollectionResultOfT"));
            Assert.That(customized.Name, Is.EqualTo($"ChildData{suffix}CollectionResultOfT"));
            Assert.That(customized.CustomCodeView!.Properties.Select(p => p.Name), Does.Contain("CustomMember"));

            // Rebuilding either operation must retain its allocated or preserved identity.
            var rebuilt = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);
            Assert.That(rebuilt.Name, Is.EqualTo(ordinary.Name));
            Assert.That(rebuilt.CustomCodeView, Is.Null);
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void HandwrittenHelperIdentityIsReservedBeforeEitherCreationOrder(bool isAsync, bool referencedFirst)
        {
            var suffix = isAsync ? "Async" : "";
            var expectedName = $"ChildrenGetCustomized{suffix}CollectionResultOfT";
            var source = $$"""
                namespace Samples
                {
                    internal class PagingCustomization
                    {
                        internal object Create() => new {{expectedName}}(null, null, null);
                    }
                }
                """;
            var (plugin, client, methods, itemType) = CreateScenario("ChildrenGetCustomized", source);
            var (ordinary, referenced) = CreateHelpers(plugin, client, methods, itemType, isAsync, referencedFirst);

            Assert.That(ordinary.Name, Is.Not.EqualTo(referenced.Name), "Distinct operations must not emit the same helper file");
            Assert.That(ordinary.RelativeFilePath, Is.Not.EqualTo(referenced.RelativeFilePath));
            Assert.That(ordinary.Name, Is.EqualTo($"ChildrenGetCustomized{suffix}0CollectionResultOfT"));
            Assert.That(referenced.Name, Is.EqualTo(expectedName));
            Assert.That(referenced.CustomCodeView, Is.Null);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ArrayAllocatorCannotClaimFutureCustomizedHelperIdentity(bool isAsync)
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
                    [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("ChildrenGetCustomized{{suffix}}CollectionResultOfT")]
                    internal partial class ChildData{{suffix}}CollectionResultOfT { }
                }
                """;
            var (plugin, client, methods, itemType) = CreateScenario("ChildData", source);

            // Array-response helpers use this same allocator, before any regular helper is created.
            var allocated = plugin.OutputLibrary.GetUniqueCollectionResultName($"ChildData{suffix}");
            var customized = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[1], itemType, isAsync);

            Assert.That(allocated, Is.EqualTo($"ChildData{suffix}0"));
            Assert.That(customized.Name, Is.EqualTo($"ChildData{suffix}CollectionResultOfT"));
        }

        private static (TypeProvider Ordinary, TypeProvider Preserved) CreateHelpers(
            ManagementClientGenerator plugin, ClientProvider client, InputPagingServiceMethod[] methods,
            CSharpType itemType, bool isAsync, bool preservedFirst)
        {
            var firstIndex = preservedFirst ? 1 : 0;
            var first = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[firstIndex], itemType, isAsync);
            var second = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[1 - firstIndex], itemType, isAsync);
            return preservedFirst ? (second, first) : (first, second);
        }

        private static (ManagementClientGenerator Plugin, ClientProvider Client, InputPagingServiceMethod[] Methods, CSharpType ItemType) CreateScenario(string itemName, string source)
        {
            var item = InputFactory.Model(itemName, usage: InputModelTypeUsage.Output);
            var page = InputFactory.Model("ChildList", usage: InputModelTypeUsage.Output, properties:
            [
                InputFactory.Property("value", InputFactory.Array(item)),
                InputFactory.Property("nextLink", InputPrimitiveType.String)
            ]);
            var methods = new[] { "ListOrdinary", "ListCustomized" }.Select(name =>
            {
                var operation = InputFactory.Operation(name, responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: page)]);
                return InputFactory.PagingServiceMethod(name, operation,
                    pagingMetadata: InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body));
            }).ToArray();
            var inputClient = InputFactory.Client("Children", methods: methods);
            var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient], inputModels: () => [item, page], customizationSources: [source]).Object;
            return (plugin, plugin.TypeFactory.CreateClient(inputClient)!, methods, plugin.TypeFactory.CreateCSharpType(item)!);
        }
    }
}
