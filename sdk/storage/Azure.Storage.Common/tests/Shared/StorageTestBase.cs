// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Storage.Test.Shared
{
    public abstract class StorageTestBase : RecordedTestBase
    {
        public StorageTestBase(RecordedTestMode? mode = null)
            // TODO: Correctly parameterize this test with sync/async when we add sync overloads
            : base(false, mode ?? GetModeFromEnvironment())
        {
            this.Sanitizer = new StorageRecordedTestSanitizer();
            this.Matcher = new RecordMatcher(this.Sanitizer);
        }

        public override TClient InstrumentClient<TClient>(TClient client)
            // TODO: Enable instrumentation when we add sync overloads (by deleting this override)
            => client;

        public DateTimeOffset GetUtcNow() => this.Recording.UtcNow;

        public byte[] GetRandomBuffer(long size)
            => TestHelper.GetRandomBuffer(size, this.Recording.Random);

        public string GetNewString(int length = 20)
        {
            var buffer = new char[length];
            for (var i = 0; i < length; i++)
            {
                buffer[i] = (char)('a' + this.Recording.Random.Next(0, 25));
            }
            return new string(buffer);
        }

        public string GetNewMetadataName() => $"test_metadata_{this.Recording.Random.NewGuid().ToString().Replace("-", "_")}";

        public IDictionary<string, string> BuildMetadata()
            =>  new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { "foo", "bar" },
                    { "meta", "data" }
                };

        public IPAddress GetIPAddress()
        {
            var a = this.Recording.Random.Next(0, 256);
            var b = this.Recording.Random.Next(0, 256);
            var c = this.Recording.Random.Next(0, 256);
            var d = this.Recording.Random.Next(0, 256);
            var ipString = $"{a}.{b}.{c}.{d}";
            return IPAddress.Parse(ipString);
        }

        public TokenCredential GetOAuthCredential() =>
            this.GetOAuthCredential(TestConfigurations.DefaultTargetOAuthTenant);

        public TokenCredential GetOAuthCredential(TenantConfiguration config) =>
            this.GetOAuthCredential(
                config.ActiveDirectoryTenantId,
                config.ActiveDirectoryApplicationId,
                config.ActiveDirectoryApplicationSecret);

        public TokenCredential GetOAuthCredential(string tenantId, string appId, string secret) =>
            new ClientSecretCredential(
                tenantId,
                appId,
                secret);

        public void AssertMetadataEquality(IDictionary<string, string> expected, IDictionary<string, string> actual)
        {
            Assert.IsNotNull(expected, "Expected metadata is null");
            Assert.IsNotNull(actual, "Actual metadata is null");

            Assert.AreEqual(expected.Count, actual.Count, "Metadata counts are not equal");

            foreach (var kvp in expected)
            {
                if (!actual.TryGetValue(kvp.Key, out var value) ||
                    String.Compare(kvp.Value, value, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    Assert.Fail($"Expected key <{kvp.Key}> with value <{kvp.Value}> not found");
                }
            }
        }

        /// <summary>
        /// To prevent test flakiness, we simply warn when certain timing sensitive
        /// tests don't appear to work as expected.  However, we will ask you to run
        /// it again if you're recording a test because it should work correctly at
        /// least then.
        /// </summary>
        public void WarnCopyCompletedTooQuickly()
        {
            if (this.Mode == RecordedTestMode.Record)
            {
                Assert.Fail("Copy may have completed too quickly to abort.  Please record again.");
            }
            else
            {
                Assert.Inconclusive("Copy may have completed too quickly to abort.");
            }
        }

        /// <summary>
        /// A number of our tests have built in delays while we wait an expected
        /// amount of time for a service operation to complete and this method
        /// allows us to wait (unless we're playing back recordings, which can
        /// complete immediately).
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to wait.</param>
        /// <param name="playbackDelayMilliseconds">
        /// An optional number of milliseconds to wait if we're playing back a
        /// recorded test.  This is useful for allowing client side events to
        /// get processed.
        /// </param>
        /// <returns>A task that will (optionally) delay.</returns>
        public async Task Delay(int milliseconds = 1000, int? playbackDelayMilliseconds = null)
        {
            if (this.Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(milliseconds);
            }
            else if (playbackDelayMilliseconds != null)
            {
                await Task.Delay(playbackDelayMilliseconds.Value);
            }
        }
    }
}
