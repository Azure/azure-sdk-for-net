// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using AzureSdkContentUnderstanding.Skills;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for the pure helpers in
    /// <c>tools/cu-skill/CreateAndTestRouterCommand.cs</c> (mirrors Python's
    /// <c>tests/test_skills_classify_route_router.py</c>).
    /// </summary>
    public class SkillCreateAndTestRouterCommandTests
    {
        private static JsonObject Field(string value, double confidence)
            => new() { ["valueString"] = value, ["confidence"] = confidence };

        private static JsonObject Segment(string category, JsonObject fields)
            => new() { ["category"] = category, ["fields"] = fields };

        private static JsonObject DocWithSegments(params JsonObject[] segments)
        {
            var arr = new JsonArray();
            foreach (var s in segments)
            {
                arr.Add(s);
            }
            return new JsonObject { ["contents"] = arr };
        }

        // -------------------------------------------------------------------
        // SummarizeRouted
        // -------------------------------------------------------------------

        [Test]
        public void SummarizeRouted_UsesPerCategoryDenominator()
        {
            // Three invoice segments (all filled) must report 100%, not be
            // diluted by other categories' segments.
            var doc = DocWithSegments(
                Segment("invoice", new JsonObject { ["InvoiceNumber"] = Field("INV-1", 0.9) }),
                Segment("invoice", new JsonObject { ["InvoiceNumber"] = Field("INV-2", 0.91) }),
                Segment("invoice", new JsonObject { ["InvoiceNumber"] = Field("INV-3", 0.92) }),
                Segment("bank_statement", new JsonObject { ["AccountNumber"] = Field("12345", 0.8) }));

            var results = new[] { (DocName: "packet_a", Doc: doc) };
            var text = CreateAndTestRouterCommand.SummarizeRouted(results);

            // Invoice: 3 segments, 3 filled → 100%
            StringAssert.Contains("category: invoice  (3 segments)", text);
            StringAssert.Contains("InvoiceNumber", text);
            StringAssert.Contains("100.0%", text);
            // Bank statement: 1 segment, 1 filled → 100% (singular "segment"
            // is also acceptable; .NET impl currently uses "segments" always).
            Assert.That(
                text.Contains("category: bank_statement  (1 segment)") ||
                    text.Contains("category: bank_statement  (1 segments)"),
                "bank_statement segment count wrong: " + text);
            // Packet-wide denominator must NOT leak through.
            StringAssert.DoesNotContain("33.3%", text);
            StringAssert.DoesNotContain("25.0%", text);
        }

        [Test]
        public void SummarizeRouted_ReportsZeroFillForMissingFieldInSomeSegments()
        {
            // Two invoice segments, only one has TotalAmount → 50% fill.
            var doc = DocWithSegments(
                Segment("invoice", new JsonObject
                {
                    ["InvoiceNumber"] = Field("INV-1", 0.9),
                    ["TotalAmount"] = Field("$100", 0.7),
                }),
                Segment("invoice", new JsonObject { ["InvoiceNumber"] = Field("INV-2", 0.91) }));

            var results = new[] { (DocName: "packet", Doc: doc) };
            var text = CreateAndTestRouterCommand.SummarizeRouted(results);

            StringAssert.Contains("category: invoice  (2 segments)", text);
            // InvoiceNumber appears in both → 100%
            StringAssert.Contains("InvoiceNumber", text);
            StringAssert.Contains("100.0%", text);
            // TotalAmount appears in 1 of 2 → 50%
            StringAssert.Contains("TotalAmount", text);
            StringAssert.Contains(" 50.0%", text);
        }

        // -------------------------------------------------------------------
        // WireInnerIds — .NET impl returns a (Patched, Errors) tuple so we
        // can directly mirror Python's full coverage (missing alias / extra
        // inner / prebuilt passthrough).
        // -------------------------------------------------------------------

        private static JsonObject OuterWithCategories(params (string Cat, string AnalyzerId)[] cats)
        {
            var categories = new JsonObject();
            foreach (var (cat, id) in cats)
            {
                categories[cat] = new JsonObject { ["description"] = "d", ["analyzerId"] = id };
            }
            return new JsonObject
            {
                ["baseAnalyzerId"] = "prebuilt-document",
                ["config"] = new JsonObject
                {
                    ["enableSegment"] = true,
                    ["contentCategories"] = categories,
                },
            };
        }

        [Test]
        public void WireInnerIds_MissingAlias_RecordsError()
        {
            var outer = OuterWithCategories(
                ("invoice", "invoice"),
                ("loan", "loan_application"));

            var aliasToId = new Dictionary<string, string> { ["invoice"] = "real-invoice-id" };
            var (_, errors) = CreateAndTestRouterCommand.WireInnerIds(outer, aliasToId);

            Assert.That(
                errors.Exists(e => e.Contains("loan_application")),
                $"expected error mentioning 'loan_application'; got: [{string.Join(" | ", errors)}]");
        }

        [Test]
        public void WireInnerIds_ExtraInner_RecordsError()
        {
            var outer = OuterWithCategories(("invoice", "invoice"));

            var aliasToId = new Dictionary<string, string>
            {
                ["invoice"] = "real-invoice-id",
                ["extra"] = "unused-id",
            };
            var (_, errors) = CreateAndTestRouterCommand.WireInnerIds(outer, aliasToId);

            Assert.That(
                errors.Exists(e => e.Contains("extra") && e.Contains("no category")),
                $"expected error mentioning 'extra' + 'no category'; got: [{string.Join(" | ", errors)}]");
        }

        [Test]
        public void WireInnerIds_PrebuiltPassthrough_LeavesPrebuiltsUntouched()
        {
            // Categories routed at a service prebuilt (e.g. prebuilt-invoice)
            // must skip alias resolution and be left untouched. No
            // --inner-schema needed for them.
            var outer = OuterWithCategories(
                ("invoice", "prebuilt-invoice"),
                ("receipt", "prebuilt-receipt"),
                ("custom_loan", "loan_application"));
            // omitContent matches Python's parity fixture.
            ((JsonObject)outer["config"]!)["omitContent"] = true;

            var aliasToId = new Dictionary<string, string>
            {
                ["loan_application"] = "real-loan-id",
            };

            var (patched, errors) = CreateAndTestRouterCommand.WireInnerIds(outer, aliasToId);

            Assert.That(errors, Is.Empty, $"unexpected errors: [{string.Join(" | ", errors)}]");
            var cats = (JsonObject)patched["config"]!["contentCategories"]!;
            // Prebuilts unchanged
            Assert.That(cats["invoice"]!["analyzerId"]!.GetValue<string>(),
                Is.EqualTo("prebuilt-invoice"));
            Assert.That(cats["receipt"]!["analyzerId"]!.GetValue<string>(),
                Is.EqualTo("prebuilt-receipt"));
            // Custom alias resolved
            Assert.That(cats["custom_loan"]!["analyzerId"]!.GetValue<string>(),
                Is.EqualTo("real-loan-id"));
        }

        // -------------------------------------------------------------------
        // ParseInnerArg
        // -------------------------------------------------------------------

        [Test]
        public void ParseInnerArg_AliasEqualsPath_ParsesCorrectly()
        {
            var parsed = CreateAndTestRouterCommand.ParseInnerArg(
                new[] { "invoice=/tmp/inv.json", "bank=/tmp/b.json" });
            Assert.That(parsed["invoice"], Is.EqualTo("/tmp/inv.json"));
            Assert.That(parsed["bank"], Is.EqualTo("/tmp/b.json"));
        }

        [Test]
        public void ParseInnerArg_MissingEquals_Throws()
        {
            Assert.Throws<System.InvalidOperationException>(
                () => CreateAndTestRouterCommand.ParseInnerArg(new[] { "invoice/tmp/inv.json" }));
        }

        // -------------------------------------------------------------------
        // VersionSortKey — pure key extractor
        // -------------------------------------------------------------------

        [Test]
        public void VersionSortKey_BareAlias_ReturnsGroupZero()
        {
            var key = CreateAndTestRouterCommand.VersionSortKey("invoice", "invoice");
            Assert.That(key.Group, Is.EqualTo(0));
            Assert.That(key.Version, Is.EqualTo(0));
        }

        [Test]
        public void VersionSortKey_VPrefixedNumeric_ReturnsGroupOneWithVersion()
        {
            var v9 = CreateAndTestRouterCommand.VersionSortKey("invoice_v9", "invoice");
            var v10 = CreateAndTestRouterCommand.VersionSortKey("invoice_v10", "invoice");
            Assert.That(v9.Group, Is.EqualTo(1));
            Assert.That(v9.Version, Is.EqualTo(9));
            Assert.That(v10.Group, Is.EqualTo(1));
            Assert.That(v10.Version, Is.EqualTo(10));
            // The whole point of the fix: v10 sorts higher than v9.
            Assert.That(v10, Is.GreaterThan(v9));
        }

        [Test]
        public void VersionSortKey_BareNumeric_ReturnsGroupOneWithVersion()
        {
            // `<alias>_<N>` without the `v` should also be recognised as a version.
            var key = CreateAndTestRouterCommand.VersionSortKey("invoice_42", "invoice");
            Assert.That(key.Group, Is.EqualTo(1));
            Assert.That(key.Version, Is.EqualTo(42));
        }

        [Test]
        public void VersionSortKey_NonNumericSuffix_ReturnsGroupTwoWithSuffix()
        {
            var key = CreateAndTestRouterCommand.VersionSortKey("invoice_draft", "invoice");
            Assert.That(key.Group, Is.EqualTo(2));
            Assert.That(key.Version, Is.EqualTo(0));
            Assert.That(key.Lex, Is.EqualTo("draft"));
        }

        // -------------------------------------------------------------------
        // DiscoverInnerFromDir — end-to-end filesystem-touching resolution
        // -------------------------------------------------------------------

        private static string MakeTempDir()
        {
            var d = Path.Combine(Path.GetTempPath(), "cu-skill-discover-" + Path.GetRandomFileName());
            Directory.CreateDirectory(d);
            return d;
        }

        private static void WriteEmptyJson(string dir, string name)
            => File.WriteAllText(Path.Combine(dir, name), "{}");

        private static JsonObject OuterWithAliases(params string?[] aliases)
        {
            var categories = new JsonObject();
            for (var i = 0; i < aliases.Length; i++)
            {
                var entry = new JsonObject { ["description"] = "d" };
                if (aliases[i] is not null)
                    entry["analyzerId"] = aliases[i];
                categories[$"cat_{i}"] = entry;
            }
            return new JsonObject
            {
                ["baseAnalyzerId"] = "prebuilt-document",
                ["config"] = new JsonObject
                {
                    ["enableSegment"] = true,
                    ["contentCategories"] = categories,
                },
            };
        }

        [Test]
        public void DiscoverInnerFromDir_ResolvesExactMatchStem()
        {
            var dir = MakeTempDir();
            try
            {
                WriteEmptyJson(dir, "invoice.json");
                WriteEmptyJson(dir, "bank_statement.json");

                var outer = OuterWithAliases("invoice", "bank_statement");
                var resolved = CreateAndTestRouterCommand.DiscoverInnerFromDir(outer, dir);

                Assert.That(resolved, Has.Count.EqualTo(2));
                Assert.That(resolved["invoice"], Is.EqualTo(Path.Combine(dir, "invoice.json")));
                Assert.That(resolved["bank_statement"], Is.EqualTo(Path.Combine(dir, "bank_statement.json")));
            }
            finally
            {
                Directory.Delete(dir, recursive: true);
            }
        }

        [Test]
        public void DiscoverInnerFromDir_PicksNaturalVersionMaxNotAlphabeticalLast()
        {
            // The bug that got shipped: `invoice_v10.json` sorted alphabetically
            // BEFORE `invoice_v9.json` (because '1' < '9' char-by-char after the
            // common `invoice_v` prefix), so "alphabetical last" returned v9.
            // With the natural version sort, v10 wins.
            var dir = MakeTempDir();
            try
            {
                WriteEmptyJson(dir, "invoice_v1.json");
                WriteEmptyJson(dir, "invoice_v2.json");
                WriteEmptyJson(dir, "invoice_v9.json");
                WriteEmptyJson(dir, "invoice_v10.json");

                var resolved = CreateAndTestRouterCommand.DiscoverInnerFromDir(OuterWithAliases("invoice"), dir);
                Assert.That(resolved["invoice"], Is.EqualTo(Path.Combine(dir, "invoice_v10.json")));
            }
            finally
            {
                Directory.Delete(dir, recursive: true);
            }
        }

        [Test]
        public void DiscoverInnerFromDir_PrefersVersionedOverBareAlias()
        {
            // Bare `<alias>.json` is group 0, `<alias>_v<N>.json` is group 1.
            // A versioned file should always beat the bare file as "newer".
            var dir = MakeTempDir();
            try
            {
                WriteEmptyJson(dir, "invoice.json");
                WriteEmptyJson(dir, "invoice_v1.json");

                var resolved = CreateAndTestRouterCommand.DiscoverInnerFromDir(OuterWithAliases("invoice"), dir);
                Assert.That(resolved["invoice"], Is.EqualTo(Path.Combine(dir, "invoice_v1.json")));
            }
            finally
            {
                Directory.Delete(dir, recursive: true);
            }
        }

        [Test]
        public void DiscoverInnerFromDir_SkipsPrebuiltAliases()
        {
            // `prebuilt-invoice` is a service-side analyzer; the tool must
            // NOT require a local file for it. It also shouldn't cause a
            // "missing alias" failure.
            var dir = MakeTempDir();
            try
            {
                WriteEmptyJson(dir, "invoice.json");

                var outer = OuterWithAliases("invoice", "prebuilt-invoice");
                var resolved = CreateAndTestRouterCommand.DiscoverInnerFromDir(outer, dir);

                Assert.That(resolved, Has.Count.EqualTo(1));
                Assert.That(resolved.ContainsKey("invoice"), Is.True);
                Assert.That(resolved.ContainsKey("prebuilt-invoice"), Is.False);
            }
            finally
            {
                Directory.Delete(dir, recursive: true);
            }
        }

        [Test]
        public void DiscoverInnerFromDir_SkipsCategoriesWithoutAnalyzerId()
        {
            // A category with no `analyzerId` is a classification-only bucket
            // ("other") — no schema file required.
            var dir = MakeTempDir();
            try
            {
                WriteEmptyJson(dir, "invoice.json");

                var outer = OuterWithAliases("invoice", null);
                var resolved = CreateAndTestRouterCommand.DiscoverInnerFromDir(outer, dir);

                Assert.That(resolved, Has.Count.EqualTo(1));
            }
            finally
            {
                Directory.Delete(dir, recursive: true);
            }
        }

        [Test]
        public void DiscoverInnerFromDir_MissingAliases_ThrowsWithEveryName()
        {
            var dir = MakeTempDir();
            try
            {
                WriteEmptyJson(dir, "invoice.json");

                var outer = OuterWithAliases("invoice", "bank_statement", "loan_application");
                var ex = Assert.Throws<System.InvalidOperationException>(
                    () => CreateAndTestRouterCommand.DiscoverInnerFromDir(outer, dir));

                Assert.That(ex!.Message, Does.Contain("bank_statement"));
                Assert.That(ex.Message, Does.Contain("loan_application"));
                // The resolved alias should NOT appear in the missing list.
                Assert.That(ex.Message, Does.Not.Contain("[invoice"));
            }
            finally
            {
                Directory.Delete(dir, recursive: true);
            }
        }

        [Test]
        public void DiscoverInnerFromDir_UnrelatedJsonFilesIgnored()
        {
            var dir = MakeTempDir();
            try
            {
                WriteEmptyJson(dir, "invoice.json");
                WriteEmptyJson(dir, "notes.json");
                WriteEmptyJson(dir, "settings.json");

                var resolved = CreateAndTestRouterCommand.DiscoverInnerFromDir(OuterWithAliases("invoice"), dir);
                Assert.That(resolved, Has.Count.EqualTo(1));
                Assert.That(resolved["invoice"], Is.EqualTo(Path.Combine(dir, "invoice.json")));
            }
            finally
            {
                Directory.Delete(dir, recursive: true);
            }
        }

        [Test]
        public void DiscoverInnerFromDir_NonExistentDir_Throws()
        {
            var missing = Path.Combine(Path.GetTempPath(), "definitely-not-there-" + Path.GetRandomFileName());
            var outer = OuterWithAliases("invoice");
            var ex = Assert.Throws<System.InvalidOperationException>(
                () => CreateAndTestRouterCommand.DiscoverInnerFromDir(outer, missing));
            Assert.That(ex!.Message, Does.Contain("--schema-dir is not a directory"));
        }
    }
}
