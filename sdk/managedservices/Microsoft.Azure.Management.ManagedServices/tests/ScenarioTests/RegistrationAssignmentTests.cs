// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
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
        public async void RegistrationAssignmentTests_CRUD()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new ManagedServicesTestBase(context))
                {
                    var registrationDefinition = ManagedServicesTestUtilities.GetRegistrationDefintion();
                    var registrationAssignment = ManagedServicesTestUtilities.GetRegistrationAssignment();

                    //1. Create registration assignment
                    var registrationDefinitionResponse = await testFixture.ManagedServicesClient.RegistrationDefinitions
                        .CreateOrUpdateAsync(
                            registrationDefinitionId: ManagedServicesTestUtilities.registratonDefinitionId,
                            scope: ManagedServicesTestUtilities.scope,
                            requestBody: registrationDefinition);

                    Assert.NotNull(registrationDefinitionResponse);
                    Assert.Equal(ManagedServicesTestUtilities.registratonDefinitionId, registrationDefinitionResponse.Name);
                    Assert.Equal(ProvisioningState.Succeeded, registrationDefinitionResponse.Properties.ProvisioningState);

                    var registrationAssignemntResponse = await testFixture.ManagedServicesClient.RegistrationAssignments
                        .CreateOrUpdateAsync(
                        scope: ManagedServicesTestUtilities.scope,
                        registrationAssignmentId: ManagedServicesTestUtilities.registrationAssignmentId,
                        requestBody: registrationAssignment);

                    Assert.NotNull(registrationAssignemntResponse);
                    Assert.Equal(ManagedServicesTestUtilities.registrationAssignmentId, registrationAssignemntResponse.Name);
                    Assert.Equal(ProvisioningState.Succeeded, registrationAssignemntResponse.Properties.ProvisioningState);

                    //2. Get registration assignment
                    registrationAssignemntResponse = await testFixture.ManagedServicesClient.RegistrationAssignments
                        .GetAsync(
                        scope: ManagedServicesTestUtilities.scope,
                        registrationAssignmentId: ManagedServicesTestUtilities.registrationAssignmentId);

                    Assert.NotNull(registrationAssignemntResponse);
                    Assert.Equal(ManagedServicesTestUtilities.registrationAssignmentId, registrationAssignemntResponse.Name);

                    //3. Get registration assignment collections
                    var registrationAssignmentResponses = await testFixture.ManagedServicesClient.RegistrationAssignments
                        .ListAsync(
                        scope: ManagedServicesTestUtilities.scope,
                        expandRegistrationDefinition: true);

                    Assert.Contains(ManagedServicesTestUtilities.registrationAssignmentId, registrationAssignmentResponses.Select(x => x.Name));

                    //4. Get registration assignment collections expanded
                    registrationAssignmentResponses = await testFixture.ManagedServicesClient.RegistrationAssignments
                        .ListAsync(
                        scope: ManagedServicesTestUtilities.scope,
                        expandRegistrationDefinition: true);

                    Assert.NotNull(registrationAssignmentResponses.First().Properties.RegistrationDefinition);

                    //5. Delete registration assignment
                    await testFixture.ManagedServicesClient.RegistrationAssignments
                        .DeleteAsync(
                        scope: ManagedServicesTestUtilities.scope,
                        registrationAssignmentId: ManagedServicesTestUtilities.registrationAssignmentId);

                    Assert.NotNull(registrationAssignemntResponse);

                    //6. Get registration assignment collections
                    registrationAssignmentResponses = await testFixture.ManagedServicesClient.RegistrationAssignments
                        .ListAsync(
                        scope: ManagedServicesTestUtilities.scope);

                    Assert.DoesNotContain(ManagedServicesTestUtilities.registrationAssignmentId, registrationAssignmentResponses.Select(x => x.Name));
                }
            }
        }
    }
}
