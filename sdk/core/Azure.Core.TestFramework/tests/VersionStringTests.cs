// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    public class VersionStringTests
    {
        [TestCase("2020-01-01", "2020-01-01", 0)]
        [TestCase("2020-01-02", "2020-01-01", 1)]
        [TestCase("2020-01-01", "2020-01-02", -1)]
        [TestCase("2020-01-01-alpha", "2020-01-01-alpha", 0)]
        [TestCase("2020-01-01", "2020-01-01-alpha", 1)]
        [TestCase("2020-01-01-beta", "2020-01-01-alpha", 1)]
        [TestCase("2020-01-01-alpha", "2020-01-01", -1)]
        [TestCase("2020-01-01-alpha", "2020-01-01-beta", -1)]
        public void CompareTo(string left, string right, int expected)
        {
            VersionString vLeft = new VersionString(left);
            VersionString vRight = new VersionString(right);
            Assert.AreEqual(expected, vLeft.CompareTo(vRight));
        }
    }
}
