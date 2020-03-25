// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace GuestConfiguration.Tests.ScenarioTests
{
    using GuestConfiguration.Tests.Helpers;
    using GuestConfiguration.Tests.TestSupport;
    using Microsoft.Azure.Management.GuestConfiguration;
    using Microsoft.Azure.Management.GuestConfiguration.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class AutomationTest 
    {
        private const string ResourceGroupName = "vivga";
        private const string VMName = "vivga0";
        private const string AssignmentName = "AuditSecureProtocol";

        [Fact]
        public void CanCreateGetUpdateGuestConfigurationAssignment()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new GuestConfigurationTestBase(context))
                {
                    var gcAssignmentToCreateDefinition = new GuestConfigurationAssignmentForPutDefinition(
                        ResourceGroupName,
                        VMName,
                        new GuestConfigurationAssignment(name: AssignmentName,
                        location: "westcentralus",
                        properties: new GuestConfigurationAssignmentProperties()
                        {
                            Context = "Azure policy A",
                            GuestConfiguration = new GuestConfigurationNavigation()
                            {
                                Name = AssignmentName,
                                Version = "1.0.0.3"
                            }
                        })
                     );

                    // create a new guest configuration assignment
                    var gcAssignmentCreated = GuestConfigurationAssignmentsOperationsExtensions.CreateOrUpdate(testFixture.GuestConfigurationClient.GuestConfigurationAssignments,
                        gcAssignmentToCreateDefinition.Parameters.Name,
                        gcAssignmentToCreateDefinition.Parameters,
                        gcAssignmentToCreateDefinition.ResourceGroupName,
                        gcAssignmentToCreateDefinition.VmName);

                    Assert.NotNull(gcAssignmentCreated);

                    // Get created guest configuration assignment
                    var gcAssignmentRetrieved = GuestConfigurationAssignmentsOperationsExtensions.Get(testFixture.GuestConfigurationClient.GuestConfigurationAssignments,
                        gcAssignmentToCreateDefinition.ResourceGroupName,
                        gcAssignmentToCreateDefinition.Parameters.Name,
                        gcAssignmentToCreateDefinition.VmName);

                    Assert.NotNull(gcAssignmentRetrieved);
                    Assert.Equal(gcAssignmentToCreateDefinition.Parameters.Name, gcAssignmentRetrieved.Name);

                    // update guest configuration assignment
                    var updateParameters = gcAssignmentToCreateDefinition.GetParametersForUpdate();
                    var gcAssignmentUpdated = GuestConfigurationAssignmentsOperationsExtensions.CreateOrUpdate(testFixture.GuestConfigurationClient.GuestConfigurationAssignments,
                        updateParameters.Name,
                        updateParameters,
                        gcAssignmentToCreateDefinition.ResourceGroupName,
                        gcAssignmentToCreateDefinition.VmName);

                    Assert.NotNull(gcAssignmentUpdated);
                    Assert.Equal(updateParameters.Properties.Context, gcAssignmentUpdated.Properties.Context);
                }
            }
        }

        [Fact]
        public void CanGetGuestConfigurationAssignmentReports()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new GuestConfigurationTestBase(context))
                {
                    // get guest configuration assignment
                    var gcAssignment = GuestConfigurationAssignmentsOperationsExtensions.Get(testFixture.GuestConfigurationClient.GuestConfigurationAssignments,
                        ResourceGroupName,
                        AssignmentName,
                        VMName);

                    Assert.NotNull(gcAssignment);

                    // Get reports
                    var gcAssignmentReportsRetrieved = GuestConfigurationAssignmentReportsOperationsExtensions.List(testFixture.GuestConfigurationClient.GuestConfigurationAssignmentReports,
                                             ResourceGroupName,
                                             AssignmentName,
                                             VMName);

                    Assert.NotNull(gcAssignmentReportsRetrieved);
                    Assert.True(gcAssignmentReportsRetrieved.Value.Count >= 0);
                }
            }  
        }

        [Fact]
        public void CanListAllGuestConfigurationAssignments()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new GuestConfigurationTestBase(context))
                {
                    // get guest configuration assignment
                    var gcAssignments = GuestConfigurationAssignmentsOperationsExtensions.List(testFixture.GuestConfigurationClient.GuestConfigurationAssignments,
                        ResourceGroupName,
                        VMName);

                    Assert.NotNull(gcAssignments);
                    Assert.True(gcAssignments.IsAny());
                }
            }
        }
    }
}


