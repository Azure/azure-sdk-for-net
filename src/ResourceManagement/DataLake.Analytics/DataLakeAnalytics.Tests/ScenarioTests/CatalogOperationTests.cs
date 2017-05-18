// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;

namespace DataLakeAnalytics.Tests
{
    public class CatalogOperationTests : TestBase
    {
        private CommonTestFixture commonData;

        [Fact]
        public void GetCatalogItemsTest()
        {
            // this test currently tests for Database, table TVF, view, types and procedure
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                commonData = new CommonTestFixture(context);
                commonData.HostUrl =
                    commonData.DataLakeAnalyticsManagementHelper.TryCreateDataLakeAnalyticsAccount(commonData.ResourceGroupName,
                        commonData.Location, commonData.DataLakeStoreAccountName, commonData.SecondDataLakeAnalyticsAccountName);
                
                commonData.DataLakeAnalyticsManagementHelper.CreateCatalog(commonData.ResourceGroupName,
                    commonData.SecondDataLakeAnalyticsAccountName, commonData.DatabaseName, commonData.TableName, commonData.TvfName, commonData.ViewName, commonData.ProcName);
                using (var clientToUse = commonData.GetDataLakeAnalyticsCatalogManagementClient(context))
                {
                    var dbListResponse = clientToUse.Catalog.ListDatabases(
                        commonData.SecondDataLakeAnalyticsAccountName);

                    Assert.True(dbListResponse.Count() >= 1);

                    // look for the DB we created
                    Assert.True(dbListResponse.Any(db => db.Name.Equals(commonData.DatabaseName)));

                    // Get the specific Database as well
                    var dbGetResponse = clientToUse.Catalog.GetDatabase(commonData.SecondDataLakeAnalyticsAccountName, commonData.DatabaseName);

                    Assert.Equal(commonData.DatabaseName, dbGetResponse.Name);

                    // Get the table list
                    var tableListResponse = clientToUse.Catalog.ListTables(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName);

                    Assert.True(tableListResponse.Count() >= 1);

                    // look for the table we created
                    Assert.True(tableListResponse.Any(table => table.Name.Equals(commonData.TableName)));

                    // Get the specific table as well
                    var tableGetResponse = clientToUse.Catalog.GetTable(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName, commonData.TableName);

                    Assert.Equal(commonData.TableName, tableGetResponse.Name);

                    // Get the TVF list
                    var tvfListResponse = clientToUse.Catalog.ListTableValuedFunctions(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName);

                    Assert.True(tvfListResponse.Count() >= 1);

                    // look for the tvf we created
                    Assert.True(tvfListResponse.Any(tvf => tvf.Name.Equals(commonData.TvfName)));

                    // Get the specific TVF as well
                    var tvfGetResponse = clientToUse.Catalog.GetTableValuedFunction(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName, commonData.TvfName);

                    Assert.Equal(commonData.TvfName, tvfGetResponse.Name);

                    // Get the View list
                    var viewListResponse = clientToUse.Catalog.ListViews(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName);

                    Assert.True(viewListResponse.Count() >= 1);

                    // look for the view we created
                    Assert.True(viewListResponse.Any(view => view.Name.Equals(commonData.ViewName)));

                    // Get the specific view as well
                    var viewGetResponse = clientToUse.Catalog.GetView(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName, commonData.ViewName);

                    Assert.Equal(commonData.ViewName, viewGetResponse.Name);

                    // Get the Procedure list
                    var procListResponse = clientToUse.Catalog.ListProcedures(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName);

                    Assert.True(procListResponse.Count() >= 1);

                    // look for the procedure we created
                    Assert.True(procListResponse.Any(proc => proc.Name.Equals(commonData.ProcName)));

                    // Get the specific procedure as well
                    var procGetResponse = clientToUse.Catalog.GetProcedure(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName, commonData.ProcName);

                    Assert.Equal(commonData.ProcName, procGetResponse.Name);

                    // Get the Partition list
                    var partitionList = clientToUse.Catalog.ListTablePartitions(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName, commonData.TableName);

                    Assert.True(partitionList.Count() >= 1);

                    var specificPartition = partitionList.First();
                    
                    // Get the specific partition as well
                    var partitionGetResponse = clientToUse.Catalog.GetTablePartition(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName, commonData.TableName, specificPartition.Name);

                    Assert.Equal(specificPartition.Name, partitionGetResponse.Name);

                    // Get all the types
                    var typeGetResponse = clientToUse.Catalog.ListTypes(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName);


                    Assert.NotNull(typeGetResponse);
                    Assert.NotEmpty(typeGetResponse);

                    // Get all the types that are not complex
                    typeGetResponse = clientToUse.Catalog.ListTypes(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, CommonTestFixture.SchemaName, new Microsoft.Rest.Azure.OData.ODataQuery<USqlType>{Filter = "isComplexType eq false"});


                    Assert.NotNull(typeGetResponse);
                    Assert.NotEmpty(typeGetResponse);
                    Assert.False(typeGetResponse.Any(type => type.IsComplexType.Value));
                }
            }
        }

        [Fact]
        public void CredentialCRUDTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                commonData = new CommonTestFixture(context);
                commonData.HostUrl =
                    commonData.DataLakeAnalyticsManagementHelper.TryCreateDataLakeAnalyticsAccount(commonData.ResourceGroupName,
                        commonData.Location, commonData.DataLakeStoreAccountName, commonData.SecondDataLakeAnalyticsAccountName);
                
                commonData.DataLakeAnalyticsManagementHelper.CreateCatalog(commonData.ResourceGroupName,
                    commonData.SecondDataLakeAnalyticsAccountName, commonData.DatabaseName, commonData.TableName, commonData.TvfName, commonData.ViewName, commonData.ProcName);
                using (var clientToUse = commonData.GetDataLakeAnalyticsCatalogManagementClient(context))
                {
                    // create the credential
                    clientToUse.Catalog.CreateCredential(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, commonData.SecretName,
                        new DataLakeAnalyticsCatalogCredentialCreateParameters
                        {
                            Password = commonData.SecretPwd,
                            Uri = "https://adlasecrettest.contoso.com:443",
                            UserId = TestUtilities.GenerateGuid("fakeUserId01").ToString()
                        });

                    // Attempt to create the secret again, which should throw
                    Assert.Throws<CloudException>(
                        () => clientToUse.Catalog.CreateCredential(
                                commonData.SecondDataLakeAnalyticsAccountName,
                                commonData.DatabaseName, commonData.SecretName,
                                new DataLakeAnalyticsCatalogCredentialCreateParameters
                                {
                                    Password = commonData.SecretPwd,
                                    Uri = "https://adlasecrettest.contoso.com:443",
                                    UserId = TestUtilities.GenerateGuid("fakeUserId02").ToString()
                                }));

                    // create another credential
                    var secondSecretName = commonData.SecretName + "dup";
                    clientToUse.Catalog.CreateCredential(
                    commonData.SecondDataLakeAnalyticsAccountName,
                    commonData.DatabaseName, secondSecretName,
                    new DataLakeAnalyticsCatalogCredentialCreateParameters
                    {
                        Password = commonData.SecretPwd,
                        Uri = "https://adlasecrettest.contoso.com:443",
                        UserId = TestUtilities.GenerateGuid("fakeUserId03").ToString()
                    });

                    // Get the credential and ensure the response contains a date.
                    var secretGetResponse = clientToUse.Catalog.GetCredential(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, commonData.SecretName);

                    Assert.NotNull(secretGetResponse);
                    Assert.NotNull(secretGetResponse.Name);

                    // Get the Credential list
                    var credListResponse = clientToUse.Catalog.ListCredentials(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName);
                    Assert.True(credListResponse.Count() >= 1);
                    // look for the credential we created
                    Assert.True(credListResponse.Any(cred => cred.Name.Equals(commonData.SecretName)));


                    // Get the specific credential as well
                    var credGetResponse = clientToUse.Catalog.GetCredential(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, commonData.SecretName);
                    Assert.Equal(commonData.SecretName, credGetResponse.Name);

                    // Delete the credential
                    clientToUse.Catalog.DeleteCredential(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, commonData.SecretName,
                        new DataLakeAnalyticsCatalogCredentialDeleteParameters(commonData.SecretPwd));

                    // Try to get the credential which should throw
                    Assert.Throws<CloudException>(() => clientToUse.Catalog.GetCredential(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, commonData.SecretName));

                    // Re-create and delete the credential using cascade = true, which should still succeed.
                    clientToUse.Catalog.CreateCredential(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, commonData.SecretName,
                        new DataLakeAnalyticsCatalogCredentialCreateParameters
                        {
                            Password = commonData.SecretPwd,
                            Uri = "https://adlasecrettest.contoso.com:443",
                            UserId = TestUtilities.GenerateGuid("fakeUserId01").ToString()
                        });

                    clientToUse.Catalog.DeleteCredential(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, commonData.SecretName,
                        new DataLakeAnalyticsCatalogCredentialDeleteParameters(commonData.SecretPwd), cascade: true);

                    // Try to get the credential which should throw
                    Assert.Throws<CloudException>(() => clientToUse.Catalog.GetCredential(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, commonData.SecretName));

                    // TODO: once support is available for delete all credentials add tests here for that.
                }
            }
        }

        [Fact]
        public void SecretCRUDTest()
        {
            // NOTE: This is deprecated and will be removed in a future release
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                commonData = new CommonTestFixture(context);
                commonData.HostUrl =
                    commonData.DataLakeAnalyticsManagementHelper.TryCreateDataLakeAnalyticsAccount(commonData.ResourceGroupName,
                        commonData.Location, commonData.DataLakeStoreAccountName, commonData.SecondDataLakeAnalyticsAccountName);
                
                commonData.DataLakeAnalyticsManagementHelper.CreateCatalog(commonData.ResourceGroupName,
                    commonData.SecondDataLakeAnalyticsAccountName, commonData.DatabaseName, commonData.TableName, commonData.TvfName, commonData.ViewName, commonData.ProcName);
                using (var clientToUse = commonData.GetDataLakeAnalyticsCatalogManagementClient(context))
                {
                    using (var jobClient = commonData.GetDataLakeAnalyticsJobManagementClient(context))
                    {
                        // create the secret
                        clientToUse.Catalog.CreateSecret(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, commonData.SecretName,
                            new DataLakeAnalyticsCatalogSecretCreateOrUpdateParameters
                            {
                                Password = commonData.SecretPwd,
                                Uri = "https://adlasecrettest.contoso.com:443"
                            });

                        // Attempt to create the secret again, which should throw
                        Assert.Throws<CloudException>(
                            () => clientToUse.Catalog.CreateSecret(
                                    commonData.SecondDataLakeAnalyticsAccountName,
                                    commonData.DatabaseName, commonData.SecretName,
                                    new DataLakeAnalyticsCatalogSecretCreateOrUpdateParameters
                                    {
                                        Password = commonData.SecretPwd,
                                        Uri = "https://adlasecrettest.contoso.com:443"
                                    }));

                        // create another secret
                        var secondSecretName = commonData.SecretName + "dup";
                        clientToUse.Catalog.CreateSecret(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, secondSecretName,
                        new DataLakeAnalyticsCatalogSecretCreateOrUpdateParameters
                        {
                            Password = commonData.SecretPwd,
                            Uri = "https://adlasecrettest.contoso.com:443"
                        });

                        // Get the secret and ensure the response contains a date.
                        var secretGetResponse = clientToUse.Catalog.GetSecret(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, commonData.SecretName);

                        Assert.NotNull(secretGetResponse);
                        Assert.NotNull(secretGetResponse.CreationTime);

                        // Delete the secret
                        clientToUse.Catalog.DeleteSecret(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, commonData.SecretName);

                        // Try to get the secret which should throw
                        Assert.Throws<CloudException>(() => clientToUse.Catalog.GetSecret(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, commonData.SecretName));

                        // Delete all secrets
                        clientToUse.Catalog.DeleteAllSecrets(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName);

                        // Try to get the second secret, which should throw.
                        // Try to get the secret which should throw
                        Assert.Throws<CloudException>(() => clientToUse.Catalog.GetSecret(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, secondSecretName));
                    }
                }
            }
        }
    }
}
