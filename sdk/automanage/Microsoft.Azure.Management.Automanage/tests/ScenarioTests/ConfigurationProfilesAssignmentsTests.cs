// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
namespace Automanage.Tests.ScenarioTests
{
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Automanage.Tests.Helpers;
    using Microsoft.Azure.Management.Automanage;
    using Microsoft.Azure.Management.Automanage.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;    
    using Xunit;
    using Xunit.Abstractions;

    public class ConfigurationProfilesAssignmentsTests : TestBase
    {
        private RecordedDelegatingHandler handler;
        private string vmName = "mynewamvmVM2";
        private string vmID = "/subscriptions/cdd53a71-7d81-493d-bce6-224fec7223a9/resourceGroups/mynewamvmVM_group/providers/Microsoft.Compute/virtualMachines/mynewamvmVM2";
        private string automanageAccountId = "/subscriptions/cdd53a71-7d81-493d-bce6-224fec7223a9/resourceGroups/AMVM-SubLib-017_group/providers/Microsoft.Automanage/accounts/AMVM-SubLib-017-ABP";
        public ConfigurationProfilesAssignmentsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ConfigurationProfilesListAssignmentsGetsExpectedProfile()
        {
            var thisType = this.GetType();
            using (MockContext context = MockContext.Start(thisType))
            {
                var automanageClient = GetAutomanagementClient(context, handler);
                //var actual2 = await automanageClient.ConfigurationProfileAssignments.ListWithHttpMessagesAsync("DeluxeTest");                          
                var actual = automanageClient.ConfigurationProfileAssignments.List("DeluxeTest");
                Assert.NotNull(actual);                
            }
        }

        [Fact]
        //[Trait("Category", "Scenario")]
        public void ConfigurationProfilesAssignmentsCreatesProfile()
        {
            var thisType = this.GetType();
            using (MockContext context = MockContext.Start(thisType))
            {
                var automanageClient = GetAutomanagementClient(context, handler);

                //create new ProfileAssignment
                var expectedProfile = GetAConfigurationProfileAssignment();
                var actual = automanageClient.ConfigurationProfileAssignments.BeginCreateOrUpdateAsync(
                    configurationProfileAssignmentName: expectedProfile.Name,
                    parameters: expectedProfile, 
                    resourceGroupName: "mynewamvmVM_group", 
                    vmName: vmName) ;                

                Assert.NotNull(actual);
            }
        }

        private ConfigurationProfileAssignment GetAConfigurationProfileAssignment()
        {
            var assignmentProperties = new ConfigurationProfileAssignmentProperties(
                configurationProfile: "Azure Best Practices - Prod",
                targetId: vmID,
                accountId: automanageAccountId,
                configurationProfilePreferenceId: null, //change to the ARM id of a preference object to test preference application
                provisioningStatus: null,
                compliance: null);
            
            var thisAssignment = new ConfigurationProfileAssignment(
                id: null,
                name: "default",
                location: "East US 2",
                properties: assignmentProperties);
            return thisAssignment;
        }
    }
}