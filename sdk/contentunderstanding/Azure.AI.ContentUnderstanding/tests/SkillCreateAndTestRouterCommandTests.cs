// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;
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
    }
}
