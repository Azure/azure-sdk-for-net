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
        private static readonly string SomeDoubleRoundTrip = XmlConvert.ToString(SomeDouble);
        private const long SomeInt64 = long.MaxValue;
        private const string SomeString = "someString";
        private const string StringWithSingleQuotes = "so'meS'tri'ng";
        private const bool SomeTrueBool = true;
        private const bool SomeFalseBool = false;
        private static readonly DateTime s_someDateTime = DateTime.Parse("2020-07-23T21:20:41.6667782Z", null, System.Globalization.DateTimeStyles.RoundtripKind);
        private static readonly DateTimeOffset s_someDateTimeOffset = DateTimeOffset.Parse("2020-07-23T21:20:41.6667782Z");
        private static string s_someDateTimeOffsetRoundtrip = XmlConvert.ToString(s_someDateTimeOffset.UtcDateTime, XmlDateTimeSerializationMode.RoundtripKind);
        private static readonly Guid s_someGuid = new Guid("66cf3753-1cc9-44c4-b857-4546f744901b");
        private static readonly string s_someGuidString = "66cf3753-1cc9-44c4-b857-4546f744901b";

        private static readonly byte[] s_someBinary = new byte[] { 0xFF, 0x02, 0x03, 0x04 };

        private static readonly BinaryData s_someBinaryData = new BinaryData(new byte[]
        {
            0xFF, 0x02, 0x03, 0x04,
        });

        public static object[] QueryFilterTestCases =
        {
            new object[] { TableOdataFilter.Create($"String ge {SomeString}"), $"String ge '{SomeString}'" },
            new object[] { TableOdataFilter.Create($"String ge {StringWithSingleQuotes}"), $"String ge 'so''meS''tri''ng'" },
            new object[] { TableOdataFilter.Create($"Guid eq {s_someGuid}"), $"Guid eq guid'{s_someGuidString}'" },
            new object[] { TableOdataFilter.Create($"Int64 ge {SomeInt64}"), $"Int64 ge {SomeInt64}L" },
            new object[] { TableOdataFilter.Create($"Double ge {SomeDouble}"), $"Double ge {SomeDoubleRoundTrip}" },
            new object[] { TableOdataFilter.Create($"Int32 ge {SomeInt}"), $"Int32 ge {SomeInt}" },
            new object[] { TableOdataFilter.Create($"DateTimeOffset ge {s_someDateTimeOffset}"), $"DateTimeOffset ge datetime'{s_someDateTimeOffsetRoundtrip}'" },
            new object[] { TableOdataFilter.Create($"DateTime lt {s_someDateTime}"), $"DateTime lt datetime'{s_someDateTimeOffsetRoundtrip}'" },
            new object[] { TableOdataFilter.Create($"Bool eq {SomeTrueBool}"), "Bool eq true" },
            new object[] { TableOdataFilter.Create($"Bool eq {SomeFalseBool}"), "Bool eq false" },
            new object[] { TableOdataFilter.Create($"Binary eq { s_someBinary}"), $"Binary eq X'{string.Join(string.Empty, s_someBinary.Select(b => b.ToString("X2")))}'" },
            new object[] { TableOdataFilter.Create($"Binary eq {s_someBinaryData}"), $"Binary eq X'{string.Join(string.Empty, s_someBinaryData.ToArray().Select(b => b.ToString("X2")))}'" }
        };

        [Test]
        [TestCaseSource(nameof(QueryFilterTestCases))]
        public void QueryFilterTest(string actualFilter, string expected)
        {
            Assert.AreEqual(expected, actualFilter);
        }
    }
}
