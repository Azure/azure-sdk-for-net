// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class AnalyzeTextOptionsTests
    {
        [Test]
        public void RequiresText()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new AnalyzeTextOptions(null, LexicalTokenizerName.Whitespace));
            Assert.AreEqual("text", ex.ParamName);
        }
    }
}
