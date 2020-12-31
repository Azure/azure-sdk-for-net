// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Iot.TimeSeriesInsights.Tests
{
    /// <summary>
    /// This class will initialize all the settings and create and instance of the Time Series Insights client.
    /// </summary>
    [Parallelizable(ParallelScope.Self)]
    public abstract class E2eTestBase : RecordedTestBase<TimeSeriesInsightsTestEnvironment>
    {
        protected static readonly int MaxTries = 1000;

        // Based on testing, the max length of models can be 27 only and works well for other resources as well. This can be updated when required.
        protected static readonly int MaxIdLength = 27;

        public E2eTestBase(bool isAsync)
         : base(isAsync, TestSettings.Instance.TestMode)
        {
            Sanitizer = new TestUrlSanitizer();
        }

        [SetUp]
        public virtual void SetupE2eTestBase()
        {
            TestDiagnostics = false;

            // TODO: set via client options and pipeline instead
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected TimeSeriesInsightsClient GetClient(TimeSeriesInsightsClientOptions options = null)
        {
            if (options == null)
            {
                options = new TimeSeriesInsightsClientOptions();
            }

            return InstrumentClient(
                new TimeSeriesInsightsClient(
                    TestEnvironment.TimeSeriesInsightsHostname,
                    TestEnvironment.Credential,
                    InstrumentClientOptions(options)));
        }

        protected TimeSeriesInsightsClient GetFakeClient()
        {
            return InstrumentClient(
                new TimeSeriesInsightsClient(
                    TestEnvironment.TimeSeriesInsightsHostname,
                    new FakeTokenCredential(),
                    InstrumentClientOptions(new TimeSeriesInsightsClientOptions())));
        }
    }
}
