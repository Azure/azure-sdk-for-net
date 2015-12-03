//
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

namespace Microsoft.Azure.Management.Intune.Tests.Helpers
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;

    public static class IntuneClientHelper
    {
        private static IntuneResourceManagementClient intuneClient;
        private static string asuHostName;
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static IntuneResourceManagementClient GetIntuneResourceManagementClient(MockContext context)
        {
            if (intuneClient == null)
            {
                lock(sync)
                {
                    if (intuneClient == null)
                    {
                        intuneClient = context.GetServiceClient<IntuneResourceManagementClient>();
                    }
                }
            }
            return intuneClient;         
        }        

        /// <summary>
        /// synchronization object..
        /// </summary>
        private static object sync = new object();

        /// <summary>
        /// ASU host name for the tenant
        /// </summary>        
        internal static string AsuHostName
        {
            get
            {
                if(intuneClient == null)
                {
                    throw new System.Exception("IntuneClient is not instantiated yet.");
                }

                if (asuHostName == null)
                {
                    var location = intuneClient.GetLocationByHostName();
                    asuHostName = location.HostName;                    
                }

                return asuHostName;
            }
        }

        internal static void InitializeEnvironment()
        {   //Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=3e9e6f07-6225-4d10-8fd4-5f0236c28f5a;Environment=Dogfood;UserId=admin@aad296.ccsctp.net;Password=XXXXXXX");
            //Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=None;Environment=Dogfood;UserId=admin@uxmdmonly.ccsctp.net;Password=XXXXXX");         
            //Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=None;Environment=Prod;UserId=admin@franktrtestdomain.onmicrosoft.com;Password=XXXXXX");         
            //Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=None;Environment=Prod;UserId=admin@IntuneAzureCLIMSUA06.onmicrosoft.com;Password=XXXXXX");         
            //AZURE_TEST_MODE = None, Record, Playback
            //Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
        }
    }
}
