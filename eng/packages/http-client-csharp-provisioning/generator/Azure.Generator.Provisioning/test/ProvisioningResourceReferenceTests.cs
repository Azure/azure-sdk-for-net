// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Providers;
using Azure.Generator.Provisioning.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System.Linq;

namespace Azure.Generator.Provisioning.Tests
{
    public class ProvisioningResourceReferenceTests
    {
        [Test]
        public void HelperUsesLibraryNamespaceAndClearsNullReferences()
        {
            ProvisioningMockHelpers.LoadMockPlugin(primaryNamespace: "Azure.Provisioning.Sample");
            var provider = ProvisioningGenerator.Instance.OutputLibrary.ResourceReference;

            Assert.That(provider, Is.SameAs(ProvisioningGenerator.Instance.OutputLibrary.ResourceReference));
            Assert.That(provider.Type.Namespace, Is.EqualTo("Azure.Provisioning.Sample"));
            Assert.That(provider.RelativeFilePath,
                Is.EqualTo(System.IO.Path.Combine("src", "Generated", "Internal", "ProvisioningResourceReference.cs")));
            Assert.That(provider.DeclarationModifiers.HasFlag(
                TypeSignatureModifiers.Internal | TypeSignatureModifiers.Sealed | TypeSignatureModifiers.Class), Is.True);
            Assert.That(provider.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public), Is.False);

            string generated = new TypeProviderWriter(provider).Write().Content;
            Assert.That(generated, Does.Contain("where T : global::Azure.Provisioning.Primitives.ProvisionableResource"));
            Assert.That(generated, Does.Contain("_reference.ClearValue();"));
            Assert.That(generated, Does.Contain("new global::Azure.Provisioning.Expressions.IdentifierExpression(value.BicepIdentifier)"));
            Assert.That(generated, Does.Not.Contain("BicepSyntax.Null()"));
        }

        [Test]
        public void LibraryWithoutResourceReferencesDoesNotEmitHelper()
        {
            ProvisioningMockHelpers.LoadMockPlugin(armProviderSchema: () => new ArmProviderSchema([], []));

            Assert.That(ProvisioningGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<ProvisioningResourceReferenceProvider>(), Is.Empty);
        }
    }
}
