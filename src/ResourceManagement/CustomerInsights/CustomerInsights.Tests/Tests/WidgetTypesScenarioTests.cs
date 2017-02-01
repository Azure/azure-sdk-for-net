// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// --------------------------------------------------------------------------------------------------------------------
namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Azure.Management.CustomerInsights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;
    using System.Linq;
    using System.Threading;

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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

				var result = aciClient.WidgetTypes.ListByHubWithHttpMessagesAsync(ResourceGroupName, HubName).Result;

                Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);
            }
        }
    }
}