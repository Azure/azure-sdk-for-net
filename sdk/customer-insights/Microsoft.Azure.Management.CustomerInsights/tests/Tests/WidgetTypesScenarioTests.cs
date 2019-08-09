// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerInsights.Tests.Tests
{
    using System.Net;
    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class WidgetTypesScenarioTests
    {
		/// <summary>
		/// Hub Name
		/// </summary>
	    static readonly string HubName;

		/// <summary>
		/// Reosurce Group Name
		/// </summary>
		static readonly string ResourceGroupName;

		static WidgetTypesScenarioTests()
		{
            HubName = AppSettings.HubName;
            ResourceGroupName = AppSettings.ResourceGroupName;
        }
        
        [Fact]
        public void ListWidgetTypesInHub()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

				var result = aciClient.WidgetTypes.ListByHubWithHttpMessagesAsync(ResourceGroupName, HubName).Result;

                Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);
            }
        }
    }
}
