// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class DateTimeOffsetParserTests
    {
        [Test]
        public void TestParserCanParseUtcDateTime()
        {
            var input = "2022-05-13T16:59:04.531199+00:00";
            var sampleAsDateTimeOffset = DateTimeOffsetParser.ParseAndGetDateTimeOffset(input);

            Assert.NotNull(sampleAsDateTimeOffset);
            Assert.AreEqual(new TimeSpan(0,0,0), sampleAsDateTimeOffset.Offset);
        }

        [Test]
        public void TestParserCanParseDateTimeWithOffset()
        {
            var input = "2022-05-13T12:30:39.0516617-07:00";
            var sampleAsDateTimeOffset = DateTimeOffsetParser.ParseAndGetDateTimeOffset(input);

            Assert.NotNull(sampleAsDateTimeOffset);
            Assert.AreEqual(new TimeSpan(0, 0, 0), sampleAsDateTimeOffset.Offset);
        }

        [Test]
        public void TestParserCanParseIsoDateTimeFormat()
        {
            var input = "2022-05-13T16:59:04.531199Z";
            var sampleAsDateTimeOffset = DateTimeOffsetParser.ParseAndGetDateTimeOffset(input);

            Assert.NotNull(sampleAsDateTimeOffset);
            Assert.AreEqual(new TimeSpan(0, 0, 0), sampleAsDateTimeOffset.Offset);
        }
    }
}
