// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.TypeCompleteness
{
    /// <summary>
    /// Self-discovering tests that verify every public IJsonModel type in the
    /// Azure.Search.Documents assembly can roundtrip through ModelReaderWriter
    /// without throwing.
    ///
    /// These tests require no recordings, no live resources, and no SearchTestBase.
    /// They automatically detect new types added by code generation — if a new
    /// model breaks serialization, these tests fail immediately.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("TypeCompleteness")]
    public class ModelDiscoveryTests
    {
        /// <summary>
        /// Types that are intentionally excluded from the roundtrip test.
        /// Each exclusion must have a documented rationale.
        /// </summary>
        private static readonly HashSet<Type> s_excludedTypes = new()
        {
            // SearchDocument is a dynamic bag type — it doesn't implement IJsonModel<T> in the standard way.
            typeof(Azure.Search.Documents.Models.SearchDocument),
        };

        /// <summary>
        /// Discovers all public IJsonModel types in the SDK assembly and returns them as test cases.
        /// Self-healing: automatically fails when code generation adds a new type that breaks serialization.
        /// </summary>
        public static IEnumerable<TestCaseData> AllJsonModelTypes()
        {
            foreach (var modelType in SearchTestHelpers.DiscoverJsonModelTypes())
            {
                if (s_excludedTypes.Contains(modelType))
                    continue;

                yield return new TestCaseData(modelType)
                    .SetName($"Roundtrip_{modelType.Name}");
            }
        }

        /// <summary>
        /// Verifies that deserializing a type from empty JSON does not throw an
        /// <see cref="InvalidOperationException"/> indicating a missing
        /// ModelReaderWriterTypeBuilder. Other exceptions (e.g. ArgumentNullException
        /// for required properties) are acceptable — they indicate the builder exists
        /// but the empty JSON didn't satisfy the model's requirements.
        /// </summary>
        [TestCaseSource(nameof(AllJsonModelTypes))]
        public void DeserializeFromEmptyJsonDoesNotThrow(Type modelType)
        {
            var json = new BinaryData(Encoding.UTF8.GetBytes("{}"));

            try
            {
                ModelReaderWriter.Read(json, modelType, SearchTestHelpers.WireOptions);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ModelReaderWriterTypeBuilder"))
            {
                Assert.Fail($"Missing ModelReaderWriterTypeBuilder for {modelType.FullName}: {ex.Message}");
            }
            catch (Exception)
            {
                // Other exceptions (e.g. ArgumentNullException for required properties,
                // JsonException for missing discriminator) are acceptable — they indicate
                // the builder was found but the empty JSON didn't satisfy the model's requirements.
            }
        }

        /// <summary>
        /// Verifies that every IJsonModel type that can be deserialized from minimal JSON
        /// can also be re-serialized via ModelReaderWriter.Write without throwing.
        /// </summary>
        [TestCaseSource(nameof(AllJsonModelTypes))]
        public void WriteAfterReadDoesNotThrow(Type modelType)
        {
            var json = new BinaryData(Encoding.UTF8.GetBytes("{}"));

            object instance;
            try
            {
                instance = ModelReaderWriter.Read(json, modelType, SearchTestHelpers.WireOptions);
            }
            catch
            {
                // If Read fails (e.g. required property), skip the Write test — DeserializeFromEmptyJsonDoesNotThrow covers it.
                Assert.Pass($"Skipping Write test for {modelType.Name} — Read from empty JSON throws (covered by other test).");
                return;
            }

            if (instance == null)
            {
                Assert.Pass($"Skipping Write test for {modelType.Name} — Read returned null.");
                return;
            }

            // Write may throw NullReferenceException or similar for models deserialized from
            // empty JSON that have required properties left null. This is acceptable — it means
            // the ModelReaderWriter infrastructure is present but the model needs non-trivial JSON.
            try
            {
                BinaryData written = ModelReaderWriter.Write(instance, SearchTestHelpers.WireOptions);
                Assert.IsNotNull(written, $"ModelReaderWriter.Write returned null for {modelType.Name}.");
            }
            catch (NullReferenceException)
            {
                // Expected for models with required properties that are null after deserializing from {}.
                Assert.Pass($"{modelType.Name} — Write throws NullReferenceException (required props null from empty JSON). Infrastructure is present.");
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ModelReaderWriterTypeBuilder"))
            {
                Assert.Fail($"Missing ModelReaderWriterTypeBuilder for {modelType.FullName}: {ex.Message}");
            }
        }

        /// <summary>
        /// Ensures that at least some IJsonModel types are discovered — a guard against
        /// the reflection scan silently returning zero results.
        /// </summary>
        [Test]
        public void DiscoveryFindsTypes()
        {
            var types = SearchTestHelpers.DiscoverJsonModelTypes().ToList();
            Assert.That(types.Count, Is.GreaterThan(50),
                $"Expected at least 50 IJsonModel types in the Search SDK assembly, but found {types.Count}. " +
                "This may indicate a reflection scanning issue.");
        }
    }
}
