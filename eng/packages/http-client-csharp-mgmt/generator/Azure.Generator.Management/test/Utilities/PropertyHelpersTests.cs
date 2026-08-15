// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    internal class PropertyHelpersTests
    {
        [Test]
        public void GetCombinedPropertyNameInsertsOuterNameAfterIsPrefix()
        {
            ManagementMockHelpers.LoadMockPlugin();
            var enclosingType = new TestTypeProvider();
            var innerProperty = new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(bool), "IsEnabled", new AutoPropertyBody(true), enclosingType);
            var outerProperty = new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(object), "Bar", new AutoPropertyBody(true), enclosingType);

            var result = PropertyHelpers.GetCombinedPropertyName(innerProperty, outerProperty);

            Assert.That(result, Is.EqualTo("IsBarEnabled"));
        }

        [Test]
        public void GetCombinedPropertyNameDoesNotTreatIsolationAsIsPrefix()
        {
            ManagementMockHelpers.LoadMockPlugin();
            var enclosingType = new TestTypeProvider();
            var innerProperty = new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(string), "IsolationMode", new AutoPropertyBody(true), enclosingType);
            var outerProperty = new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(object), "Network", new AutoPropertyBody(true), enclosingType);

            var result = PropertyHelpers.GetCombinedPropertyName(innerProperty, outerProperty);

            Assert.That(result, Is.EqualTo("NetworkIsolationMode"));
        }

        private class TestTypeProvider : TypeProvider
        {
            protected override string BuildName() => nameof(TestTypeProvider);

            protected override string BuildRelativeFilePath() => $"{Name}.cs";
        }
    }
}
