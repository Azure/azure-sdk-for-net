// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager;
using Humanizer;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    public class ExtensionProviderTests
    {
        private ManagementClientGenerator _plugin;

        public ExtensionProviderTests()
        {
            _plugin = null!;
        }

        [SetUp]
        public void Setup()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [client]);

            _plugin = plugin.Object;
        }

        [TestCase]
        public void Verify_GetResourceCollectionMethod()
        {
            // find the resource
            var resource = _plugin.OutputLibrary.TypeProviders
                .OfType<ResourceClientProvider>().FirstOrDefault();

            Assert.IsNotNull(resource);
            var collection = resource?.ResourceCollection;
            Assert.IsNotNull(collection);

            // find the extension
            var extension = _plugin.OutputLibrary.TypeProviders
                .OfType<ExtensionProvider>().FirstOrDefault();
            Assert.IsNotNull(extension);

            // validate the get collection method
            var method = extension!.Methods.FirstOrDefault(m => m.Signature.Name == $"Get{resource?.ResourceName.Pluralize()}")!;

            Assert.IsNotNull(method);
            Assert.AreEqual(collection!.Type, method.Signature.ReturnType);
        }

        [TestCase]
        public void Verify_GetResourceByIdMethods()
        {
            // find the resource
            var resource = _plugin.OutputLibrary.TypeProviders
                .OfType<ResourceClientProvider>().FirstOrDefault();
            Assert.IsNotNull(resource);
            var collection = resource?.ResourceCollection;
            Assert.IsNotNull(collection);
            // find the extension
            var extension = _plugin.OutputLibrary.TypeProviders
                .OfType<ExtensionProvider>().FirstOrDefault();
            Assert.IsNotNull(extension);
            // validate the get by id methods
            var getMethod = extension!.Methods.FirstOrDefault(m => m.Signature.Name == $"Get{resource?.Name}");
            Assert.IsNotNull(getMethod);
            Assert.AreEqual(resource!.Type, getMethod!.Signature.ReturnType);
        }

        [TestCase]
        public void Verify_MockableResourcesWithNoMethods_AreNotGenerated()
        {
            // Verify that all MockableResourceProvider instances in the output have at least one method
            // This ensures that mockable resources without methods are filtered out
            var mockableResources = _plugin.OutputLibrary.TypeProviders
                .OfType<MockableResourceProvider>().ToList();

            // With resources defined, there should be mockable resources
            Assert.That(mockableResources.Count, Is.GreaterThan(0), "There should be at least one mockable resource when resources are defined");

            // All mockable resources in the output should have at least one method
            foreach (var mockableResource in mockableResources)
            {
                Assert.That(mockableResource.Methods.Count, Is.GreaterThan(0),
                    $"MockableResourceProvider '{mockableResource.Name}' should have at least one method to be included in the output.");
            }
        }

        [TestCase]
        public void Verify_ScopeUrlOperation_GeneratesArmClientExtension()
        {
            // Arrange: load a client that contains only a scope URL non-resource method
            // (path starts with /{resourceId}/providers/..., operationScope = Extension)
            var (client, models) = InputResourceData.ClientWithScopeUrlOperation();
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [client]);

            // Find the extension provider
            var extension = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ExtensionProvider>().FirstOrDefault();
            Assert.IsNotNull(extension, "ExtensionProvider should be generated");

            // The scope URL operation is named "listBackupInstances".
            // Find any non-private method from the extension provider that relates to the scope URL operation.
            var publicExtensionMethods = extension!.Methods
                .Where(m => !m.Signature.Modifiers.HasFlag(Microsoft.TypeSpec.Generator.Primitives.MethodSignatureModifiers.Private))
                .ToList();

            // There must be at least one public extension method for the scope URL non-resource operation.
            Assert.IsNotEmpty(publicExtensionMethods, $"Extension provider should have public methods. All methods: {string.Join(", ", extension.Methods.Select(m => m.Signature.Name))}");

            // For scope URL (Extension-scope) non-resource methods, ALL public extension methods
            // must have ArmClient as the 'this' (first) parameter - NOT TenantResource or any other type.
            foreach (var m in publicExtensionMethods)
            {
                var thisParameter = m.Signature.Parameters.FirstOrDefault();
                Assert.IsNotNull(thisParameter, $"Extension method '{m.Signature.Name}' should have at least one parameter");
                Assert.AreEqual(typeof(ArmClient), thisParameter!.Type.FrameworkType,
                    $"Extension method '{m.Signature.Name}' must target ArmClient, not TenantResource or any other type (scope URL operation fix - issue #56628).");
            }
        }
    }
}
