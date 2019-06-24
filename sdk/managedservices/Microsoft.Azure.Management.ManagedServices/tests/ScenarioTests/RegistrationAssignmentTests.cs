// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Collections;
using ManagedServices.Tests.Helpers;
using Microsoft.Azure.Management.ManagedServices;
using Microsoft.Azure.Management.ManagedServices.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ManagedServices.Tests.ScenarioTests
{
    public class RegistrationAssignmentTests : TestBase
    {
        [Fact]
        public void RegistrationAssignmentTests_CRUD()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                using (var testFixture = new ManagedServicesTestBase(context))
                {
                    var registrationDefinition = ManagedServicesTestUtilities.GetRegistrationDefintion();
                    var registrationAssignment= ManagedServicesTestUtilities.GetRegistrationAssignment();

                    //1. Create registration assignment
                    var registrationDefinitionResponse = testFixture.ManagedServicesClient.RegistrationDefinitions
                        .CreateOrUpdate(
                            registrationDefinitionId: ManagedServicesTestUtilities.registratonDefinitionId,
                            apiVersion: ManagedServicesTestUtilities.apiVersion,
                            scope: ManagedServicesTestUtilities.scope,
                            requestBody: registrationDefinition);

                    Assert.NotNull(registrationDefinitionResponse);
                    Assert.Equal(ManagedServicesTestUtilities.registratonDefinitionId, registrationDefinitionResponse.Name);                    
                    Assert.Equal(ProvisioningState.Succeeded, registrationDefinitionResponse.Properties.ProvisioningState);

                    var registrationAssignemntResponse = testFixture.ManagedServicesClient.RegistrationAssignments
                        .CreateOrUpdate(
                        scope: ManagedServicesTestUtilities.scope,
                        apiVersion: ManagedServicesTestUtilities.apiVersion,
                        registrationAssignmentId: ManagedServicesTestUtilities.registrationAssignmentId,
                        requestBody: registrationAssignment);

                    Assert.NotNull(registrationAssignemntResponse);
                    Assert.Equal(ManagedServicesTestUtilities.registrationAssignmentId, registrationAssignemntResponse.Name);                    
                    Assert.Equal(ProvisioningState.Succeeded, registrationAssignemntResponse.Properties.ProvisioningState);

                    //2. Get registration assignment
                    registrationAssignemntResponse = testFixture.ManagedServicesClient.RegistrationAssignments
                        .Get(
                        scope: ManagedServicesTestUtilities.scope,
                        apiVersion: ManagedServicesTestUtilities.apiVersion,
                        registrationAssignmentId: ManagedServicesTestUtilities.registrationAssignmentId);

                    Assert.NotNull(registrationAssignemntResponse);
                    Assert.Equal(ManagedServicesTestUtilities.registrationAssignmentId, registrationAssignemntResponse.Name);

                    //3. Get registration assignment collections
                    var registrationAssignemntResponses = testFixture.ManagedServicesClient.RegistrationAssignments
                        .List(
                        scope: ManagedServicesTestUtilities.scope,
                        apiVersion: ManagedServicesTestUtilities.apiVersion,
                        expandRegistrationDefinition: true);

                    Assert.NotNull(registrationAssignemntResponses);

                    //4. Get registration assignment collections expanded
                    registrationAssignemntResponses = testFixture.ManagedServicesClient.RegistrationAssignments
                        .List(
                        scope: ManagedServicesTestUtilities.scope,
                        apiVersion: ManagedServicesTestUtilities.apiVersion,
                        expandRegistrationDefinition: true);

                    Assert.NotNull(registrationAssignemntResponses);

                    //5. Delete registration assignment
                    testFixture.ManagedServicesClient.RegistrationAssignments
                        .Delete(
                        scope: ManagedServicesTestUtilities.scope,
                        apiVersion: ManagedServicesTestUtilities.apiVersion,
                        registrationAssignmentId: ManagedServicesTestUtilities.registrationAssignmentId);

                    Assert.NotNull(registrationAssignemntResponse);
                    Assert.Equal(ManagedServicesTestUtilities.registrationAssignmentId, registrationAssignemntResponse.Name);

                    //6. Get registration assignment collections
                    registrationAssignemntResponses = testFixture.ManagedServicesClient.RegistrationAssignments
                        .List(
                        scope: ManagedServicesTestUtilities.scope,
                        apiVersion: ManagedServicesTestUtilities.apiVersion);

                    foreach (var assignment in registrationAssignemntResponses)
                    {
                        Assert.False(assignment.Name == ManagedServicesTestUtilities.registrationAssignmentId);
                    }
                }
            }
        }
    }
}