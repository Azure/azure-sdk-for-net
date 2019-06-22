// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ManagedServices.Tests.Helpers;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Microsoft.Azure.Management.ManagedServices;
using Microsoft.Azure.Management.ManagedServices.Models;

namespace ManagedServices.Tests.ScenarioTests
{
    public class RegistrationDefintionTests : TestBase
    {
        [Fact]
        public void RegistrationDefintionTests_CRUD()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                using (var testFixture = new ManagedServicesTestBase(context))
                {
                    var registrationDefinition = ManagedServicesTestUtilities.GetRegistrationDefintion();

                    //1. Create Registration Defintion
                    var registrationDefinitionResponse = testFixture.ManagedServicesClient.RegistrationDefinitions
                        .CreateOrUpdate(
                            registrationDefinitionId: ManagedServicesTestUtilities.registratonDefinitionId,
                            apiVersion: ManagedServicesTestUtilities.apiVersion,
                            scope: ManagedServicesTestUtilities.scope,
                            requestBody: registrationDefinition);

                    Assert.NotNull(registrationDefinitionResponse);
                    Assert.Equal(ProvisioningState.Succeeded, registrationDefinitionResponse.Properties.ProvisioningState);

                    //2. Get Registration Defintion
                    registrationDefinitionResponse = testFixture.ManagedServicesClient.RegistrationDefinitions
                        .Get(
                        scope: ManagedServicesTestUtilities.scope,
                        registrationDefinitionId: ManagedServicesTestUtilities.registratonDefinitionId,
                        apiVersion: ManagedServicesTestUtilities.apiVersion);

                    Assert.NotNull(registrationDefinitionResponse);
                    Assert.Equal(ManagedServicesTestUtilities.registrationDefinitionName, registrationDefinitionResponse.Properties.RegistrationDefinitionName);

                    //3. Get Registration Defintion collection
                    var registrationDefinitionsResponse = testFixture.ManagedServicesClient.RegistrationDefinitions
                        .List(
                        scope: ManagedServicesTestUtilities.scope,
                        apiVersion: ManagedServicesTestUtilities.apiVersion);

                    Assert.NotNull(registrationDefinitionsResponse);
                    Assert.Single(registrationDefinitionsResponse);

                    //4. Delete Registration Defintion
                    testFixture.ManagedServicesClient.RegistrationDefinitions
                        .Delete(
                        scope: ManagedServicesTestUtilities.scope,
                        registrationDefinitionId: ManagedServicesTestUtilities.registratonDefinitionId,
                        apiVersion: ManagedServicesTestUtilities.apiVersion);

                    Assert.NotNull(registrationDefinitionResponse);

                    //5. Get Registration Defintion collection
                    registrationDefinitionsResponse = testFixture.ManagedServicesClient.RegistrationDefinitions
                        .List(
                        scope: ManagedServicesTestUtilities.scope,
                        apiVersion: ManagedServicesTestUtilities.apiVersion);

                    Assert.Empty(registrationDefinitionsResponse);
                }
            }
        }
    }
}