// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using Azure;
using Azure.Core;
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

            Assert.That(resource, Is.Not.Null);
            var collection = resource?.ResourceCollection;
            Assert.That(collection, Is.Not.Null);

            // find the extension
            var extension = _plugin.OutputLibrary.TypeProviders
                .OfType<ExtensionProvider>().FirstOrDefault();
            Assert.That(extension, Is.Not.Null);

            // validate the get collection method
            var method = extension!.Methods.FirstOrDefault(m => m.Signature.Name == $"Get{resource?.ResourceName.Pluralize()}")!;

            Assert.That(method, Is.Not.Null);
            Assert.That(method.Signature.ReturnType, Is.EqualTo(collection!.Type));
        }

        [TestCase]
        public void Verify_GetResourceByIdMethods()
        {
            // find the resource
            var resource = _plugin.OutputLibrary.TypeProviders
                .OfType<ResourceClientProvider>().FirstOrDefault();
            Assert.That(resource, Is.Not.Null);
            var collection = resource?.ResourceCollection;
            Assert.That(collection, Is.Not.Null);
            // find the extension
            var extension = _plugin.OutputLibrary.TypeProviders
                .OfType<ExtensionProvider>().FirstOrDefault();
            Assert.That(extension, Is.Not.Null);
            // validate the get by id methods
            var getMethod = extension!.Methods.FirstOrDefault(m => m.Signature.Name == $"Get{resource?.Name}");
            Assert.That(getMethod, Is.Not.Null);
            Assert.That(getMethod!.Signature.ReturnType, Is.EqualTo(resource!.Type));
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
        public void Verify_MockingCrefQualifiesModelParameters()
        {
            var model = InputFactory.Model("ResponseType", clientNamespace: "Samples.Models");
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var modelType = plugin.Object.TypeFactory.CreateCSharpType(model);
            Assert.That(modelType, Is.Not.Null);

            Assert.That(modelType!.GetXmlDocTypeName(), Is.EqualTo("Samples.Models.ResponseType"));
        }

        [TestCase]
        public void Verify_ExtensionScopedResourceListMethod_GeneratedOnArmClient()
        {
            var (client, models) = InputResourceData.ClientWithExtensionScopedResourceList();
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [client]);

            var mockableArmClient = plugin.Object.OutputLibrary.TypeProviders
                .OfType<MockableResourceProvider>()
                .SingleOrDefault(p => p.ArmCoreType.Equals(typeof(ArmClient)));
            Assert.That(mockableArmClient, Is.Not.Null);

            var mockableMethod = mockableArmClient!.Methods.SingleOrDefault(m => m.Signature.Name == "GetEvents");
            Assert.That(mockableMethod, Is.Not.Null);
            var returnType = mockableMethod!.Signature.ReturnType;
            Assert.That(returnType, Is.Not.Null);
            Assert.That(returnType!.FrameworkType, Is.EqualTo(typeof(Pageable<>)));
            Assert.That(returnType.Arguments[0].Name, Is.EqualTo("EventResource"));
            Assert.That(mockableMethod.Signature.Parameters[0].Name, Is.EqualTo("scope"));
            Assert.That(mockableMethod.Signature.Parameters[0].Type.Name, Is.EqualTo(nameof(ResourceIdentifier)));

            var extension = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ExtensionProvider>()
                .SingleOrDefault();
            Assert.That(extension, Is.Not.Null);

            var extensionMethod = extension!.Methods.FirstOrDefault(m =>
                m.Signature.Name == "GetEvents" &&
                m.Signature.Parameters[0].Type.Name == nameof(ArmClient));
            Assert.That(extensionMethod, Is.Not.Null);
            Assert.That(extensionMethod!.Signature.Parameters[0].Type.Name, Is.EqualTo(nameof(ArmClient)));
            Assert.That(extensionMethod.Signature.Parameters[1].Name, Is.EqualTo("scope"));
            Assert.That(extensionMethod.Signature.Parameters[1].Type.Name, Is.EqualTo(nameof(ResourceIdentifier)));
        }
    }
}
