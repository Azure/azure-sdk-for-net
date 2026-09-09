// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Compile-time and unit coverage for ModelFactory overload resolution.
    /// </summary>
    public class ContentUnderstandingModelFactoryTests
    {
        [Test]
        public void AnalysisContent_OmittedOptionalArgs_BindsWithoutAmbiguity()
        {
            Func<AnalysisContent> create = () => ContentUnderstandingModelFactory.AnalysisContent();
            Assert.IsNotNull(create);
        }

        [Test]
        public void AnalysisContent_NamedKind_BindsWithoutAmbiguity()
        {
            AnalysisContent content = ContentUnderstandingModelFactory.AnalysisContent(
                kind: "document",
                mimeType: "application/pdf");
            Assert.IsNotNull(content);
            Assert.AreEqual(AnalysisContentKind.Document, content.Kind);
            Assert.AreEqual("application/pdf", content.MimeType);
        }

        [Test]
        public void AnalysisContent_WithMetadata_UsesGeneratedOverload()
        {
            var metadata = new Dictionary<string, string> { ["Author"] = "Ada" };
            AnalysisContent content = ContentUnderstandingModelFactory.AnalysisContent(
                kind: "document",
                metadata: metadata);

            Assert.IsNotNull(content);
            Assert.AreEqual("Ada", content.Metadata!["Author"]);
        }

        [Test]
        public void AnalysisContent_CompatibilityOverload_AllArguments()
        {
            // Compatibility overload requires all seven arguments (no defaults) so it does not
            // compete with the generated overload that includes metadata.
            AnalysisContent content = ContentUnderstandingModelFactory.AnalysisContent(
                "document",
                "application/pdf",
                "prebuilt-layout",
                category: null,
                path: null,
                markdown: "# Title",
                fields: null);

            Assert.AreEqual(AnalysisContentKind.Document, content.Kind);
            Assert.AreEqual("application/pdf", content.MimeType);
            Assert.AreEqual("prebuilt-layout", content.AnalyzerId);
            Assert.AreEqual("# Title", content.Markdown);
        }
    }
}
