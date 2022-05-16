// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace TestBase.Tests
{
    public class FlightingRingsTests : TestbaseBase
    {
        //FlightingRingName obtained through the ListWithHttpMessagesAsync method
        string flightingRingResourceName = "Insider-Beta-Channel";
        string nextPageLink = null;

        [Fact]
        public void TestFlightingRing()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);

                try
                {
                    var result = t_TestBaseClient.FlightingRings.ListWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName).GetAwaiter().GetResult();
                    Assert.NotNull(result);
                    Assert.NotNull(result.Body);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }

                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.FlightingRings.ListNextWithHttpMessagesAsync(nextPageLink));

                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.FlightingRings.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, ErrorValue));

                try
                {
                    var flightingRing = t_TestBaseClient.FlightingRings.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, flightingRingResourceName).GetAwaiter().GetResult();
                    Assert.Equal(flightingRingResourceName, flightingRing.Body.Name);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }

            }
        }
    }
}
