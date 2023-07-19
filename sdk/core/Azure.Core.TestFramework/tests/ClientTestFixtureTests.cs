// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    public class ClientTestFixtureTests
    {
        private enum FakeVersion
        {
            /// <summary>
            /// The 2021-06-08 service version.
            /// </summary>
            V2021_06_08 = 1,

            /// <summary>
            /// The 2021-08-06 service version.
            /// </summary>
            V2021_08_06 = 2
        }

        [TestCase(new object[] { "2021-04-01", "2019-10-01" }, "2021-04-01")]
        [TestCase(new object[] { "2021-04-01", "2021-04-01-alpha.1", "2019-10-01" }, "2021-04-01")]
        [TestCase(new object[] { "2021-04-01", "2021-05-01-alpha.1", "2019-10-01" }, "2021-05-01-alpha.1")]
        [TestCase(new object[] { "2021-04-01", "2021-05-01-alpha.1", "2021-05-01-beta.1", "2019-10-01" }, "2021-05-01-beta.1")]
        [TestCase(new object[] { FakeVersion.V2021_08_06, FakeVersion.V2021_06_08 }, FakeVersion.V2021_08_06)]
        public void GetMax(object[] versions, object expected)
        {
            var fixture = new ClientTestFixtureAttribute(versions);
            var versionArray = fixture.GetType().GetField("_serviceVersions", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(fixture) as object[];
            var max = ClientTestFixtureAttribute.GetMax(versionArray);
            Assert.AreEqual(expected.ToString(), max.ToString());
        }

        [Test]
        public void GetMaxIntWithMix()
        {
            Assert.Throws<InvalidOperationException>(() => new ClientTestFixtureAttribute(new object[] { FakeVersion.V2021_08_06, "2021-04-01", FakeVersion.V2021_06_08 }));
        }

        [Test]
        public void GetMaxStringWithMix()
        {
            Assert.Throws<InvalidOperationException>(() => new ClientTestFixtureAttribute(new object[] { "2021-04-01", 1, "2019-10-01" }));
        }
    }
}
