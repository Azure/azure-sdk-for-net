// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using Microsoft.TypeSpec.Generator.AspNetServer.Providers;
using Microsoft.TypeSpec.Generator.AspNetServer.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Microsoft.TypeSpec.Generator.AspNetServer.Tests.Providers
{
    public class HelloWorldProviderTests
    {
        [SetUp]
        public void SetUp()
        {
            // Each test gets a fresh mocked plugin so static state from a prior
            // test (e.g., CodeModelGenerator._instance) doesn't leak in.
            AspNetServerMockHelpers.LoadMockPlugin();
        }

        [Test]
        public void OutputLibrary_includes_HelloWorldProvider()
        {
            var library = new AspNetServerOutputLibrary();
            var providers = library.TypeProviders;

            Assert.That(providers, Is.Not.Null);
            Assert.That(providers.OfType<HelloWorldProvider>().Count(), Is.EqualTo(1));
        }

        [Test]
        public void HelloWorldProvider_has_expected_name_and_relative_path()
        {
            var library = new AspNetServerOutputLibrary();
            var provider = library.TypeProviders.OfType<HelloWorldProvider>().Single();

            Assert.That(provider.Name, Is.EqualTo("HelloWorld"));
            Assert.That(
                provider.RelativeFilePath,
                Is.EqualTo(Path.Combine("src", "Generated", "HelloWorld.cs")));
        }

        [Test]
        public void HelloWorldProvider_emits_static_internal_class()
        {
            var library = new AspNetServerOutputLibrary();
            var provider = library.TypeProviders.OfType<HelloWorldProvider>().Single();

            var modifiers = provider.DeclarationModifiers;
            Assert.That(
                modifiers.HasFlag(TypeSignatureModifiers.Internal),
                $"Expected Internal modifier; got {modifiers}.");
            Assert.That(
                modifiers.HasFlag(TypeSignatureModifiers.Static),
                $"Expected Static modifier; got {modifiers}.");
            Assert.That(
                modifiers.HasFlag(TypeSignatureModifiers.Class),
                $"Expected Class modifier; got {modifiers}.");
        }

        [Test]
        public void HelloWorldProvider_exposes_a_public_static_Greet_method()
        {
            var library = new AspNetServerOutputLibrary();
            var provider = library.TypeProviders.OfType<HelloWorldProvider>().Single();

            var greet = provider.Methods.SingleOrDefault(m => m.Signature.Name == "Greet");
            Assert.That(greet, Is.Not.Null, "Expected a Greet method on HelloWorldProvider.");

            var modifiers = greet!.Signature.Modifiers;
            Assert.That(
                modifiers.HasFlag(MethodSignatureModifiers.Public),
                $"Expected Public modifier; got {modifiers}.");
            Assert.That(
                modifiers.HasFlag(MethodSignatureModifiers.Static),
                $"Expected Static modifier; got {modifiers}.");
            Assert.That(greet.Signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(greet.Signature.Parameters, Is.Empty);
        }
    }
}
