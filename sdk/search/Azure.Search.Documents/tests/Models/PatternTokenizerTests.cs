// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class PatternTokenizerTests
    {
        [TestCaseSource(nameof(RoundtripsRegexFlagsData))]
        public void RoundtripsRegexFlags(PatternTokenizer expected)
        {
            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IUtf8JsonSerializable)expected).Write(writer);
            }

            using JsonDocument doc = JsonDocument.Parse(stream.ToArray());
            PatternTokenizer actual = LexicalTokenizer.DeserializeLexicalTokenizer(doc.RootElement) as PatternTokenizer;

            CollectionAssert.AreEqual(expected.Flags, actual?.Flags);
        }

        private static IEnumerable<PatternTokenizer> RoundtripsRegexFlagsData
        {
            get
            {
                yield return new PatternTokenizer("test");
                yield return new PatternTokenizer("test")
                {
                    Flags =
                    {
                        RegexFlag.CaseInsensitive,
                    }
                };
                yield return new PatternTokenizer("test")
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
