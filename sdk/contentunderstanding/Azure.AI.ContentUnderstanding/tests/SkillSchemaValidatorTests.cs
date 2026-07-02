// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.IO;
using System.Text.Json;
using AzureSdkContentUnderstanding.Skills;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <c>tools/cu-skill/SchemaValidator.cs</c> (mirrors
    /// Python's <c>tests/test_skills_shared_schema_validator.py</c>).
    /// </summary>
    /// <remarks>
    /// The validator is pure-C# (no Azure.* imports, no network). These tests
    /// cover:
    /// <list type="bullet">
    ///   <item>valid single-type schema</item>
    ///   <item>valid classify-and-route schema</item>
    ///   <item>unknown <c>baseAnalyzerId</c> rejected (catches the
    ///         <c>prebuilt-documentAnalyzer</c> typo class observed during live testing)</item>
    ///   <item>missing <c>fieldSchema</c> on non-classifier</item>
    ///   <item>classify-route schemas reject top-level <c>fieldSchema</c></item>
    ///   <item><c>enableSegment = true</c> is required on classify-route</item>
    ///   <item>file loading: missing file, invalid JSON</item>
    ///   <item>purity guard: SchemaValidator.cs source contains no Azure.* or
    ///         HTTP using directives (see <c>tools/cu-skill/about.md</c>)</item>
    /// </list>
    /// </remarks>
    [TestFixture]
    public class SkillSchemaValidatorTests
    {
        private static JsonElement Parse(string json)
        {
            // Cache the document so the JsonElement stays valid for the test —
            // JsonDocument.Parse owns the underlying buffer and disposing it
            // invalidates every JsonElement, so we keep it alive on the heap.
            // Tests are short-lived; GC reclaims when the fixture is torn down.
            var doc = JsonDocument.Parse(json);
            _liveDocs.Add(doc);
            return doc.RootElement;
        }

        private static readonly System.Collections.Generic.List<JsonDocument> _liveDocs = new();

        [OneTimeTearDown]
        public void DisposeLiveDocs()
        {
            foreach (var d in _liveDocs)
            {
                d.Dispose();
            }
            _liveDocs.Clear();
        }

        // -------------------------------------------------------------------
        // Valid schemas
        // -------------------------------------------------------------------

        [Test]
        public void Validate_ValidSingleTypeSchema_ReturnsOk()
        {
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-document"",
                ""fieldSchema"": {
                    ""fields"": {
                        ""invoiceNumber"": {
                            ""type"": ""string"",
                            ""method"": ""extract"",
                            ""description"": ""Invoice number printed at the top right.""
                        }
                    }
                }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsTrue(result.Ok, "Errors: " + string.Join("; ", result.Errors));
            Assert.IsEmpty(result.Errors);
        }

        [Test]
        public void Validate_ValidClassifyRouteSchema_ReturnsOk()
        {
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-document"",
                ""config"": {
                    ""enableSegment"": true,
                    ""contentCategories"": {
                        ""invoice"": {
                            ""description"": ""Pages whose top heading is 'Invoice'."",
                            ""analyzerId"": ""invoice_extractor_v1""
                        },
                        ""bank_statement"": {
                            ""description"": ""Pages whose top heading is 'Bank Statement'."",
                            ""analyzerId"": ""bank_statement_extractor_v1""
                        }
                    }
                }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsTrue(result.Ok, "Errors: " + string.Join("; ", result.Errors));
        }

        [Test]
        public void Validate_ClassifyRouteCategoryWithoutAnalyzerId_AllowedForOtherBucket()
        {
            // Category without analyzerId classifies only; the route is fine
            // and is a documented pattern for an "other" catch-all.
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-document"",
                ""config"": {
                    ""enableSegment"": true,
                    ""contentCategories"": {
                        ""invoice"": { ""description"": ""Invoices."", ""analyzerId"": ""inv"" },
                        ""other"":   { ""description"": ""Anything else."" }
                    }
                }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsTrue(result.Ok, "Errors: " + string.Join("; ", result.Errors));
        }

        // -------------------------------------------------------------------
        // Single-type rejections
        // -------------------------------------------------------------------

        [Test]
        public void Validate_UnknownBaseAnalyzerId_Rejected()
        {
            // Catches the `prebuilt-documentAnalyzer` typo class — the
            // service returns InvalidBaseAnalyzerId without a useful message,
            // so we catch it locally with the actual allow-list.
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-documentAnalyzer"",
                ""fieldSchema"": { ""fields"": { ""x"": { ""type"": ""string"" } } }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsFalse(result.Ok);
            Assert.That(result.Errors, Has.Some.Contains("baseAnalyzerId"));
            Assert.That(result.Errors, Has.Some.Contains("prebuilt-documentAnalyzer"));
        }

        [Test]
        public void Validate_MissingFieldSchemaOnNonClassifier_Rejected()
        {
            var schema = Parse(@"{ ""baseAnalyzerId"": ""prebuilt-document"" }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsFalse(result.Ok);
            Assert.That(result.Errors, Has.Some.Contains("fieldSchema"));
        }

        [Test]
        public void Validate_EmptyFieldsObject_Rejected()
        {
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-document"",
                ""fieldSchema"": { ""fields"": {} }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsFalse(result.Ok);
            Assert.That(result.Errors, Has.Some.Contains("at least one field"));
        }

        [Test]
        public void Validate_UnknownFieldType_Rejected()
        {
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-document"",
                ""fieldSchema"": {
                    ""fields"": { ""x"": { ""type"": ""float"" } }
                }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsFalse(result.Ok);
            Assert.That(result.Errors, Has.Some.Contains("'float'"));
        }

        [Test]
        public void Validate_UnknownFieldMethod_Rejected()
        {
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-document"",
                ""fieldSchema"": {
                    ""fields"": { ""x"": { ""type"": ""string"", ""method"": ""infer"" } }
                }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsFalse(result.Ok);
            Assert.That(result.Errors, Has.Some.Contains("'infer'"));
        }

        [Test]
        public void Validate_NestedObjectField_RecursesIntoProperties()
        {
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-document"",
                ""fieldSchema"": {
                    ""fields"": {
                        ""billTo"": {
                            ""type"": ""object"",
                            ""properties"": {
                                ""name"": { ""type"": ""bogus"" }
                            }
                        }
                    }
                }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsFalse(result.Ok);
            Assert.That(result.Errors, Has.Some.Contains("billTo"));
            Assert.That(result.Errors, Has.Some.Contains("'bogus'"));
        }

        [Test]
        public void Validate_ArrayField_RecursesIntoItems()
        {
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-document"",
                ""fieldSchema"": {
                    ""fields"": {
                        ""lineItems"": {
                            ""type"": ""array"",
                            ""items"": { ""type"": ""nope"" }
                        }
                    }
                }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsFalse(result.Ok);
            // The path uses bracketed notation: `fieldSchema.fields['lineItems'].items.type`.
            Assert.That(result.Errors, Has.Some.Contains("'lineItems'"));
            Assert.That(result.Errors, Has.Some.Contains(".items.type"));
            Assert.That(result.Errors, Has.Some.Contains("'nope'"));
        }

        // -------------------------------------------------------------------
        // Classify-and-route rejections
        // -------------------------------------------------------------------

        [Test]
        public void Validate_ClassifyRouteWithTopLevelFieldSchema_Rejected()
        {
            // Field extraction belongs in inner analyzers, not the outer
            // classifier — catch this before the service does.
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-document"",
                ""fieldSchema"": { ""fields"": { ""x"": { ""type"": ""string"" } } },
                ""config"": {
                    ""enableSegment"": true,
                    ""contentCategories"": {
                        ""invoice"": { ""description"": ""d"", ""analyzerId"": ""a"" }
                    }
                }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsFalse(result.Ok);
            Assert.That(result.Errors, Has.Some.Contains("fieldSchema").And.Some.Contains("inner"));
        }

        [Test]
        public void Validate_ClassifyRouteWithoutEnableSegment_Rejected()
        {
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-document"",
                ""config"": {
                    ""contentCategories"": {
                        ""invoice"": { ""description"": ""d"", ""analyzerId"": ""a"" }
                    }
                }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsFalse(result.Ok);
            Assert.That(result.Errors, Has.Some.Contains("enableSegment"));
        }

        [Test]
        public void Validate_ClassifyRouteWithEmptyCategoryDescription_Rejected()
        {
            var schema = Parse(@"{
                ""baseAnalyzerId"": ""prebuilt-document"",
                ""config"": {
                    ""enableSegment"": true,
                    ""contentCategories"": {
                        ""invoice"": { ""description"": ""  "", ""analyzerId"": ""a"" }
                    }
                }
            }");

            var result = SchemaValidator.Validate(schema);

            Assert.IsFalse(result.Ok);
            Assert.That(result.Errors, Has.Some.Contains("description"));
        }

        // -------------------------------------------------------------------
        // ValidateFile
        // -------------------------------------------------------------------

        [Test]
        public void ValidateFile_MissingFile_ReturnsError()
        {
            var missing = Path.Combine(Path.GetTempPath(), "definitely-not-there-" + Path.GetRandomFileName());

            var result = SchemaValidator.ValidateFile(missing);

            Assert.IsFalse(result.Ok);
            Assert.That(result.Errors, Has.Some.Contains("not found"));
        }

        [Test]
        public void ValidateFile_InvalidJson_ReturnsError()
        {
            var path = Path.Combine(Path.GetTempPath(), "broken-" + Path.GetRandomFileName() + ".json");
            try
            {
                File.WriteAllText(path, "{ this is not json");
                var result = SchemaValidator.ValidateFile(path);

                Assert.IsFalse(result.Ok);
                Assert.That(result.Errors, Has.Some.Contains("not valid JSON"));
            }
            finally
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
        }

        [Test]
        public void ValidateFile_ValidSchemaOnDisk_RoundTrips()
        {
            var path = Path.Combine(Path.GetTempPath(), "valid-" + Path.GetRandomFileName() + ".json");
            try
            {
                File.WriteAllText(path, @"{
                    ""baseAnalyzerId"": ""prebuilt-document"",
                    ""fieldSchema"": { ""fields"": { ""x"": { ""type"": ""string"" } } }
                }");
                var result = SchemaValidator.ValidateFile(path);

                Assert.IsTrue(result.Ok, "Errors: " + string.Join("; ", result.Errors));
            }
            finally
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
        }

        // -------------------------------------------------------------------
        // Allow-list surface
        // -------------------------------------------------------------------

        [Test]
        public void KnownBaseAnalyzerIds_OnlyContainsModalityPrebuilts()
        {
            // Sanity check: the allow-list must NOT include `*Search` variants,
            // `prebuilt-invoice`, or `prebuilt-receipt` — these return
            // `InvalidBaseAnalyzerId` if used as `baseAnalyzerId` for a custom
            // analyzer. Only modality-level prebuilts are valid.
            var expected = new[] { "prebuilt-document", "prebuilt-audio", "prebuilt-video", "prebuilt-image" };
            CollectionAssert.AreEquivalent(expected, SchemaValidator.KnownBaseAnalyzerIds);
        }

        // -------------------------------------------------------------------
        // Purity guard
        // -------------------------------------------------------------------

        [Test]
        public void SchemaValidatorSource_DoesNotImportAzureOrHttpNamespaces()
        {
            // The validator is intentionally pure-C# so it can be unit-tested
            // without spinning up the Azure SDK, and so it can be reused from
            // any context (CI, scripts, samples). Drift would creep in if a
            // future change accidentally pulls in Azure.Core or HttpClient.
            var sourcePath = LocateSchemaValidatorSource();
            Assert.IsTrue(File.Exists(sourcePath), $"SchemaValidator.cs not found at {sourcePath}");

            var source = File.ReadAllText(sourcePath);
            foreach (var forbidden in new[]
            {
                "using Azure.",
                "using System.Net.Http",
                "using System.Net.Sockets",
                "WebClient",
            })
            {
                Assert.That(source, Does.Not.Contain(forbidden),
                    $"SchemaValidator.cs must not contain `{forbidden}` — see tools/cu-skill/about.md");
            }
        }

        private static string LocateSchemaValidatorSource()
        {
            // Walk up from the test assembly location to find the package
            // root, then build the well-known relative path. The test
            // assembly may live under either `tests/bin/...` (in-tree builds)
            // or `artifacts/bin/<assembly>/...` (CI / `dotnet test` layout),
            // so try a generous depth.
            var dir = TestContext.CurrentContext.TestDirectory;
            for (int i = 0; i < 20 && dir is not null; i++)
            {
                var candidate = Path.Combine(dir, "tools", "cu-skill", "SchemaValidator.cs");
                if (File.Exists(candidate))
                {
                    return candidate;
                }
                // Also try the well-known relative path from the artifacts
                // layout (`artifacts/bin/<assembly>/Debug/<tfm>` -> repo root
                // -> `sdk/contentunderstanding/tools/cu-skill`).
                var artifacts = Path.Combine(
                    dir,
                    "sdk", "contentunderstanding", "tools", "cu-skill", "SchemaValidator.cs");
                if (File.Exists(artifacts))
                {
                    return artifacts;
                }
                dir = Path.GetDirectoryName(dir);
            }
            // Fall back so the assertion's failure message points at an
            // expected location near the test assembly.
            return Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                "..", "..", "..", "..", "..", "tools", "cu-skill", "SchemaValidator.cs");
        }
    }
}
