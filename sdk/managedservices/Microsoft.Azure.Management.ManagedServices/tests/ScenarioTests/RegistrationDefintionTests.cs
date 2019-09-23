// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ManagedServices.Tests.Helpers;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ManagedServices;
using Microsoft.Azure.Management.ManagedServices.Models;
using Xunit;
using System.Linq;

namespace ManagedServices.Tests.ScenarioTests
{
    public class RegistrationDefintionTests : TestBase
    {
        [Fact]
        public async void RegistrationDefintionTests_CRUD()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new ManagedServicesTestBase(context))
                {
                    var registrationDefinition = ManagedServicesTestUtilities.GetRegistrationDefintion();

                    //1. Create Registration Defintion
                    var registrationDefinitionResponse = await testFixture.ManagedServicesClient.RegistrationDefinitions
                        .CreateOrUpdateAsync(
                            registrationDefinitionId: ManagedServicesTestUtilities.registratonDefinitionId,
                            scope: ManagedServicesTestUtilities.scope,
                            requestBody: registrationDefinition);

                    Assert.NotNull(registrationDefinitionResponse);
                    Assert.Equal(ProvisioningState.Succeeded, registrationDefinitionResponse.Properties.ProvisioningState);

                    //2. Get Registration Defintion
                    registrationDefinitionResponse = await testFixture.ManagedServicesClient.RegistrationDefinitions
                        .GetAsync(
                        scope: ManagedServicesTestUtilities.scope,
                        registrationDefinitionId: ManagedServicesTestUtilities.registratonDefinitionId);

                    Assert.NotNull(registrationDefinitionResponse);
                    Assert.Equal(ManagedServicesTestUtilities.registrationDefinitionName, registrationDefinitionResponse.Properties.RegistrationDefinitionName);

                    //3. Get Registration Defintion collection
                    var registrationDefinitionsResponses = await testFixture.ManagedServicesClient.RegistrationDefinitions
                        .ListAsync(scope: ManagedServicesTestUtilities.scope);

                    Assert.Contains(ManagedServicesTestUtilities.registratonDefinitionId, registrationDefinitionsResponses.Select(x => x.Name));

                    //4. Delete Registration Defintion
                    await testFixture.ManagedServicesClient.RegistrationDefinitions
                        .DeleteAsync(
                        scope: ManagedServicesTestUtilities.scope,
                        registrationDefinitionId: ManagedServicesTestUtilities.registratonDefinitionId);

                    //5. Get Registration Defintion (make sure it is deleted)
                    registrationDefinitionsResponses = await testFixture.ManagedServicesClient.RegistrationDefinitions
                        .ListAsync(scope: ManagedServicesTestUtilities.scope);

                    Assert.DoesNotContain(ManagedServicesTestUtilities.registratonDefinitionId, registrationDefinitionsResponses.Select(x => x.Name));
                }
            }
        }
    }
}
