// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class UtilitiesTests
    {
        public static IEnumerable<TestCaseData> GenerateRoomFilterTestCases()
        {
            const string ns = "ns/";

            yield return new TestCaseData(ns, null, null, false).Returns(string.Empty);
            yield return new TestCaseData(ns, null, null, true).Returns("'0~bnMv~' in groups");
            yield return new TestCaseData(ns, new[] { "g1" }, null, false).Returns("'0~bnMv~ZzE' in groups");
            yield return new TestCaseData(ns, new[] { "g1" }, null, true).Returns("'0~bnMv~ZzE' in groups");
            yield return new TestCaseData(ns, null, new[] { "g1" }, false).Returns("not ('0~bnMv~ZzE' in groups)");
            yield return new TestCaseData(ns, null, new[] { "g1" }, true).Returns("'0~bnMv~' in groups and not ('0~bnMv~ZzE' in groups)");
            yield return new TestCaseData(ns, new[] { "g1", "g2" }, null, false).Returns("'0~bnMv~ZzE' in groups or '0~bnMv~ZzI' in groups");
            yield return new TestCaseData(ns, null, new[] { "g1", "g2" }, false).Returns("not ('0~bnMv~ZzE' in groups) and not ('0~bnMv~ZzI' in groups)");
            yield return new TestCaseData(ns, new[] { "g1", "g2" }, new[] { "g3", "g4" }, false).Returns("'0~bnMv~ZzE' in groups or '0~bnMv~ZzI' in groups and not ('0~bnMv~ZzM' in groups) and not ('0~bnMv~ZzQ' in groups)");
        }

        [TestCaseSource(nameof(GenerateRoomFilterTestCases))]
        public string GenerateRoomFilter(string @namespace, IList<string> rooms, IList<string> exceptRooms, bool containsNamespace)
        {
            return Utilities.GenerateRoomFilter(@namespace, rooms, exceptRooms, containsNamespace);
        }
    }
}
