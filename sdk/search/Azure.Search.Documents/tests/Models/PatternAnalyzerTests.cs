// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class PatternAnalyzerTests
    {
        [TestCaseSource(nameof(RoundtripsRegexFlagsData))]
        public void RoundtripsRegexFlags(PatternAnalyzer expected)
        {
            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<PatternAnalyzer>)expected).Write(writer, ModelReaderWriterOptions.Json);
            }

            using JsonDocument doc = JsonDocument.Parse(stream.ToArray());
            PatternAnalyzer actual = LexicalAnalyzer.DeserializeLexicalAnalyzer(doc.RootElement, ModelReaderWriterOptions.Json) as PatternAnalyzer;

            CollectionAssert.AreEqual(expected.Flags, actual?.Flags);
        }

        private static IEnumerable<PatternAnalyzer> RoundtripsRegexFlagsData
        {
            get
            {
                yield return new PatternAnalyzer("test");
                yield return new PatternAnalyzer("test")
                {
                    Flags =
                    {
                        RegexFlag.CaseInsensitive,
                    }
                };
                yield return new PatternAnalyzer("test")
                {
                    Flags =
                    {
                        RegexFlag.CaseInsensitive,
                        RegexFlag.Literal
                    }
                };
            }
        }
    }
}
