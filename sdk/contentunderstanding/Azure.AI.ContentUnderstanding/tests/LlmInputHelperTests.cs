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
    }
}
