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
//

namespace Microsoft.Azure.Management.TrafficManager.Testing.Helpers
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.TrafficManager.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public static class TrafficManagerHelper
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <param name="context"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static TrafficManagerManagementClient GetTrafficManagerManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<TrafficManagerManagementClient>();
        }

        public static Profile BuildProfile(string id, string name, string type, string location, Dictionary<string, string> tags, string profileStatus, string trafficRoutingMethod, DnsConfig dnsConfig, MonitorConfig monitorConfig, Endpoint[] endpoints)
        {
            return new Profile(
                id: id,
                name: name,
                type: type,
                location: location,
                tags: tags,
                profileStatus: profileStatus,
                trafficRoutingMethod: trafficRoutingMethod,
                dnsConfig: dnsConfig,
                monitorConfig: monitorConfig,
                endpoints: endpoints);
        }

        public static Profile GenerateDefaultProfile(string profileName)
        {
            return TrafficManagerHelper.BuildProfile(
                id: null,
                name: profileName,
                type: "microsoft.network/trafficmanagerprofiles",
                location: "global",
                tags: null,
                profileStatus: "Enabled",
                trafficRoutingMethod: "Performance",
                dnsConfig: new DnsConfig
                {
                    RelativeName = profileName,
                    Ttl = 35
                }, 
                monitorConfig: new MonitorConfig
                {
                    Protocol = "http",
                    Port = 80,
                    Path = "/testpath.aspx"
                }, 
                endpoints: new []
                {
                    new Endpoint
                    {
                        Id = null,
                        Name = "My external endpoint",
                        Type = "Microsoft.network/TrafficManagerProfiles/ExternalEndpoints",
                        TargetResourceId = null,
                        Target = "foobar.contoso.com",
                        EndpointLocation = "North Europe",
                        EndpointStatus = "Enabled"
                    } 
                });
        }
    }
}
