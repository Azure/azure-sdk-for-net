// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System;
using System.Linq;

namespace Azure.Generator.Mgmt.Tests
{
    /// <summary>
    /// Regression tests for https://github.com/Azure/azure-sdk-for-net/issues/61851.
    /// <para>
    /// <c>ScmModelProvider.BuildConstructors</c> mutates the cached <c>FullConstructor</c> in place for
    /// dynamic models: it appends the <c>_patch = patch;</c> assignment and the <c>SetPropagators</c> call,
    /// and prepends an SCME0001 suppression. Several <c>TypeProvider.Update</c> overloads clear the
    /// constructor cache without clearing <c>FullConstructor</c>, so a second build applied those mutations
    /// a second time and emitted duplicated statements and duplicated <c>#pragma</c> directives.
    /// </para>
    /// <para>
    /// Each test drives a single provider instance and asserts that rebuilding its constructors does not
    /// change the emitted content.
    /// </para>
    /// </summary>
    public class DynamicModelConstructorTests
    {
        private const string PatchAssignment = "_patch = patch;";
        private const string SetPropagatorsCall = "SetPropagators(PropagateSet, PropagateGet);";
        private const string PragmaDisable = "#pragma warning disable SCME0001";
        private const string PragmaRestore = "#pragma warning restore SCME0001";

        private static InputModelType LoadDynamicModel()
        {
            // SetPropagators is only emitted when the model has at least one property whose type is
            // itself a dynamic model, so the parent needs a nested dynamic model property.
            var nested = InputFactory.Model(
                "NestedWidget",
                properties: [InputFactory.Property("label", InputPrimitiveType.String)],
                isDynamicModel: true);
            var parent = InputFactory.Model(
                "DynamicWidget",
                properties:
                [
                    InputFactory.Property("nested", nested),
                    InputFactory.Property("size", InputPrimitiveType.Int32),
                ],
                isDynamicModel: true);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [nested, parent],
                primaryNamespace: "Azure.ResourceManager.Test");
            // Register the nested provider in the type map so the parent is recognized as having
            // dynamic properties.
            _ = plugin.Object.TypeFactory.CreateModel(nested);
            return parent;
        }

        private static string Write(TypeProvider provider) => new TypeProviderWriter(provider).Write().Content;

        private static int CountOccurrences(string content, string value)
        {
            var count = 0;
            var index = content.IndexOf(value, StringComparison.Ordinal);
            while (index >= 0)
            {
                count++;
                index = content.IndexOf(value, index + value.Length, StringComparison.Ordinal);
            }
            return count;
        }

        private static void AssertPatchWiringIsWellFormed(string content, int constructorCount)
        {
            Assert.That(CountOccurrences(content, PatchAssignment), Is.EqualTo(1));
            Assert.That(CountOccurrences(content, SetPropagatorsCall), Is.EqualTo(constructorCount));
            Assert.That(CountOccurrences(content, PragmaDisable), Is.EqualTo(constructorCount));
            Assert.That(CountOccurrences(content, PragmaRestore), Is.EqualTo(constructorCount));
        }

        [Test]
        public void DynamicManagementModelWiresJsonPatchExactlyOncePerConstructor()
        {
            var provider = new ManagementModelProvider(LoadDynamicModel());

            AssertPatchWiringIsWellFormed(Write(provider), provider.Constructors.Count);
        }

        [Test]
        public void RebuildingConstructorsDoesNotDuplicateJsonPatchWiring()
        {
            var provider = new ManagementModelProvider(LoadDynamicModel());

            // Reproduce the real generation ordering: a visitor materializes the constructors, then an
            // identity change clears the constructor cache and a later visitor rebuilds them.
            _ = provider.Constructors;
            var before = Write(provider);

            provider.Update(name: provider.Name);
            _ = provider.Constructors;
            var after = Write(provider);

            Assert.That(after, Is.EqualTo(before));
            AssertPatchWiringIsWellFormed(after, provider.Constructors.Count);
        }

        [Test]
        public void RepeatedConstructorRebuildsDoNotDuplicateJsonPatchWiring()
        {
            var provider = new ManagementModelProvider(LoadDynamicModel());

            _ = provider.Constructors;
            var before = Write(provider);

            for (var i = 0; i < 5; i++)
            {
                provider.Update(name: provider.Name);
                _ = provider.Constructors;
            }

            Assert.That(Write(provider), Is.EqualTo(before));
        }

        [Test]
        public void NamespaceChangeDoesNotDuplicateJsonPatchWiring()
        {
            var provider = new ManagementModelProvider(LoadDynamicModel());

            _ = provider.Constructors;
            var before = Write(provider);

            // A namespace change also clears the constructor cache without clearing FullConstructor.
            // The emitted namespace/usings legitimately change, so only the patch wiring is compared.
            provider.Update(@namespace: "Azure.ResourceManager.Test.Other");
            _ = provider.Constructors;
            var after = Write(provider);

            AssertPatchWiringIsWellFormed(before, provider.Constructors.Count);
            AssertPatchWiringIsWellFormed(after, provider.Constructors.Count);
        }

        [Test]
        public void ResetRebuildsConstructorsWithoutDuplicatingJsonPatchWiring()
        {
            var provider = new ManagementModelProvider(LoadDynamicModel());

            _ = provider.Constructors;
            var before = Write(provider);

            // reset: true must genuinely rebuild the constructors, so the cached build has to be
            // discarded as well.
            provider.Update(name: provider.Name, reset: true);
            _ = provider.Constructors;
            var after = Write(provider);

            Assert.That(after, Is.EqualTo(before));
            AssertPatchWiringIsWellFormed(after, provider.Constructors.Count);
        }

        [Test]
        public void DynamicResourceDataModelRebuildDoesNotDuplicateJsonPatchWiring()
        {
            var (client, models) = InputResourceData.ClientWithResource(isDynamicModel: true);
            var resourceModel = models.Single();
            _ = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [client],
                primaryNamespace: "Azure.ResourceManager.Test");

            var provider = new ResourceDataModelProvider(resourceModel);

            _ = provider.Constructors;
            var before = Write(provider);

            provider.Update(name: provider.Name);
            _ = provider.Constructors;
            var after = Write(provider);

            Assert.That(after, Is.EqualTo(before));
            Assert.That(CountOccurrences(after, PatchAssignment), Is.EqualTo(1));
            Assert.That(CountOccurrences(after, PragmaDisable), Is.EqualTo(CountOccurrences(after, PragmaRestore)));
        }

        [Test]
        public void NonDynamicManagementModelHasNoJsonPatchWiring()
        {
            var model = InputFactory.Model(
                "PlainWidget",
                properties: [InputFactory.Property("name", InputPrimitiveType.String)]);
            _ = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [model],
                primaryNamespace: "Azure.ResourceManager.Test");

            var provider = new ManagementModelProvider(model);
            _ = provider.Constructors;
            provider.Update(name: provider.Name);
            var content = Write(provider);

            Assert.That(content, Does.Not.Contain(SetPropagatorsCall));
            Assert.That(content, Does.Not.Contain(PatchAssignment));
        }
    }
}
