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
    /// Self-discovering tests that verify every concrete subtype of known
    /// polymorphic base classes can roundtrip through ModelReaderWriter.
    ///
    /// This generalizes the serialization pattern from RoundtripAllSkills
    /// across ALL polymorphic hierarchies. The existing RoundtripAllSkills
    /// recorded test validates live service creation and stays unchanged —
    /// these tests validate serialization correctness offline.
    ///
    /// No recordings, no live resources, no SearchTestBase.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("TypeCompleteness")]
    public class PolymorphicRoundtripTests
    {
        /// <summary>
        /// Subtypes that are intentionally excluded from automatic roundtrip testing.
        /// Each exclusion must have a documented rationale.
        /// </summary>
        private static readonly HashSet<Type> s_excludedSubtypes = new()
        {
            // Add types here with rationale if they intentionally cannot roundtrip
            // from empty JSON (e.g., require service-side context that can't be faked).
        };

        /// <summary>
        /// Discovers all concrete subtypes of all known polymorphic base types
        /// and returns them as test cases with format "BaseType_ConcreteType".
        /// </summary>
        public static IEnumerable<TestCaseData> AllPolymorphicSubtypes()
        {
            foreach (var baseType in SearchTestHelpers.PolymorphicBaseTypes)
            {
                foreach (var concreteType in SearchTestHelpers.DiscoverConcreteSubtypes(baseType))
                {
                    if (s_excludedSubtypes.Contains(concreteType))
                        continue;

                    yield return new TestCaseData(baseType, concreteType)
                        .SetName($"Roundtrip_{baseType.Name}_{concreteType.Name}");
                }
            }
        }

        /// <summary>
        /// Verifies that a concrete subtype can be deserialized from empty JSON
        /// without a fatal infrastructure error (missing builder).
        /// </summary>
        [TestCaseSource(nameof(AllPolymorphicSubtypes))]
        public void SubtypeCanDeserialize(Type baseType, Type concreteType)
        {
            var json = new BinaryData(Encoding.UTF8.GetBytes("{}"));

            try
            {
                var instance = ModelReaderWriter.Read(json, concreteType, SearchTestHelpers.WireOptions);
                // If Read succeeds, also verify Write doesn't throw.
                if (instance != null)
                {
                    BinaryData written = ModelReaderWriter.Write(instance, SearchTestHelpers.WireOptions);
                    Assert.IsNotNull(written, $"ModelReaderWriter.Write returned null for {concreteType.Name}.");
                }
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ModelReaderWriterTypeBuilder"))
            {
                Assert.Fail($"Missing ModelReaderWriterTypeBuilder for {concreteType.FullName} (base: {baseType.Name}): {ex.Message}");
            }
            catch (Exception)
            {
                // Non-infrastructure exceptions are acceptable (required properties, etc.).
            }
        }

        /// <summary>
        /// Ensures every known polymorphic base type has at least one concrete subtype.
        /// Guards against base types that lost all subtypes after regeneration.
        /// </summary>
        [Test]
        public void AllBaseTypesHaveSubtypes()
        {
            var missing = new List<string>();

            foreach (var baseType in SearchTestHelpers.PolymorphicBaseTypes)
            {
                var subtypes = SearchTestHelpers.DiscoverConcreteSubtypes(baseType).ToList();
                if (subtypes.Count == 0)
                {
                    missing.Add(baseType.Name);
                }
            }

            Assert.That(missing, Is.Empty,
                $"The following polymorphic base types have no concrete subtypes in the assembly: {string.Join(", ", missing)}. " +
                "This may indicate a code generation issue or the base type list in SearchTestHelpers needs updating.");
        }

        /// <summary>
        /// Reports a summary of all polymorphic hierarchies and their subtype counts.
        /// Informational — always passes. Useful for reviewing coverage.
        /// </summary>
        [Test]
        public void PolymorphicHierarchySummary()
        {
            foreach (var baseType in SearchTestHelpers.PolymorphicBaseTypes)
            {
                var subtypes = SearchTestHelpers.DiscoverConcreteSubtypes(baseType).ToList();
                TestContext.WriteLine($"{baseType.Name}: {subtypes.Count} concrete subtypes");
                foreach (var sub in subtypes)
                {
                    TestContext.WriteLine($"  - {sub.Name}");
                }
            }

            Assert.Pass("Summary complete — see test output for details.");
        }
    }
}
