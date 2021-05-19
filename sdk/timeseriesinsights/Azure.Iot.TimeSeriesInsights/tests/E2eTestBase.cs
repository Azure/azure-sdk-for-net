// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
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

        protected async Task<TimeSeriesId> GetUniqueTimeSeriesInstanceIdAsync(TimeSeriesInsightsClient tsiClient, int numOfIdKeys)
        {
            numOfIdKeys.Should().BeInRange(1, 3);

            for (int tryNumber = 0; tryNumber < MaxTries; ++tryNumber)
            {
                var id = new List<string>();
                for (int i = 0; i < numOfIdKeys; i++)
                {
                    id.Add(Recording.GenerateAlphaNumericId(string.Empty, 5));
                }

                TimeSeriesId tsId = numOfIdKeys switch
                {
                    1 => new TimeSeriesId(id[0]),
                    2 => new TimeSeriesId(id[0], id[1]),
                    3 => new TimeSeriesId(id[0], id[1], id[2]),
                    _ => throw new Exception($"Invalid number of Time Series Insights Id properties."),
                };

                Response<InstancesOperationResult[]> getInstancesResult = await tsiClient
                    .GetInstancesAsync(new List<TimeSeriesId> { tsId })
                    .ConfigureAwait(false);

                if (getInstancesResult.Value?.First()?.Error != null)
                {
                    return tsId;
                }
            }

            throw new Exception($"Unique Id could not be found");
        }
    }
}
