// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Xml;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class QueryFilterTests
    {
        private const int SomeInt = 10;
        private const double SomeDouble = 10.10;
        private const long SomeInt64 = long.MaxValue;
        private const string SomeString = "someString";
        private const bool SomeTrueBool = true;
        private const bool SomeFalseBool = false;
        private static readonly DateTime s_someDateTime = DateTime.Parse("2020-07-23T21:20:41.6667782Z", null, System.Globalization.DateTimeStyles.RoundtripKind);
        private static readonly DateTimeOffset s_someDateTimeOffset = DateTimeOffset.Parse("2020-07-23T21:20:41.6667782Z");
        private static string s_someDateTimeOffsetRoundtrip = XmlConvert.ToString(s_someDateTimeOffset.UtcDateTime, XmlDateTimeSerializationMode.RoundtripKind);
        private static readonly Guid s_someGuid = new Guid("66cf3753-1cc9-44c4-b857-4546f744901b");
        private static readonly string s_someGuidString = "66cf3753-1cc9-44c4-b857-4546f744901b";

        private static readonly byte[] s_someBinary = new byte[] { 0x01, 0x02, 0x03, 0x04 };

        private static readonly BinaryData s_someBinaryData = new BinaryData(new byte[]
        {
            0x01, 0x02, 0x03, 0x04,
        });

        public static object[] QueryFilterTestCases =
        {
            new object[] { QueryFilter.Create($"String ge {SomeString}"), $"String ge '{SomeString}'" },
            new object[] { QueryFilter.Create($"Guid eq {s_someGuid}"), $"Guid eq guid'{s_someGuidString}'" },
            new object[] { QueryFilter.Create($"Int64 ge {SomeInt64}L"), $"Int64 ge {SomeInt64}L" },
            new object[] { QueryFilter.Create($"Double ge {SomeDouble}"), $"Double ge {SomeDouble}" },
            new object[] { QueryFilter.Create($"Int32 ge {SomeInt}"), $"Int32 ge {SomeInt}" },
            new object[] { QueryFilter.Create($"DateTimeOffset ge {s_someDateTimeOffset}"), $"DateTimeOffset ge datetime'{s_someDateTimeOffsetRoundtrip}'" },
            new object[] { QueryFilter.Create($"DateTime lt {s_someDateTime}"), $"DateTime lt datetime'{s_someDateTimeOffsetRoundtrip}'" },
            new object[] { QueryFilter.Create($"Bool eq {SomeTrueBool}"), "Bool eq true" },
            new object[] { QueryFilter.Create($"Bool eq {SomeFalseBool}"), "Bool eq false" },
            new object[] { QueryFilter.Create($"Binary eq { s_someBinary}"), $"Binary eq X'{string.Join(string.Empty, s_someBinary.Select(b => b.ToString("D2")))}'" },
            new object[] { QueryFilter.Create($"Binary eq {s_someBinaryData}"), $"Binary eq X'{string.Join(string.Empty, s_someBinaryData.ToArray().Select(b => b.ToString("D2")))}'" }
        };

        [Test]
        [TestCaseSource(nameof(QueryFilterTestCases))]
        public void QueryFilterTest(string actualFilter, string expected)
        {
            Assert.AreEqual(expected, actualFilter);
        }
    }
}
