// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.PhoneNumbers.SipRouting.Tests
{
    public class SipRoutingClientLiveTestBase : RecordedTestBase<SipRoutingClientTestEnvironment>
    {
        private const string URIDomainNameReplacerRegEx = @"https://([^/?]+)";
        private const string DummyTestDomain = "testdomain.com";
        private string testDomain;
        protected TestData? TestData;

        public SipRoutingClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            testDomain = TestEnvironment.Mode != RecordedTestMode.Playback ? TestEnvironment.GetTestDomain() ?? DummyTestDomain : DummyTestDomain;

            JsonPathSanitizers.Add("$..credential");
            SanitizedHeaders.Add("x-ms-content-sha256");
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainNameReplacerRegEx) { Value = "https://sanitized.communication.azure.com" });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(testDomain) { Value = DummyTestDomain });
        }

        [SetUp]
        public void SetUpTestData()
        {
            var testRandom = Recording.Random;
            var randomGuid = testRandom.NewGuid();
            TestData = new TestData(testDomain, randomGuid.ToString());
        }

        public bool SkipSipRoutingLiveTests
            => TestEnvironment.Mode != RecordedTestMode.Playback &&
            string.Equals(Environment.GetEnvironmentVariable("SKIP_SIPROUTING_LIVE_TESTS"), "True", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Creates a <see cref="SipRoutingClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="SipRoutingClient" />.</returns>
        protected SipRoutingClient CreateClient(bool isInstrumented = true)
        {
            var client = new SipRoutingClient(
                    TestEnvironment.LiveTestDynamicConnectionString,
                    InstrumentClientOptions(new SipRoutingClientOptions()));

            // We always create the instrumented client to suppress the instrumentation check
            var instrumentedClient = InstrumentClient(client);
            return isInstrumented ? instrumentedClient : client;
        }

        /// <summary>
        /// Creates a <see cref="SipRoutingClient" /> with the token credential
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="SipRoutingClient" />.</returns>
        protected SipRoutingClient CreateClientWithTokenCredential(bool isInstrumented = true)
        {
            var client = new SipRoutingClient(
                    new Uri(ConnectionString.Parse(TestEnvironment.LiveTestDynamicConnectionString, allowEmptyValues: true).GetRequired("endpoint")),
                    (Mode == RecordedTestMode.Playback) ? new MockCredential() : new DefaultAzureCredential(),
                    InstrumentClientOptions(new SipRoutingClientOptions()));

            return isInstrumented ? InstrumentClient(client) : client;
        }

        protected bool RouteAreEqual(SipTrunkRoute expected, SipTrunkRoute actual)
        {
            var areEqual = (
                expected.Name == actual.Name &&
                expected.Description == actual.Description &&
                expected.NumberPattern == actual.NumberPattern &&
                expected.Trunks.Count == actual.Trunks.Count);

            for (int i = 0; i < expected.Trunks.Count; i++)
            {
                areEqual = areEqual && (expected.Trunks[i] == actual.Trunks[i]);
            }

            return areEqual;
        }

        protected bool TrunkAreEqual(SipTrunk expected, SipTrunk actual)
        {
            return expected.Fqdn == actual.Fqdn && expected.SipSignalingPort == actual.SipSignalingPort;
        }
    }
}
