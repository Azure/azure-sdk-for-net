// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Iot.TimeSeriesInsights.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.Iot.TimeSeriesInsights.Tests
{
    public class ModelSettingsTests : E2eTestBase
    {
        public ModelSettingsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsClient_ModelSettingsTest()
        {
            TimeSeriesInsightsClient client = GetClient();

            // GET model settings
            Response<TimeSeriesModelSettings> currentSettings = await client.GetModelSettingsAsync().ConfigureAwait(false);
            currentSettings.GetRawResponse().Status.Should().Be((int)HttpStatusCode.OK);
            string testName = "testModel";

            // UPDATE model settings
            Response<TimeSeriesModelSettings> updatedSettingsName = await client.UpdateModelSettingsNameAsync(testName).ConfigureAwait(false);
            updatedSettingsName.GetRawResponse().Status.Should().Be((int)HttpStatusCode.OK);
            updatedSettingsName.Value.Name.Should().Be(testName);
            // TODO 9430977: Add a test for updating default Type Id. Need existing Model type to update with associated type Id.
        }

        [Test]
        public void UpdateModelSettingsWithInvalidType_ThrowsBadRequestException()
        {
            // arrange
            TimeSeriesInsightsClient client = GetClient();

            // act
            Func<Task> act = async () => await client.UpdateModelSettingsDefaultTypeIdAsync("testId").ConfigureAwait(false);

            // assert
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}
