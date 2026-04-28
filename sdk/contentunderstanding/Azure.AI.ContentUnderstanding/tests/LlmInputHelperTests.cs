// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using Azure;
using Azure.AI.ContentUnderstanding;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="LlmInputHelper.ToLlmInput"/>.
    /// </summary>
    [TestFixture]
    public class LlmInputHelperTests
    {
        // ---------------------------------------------------------------
        // Basic input validation
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_NullResult_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => LlmInputHelper.ToLlmInput(null!));
        }

        [Test]
        public void ToLlmInput_EmptyContents_ReturnsEmptyString()
        {
            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new List<AnalysisContent>());

            Assert.AreEqual(string.Empty, LlmInputHelper.ToLlmInput(result));
        }

        // ---------------------------------------------------------------
        // Single document
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_SingleDocument_WithFieldsAndMarkdown()
        {
            var fields = new Dictionary<string, ContentField>
            {
                ["VendorName"] = ContentUnderstandingModelFactory.ContentStringField(value: "CONTOSO LTD."),
                ["InvoiceDate"] = ContentUnderstandingModelFactory.ContentStringField(value: "2019-11-15"),
            };

            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "CONTOSO LTD.\n\n# INVOICE",
                fields: fields,
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("contentType: document"));
            Assert.That(output, Does.Contain("VendorName: CONTOSO LTD."));
            Assert.That(output, Does.Contain("InvoiceDate: '2019-11-15'"));
            Assert.That(output, Does.Contain("pages: 1"));
            Assert.That(output, Does.Contain("CONTOSO LTD."));
            Assert.That(output, Does.Contain("# INVOICE"));
        }

        [Test]
        public void ToLlmInput_SingleDocument_FieldsOnly()
        {
            var fields = new Dictionary<string, ContentField>
            {
                ["VendorName"] = ContentUnderstandingModelFactory.ContentStringField(value: "CONTOSO LTD."),
            };

            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Some markdown",
                fields: fields,
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result, includeMarkdown: false);

            Assert.That(output, Does.Contain("VendorName: CONTOSO LTD."));
            Assert.That(output, Does.Not.Contain("Some markdown"));
        }

        [Test]
        public void ToLlmInput_SingleDocument_MarkdownOnly()
        {
            var fields = new Dictionary<string, ContentField>
            {
                ["VendorName"] = ContentUnderstandingModelFactory.ContentStringField(value: "CONTOSO LTD."),
            };

            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Some markdown",
                fields: fields,
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result, includeFields: false);

            Assert.That(output, Does.Not.Contain("VendorName"));
            Assert.That(output, Does.Contain("Some markdown"));
        }

        // ---------------------------------------------------------------
        // Metadata
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_WithMetadata_IncludesAfterContentType()
        {
            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "text",
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            var metadata = new Dictionary<string, object>
            {
                ["source"] = "invoice.pdf",
                ["department"] = "finance"
            };

            string output = LlmInputHelper.ToLlmInput(result, metadata: metadata);

            Assert.That(output, Does.Contain("source: invoice.pdf"));
            Assert.That(output, Does.Contain("department: finance"));
            // metadata should appear after contentType
            int ctIdx = output.IndexOf("contentType:");
            int srcIdx = output.IndexOf("source:");
            Assert.That(srcIdx, Is.GreaterThan(ctIdx));
        }

        [TestCase("contentType")]
        [TestCase("timeRange")]
        [TestCase("category")]
        [TestCase("pages")]
        [TestCase("fields")]
        [TestCase("rai_warnings")]
        public void ToLlmInput_WithReservedMetadataKey_ThrowsArgumentException(string reservedKey)
        {
            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "text",
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            var metadata = new Dictionary<string, object>
            {
                [reservedKey] = "custom"
            };

            ArgumentException? ex = Assert.Throws<ArgumentException>(() => LlmInputHelper.ToLlmInput(result, metadata: metadata));

            Assert.That(ex!.ParamName, Is.EqualTo("metadata"));
            Assert.That(ex.Message, Does.Contain("reserved front matter key"));
            Assert.That(ex.Message, Does.Contain(reservedKey));
        }

        // ---------------------------------------------------------------
        // Multi-page document
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_MultiPageDocument_ShowsPageRange()
        {
            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Page 1 text\n\n<!-- PageBreak -->\n\nPage 2 text",
                startPageNumber: 1,
                endPageNumber: 2);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("pages: 1-2"));
            Assert.That(output, Does.Contain("<!-- page 1 -->"));
            Assert.That(output, Does.Contain("<!-- page 2 -->"));
            Assert.That(output, Does.Not.Contain("<!-- PageBreak -->"));
        }

        [Test]
        public void ToLlmInput_PageMarkersFromSpans()
        {
            var page1 = ContentUnderstandingModelFactory.DocumentPage(
                pageNumber: 1,
                spans: new[] { ContentUnderstandingModelFactory.ContentSpan(offset: 0, length: 10) });
            var page2 = ContentUnderstandingModelFactory.DocumentPage(
                pageNumber: 2,
                spans: new[] { ContentUnderstandingModelFactory.ContentSpan(offset: 30, length: 10) });

            string markdown = "Page 1 text\n\n<!-- PageBreak -->\n\nPage 2 text";

            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: markdown,
                startPageNumber: 1,
                endPageNumber: 2,
                pages: new[] { page1, page2 });

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("<!-- page 1 -->"));
            Assert.That(output, Does.Contain("<!-- page 2 -->"));
            Assert.That(output, Does.Not.Contain("<!-- PageBreak -->"));
        }

        // ---------------------------------------------------------------
        // Audio/Visual content
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_SingleAudioVisual_NoTimeRange()
        {
            var fields = new Dictionary<string, ContentField>
            {
                ["Summary"] = ContentUnderstandingModelFactory.ContentStringField(value: "A short call."),
            };

            var content = ContentUnderstandingModelFactory.AudioVisualContent(
                mimeType: "audio/wav",
                markdown: "Speaker 1: Hello",
                fields: fields,
                startTimeMsValue: 0,
                endTimeMsValue: 23000);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("contentType: audioVisual"));
            Assert.That(output, Does.Contain("Summary: A short call."));
            // Single segment shouldn't have timeRange
            Assert.That(output, Does.Not.Contain("timeRange"));
        }

        [Test]
        public void ToLlmInput_MultiSegmentAudioVisual_IncludesTimeRange()
        {
            var seg1 = ContentUnderstandingModelFactory.AudioVisualContent(
                mimeType: "video/mp4",
                markdown: "Speaker 1: Opening...",
                startTimeMsValue: 0,
                endTimeMsValue: 23000);

            var seg2 = ContentUnderstandingModelFactory.AudioVisualContent(
                mimeType: "video/mp4",
                markdown: "Speaker 3: Continuing...",
                startTimeMsValue: 24000,
                endTimeMsValue: 43000);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new AnalysisContent[] { seg1, seg2 });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("timeRange: 00:00 \u2013 00:23"));
            Assert.That(output, Does.Contain("timeRange: 00:24 \u2013 00:43"));
            Assert.That(output, Does.Contain("*****"));
        }

        [Test]
        public void ToLlmInput_MultiSegmentAudioVisual_PreservesInputOrder()
        {
            var seg1 = ContentUnderstandingModelFactory.AudioVisualContent(
                mimeType: "video/mp4",
                markdown: "Input first, later in time.",
                startTimeMsValue: 60000,
                endTimeMsValue: 70000);

            var seg2 = ContentUnderstandingModelFactory.AudioVisualContent(
                mimeType: "video/mp4",
                markdown: "Input second, earlier in time.",
                startTimeMsValue: 0,
                endTimeMsValue: 10000);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new AnalysisContent[] { seg1, seg2 });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output.IndexOf("Input first, later in time.", StringComparison.Ordinal),
                Is.LessThan(output.IndexOf("Input second, earlier in time.", StringComparison.Ordinal)));
        }

        // ---------------------------------------------------------------
        // Document classification
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_Classification_SkipsParentRendersChildren()
        {
            // Parent: has segments, no category
            var parent = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Full document text (should be skipped)",
                startPageNumber: 1,
                endPageNumber: 3,
                segments: new[]
                {
                    ContentUnderstandingModelFactory.DocumentContentSegment(
                        segmentId: "seg1",
                        category: "Invoice",
                        span: ContentUnderstandingModelFactory.ContentSpan(offset: 0, length: 10),
                        startPageNumber: 1,
                        endPageNumber: 1)
                });

            // Child 1: has category
            var child1 = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Invoice content",
                category: "Invoice",
                startPageNumber: 1,
                endPageNumber: 1);

            // Child 2: has category
            var child2 = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Bank statement content",
                category: "BankStatement",
                startPageNumber: 2,
                endPageNumber: 3);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new AnalysisContent[] { parent, child1, child2 });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Not.Contain("Full document text (should be skipped)"));
            Assert.That(output, Does.Contain("category: Invoice"));
            Assert.That(output, Does.Contain("category: BankStatement"));
            Assert.That(output, Does.Contain("Invoice content"));
            Assert.That(output, Does.Contain("Bank statement content"));
            Assert.That(output, Does.Contain("*****"));
        }

        // ---------------------------------------------------------------
        // Field resolution
        // ---------------------------------------------------------------

        [Test]
        public void ResolveFields_NestedObject()
        {
            var innerFields = new Dictionary<string, ContentField>
            {
                ["Amount"] = ContentUnderstandingModelFactory.ContentNumberField(value: 165.0),
                ["CurrencyCode"] = ContentUnderstandingModelFactory.ContentStringField(value: "USD"),
            };

            var fields = new Dictionary<string, ContentField>
            {
                ["TotalAmount"] = ContentUnderstandingModelFactory.ContentObjectField(value: innerFields),
            };

            var resolved = LlmInputHelper.ResolveFields(fields);

            Assert.That(resolved.ContainsKey("TotalAmount"));
            var total = resolved["TotalAmount"] as Dictionary<string, object>;
            Assert.IsNotNull(total);
            Assert.AreEqual(165L, total!["Amount"]); // double 165.0 resolved as long by int check
            Assert.AreEqual("USD", total["CurrencyCode"]);
        }

        [Test]
        public void ResolveFields_Array()
        {
            var arrItems = new List<ContentField>
            {
                ContentUnderstandingModelFactory.ContentStringField(value: "Topic A"),
                ContentUnderstandingModelFactory.ContentStringField(value: "Topic B"),
            };

            var fields = new Dictionary<string, ContentField>
            {
                ["Topics"] = ContentUnderstandingModelFactory.ContentArrayField(value: arrItems),
            };

            var resolved = LlmInputHelper.ResolveFields(fields);

            Assert.That(resolved.ContainsKey("Topics"));
            var topics = resolved["Topics"] as List<object>;
            Assert.IsNotNull(topics);
            Assert.AreEqual(2, topics!.Count);
            Assert.AreEqual("Topic A", topics[0]);
            Assert.AreEqual("Topic B", topics[1]);
        }

        [Test]
        public void ResolveFields_NullValueSkipped()
        {
            var fields = new Dictionary<string, ContentField>
            {
                ["Present"] = ContentUnderstandingModelFactory.ContentStringField(value: "exists"),
                ["Missing"] = ContentUnderstandingModelFactory.ContentStringField(value: null),
            };

            var resolved = LlmInputHelper.ResolveFields(fields);

            Assert.That(resolved.ContainsKey("Present"));
            Assert.That(!resolved.ContainsKey("Missing"));
        }

        [Test]
        public void ResolveFields_DateConverted()
        {
            var dto = new DateTimeOffset(2019, 11, 15, 0, 0, 0, TimeSpan.Zero);
            var fields = new Dictionary<string, ContentField>
            {
                ["InvoiceDate"] = ContentUnderstandingModelFactory.ContentDateTimeOffsetField(value: dto),
            };

            var resolved = LlmInputHelper.ResolveFields(fields);

            Assert.AreEqual("2019-11-15", resolved["InvoiceDate"]);
        }

        [Test]
        public void ResolveFields_TimeConverted()
        {
            var ts = new TimeSpan(14, 30, 0);
            var fields = new Dictionary<string, ContentField>
            {
                ["MeetingTime"] = ContentUnderstandingModelFactory.ContentTimeField(value: ts),
            };

            var resolved = LlmInputHelper.ResolveFields(fields);

            Assert.AreEqual("14:30:00", resolved["MeetingTime"]);
        }

        [Test]
        public void ResolveFields_BooleanField()
        {
            var fields = new Dictionary<string, ContentField>
            {
                ["IsVerified"] = ContentUnderstandingModelFactory.ContentBooleanField(value: true),
            };

            var resolved = LlmInputHelper.ResolveFields(fields);

            Assert.AreEqual(true, resolved["IsVerified"]);
        }

        [Test]
        public void ResolveFields_IntegerField()
        {
            var fields = new Dictionary<string, ContentField>
            {
                ["Quantity"] = ContentUnderstandingModelFactory.ContentIntegerField(value: 42),
            };

            var resolved = LlmInputHelper.ResolveFields(fields);

            Assert.AreEqual(42L, resolved["Quantity"]);
        }

        [Test]
        public void ToLlmInput_JsonField_PreservesStructuredYaml()
        {
            var fields = new Dictionary<string, ContentField>
            {
                ["Data"] = ContentUnderstandingModelFactory.ContentJsonField(
                    value: BinaryData.FromString("{\"key\":\"val\",\"items\":[1,2],\"active\":true,\"nested\":{\"score\":3.5}}")),
            };

            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Text",
                fields: fields,
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("Data:"));
            Assert.That(output, Does.Contain("key: val"));
            Assert.That(output, Does.Contain("items:"));
            Assert.That(output, Does.Contain("- 1"));
            Assert.That(output, Does.Contain("- 2"));
            Assert.That(output, Does.Contain("active: true"));
            Assert.That(output, Does.Contain("nested:"));
            Assert.That(output, Does.Contain("score: 3.5"));
            Assert.That(output, Does.Not.Contain("'{\"key\":\"val\""));
        }

        // ---------------------------------------------------------------
        // YAML serialization
        // ---------------------------------------------------------------

        [Test]
        public void YamlScalar_QuotesBoolLikeStrings()
        {
            Assert.AreEqual("'true'", LlmInputHelper.YamlScalar("true"));
            Assert.AreEqual("'false'", LlmInputHelper.YamlScalar("false"));
            Assert.AreEqual("'yes'", LlmInputHelper.YamlScalar("yes"));
            Assert.AreEqual("'null'", LlmInputHelper.YamlScalar("null"));
        }

        [Test]
        public void YamlScalar_QuotesDateLikeStrings()
        {
            Assert.AreEqual("'2019-11-15'", LlmInputHelper.YamlScalar("2019-11-15"));
        }

        [Test]
        public void YamlScalar_QuotesNumberLikeStrings()
        {
            Assert.AreEqual("'123'", LlmInputHelper.YamlScalar("123"));
            Assert.AreEqual("'3.14'", LlmInputHelper.YamlScalar("3.14"));
        }

        [Test]
        public void YamlScalar_NoQuotesForPlainStrings()
        {
            Assert.AreEqual("hello", LlmInputHelper.YamlScalar("hello"));
            Assert.AreEqual("CONTOSO LTD.", LlmInputHelper.YamlScalar("CONTOSO LTD."));
        }

        [Test]
        public void YamlScalar_IntegerValue()
        {
            Assert.AreEqual("42", LlmInputHelper.YamlScalar(42));
        }

        [Test]
        public void YamlScalar_DoubleWholeValue()
        {
            Assert.AreEqual("165", LlmInputHelper.YamlScalar(165.0));
        }

        [Test]
        public void YamlScalar_DoubleDecimalValue()
        {
            Assert.AreEqual("3.14", LlmInputHelper.YamlScalar(3.14));
        }

        [Test]
        public void YamlScalar_BoolValue()
        {
            Assert.AreEqual("true", LlmInputHelper.YamlScalar(true));
            Assert.AreEqual("false", LlmInputHelper.YamlScalar(false));
        }

        [Test]
        public void YamlScalar_InfinityAndNaN()
        {
            // Should not crash, just produce string representation
            string inf = LlmInputHelper.YamlScalar(double.PositiveInfinity);
            Assert.That(inf, Does.Contain("Infinity").IgnoreCase);

            string nan = LlmInputHelper.YamlScalar(double.NaN);
            Assert.That(nan, Does.Contain("NaN").IgnoreCase);
        }

        [Test]
        public void YamlScalar_QuotesSpecialStart()
        {
            Assert.AreEqual("'- item'", LlmInputHelper.YamlScalar("- item"));
            Assert.AreEqual("'# comment'", LlmInputHelper.YamlScalar("# comment"));
        }

        [Test]
        public void YamlScalar_QuotesEmptyString()
        {
            Assert.AreEqual("''", LlmInputHelper.YamlScalar(""));
        }

        // ---------------------------------------------------------------
        // RAI warnings
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_WithWarnings_IncludesRaiWarnings()
        {
            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Some text",
                startPageNumber: 1,
                endPageNumber: 1);

            var warnings = new List<ResponseError>
            {
                new ResponseError("hate", "Content flagged for harmful language."),
            };

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content },
                warnings: warnings);

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("rai_warnings:"));
            Assert.That(output, Does.Contain("code: hate"));
            Assert.That(output, Does.Contain("message: Content flagged for harmful language."));
        }

        [Test]
        public void ToLlmInput_WithWarningsAndBothIncludeFlagsFalse_StillIncludesRaiWarnings()
        {
            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Some text",
                fields: new Dictionary<string, ContentField>
                {
                    ["Name"] = ContentUnderstandingModelFactory.ContentStringField(value: "Test"),
                },
                startPageNumber: 1,
                endPageNumber: 1);

            var warnings = new List<ResponseError>
            {
                new ResponseError("hate", "Content flagged for harmful language."),
            };

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content },
                warnings: warnings);

            string output = LlmInputHelper.ToLlmInput(result, includeFields: false, includeMarkdown: false);

            Assert.That(output, Does.Contain("rai_warnings:"));
            Assert.That(output, Does.Contain("code: hate"));
            Assert.That(output, Does.Not.Contain("Name: Test"));
            Assert.That(output, Does.Not.Contain("Some text"));
        }

        // ---------------------------------------------------------------
        // No fields, no markdown
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_NoFields_StillHasContentType()
        {
            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Some text",
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("contentType: document"));
            Assert.That(output, Does.Not.Contain("fields:"));
        }

        [Test]
        public void ToLlmInput_NoMarkdown_FrontMatterOnly()
        {
            var fields = new Dictionary<string, ContentField>
            {
                ["Name"] = ContentUnderstandingModelFactory.ContentStringField(value: "Test"),
            };

            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                fields: fields,
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("fields:"));
            Assert.That(output, Does.Contain("Name: Test"));
            // Should end with closing ---
            Assert.That(output.TrimEnd(), Does.EndWith("---"));
        }

        [Test]
        public void ToLlmInput_IncludeFieldsFalseAndIncludeMarkdownFalse_RendersFrontMatterOnly()
        {
            var fields = new Dictionary<string, ContentField>
            {
                ["Name"] = ContentUnderstandingModelFactory.ContentStringField(value: "Test"),
            };

            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Some text",
                fields: fields,
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result, includeFields: false, includeMarkdown: false);

            Assert.That(output, Does.Contain("contentType: document"));
            Assert.That(output, Does.Contain("pages: 1"));
            Assert.That(output, Does.Not.Contain("fields:"));
            Assert.That(output, Does.Not.Contain("Name: Test"));
            Assert.That(output, Does.Not.Contain("Some text"));
            Assert.That(output.TrimEnd(), Does.EndWith("---"));
        }

        // ---------------------------------------------------------------
        // Nested object in YAML output
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_NestedObjectField_InYaml()
        {
            var innerFields = new Dictionary<string, ContentField>
            {
                ["Amount"] = ContentUnderstandingModelFactory.ContentNumberField(value: 165.0),
                ["CurrencyCode"] = ContentUnderstandingModelFactory.ContentStringField(value: "USD"),
            };

            var fields = new Dictionary<string, ContentField>
            {
                ["TotalAmount"] = ContentUnderstandingModelFactory.ContentObjectField(value: innerFields),
            };

            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Text",
                fields: fields,
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("TotalAmount:"));
            Assert.That(output, Does.Contain("Amount: 165"));
            Assert.That(output, Does.Contain("CurrencyCode: USD"));
        }

        [Test]
        public void ToLlmInput_ArrayField_InYaml()
        {
            var arrItems = new List<ContentField>
            {
                ContentUnderstandingModelFactory.ContentStringField(value: "Topic A"),
                ContentUnderstandingModelFactory.ContentStringField(value: "Topic B"),
            };

            var fields = new Dictionary<string, ContentField>
            {
                ["Topics"] = ContentUnderstandingModelFactory.ContentArrayField(value: arrItems),
            };

            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Text",
                fields: fields,
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("Topics:"));
            Assert.That(output, Does.Contain("- Topic A"));
            Assert.That(output, Does.Contain("- Topic B"));
        }

        // ---------------------------------------------------------------
        // Time range formatting
        // ---------------------------------------------------------------

        [Test]
        public void FormatTimeRange_FormatsCorrectly()
        {
            string range = LlmInputHelper.FormatTimeRange(TimeSpan.Zero, TimeSpan.FromSeconds(23));
            Assert.AreEqual("00:00 \u2013 00:23", range);
        }

        [Test]
        public void FormatTimeRange_LargeValues()
        {
            string range = LlmInputHelper.FormatTimeRange(
                TimeSpan.FromMinutes(5),
                TimeSpan.FromMinutes(10) + TimeSpan.FromSeconds(30));
            Assert.AreEqual("05:00 \u2013 10:30", range);
        }

        // ---------------------------------------------------------------
        // ContentUnderstandingModelFactory.DocumentContentSegment builder
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_ClassificationWithFields()
        {
            var parentFields = new Dictionary<string, ContentField>
            {
                ["ParentField"] = ContentUnderstandingModelFactory.ContentStringField(value: "should be skipped"),
            };

            var parent = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Full text",
                fields: parentFields,
                startPageNumber: 1,
                endPageNumber: 2,
                segments: new[]
                {
                    ContentUnderstandingModelFactory.DocumentContentSegment(
                        segmentId: "seg1",
                        category: "Invoice",
                        span: ContentUnderstandingModelFactory.ContentSpan(offset: 0, length: 5),
                        startPageNumber: 1,
                        endPageNumber: 1)
                });

            var childFields = new Dictionary<string, ContentField>
            {
                ["ChildField"] = ContentUnderstandingModelFactory.ContentStringField(value: "present"),
            };

            var child = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Invoice text",
                fields: childFields,
                category: "Invoice",
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new AnalysisContent[] { parent, child });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("ChildField: present"));
            Assert.That(output, Does.Not.Contain("ParentField"));
            Assert.That(output, Does.Not.Contain("should be skipped"));
        }

        // ---------------------------------------------------------------
        // Edge: single-page shows int value
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_SinglePage_PagesIsInt()
        {
            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "text",
                startPageNumber: 3,
                endPageNumber: 3);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("pages: 3"));
        }

        // ---------------------------------------------------------------
        // Front matter structure
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_FrontMatterStructure()
        {
            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "text",
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            // Should start with --- and end front matter with ---
            Assert.That(output, Does.StartWith("---\n"));
            Assert.That(output, Does.Contain("\n---\n"));
        }

        // ---------------------------------------------------------------
        // Block separator
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_MultipleContents_SeparatedByStars()
        {
            var content1 = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "First",
                startPageNumber: 1,
                endPageNumber: 1,
                category: "A");

            var content2 = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Second",
                startPageNumber: 2,
                endPageNumber: 2,
                category: "B");

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new AnalysisContent[] { content1, content2 });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("\n\n*****\n\n"));
        }

        [Test]
        public void ToLlmInput_NonClassificationDocuments_PreservesInputOrder()
        {
            var content1 = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Page two content appears first in service order.",
                startPageNumber: 2,
                endPageNumber: 2);

            var content2 = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "Page one content appears second in service order.",
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new AnalysisContent[] { content1, content2 });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output.IndexOf("Page two content appears first in service order.", StringComparison.Ordinal),
                Is.LessThan(output.IndexOf("Page one content appears second in service order.", StringComparison.Ordinal)));
        }

        // ---------------------------------------------------------------
        // Classification: parent segment expansion
        // ---------------------------------------------------------------

        [Test]
        public void ToLlmInput_NoRouting_ExpandsAllSegments()
        {
            // No top-level children — all segments expanded from parent.
            var parent = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                path: "input1",
                markdown: "Invoice text.\n\nBank text.",
                startPageNumber: 1,
                endPageNumber: 3,
                segments: new[]
                {
                    ContentUnderstandingModelFactory.DocumentContentSegment(
                        segmentId: "segment1", category: "Invoice",
                        span: ContentUnderstandingModelFactory.ContentSpan(offset: 0, length: 13),
                        startPageNumber: 1, endPageNumber: 1),
                    ContentUnderstandingModelFactory.DocumentContentSegment(
                        segmentId: "segment2", category: "BankStatement",
                        span: ContentUnderstandingModelFactory.ContentSpan(offset: 15, length: 10),
                        startPageNumber: 2, endPageNumber: 3),
                });

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new AnalysisContent[] { parent });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("category: Invoice"));
            Assert.That(output, Does.Contain("category: BankStatement"));
            Assert.That(output, Does.Contain("Invoice text."));
            Assert.That(output, Does.Contain("Bank text."));
            Assert.That(output, Does.Contain("*****"));
        }

        [Test]
        public void ToLlmInput_PartialRouting_MixesExpandedAndRouted()
        {
            // Only Invoice is routed; BankStatement expanded from parent.
            var parent = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                path: "input1",
                markdown: "Invoice text.\n\nBank text.",
                startPageNumber: 1,
                endPageNumber: 3,
                segments: new[]
                {
                    ContentUnderstandingModelFactory.DocumentContentSegment(
                        segmentId: "segment1", category: "Invoice",
                        span: ContentUnderstandingModelFactory.ContentSpan(offset: 0, length: 13),
                        startPageNumber: 1, endPageNumber: 1),
                    ContentUnderstandingModelFactory.DocumentContentSegment(
                        segmentId: "segment2", category: "BankStatement",
                        span: ContentUnderstandingModelFactory.ContentSpan(offset: 15, length: 10),
                        startPageNumber: 2, endPageNumber: 3),
                });

            var routedInvoice = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                path: "input1/segment1",
                category: "Invoice",
                markdown: "Invoice text.",
                fields: new Dictionary<string, ContentField>
                {
                    ["Vendor"] = ContentUnderstandingModelFactory.ContentStringField(value: "CONTOSO"),
                },
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new AnalysisContent[] { parent, routedInvoice });

            string output = LlmInputHelper.ToLlmInput(result);

            string[] blocks = output.Split(new[] { "*****" }, StringSplitOptions.None);
            Assert.AreEqual(2, blocks.Length);
            // Invoice block has fields (from routed content)
            Assert.That(output, Does.Contain("Vendor: CONTOSO"));
            // BankStatement block expanded from parent (no fields)
            Assert.That(output, Does.Contain("category: BankStatement"));
            Assert.That(output, Does.Contain("Bank text."));
        }

        [Test]
        public void ToLlmInput_OutputSortedByPageNumber()
        {
            // Routed content at end of contents list still appears first if on page 1.
            var parent = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                path: "input1",
                markdown: "Page1.\n\nPage2.\n\nPage3.",
                startPageNumber: 1,
                endPageNumber: 3,
                segments: new[]
                {
                    ContentUnderstandingModelFactory.DocumentContentSegment(
                        segmentId: "segment1", category: "TypeA",
                        span: ContentUnderstandingModelFactory.ContentSpan(offset: 0, length: 6),
                        startPageNumber: 1, endPageNumber: 1),
                    ContentUnderstandingModelFactory.DocumentContentSegment(
                        segmentId: "segment2", category: "TypeB",
                        span: ContentUnderstandingModelFactory.ContentSpan(offset: 8, length: 6),
                        startPageNumber: 2, endPageNumber: 2),
                    ContentUnderstandingModelFactory.DocumentContentSegment(
                        segmentId: "segment3", category: "TypeC",
                        span: ContentUnderstandingModelFactory.ContentSpan(offset: 16, length: 6),
                        startPageNumber: 3, endPageNumber: 3),
                });

            // Routed TypeA comes last in contents list
            var routed = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                path: "input1/segment1",
                category: "TypeA",
                markdown: "Page1.",
                fields: new Dictionary<string, ContentField>
                {
                    ["Key"] = ContentUnderstandingModelFactory.ContentStringField(value: "val"),
                },
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new AnalysisContent[] { parent, routed });

            string output = LlmInputHelper.ToLlmInput(result);

            string[] blocks = output.Split(new[] { "*****" }, StringSplitOptions.None);
            Assert.AreEqual(3, blocks.Length);
            // First block should be TypeA (page 1), not TypeB (page 2)
            Assert.That(blocks[0], Does.Contain("category: TypeA"));
            Assert.That(blocks[1], Does.Contain("category: TypeB"));
            Assert.That(blocks[2], Does.Contain("category: TypeC"));
        }

        [Test]
        public void ToLlmInput_PathBasedDeduplicationNotCategoryBased()
        {
            // Two segments with same category but different segment IDs — only the routed one is deduplicated.
            var parent = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                path: "input1",
                markdown: "Inv1.\n\nInv2.",
                startPageNumber: 1,
                endPageNumber: 2,
                segments: new[]
                {
                    ContentUnderstandingModelFactory.DocumentContentSegment(
                        segmentId: "segment1", category: "Invoice",
                        span: ContentUnderstandingModelFactory.ContentSpan(offset: 0, length: 5),
                        startPageNumber: 1, endPageNumber: 1),
                    ContentUnderstandingModelFactory.DocumentContentSegment(
                        segmentId: "segment2", category: "Invoice",
                        span: ContentUnderstandingModelFactory.ContentSpan(offset: 7, length: 5),
                        startPageNumber: 2, endPageNumber: 2),
                });

            // Only segment1 is routed
            var routed = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                path: "input1/segment1",
                category: "Invoice",
                markdown: "Inv1.",
                fields: new Dictionary<string, ContentField>
                {
                    ["Vendor"] = ContentUnderstandingModelFactory.ContentStringField(value: "A"),
                },
                startPageNumber: 1,
                endPageNumber: 1);

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new AnalysisContent[] { parent, routed });

            string output = LlmInputHelper.ToLlmInput(result);

            string[] blocks = output.Split(new[] { "*****" }, StringSplitOptions.None);
            // Should have 2 blocks: routed segment1 (with fields) + expanded segment2 (no fields)
            Assert.AreEqual(2, blocks.Length);
            Assert.That(blocks[0], Does.Contain("Vendor: A"));
            // Second block is expanded from parent — no fields
            Assert.That(blocks[1], Does.Contain("Inv2."));
            Assert.That(blocks[1], Does.Not.Contain("fields:"));
        }

        // ---------------------------------------------------------------
        // CompressPageNumbers
        // ---------------------------------------------------------------

        [Test]
        public void CompressPageNumbers_SinglePage()
        {
            Assert.AreEqual(1, LlmInputHelper.CompressPageNumbers(new List<int> { 1 }));
        }

        [Test]
        public void CompressPageNumbers_ContiguousRange()
        {
            Assert.AreEqual("1-3", LlmInputHelper.CompressPageNumbers(new List<int> { 1, 2, 3 }));
        }

        [Test]
        public void CompressPageNumbers_NonContiguous()
        {
            Assert.AreEqual("2-3, 5", LlmInputHelper.CompressPageNumbers(new List<int> { 2, 3, 5 }));
        }

        [Test]
        public void CompressPageNumbers_MixedRangesAndSingles()
        {
            Assert.AreEqual("1-3, 5, 7-9", LlmInputHelper.CompressPageNumbers(new List<int> { 1, 2, 3, 5, 7, 8, 9 }));
        }

        [Test]
        public void FormatPages_UsesPagesList_WhenAvailable()
        {
            // Non-contiguous pages: 2, 3, 5. Without pages list it would show "2-5".
            var content = ContentUnderstandingModelFactory.DocumentContent(
                mimeType: "application/pdf",
                markdown: "text",
                startPageNumber: 2,
                endPageNumber: 5,
                pages: new[]
                {
                    ContentUnderstandingModelFactory.DocumentPage(pageNumber: 2,
                        spans: new[] { ContentUnderstandingModelFactory.ContentSpan(offset: 0, length: 5) }),
                    ContentUnderstandingModelFactory.DocumentPage(pageNumber: 3,
                        spans: new[] { ContentUnderstandingModelFactory.ContentSpan(offset: 5, length: 5) }),
                    ContentUnderstandingModelFactory.DocumentPage(pageNumber: 5,
                        spans: new[] { ContentUnderstandingModelFactory.ContentSpan(offset: 10, length: 5) }),
                });

            var result = ContentUnderstandingModelFactory.AnalysisResult(
                contents: new[] { content });

            string output = LlmInputHelper.ToLlmInput(result);

            Assert.That(output, Does.Contain("pages: 2-3, 5"));
        }
    }
}
