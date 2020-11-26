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

                var serviceDescription = HealthcareApisManagementTestUtilities.GetServiceDescription();

                // Create healthcare apis account
                var account = healthCareApisMgmtClient.Services.CreateOrUpdate(rgname, accountName, serviceDescription);
                HealthcareApisManagementTestUtilities.VerifyAccountProperties(account, true);
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
                string accountName = TestUtilities.GenerateName("hca");

                var serviceDescription = HealthcareApisManagementTestUtilities.GetServiceDescription();

                // Create healthcare apis account
                var account = healthCareApisMgmtClient.Services.CreateOrUpdate(rgname, accountName, serviceDescription);
                Assert.Equal(Kind.Fhir, account.Kind);
            }
        }

        [Fact]
        public void HealthcareApisCreateWithParametersTest()
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

                var serviceDescription = HealthcareApisManagementTestUtilities.GetServiceDescriptionWithProperties();

                // Create healthcareApis account
                var account = healthCareApisMgmtClient.Services.CreateOrUpdate(rgname, accountName, serviceDescription);
                HealthcareApisManagementTestUtilities.VerifyAccountProperties(account, false);
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
                string accountName = TestUtilities.GenerateName("hca");

                var serviceDescription = HealthcareApisManagementTestUtilities.GetServiceDescription(Kind.FhirR4);

                // Create healthcareApis account
                var createdAccount = healthCareApisMgmtClient.Services.CreateOrUpdate(rgname, accountName, serviceDescription);

                var servicePatchDescription = HealthcareApisManagementTestUtilities.GetServicePatchDescription();

                // Update Tags
                var account = healthCareApisMgmtClient.Services.Update(rgname, accountName, servicePatchDescription);
                Assert.True(account.Tags.Values.Contains("value3"));
                Assert.True(account.Tags.Values.Contains("value4"));
                Assert.False(account.Tags.Values.Contains("value1"));
                Assert.False(account.Tags.Values.Contains("value2"));

                // Validate
                var fetchedAccount = healthCareApisMgmtClient.Services.Get(rgname, accountName);
                Assert.Equal(servicePatchDescription.Tags.Count, fetchedAccount.Tags.Count);
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

                var accounts = healthCareApisMgmtClient.Services.ListByResourceGroup(rgname);

                Assert.Empty(accounts);

                string accountName1 = HealthcareApisManagementTestUtilities.CreateHealthcareApisAccount(healthCareApisMgmtClient, rgname);
                string accountName2 = HealthcareApisManagementTestUtilities.CreateHealthcareApisAccount(healthCareApisMgmtClient, rgname);

                accounts = healthCareApisMgmtClient.Services.ListByResourceGroup(rgname);

                Assert.Equal(2, accounts.Count());

                HealthcareApisManagementTestUtilities.VerifyAccountProperties(accounts.First(), true);
                HealthcareApisManagementTestUtilities.VerifyAccountProperties(accounts.Skip(1).First(), true);
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
                string accountName = TestUtilities.GenerateName("hca");

                var serviceDescription = HealthcareApisManagementTestUtilities.GetServiceDescription();

                // Create healthcareApis account
                var createdAccount = healthCareApisMgmtClient.Services.CreateOrUpdate(rgname, accountName, serviceDescription);

                // Validate
                var fetchedAccount = healthCareApisMgmtClient.Services.Get(rgname, accountName);
                Assert.Equal(accountName, fetchedAccount.Name);
                Assert.Equal("westus", fetchedAccount.Location);
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

                var serviceDescription = HealthcareApisManagementTestUtilities.GetServiceDescription();

                // Create healthcareApis account
                var account = healthCareApisMgmtClient.Services.CreateOrUpdate(rgname, accountName, serviceDescription);

                // Delete an account
                healthCareApisMgmtClient.Services.Delete(rgname, accountName);

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

                    var serviceDescription = HealthcareApisManagementTestUtilities.GetServiceDescription();

                    // Create healthcare apis account
                    var account = healthCareApisMgmtClient.Services.CreateOrUpdate(rgname, accountName, serviceDescription);

                    // Create private link resource
                    var plResouces = healthCareApisMgmtClient.PrivateLinkResources.ListByService(rgname, accountName);

                    PrivateEndpointConnection pec = null;
                    try
                    {
                        pec = healthCareApisMgmtClient.PrivateEndpointConnections.Get(rgname, accountName, "notExistPCN");
                    }
                    catch { }

                    // verify
                    Assert.NotNull(plResouces);
                    Assert.True(plResouces.Value.Count == 1);
                    Assert.Equal("fhir", plResouces.Value[0].GroupId);
                    Assert.Null(pec);

                    var plConnections = healthCareApisMgmtClient.PrivateEndpointConnections.ListByService(rgname, accountName);
                    Assert.True(plConnections.ToList().Count == 0);
                }
            }
        }
    }
}

