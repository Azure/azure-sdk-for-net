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
            // This test currently tests for Database, table TVF, view, types and procedure, and ACLs
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                commonData = new CommonTestFixture(context);
                commonData.HostUrl =
                    commonData.DataLakeAnalyticsManagementHelper.TryCreateDataLakeAnalyticsAccount(
                        commonData.ResourceGroupName,
                        commonData.Location, 
                        commonData.DataLakeStoreAccountName, 
                        commonData.SecondDataLakeAnalyticsAccountName
                    );

                // Wait 5 minutes for the account setup
                TestUtilities.Wait(300000);

                commonData.DataLakeAnalyticsManagementHelper.CreateCatalog(
                    commonData.ResourceGroupName,
                    commonData.SecondDataLakeAnalyticsAccountName, 
                    commonData.DatabaseName, 
                    commonData.TableName, 
                    commonData.TvfName, 
                    commonData.ViewName, 
                    commonData.ProcName);

                using (var clientToUse = commonData.GetDataLakeAnalyticsCatalogManagementClient(context))
                {
                    var dbListResponse = 
                        clientToUse.Catalog.ListDatabases(
                            commonData.SecondDataLakeAnalyticsAccountName
                        );

                    Assert.True(dbListResponse.Count() >= 1);

                    // Look for the db we created
                    Assert.True(dbListResponse.Any(db => db.Name.Equals(commonData.DatabaseName)));

                    // Get the specific Database as well
                    var dbGetResponse = 
                        clientToUse.Catalog.GetDatabase(
                            commonData.SecondDataLakeAnalyticsAccountName, 
                            commonData.DatabaseName
                        );

                    Assert.Equal(commonData.DatabaseName, dbGetResponse.Name);

                    // Get the table list
                    var tableListResponse = 
                        clientToUse.Catalog.ListTables(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName
                        );

                    Assert.True(tableListResponse.Count() >= 1);
                    Assert.True(tableListResponse.ElementAt(0).ColumnList != null && tableListResponse.ElementAt(0).ColumnList.Count() > 0);

                    // Look for the table we created
                    Assert.True(tableListResponse.Any(table => table.Name.Equals(commonData.TableName)));

                    // Get the table list with only basic info
                    tableListResponse = 
                        clientToUse.Catalog.ListTables(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName, 
                            basic: true
                        );

                    Assert.True(tableListResponse.Count() >= 1);
                    Assert.True(tableListResponse.ElementAt(0).ColumnList == null || tableListResponse.ElementAt(0).ColumnList.Count() == 0);

                    // Get the table list in just the db
                    tableListResponse = 
                        clientToUse.Catalog.ListTablesByDatabase(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName
                        );

                    Assert.True(tableListResponse.Count() >= 1);
                    Assert.True(tableListResponse.ElementAt(0).ColumnList != null && tableListResponse.ElementAt(0).ColumnList.Count > 0);
                    
                    // Look for the table we created
                    Assert.True(tableListResponse.Any(table => table.Name.Equals(commonData.TableName)));
                    
                    // Get the table list in the db with only basic info
                    tableListResponse = 
                        clientToUse.Catalog.ListTablesByDatabase(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            basic: true
                        );

                    Assert.True(tableListResponse.Count() >= 1);
                    Assert.True(tableListResponse.ElementAt(0).ColumnList == null || tableListResponse.ElementAt(0).ColumnList.Count() == 0);

                    // Get preview of the specific table
                    var tablePreviewGetResponse = 
                        clientToUse.Catalog.PreviewTable(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName, 
                            commonData.TableName 
                        );

                    Assert.True(tablePreviewGetResponse.TotalRowCount > 0);
                    Assert.True(tablePreviewGetResponse.TotalColumnCount > 0);
                    Assert.True(tablePreviewGetResponse.Rows != null && tablePreviewGetResponse.Rows.Count() > 0);
                    Assert.True(tablePreviewGetResponse.Schema != null && tablePreviewGetResponse.Schema.Count() > 0);
                    Assert.NotNull(tablePreviewGetResponse.Schema[0].Name);
                    Assert.NotNull(tablePreviewGetResponse.Schema[0].Type);

                    // Get the specific table as well
                    var tableGetResponse = 
                        clientToUse.Catalog.GetTable(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName, 
                            commonData.TableName
                        );

                    Assert.Equal(commonData.TableName, tableGetResponse.Name);

                    // Get the tvf list
                    var tvfListResponse = 
                        clientToUse.Catalog.ListTableValuedFunctions(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName
                        );

                    Assert.True(tvfListResponse.Count() >= 1);

                    // Look for the tvf we created
                    Assert.True(tvfListResponse.Any(tvf => tvf.Name.Equals(commonData.TvfName)));

                    // Get tvf list in the database
                    tvfListResponse = 
                        clientToUse.Catalog.ListTableValuedFunctionsByDatabase(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName
                        );
                    
                    Assert.True(tvfListResponse.Count() >= 1);

                    // look for the tvf we created
                    Assert.True(tvfListResponse.Any(tvf => tvf.Name.Equals(commonData.TvfName)));

                    // Get the specific tvf as well
                    var tvfGetResponse = 
                        clientToUse.Catalog.GetTableValuedFunction(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName, 
                            commonData.TvfName
                        );

                    Assert.Equal(commonData.TvfName, tvfGetResponse.Name);

                    // Get the view list
                    var viewListResponse = 
                        clientToUse.Catalog.ListViews(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName
                        );

                    Assert.True(viewListResponse.Count() >= 1);

                    // Look for the view we created
                    Assert.True(viewListResponse.Any(view => view.Name.Equals(commonData.ViewName)));

                    // Get the view list from just the database
                    viewListResponse = 
                        clientToUse.Catalog.ListViewsByDatabase(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName
                        );

                    Assert.True(viewListResponse.Count() >= 1);

                    // Look for the view we created
                    Assert.True(viewListResponse.Any(view => view.Name.Equals(commonData.ViewName)));

                    // Get the specific view as well
                    var viewGetResponse = 
                        clientToUse.Catalog.GetView(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName, 
                            commonData.ViewName
                        );

                    Assert.Equal(commonData.ViewName, viewGetResponse.Name);

                    // Get the procedure list
                    var procListResponse = 
                        clientToUse.Catalog.ListProcedures(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName
                        );

                    Assert.True(procListResponse.Count() >= 1);

                    // Look for the procedure we created
                    Assert.True(procListResponse.Any(proc => proc.Name.Equals(commonData.ProcName)));

                    // Get the specific procedure as well
                    var procGetResponse = 
                        clientToUse.Catalog.GetProcedure(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName, 
                            commonData.ProcName
                        );

                    Assert.Equal(commonData.ProcName, procGetResponse.Name);

                    // Get the partition list
                    var partitionList = 
                        clientToUse.Catalog.ListTablePartitions(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName, 
                            commonData.TableName
                        );

                    Assert.True(partitionList.Count() >= 1);

                    var specificPartition = partitionList.First();

                    // Get preview of the specific partition
                    var partitionPreviewGetResponse = 
                        clientToUse.Catalog.PreviewTablePartition(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName, 
                            commonData.TableName, 
                            specificPartition.Name
                        );

                    Assert.True(partitionPreviewGetResponse.TotalRowCount > 0);
                    Assert.True(partitionPreviewGetResponse.TotalColumnCount > 0);
                    Assert.True(partitionPreviewGetResponse.Rows != null && partitionPreviewGetResponse.Rows.Count() > 0);
                    Assert.True(partitionPreviewGetResponse.Schema != null && partitionPreviewGetResponse.Schema.Count() > 0);
                    Assert.NotNull(tablePreviewGetResponse.Schema[0].Name);
                    Assert.NotNull(tablePreviewGetResponse.Schema[0].Type);
                    
                    // Get the specific partition as well
                    var partitionGetResponse = 
                        clientToUse.Catalog.GetTablePartition(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName, 
                            commonData.TableName, 
                            specificPartition.Name
                        );

                    Assert.Equal(specificPartition.Name, partitionGetResponse.Name);

                    // Get the fragment list
                    var fragmentList =
                        clientToUse.Catalog.ListTableFragments(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName,
                            CommonTestFixture.SchemaName,
                            commonData.TableName
                        );

                    Assert.NotNull(fragmentList);
                    Assert.NotEmpty(fragmentList);

                    // Get all the types
                    var typeGetResponse = 
                        clientToUse.Catalog.ListTypes(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName
                        );

                    Assert.NotNull(typeGetResponse);
                    Assert.NotEmpty(typeGetResponse);

                    // Get all the types that are not complex
                    typeGetResponse = 
                        clientToUse.Catalog.ListTypes(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            CommonTestFixture.SchemaName, 
                            new Microsoft.Rest.Azure.OData.ODataQuery<USqlType> { Filter = "isComplexType eq false" }
                        );

                    Assert.NotNull(typeGetResponse);
                    Assert.NotEmpty(typeGetResponse);
                    Assert.False(typeGetResponse.Any(type => type.IsComplexType.Value));

                    // Prepare to grant/revoke ACLs
                    var principalId = TestUtilities.GenerateGuid();
                    var grantAclParam = new AclCreateOrUpdateParameters
                    {
                        AceType = AclType.User,
                        PrincipalId = principalId,
                        Permission = PermissionType.Use
                    };
                    var revokeAclParam = new AclDeleteParameters
                    {
                        AceType = AclType.User,
                        PrincipalId = principalId
                    };

                    // Get the initial number of ACLs by db
                    var aclByDbListResponse = 
                        clientToUse.Catalog.ListAclsByDatabase(
                            commonData.SecondDataLakeAnalyticsAccountName, 
                            commonData.DatabaseName
                        );
                    var aclByDbCount = aclByDbListResponse.Count();

                    // Get the initial number of ACLs by catalog
                    var aclListResponse = 
                        clientToUse.Catalog.ListAcls(
                            commonData.SecondDataLakeAnalyticsAccountName
                        );
                    var aclCount = aclListResponse.Count();

                    // Grant ACL to the db
                    clientToUse.Catalog.GrantAclToDatabase(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        commonData.DatabaseName, 
                        grantAclParam
                    );
                    aclByDbListResponse = 
                        clientToUse.Catalog.ListAclsByDatabase(
                            commonData.SecondDataLakeAnalyticsAccountName, 
                            commonData.DatabaseName
                        );
                    var acl = aclByDbListResponse.Last();

                    // Confirm the ACL's information
                    Assert.Equal(aclByDbCount + 1, aclByDbListResponse.Count());
                    Assert.Equal(AclType.User, acl.AceType);
                    Assert.Equal(principalId, acl.PrincipalId);
                    Assert.Equal(PermissionType.Use, acl.Permission);

                    // Revoke ACL from the db
                    clientToUse.Catalog.RevokeAclFromDatabase(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        commonData.DatabaseName, 
                        revokeAclParam
                    );
                    aclByDbListResponse = 
                        clientToUse.Catalog.ListAclsByDatabase(
                            commonData.SecondDataLakeAnalyticsAccountName, 
                            commonData.DatabaseName
                        );

                    Assert.Equal(aclByDbCount, aclByDbListResponse.Count());

                    // Grant ACL to the catalog
                    clientToUse.Catalog.GrantAcl(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        grantAclParam
                    );
                    aclListResponse = 
                        clientToUse.Catalog.ListAcls(
                            commonData.SecondDataLakeAnalyticsAccountName
                        );
                    acl = aclListResponse.Last();

                    // Confirm the ACL's information
                    Assert.Equal(aclCount + 1, aclListResponse.Count());
                    Assert.Equal(AclType.User, acl.AceType);
                    Assert.Equal(principalId, acl.PrincipalId);
                    Assert.Equal(PermissionType.Use, acl.Permission);

                    // Revoke ACL from the catalog
                    clientToUse.Catalog.RevokeAcl(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        revokeAclParam
                    );
                    aclListResponse = 
                        clientToUse.Catalog.ListAcls(
                            commonData.SecondDataLakeAnalyticsAccountName
                        );

                    Assert.Equal(aclCount, aclListResponse.Count());
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
                    commonData.DataLakeAnalyticsManagementHelper.TryCreateDataLakeAnalyticsAccount(
                        commonData.ResourceGroupName,
                        commonData.Location, 
                        commonData.DataLakeStoreAccountName, 
                        commonData.SecondDataLakeAnalyticsAccountName
                    );

                // Wait 5 minutes for the account setup
                TestUtilities.Wait(300000);

                commonData.DataLakeAnalyticsManagementHelper.CreateCatalog(
                    commonData.ResourceGroupName,
                    commonData.SecondDataLakeAnalyticsAccountName, 
                    commonData.DatabaseName, 
                    commonData.TableName, 
                    commonData.TvfName, 
                    commonData.ViewName, 
                    commonData.ProcName
                );

                using (var clientToUse = commonData.GetDataLakeAnalyticsCatalogManagementClient(context))
                {
                    // Create the credential
                    clientToUse.Catalog.CreateCredential(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, 
                        commonData.SecretName,
                        new DataLakeAnalyticsCatalogCredentialCreateParameters
                        {
                            UserId = TestUtilities.GenerateGuid("fakeUserId01").ToString(),
                            Password = commonData.SecretPwd,
                            Uri = "https://adlasecrettest.contoso.com:443",
                        }
                    );

                    // Attempt to create the secret again, which should throw
                    Assert.Throws<CloudException>(
                        () => 
                        clientToUse.Catalog.CreateCredential(
                            commonData.SecondDataLakeAnalyticsAccountName,
                            commonData.DatabaseName, 
                            commonData.SecretName,
                            new DataLakeAnalyticsCatalogCredentialCreateParameters
                            {
                                UserId = TestUtilities.GenerateGuid("fakeUserId02").ToString(),
                                Password = commonData.SecretPwd,
                                Uri = "https://adlasecrettest.contoso.com:443",
                            }
                        )
                    );

                    // Create another credential
                    var secondSecretName = commonData.SecretName + "dup";
                    clientToUse.Catalog.CreateCredential(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, 
                        secondSecretName,
                        new DataLakeAnalyticsCatalogCredentialCreateParameters
                        {
                            UserId = TestUtilities.GenerateGuid("fakeUserId03").ToString(),
                            Password = commonData.SecretPwd,
                            Uri = "https://adlasecrettest.contoso.com:443",
                        }
                    );

                    // Get the credential and ensure the response contains a date.
                    var secretGetResponse = 
                        clientToUse.Catalog.GetCredential(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName, commonData.SecretName);

                    Assert.NotNull(secretGetResponse);
                    Assert.NotNull(secretGetResponse.Name);

                    // Get the Credential list
                    var credListResponse = clientToUse.Catalog.ListCredentials(
                        commonData.SecondDataLakeAnalyticsAccountName,
                        commonData.DatabaseName);

                    Assert.True(credListResponse.Count() >= 1);

                    // Look for the credential we created
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
    }
}
