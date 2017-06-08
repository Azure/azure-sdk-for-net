// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.TrafficManager.Testing.ScenarioTests
{
    using System.Collections.Generic;
    using System.Linq;
    using global::TrafficManager.Tests.Helpers;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.TrafficManager.Models;
    using Microsoft.Azure.Management.TrafficManager.Testing.Helpers;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public partial class ProfileScenarioTests
    {      
        [Fact]
        public void CrudProfile_FastFailoverSettings()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TrafficManagerHelper.GenerateName();
                string profileName = TrafficManagerHelper.GenerateName();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                Profile profile = TrafficManagerHelper.GenerateDefaultProfileWithExternalEndpoint(profileName);

                profile.MonitorConfig.IntervalInSeconds = 10;
                profile.MonitorConfig.TimeoutInSeconds = 5;
                profile.MonitorConfig.ToleratedNumberOfFailures = 2;

                Profile createResult = trafficManagerClient.Profiles.CreateOrUpdate(resourceGroup.Name, profileName, profile);

                Assert.Equal(10, createResult.MonitorConfig.IntervalInSeconds);
                Assert.Equal(5, createResult.MonitorConfig.TimeoutInSeconds);
                Assert.Equal(2, createResult.MonitorConfig.ToleratedNumberOfFailures);

                Profile getResult = trafficManagerClient.Profiles.Get(resourceGroup.Name, profileName);

                Assert.Equal(10, getResult.MonitorConfig.IntervalInSeconds);
                Assert.Equal(5, getResult.MonitorConfig.TimeoutInSeconds);
                Assert.Equal(2, getResult.MonitorConfig.ToleratedNumberOfFailures);

                Profile update = new Profile(name: profileName, monitorConfig: profile.MonitorConfig);
                update.MonitorConfig.IntervalInSeconds = 30;
                update.MonitorConfig.TimeoutInSeconds = 6;
                update.MonitorConfig.ToleratedNumberOfFailures = 4;

                Profile updateResult = trafficManagerClient.Profiles.Update(resourceGroup.Name, profileName, update);

                Assert.Equal(30, updateResult.MonitorConfig.IntervalInSeconds);
                Assert.Equal(6, updateResult.MonitorConfig.TimeoutInSeconds);
                Assert.Equal(4, updateResult.MonitorConfig.ToleratedNumberOfFailures);

                getResult = trafficManagerClient.Profiles.Get(resourceGroup.Name, profileName);

                Assert.Equal(30, getResult.MonitorConfig.IntervalInSeconds);
                Assert.Equal(6, getResult.MonitorConfig.TimeoutInSeconds);
                Assert.Equal(4, getResult.MonitorConfig.ToleratedNumberOfFailures);

                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }
    }
}
