// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using HealthcareApis.Tests.Helpers;
using Microsoft.Azure.Management.HealthcareApis;
using Microsoft.Azure.Management.HealthcareApis.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Net;
using Xunit;

namespace HealthcareApis.Tests
{
    public class HealthcareApisTests
    {

        [Fact]
        public void HealthcareApisCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = HealthcareApisManagementTestUtilities.GetResourceManagementClient(context, handler);
                var healthCareApisMgmtClient = HealthcareApisManagementTestUtilities.GetHealthcareApisManagementClient(context, handler);

                // Create resource group
                var rgname = HealthcareApisManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Generate account name
                string accountName = TestUtilities.GenerateName("hca");

                var workspace = HealthcareApisManagementTestUtilities.GetWorkspace();

                // Create healthcare apis account
                var account = healthCareApisMgmtClient.Workspaces.BeginCreateOrUpdate(rgname, accountName, workspace);
                HealthcareApisManagementTestUtilities.VerifyWorkspaceProperties(account);
            }
        }

        [Fact]
        public void HealthcareApisCreateTestWithDefaultKind()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = HealthcareApisManagementTestUtilities.GetResourceManagementClient(context, handler);
                var healthCareApisMgmtClient = HealthcareApisManagementTestUtilities.GetHealthcareApisManagementClient(context, handler);

                // Create resource group
                var rgname = HealthcareApisManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Generate account name
                string accountName = TestUtilities.GenerateName("workspace");

                var workspace = HealthcareApisManagementTestUtilities.GetWorkspace();

                var account = healthCareApisMgmtClient.Workspaces.BeginCreateOrUpdate(rgname, accountName, workspace);

                var fhirServiceName = TestUtilities.GenerateName("fhirservice");

                var serviceDescription = HealthcareApisManagementTestUtilities.GetFhirService(false);

                var fhirService = healthCareApisMgmtClient.FhirServices.BeginCreateOrUpdate(rgname, accountName, fhirServiceName, serviceDescription);
                Assert.Equal("fhir-R4", fhirService.Kind);
            }
        }

        [Fact]
        public void HealthcareApisCreateAccountErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = HealthcareApisManagementTestUtilities.GetResourceManagementClient(context, handler);
                var healthCareApisMgmtClient = HealthcareApisManagementTestUtilities.GetHealthcareApisManagementClient(context, handler);

                // Create resource group
                var rgname = HealthcareApisManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Generate account name
                string accountName = TestUtilities.GenerateName("hca");

                var serviceDescription = HealthcareApisManagementTestUtilities.GetServiceDescription();

                // try to create account in non-existent RG
                HealthcareApisManagementTestUtilities.ValidateExpectedException(() =>
                     healthCareApisMgmtClient.Services.CreateOrUpdate("NotExistedRG", accountName, serviceDescription),
                    HttpStatusCode.NotFound.ToString());
            }
        }

        [Fact]
        public void HealthcareApisAccountUpdateWithCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = HealthcareApisManagementTestUtilities.GetResourceManagementClient(context, handler);
                var healthCareApisMgmtClient = HealthcareApisManagementTestUtilities.GetHealthcareApisManagementClient(context, handler);

                // Create resource group
                var rgname = HealthcareApisManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Generate account name
                string workspaceName = TestUtilities.GenerateName("hca");

                var workspaceDescription = HealthcareApisManagementTestUtilities.GetWorkspace();

                var workspace = healthCareApisMgmtClient.Workspaces.BeginCreateOrUpdate(rgname, workspaceName, workspaceDescription);

                string fhirServiceName = TestUtilities.GenerateName("fhirservice");

                var fhirServiceDescription = HealthcareApisManagementTestUtilities.GetFhirService(false);

                // Create FhirService
                var fhirService = healthCareApisMgmtClient.FhirServices.BeginCreateOrUpdate(rgname, workspaceName, fhirServiceName, fhirServiceDescription);

                var updatedFhirServiceDescription = HealthcareApisManagementTestUtilities.GetFhirService(true);

                // Update Tags
                var updatedFhirService = healthCareApisMgmtClient.FhirServices.BeginCreateOrUpdate(rgname, workspaceName, fhirServiceName, updatedFhirServiceDescription);
                Assert.True(updatedFhirService.Tags.Values.Contains("value3"));
                Assert.True(updatedFhirService.Tags.Values.Contains("value4"));
                Assert.False(updatedFhirService.Tags.Values.Contains("value1"));
                Assert.False(updatedFhirService.Tags.Values.Contains("value2"));

                // Validate
                var fetchedAccount = healthCareApisMgmtClient.FhirServices.Get(rgname, workspaceName, fhirServiceName);
                Assert.Equal(updatedFhirServiceDescription.Tags.Count, fetchedAccount.Tags.Count);
                Assert.Collection(fetchedAccount.Tags,
                    (keyValue) => { Assert.Equal("key3", keyValue.Key); Assert.Equal("value3", keyValue.Value); },
                    (keyValue) => { Assert.Equal("key4", keyValue.Key); Assert.Equal("value4", keyValue.Value); },
                    (keyValue) => { Assert.Equal("key5", keyValue.Key); Assert.Equal("value5", keyValue.Value); }
                );
            }
        }

        [Fact]
        public void HealthcareApisListAccountByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = HealthcareApisManagementTestUtilities.GetResourceManagementClient(context, handler);
                var healthCareApisMgmtClient = HealthcareApisManagementTestUtilities.GetHealthcareApisManagementClient(context, handler);

                // Create resource group
                var rgname = HealthcareApisManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var accounts = healthCareApisMgmtClient.Workspaces.ListByResourceGroup(rgname);

                Assert.Empty(accounts);

                string accountName1 = HealthcareApisManagementTestUtilities.CreateHealthcareApisAccount(healthCareApisMgmtClient, rgname);
                string accountName2 = HealthcareApisManagementTestUtilities.CreateHealthcareApisAccount(healthCareApisMgmtClient, rgname);

                accounts = healthCareApisMgmtClient.Workspaces.ListByResourceGroup(rgname);

                Assert.Equal(2, accounts.Count());

                HealthcareApisManagementTestUtilities.VerifyWorkspaceProperties(accounts.First());
                HealthcareApisManagementTestUtilities.VerifyWorkspaceProperties(accounts.Skip(1).First());
            }
        }

        [Fact]
        public void HealthcareApisGetAccountTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = HealthcareApisManagementTestUtilities.GetResourceManagementClient(context, handler);
                var healthCareApisMgmtClient = HealthcareApisManagementTestUtilities.GetHealthcareApisManagementClient(context, handler);

                // Create resource group
                var rgname = HealthcareApisManagementTestUtilities.CreateResourceGroup(resourcesClient);

                //generate account name
                string workspaceName = TestUtilities.GenerateName("hca");

                var workspaceDescription = HealthcareApisManagementTestUtilities.GetWorkspace();

                // Create healthcareApis account
                var workspace = healthCareApisMgmtClient.Workspaces.BeginCreateOrUpdate(rgname, workspaceName, workspaceDescription);

                // Validate
                var fetchedWorkspace = healthCareApisMgmtClient.Workspaces.Get(rgname, workspaceName);
                Assert.Equal("westus2", fetchedWorkspace.Location);
            }
        }

        [Fact]
        public void HealthcareApisDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = HealthcareApisManagementTestUtilities.GetResourceManagementClient(context, handler);
                var healthCareApisMgmtClient = HealthcareApisManagementTestUtilities.GetHealthcareApisManagementClient(context, handler);

                // Create resource group
                var rgname = HealthcareApisManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Generate account name
                string accountName = TestUtilities.GenerateName("hca");

                var workspace = HealthcareApisManagementTestUtilities.GetWorkspace();

                // Create healthcareApis account
                var account = healthCareApisMgmtClient.Workspaces.BeginCreateOrUpdate(rgname, accountName, workspace);

                // Delete an account
                healthCareApisMgmtClient.Workspaces.BeginDelete(rgname, accountName);

                // Delete an account which does not exist
                healthCareApisMgmtClient.Services.Delete(rgname, "missingaccount");
            }
        }


        [Fact]
        public void HealthcareApisDeleteAccountErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = HealthcareApisManagementTestUtilities.GetResourceManagementClient(context, handler);
                var healthCareApisMgmtClient = HealthcareApisManagementTestUtilities.GetHealthcareApisManagementClient(context, handler);

                // Create resource group
                var rgname = HealthcareApisManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // try to delete non-existent account
                HealthcareApisManagementTestUtilities.ValidateExpectedException(
                    () => healthCareApisMgmtClient.Services.Delete("NotExistedRG", "nonExistedAccountName"),
                     HttpStatusCode.NotFound.ToString());
            }
        }

        [Fact]
        public void HealthcareApisCheckNameAvailabilityTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = HealthcareApisManagementTestUtilities.GetResourceManagementClient(context, handler);
                var healthCareApisMgmtClient = HealthcareApisManagementTestUtilities.GetHealthcareApisManagementClient(context, handler);
                CheckNameAvailabilityParameters checkNameAvailabilityParameters = new CheckNameAvailabilityParameters
                {
                    Name = "hca1234",
                    Type = "Microsoft.HealthcareApis/services"
                };
                var servicesNameAvailabilityInfo = healthCareApisMgmtClient.Services.CheckNameAvailability(checkNameAvailabilityParameters);
                Assert.True(servicesNameAvailabilityInfo.NameAvailable);
            }
        }

        [Fact]
        public void HealthcareApisAccountPrivateEndpointConnectionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = HealthcareApisManagementTestUtilities.GetResourceManagementClient(context, handler);
                var healthCareApisMgmtClient = HealthcareApisManagementTestUtilities.GetHealthcareApisManagementClient(context, handler);

                // Create resource group
                var rgname = HealthcareApisManagementTestUtilities.CreateResourceGroup(resourcesClient);

                {
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("hca1234");

                    var workspace = HealthcareApisManagementTestUtilities.GetWorkspace();

                    // Create healthcare apis account
                    var account = healthCareApisMgmtClient.Workspaces.BeginCreateOrUpdate(rgname, accountName, workspace);

                    // Create private link resource
                    var plResouces = healthCareApisMgmtClient.WorkspacePrivateLinkResources.ListByWorkspace(rgname, accountName);

                    PrivateEndpointConnection pec = null;
                    try
                    {
                        pec = healthCareApisMgmtClient.WorkspacePrivateEndpointConnections.Get(rgname, accountName, "notExistPCN");
                    }
                    catch { }

                    // verify
                    Assert.NotNull(plResouces);
                    Assert.True(plResouces.Count() == 1);
                    Assert.Equal("healthcareworkspace", plResouces.First().GroupId);
                    Assert.Null(pec);

                    var plConnections = healthCareApisMgmtClient.WorkspacePrivateEndpointConnections.ListByWorkspace(rgname, accountName);
                    Assert.True(plConnections.ToList().Count == 0);
                }
            }
        }
    }
}

