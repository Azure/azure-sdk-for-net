// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Iot.TimeSeriesInsights.Tests
{
    public class TimeSeriesInsightsClientTest : E2eTestBase
    {
        public TimeSeriesInsightsClientTest(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public void FirstTest()
        {
            TimeSeriesInsightsClient client = GetClient();
        }
    }
}
