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
        private const string ResourceGroupName = "geTestResourceGroup002";
        private const string AzureVMName = "GeWin20200507";
        private const string HybridMachineName = "WIN-9DFUIQ7NP1B";
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
                        AzureVMName,
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
        public void CanCreateGetUpdateGuestConfigurationHCRPAssignment()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new GuestConfigurationTestBase(context))
                {
                    var gcAssignmentToCreateDefinition = new GuestConfigurationAssignmentForPutDefinition(
                        ResourceGroupName,
                        HybridMachineName,
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
                    var gcHCRPAssignmentCreated = GuestConfigurationHCRPAssignmentsOperationsExtensions.CreateOrUpdate(testFixture.GuestConfigurationClient.GuestConfigurationHCRPAssignments,
                        gcAssignmentToCreateDefinition.Parameters.Name,
                        gcAssignmentToCreateDefinition.Parameters,
                        gcAssignmentToCreateDefinition.ResourceGroupName,
                        gcAssignmentToCreateDefinition.VmName);

                    Assert.NotNull(gcHCRPAssignmentCreated);

                    // Get created guest configuration assignment
                    var gcHCRPAssignmentRetrieved = GuestConfigurationHCRPAssignmentsOperationsExtensions.Get(testFixture.GuestConfigurationClient.GuestConfigurationHCRPAssignments,
                        gcAssignmentToCreateDefinition.ResourceGroupName,
                        gcAssignmentToCreateDefinition.Parameters.Name,
                        gcAssignmentToCreateDefinition.VmName);

                    Assert.NotNull(gcHCRPAssignmentRetrieved);
                    Assert.Equal(gcAssignmentToCreateDefinition.Parameters.Name, gcHCRPAssignmentRetrieved.Name);

                    // update guest configuration assignment
                    var updateParameters = gcAssignmentToCreateDefinition.GetParametersForUpdate();
                    var gcHCRPAssignmentUpdated = GuestConfigurationHCRPAssignmentsOperationsExtensions.CreateOrUpdate(testFixture.GuestConfigurationClient.GuestConfigurationHCRPAssignments,
                        updateParameters.Name,
                        updateParameters,
                        gcAssignmentToCreateDefinition.ResourceGroupName,
                        gcAssignmentToCreateDefinition.VmName);

                    Assert.NotNull(gcHCRPAssignmentUpdated);
                    Assert.Equal(updateParameters.Properties.Context, gcHCRPAssignmentUpdated.Properties.Context);
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
                        AzureVMName);

                    Assert.NotNull(gcAssignment);

                    // Get reports
                    var gcAssignmentReportsRetrieved = GuestConfigurationAssignmentReportsOperationsExtensions.List(testFixture.GuestConfigurationClient.GuestConfigurationAssignmentReports,
                                             ResourceGroupName,
                                             AssignmentName,
                                             AzureVMName);

                    Assert.NotNull(gcAssignmentReportsRetrieved);
                    Assert.True(gcAssignmentReportsRetrieved.Value.Count >= 0);
                }
            }  
        }

        [Fact]
        public void CanGetGuestConfigurationHCRPAssignmentReports()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new GuestConfigurationTestBase(context))
                {
                    // get guest configuration assignment
                    var gcHCRPAssignment = GuestConfigurationHCRPAssignmentsOperationsExtensions.Get(testFixture.GuestConfigurationClient.GuestConfigurationHCRPAssignments,
                        ResourceGroupName,
                        AssignmentName,
                        HybridMachineName);

                    Assert.NotNull(gcHCRPAssignment);

                    // Get reports
                    var gcHCRPAssignmentReportsRetrieved = GuestConfigurationHCRPAssignmentReportsOperationsExtensions.List(testFixture.GuestConfigurationClient.GuestConfigurationHCRPAssignmentReports,
                                             ResourceGroupName,
                                             AssignmentName,
                                             HybridMachineName);

                    Assert.NotNull(gcHCRPAssignmentReportsRetrieved);
                    Assert.True(gcHCRPAssignmentReportsRetrieved.Value.Count >= 0);
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
                        AzureVMName);

                    Assert.NotNull(gcAssignments);
                    Assert.True(gcAssignments.IsAny());
                }
            }
        }

        [Fact]
        public void CanListAllGuestConfigurationHCRPAssignments()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new GuestConfigurationTestBase(context))
                {
                    // get guest configuration assignment
                    var gcHCRPAssignments = GuestConfigurationHCRPAssignmentsOperationsExtensions.List(testFixture.GuestConfigurationClient.GuestConfigurationHCRPAssignments,
                        ResourceGroupName,
                        HybridMachineName);

                    Assert.NotNull(gcHCRPAssignments);
                    Assert.True(gcHCRPAssignments.IsAny());
                }
            }
        }
    }
}


