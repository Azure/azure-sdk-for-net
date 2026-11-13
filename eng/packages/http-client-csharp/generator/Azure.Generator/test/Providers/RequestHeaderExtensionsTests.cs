// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Tests.Providers
{
    public class RequestHeaderExtensionsTests
    {
        [Test]
        public void AddsSetDelimitedExtensionMethods()
        {
            MockHelpers.LoadMockGenerator();
            var uriBuilderDefinition = new RequestHeaderExtensionsDefinition();

            var writer = new TypeProviderWriter(uriBuilderDefinition);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }
    }
}