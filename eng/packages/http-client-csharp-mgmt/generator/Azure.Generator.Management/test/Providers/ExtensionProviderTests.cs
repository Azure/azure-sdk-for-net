// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
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
    }
}
