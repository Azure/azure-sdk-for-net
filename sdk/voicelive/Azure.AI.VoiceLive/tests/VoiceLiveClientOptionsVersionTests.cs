// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    public class VoiceLiveClientOptionsVersionTests
    {
        [Test]
        public void DefaultServiceVersion_Is2026_07_15()
        {
            var options = new VoiceLiveClientOptions();
            var versionProperty = typeof(VoiceLiveClientOptions).GetProperty("Version", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.That(versionProperty, Is.Not.Null);
            var version = versionProperty!.GetValue(options) as string;
            Assert.That(version, Is.EqualTo("2026-07-15"));
        }

        [Test]
        public void ExplicitV2026_07_15_MapsToExpectedVersionString()
        {
            var options = new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_07_15);
            var versionProperty = typeof(VoiceLiveClientOptions).GetProperty("Version", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.That(versionProperty, Is.Not.Null);
            var version = versionProperty!.GetValue(options) as string;
            Assert.That(version, Is.EqualTo("2026-07-15"));
        }
    }
}
