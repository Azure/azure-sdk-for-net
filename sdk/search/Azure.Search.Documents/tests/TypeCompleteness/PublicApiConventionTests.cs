// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.TypeCompleteness
{
    /// <summary>
    /// Auto-validates naming conventions and API surface patterns for
    /// public types in the Azure.Search.Documents assembly.
    ///
    /// No recordings, no live resources, no SearchTestBase.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("TypeCompleteness")]
    public class PublicApiConventionTests
    {
        private static readonly Assembly s_sdkAssembly = SearchTestHelpers.SdkAssembly;

        /// <summary>
        /// Known client types that should follow the standard constructor pattern.
        /// </summary>
        private static readonly Type[] s_clientTypes = new[]
        {
            typeof(SearchClient),
            typeof(Indexes.SearchIndexClient),
            typeof(Indexes.SearchIndexerClient),
        };

        /// <summary>
        /// All public types in the SDK must be in the Azure.Search.Documents namespace
        /// or a sub-namespace thereof. Extension method classes in Microsoft.Extensions
        /// are excluded as they follow DI registration conventions.
        /// </summary>
        [Test]
        public void AllPublicTypesInCorrectNamespace()
        {
            const string rootNamespace = "Azure.Search.Documents";
            const string extensionsNamespace = "Microsoft.Extensions";

            var violations = s_sdkAssembly.GetExportedTypes()
                .Where(t => t.Namespace != null &&
                            !t.Namespace.StartsWith(rootNamespace, StringComparison.Ordinal) &&
                            !t.Namespace.StartsWith(extensionsNamespace, StringComparison.Ordinal))
                .Select(t => $"{t.FullName} (namespace: {t.Namespace})")
                .ToList();

            Assert.That(violations, Is.Empty,
                $"The following public types are not in the {rootNamespace} namespace tree:\n" +
                string.Join("\n", violations));
        }

        /// <summary>
        /// Client types should have a constructor accepting (Uri endpoint, AzureKeyCredential credential).
        /// </summary>
        [Test]
        public void ClientTypesHaveKeyCredentialConstructor()
        {
            foreach (var clientType in s_clientTypes)
            {
                var ctors = clientType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
                bool hasKeyCredCtor = ctors.Any(c =>
                {
                    var p = c.GetParameters();
                    return p.Any(param => param.ParameterType == typeof(Uri)) &&
                           p.Any(param => param.ParameterType == typeof(AzureKeyCredential));
                });

                Assert.IsTrue(hasKeyCredCtor,
                    $"{clientType.Name} must have a public constructor accepting (Uri, AzureKeyCredential, ...).");
            }
        }

        /// <summary>
        /// <see cref="SearchClientOptions"/> must inherit from <see cref="ClientOptions"/>.
        /// </summary>
        [Test]
        public void ClientOptionsInheritsFromClientOptions()
        {
            Assert.IsTrue(typeof(ClientOptions).IsAssignableFrom(typeof(SearchClientOptions)),
                $"{nameof(SearchClientOptions)} must inherit from {nameof(ClientOptions)}.");
        }

        /// <summary>
        /// All public model types should be classes, not structs (Azure SDK guideline).
        /// Extensible enums (struct wrappers) are excluded.
        /// </summary>
        [Test]
        public void PublicModelTypesAreClasses()
        {
            // Extensible enums are readonly structs — exclude types that look like them
            // (they have a single string field and implicit/explicit conversion operators).
            bool IsExtensibleEnum(Type t)
            {
                if (!t.IsValueType)
                    return false;
                var fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                return fields.Length <= 2 && fields.Any(f => f.FieldType == typeof(string));
            }

            var structModels = s_sdkAssembly.GetExportedTypes()
                .Where(t => t.IsValueType && !t.IsEnum && !IsExtensibleEnum(t))
                .Where(t => t.Namespace != null && t.Namespace.Contains("Models"))
                .Select(t => t.FullName)
                .ToList();

            Assert.That(structModels, Is.Empty,
                $"The following model types in a Models namespace are structs instead of classes:\n" +
                string.Join("\n", structModels));
        }

        /// <summary>
        /// Ensures there is a non-trivial number of public types — guards against
        /// assembly loading issues that would make all convention tests vacuously pass.
        /// </summary>
        [Test]
        public void AssemblyHasPublicTypes()
        {
            var publicTypes = s_sdkAssembly.GetExportedTypes();
            Assert.That(publicTypes.Length, Is.GreaterThan(100),
                $"Expected over 100 public types in the Search SDK assembly, but found {publicTypes.Length}.");
        }
    }
}
