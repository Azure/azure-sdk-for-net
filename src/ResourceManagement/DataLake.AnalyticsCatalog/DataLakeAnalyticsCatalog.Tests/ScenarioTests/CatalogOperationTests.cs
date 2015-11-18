//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Management.DataLake.AnalyticsCatalog;
using Microsoft.Azure.Management.DataLake.AnalyticsCatalog.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace DataLakeAnalyticsCatalog.Tests
{
    public class CatalogOperationTests : TestBase, IUseFixture<CommonTestFixture>
    {
        private CommonTestFixture commonData;

        public void SetFixture(CommonTestFixture data)
        {
            commonData = data;

        }

        [Fact]
        public void GetCatalogItemsTest()
        {
            // this test currently tests for Database, table TVF, view, types and procedure
            try
            {
                UndoContext.Current.Start();
                using (var clientToUse = commonData.GetDataLakeAnalyticsCatalogManagementClient())
                {
                    var dbListResponse = clientToUse.Catalog.ListDatabases(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName);
                    Assert.Equal(HttpStatusCode.OK, dbListResponse.StatusCode);
                    Assert.True(dbListResponse.DatabaseList.Value.Count >= 1);

                    // look for the DB we created
                    Assert.True(dbListResponse.DatabaseList.Value.Any(db => db.Name.Equals(commonData.DatabaseName)));

                    // Get the specific Database as well
                    var dbGetResponse = clientToUse.Catalog.GetDatabase(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName);
                    Assert.Equal(HttpStatusCode.OK, dbGetResponse.StatusCode);
                    Assert.Equal(commonData.DatabaseName, dbGetResponse.Database.Name);

                    // Get the table list
                    var tableListResponse = clientToUse.Catalog.ListTables(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo");
                    Assert.Equal(HttpStatusCode.OK, tableListResponse.StatusCode);
                    Assert.True(tableListResponse.TableList.Value.Count >= 1);

                    // look for the table we created
                    Assert.True(tableListResponse.TableList.Value.Any(table => table.Name.Equals(commonData.TableName)));

                    // Get the specific table as well
                    var tableGetResponse = clientToUse.Catalog.GetTable(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo", commonData.TableName);
                    Assert.Equal(HttpStatusCode.OK, tableGetResponse.StatusCode);
                    Assert.Equal(commonData.TableName, tableGetResponse.Table.Name);

                    // Get the TVF list
                    var tvfListResponse = clientToUse.Catalog.ListTableValuedFunctions(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo");
                    Assert.Equal(HttpStatusCode.OK, tvfListResponse.StatusCode);
                    Assert.True(tvfListResponse.TableValuedFunctionList.Value.Count >= 1);

                    // look for the tvf we created
                    Assert.True(tvfListResponse.TableValuedFunctionList.Value.Any(tvf => tvf.Name.Equals(commonData.TvfName)));

                    // Get the specific TVF as well
                    var tvfGetResponse = clientToUse.Catalog.GetTableValuedFunction(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo", commonData.TvfName);
                    Assert.Equal(HttpStatusCode.OK, tvfGetResponse.StatusCode);
                    Assert.Equal(commonData.TvfName, tvfGetResponse.TableValuedFunction.Name);

                    // Get the View list
                    var viewListResponse = clientToUse.Catalog.ListViews(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo");
                    Assert.Equal(HttpStatusCode.OK, viewListResponse.StatusCode);
                    Assert.True(viewListResponse.ViewList.Value.Count >= 1);

                    // look for the view we created
                    Assert.True(viewListResponse.ViewList.Value.Any(view => view.Name.Equals(commonData.ViewName)));

                    // Get the specific view as well
                    var viewGetResponse = clientToUse.Catalog.GetView(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo", commonData.ViewName);
                    Assert.Equal(HttpStatusCode.OK, viewGetResponse.StatusCode);
                    Assert.Equal(commonData.ViewName, viewGetResponse.View.Name);

                    // Get the Procedure list
                    var procListResponse = clientToUse.Catalog.ListProcedures(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo");
                    Assert.Equal(HttpStatusCode.OK, procListResponse.StatusCode);
                    Assert.True(procListResponse.ProcedureList.Value.Count >= 1);

                    // look for the procedure we created
                    Assert.True(procListResponse.ProcedureList.Value.Any(proc => proc.Name.Equals(commonData.ProcName)));

                    // Get the specific procedure as well
                    var procGetResponse = clientToUse.Catalog.GetProcedure(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo", commonData.ProcName);
                    Assert.Equal(HttpStatusCode.OK, procGetResponse.StatusCode);
                    Assert.Equal(commonData.ProcName, procGetResponse.Procedure.Name);

                    // Get all the types
                    var typeGetResponse = clientToUse.Catalog.ListTypes(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo", null);

                    Assert.Equal(HttpStatusCode.OK, typeGetResponse.StatusCode);
                    Assert.NotNull(typeGetResponse.TypeList.Value);
                    Assert.NotEmpty(typeGetResponse.TypeList.Value);

                    // Get all the types that are not complex
                    typeGetResponse = clientToUse.Catalog.ListTypes(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo", new TypeListParameters{Filter = "isComplexType eq false"});

                    Assert.Equal(HttpStatusCode.OK, typeGetResponse.StatusCode);
                    Assert.NotNull(typeGetResponse.TypeList.Value);
                    Assert.NotEmpty(typeGetResponse.TypeList.Value);
                    Assert.False(typeGetResponse.TypeList.Value.Any(type => type.IsComplexType));
                }
            }
            finally
            {
                // we don't catch any exceptions, those should all be bubbled up.
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void SecretAndCredentialCRUDTest()
        {
            try
            {
                UndoContext.Current.Start();
                using (var clientToUse = commonData.GetDataLakeAnalyticsCatalogManagementClient())
                {
                    using (var jobClient = commonData.GetDataLakeAnalyticsJobManagementClient())
                    {
                        // create the secret
                        var secretCreateResponse = clientToUse.Catalog.CreateSecret(commonData.ResourceGroupName,
                            commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName,
                            new DataLakeAnalyticsCatalogSecretCreateOrUpdateParameters
                            {
                                Password = commonData.SecretPwd,
                                SecretName = commonData.SecretName,
                                Uri = "https://adlasecrettest.contoso.com:443"
                            });

                        Assert.Equal(HttpStatusCode.OK, secretCreateResponse.StatusCode);

                        /*
                         * TODO: Enable once confirmed that we throw 409s when a secret already exists
                        // Attempt to create the secret again, which should throw
                        Assert.Throws<CloudException>(
                            () => clientToUse.Catalog.CreateSecret(commonData.ResourceGroupName,
                                commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName,
                                new DataLakeAnalyticsCatalogSecretCreateOrUpdateParameters
                                {
                                    Password = commonData.SecretPwd,
                                    SecretName = commonData.SecretName,
                                    Uri = "https://adlasecrettestnewuri.contoso.com:443"
                                }));
                        */

                        // Get the secret and ensure the response contains a date.
                        var secretGetResponse = clientToUse.Catalog.GetSecret(commonData.ResourceGroupName,
                            commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, commonData.SecretName);

                        Assert.Equal(HttpStatusCode.OK, secretGetResponse.StatusCode);
                        Assert.NotNull(secretGetResponse.Secret);
                        Assert.NotNull(secretGetResponse.Secret.CreationTime);

                        // Create a credential with the secret
                        var credentialCreationScript =
                            string.Format(
                                @"USE {0}; CREATE CREDENTIAL {1} WITH USER_NAME = ""scope@rkm4grspxa"", IDENTITY = ""{2}"";",
                                commonData.DatabaseName, commonData.CredentialName, commonData.SecretName);
                        commonData.CatalogManagementHelper.RunJobToCompletion(jobClient, commonData.ResourceGroupName,
                            commonData.DataLakeAnalyticsAccountName, TestUtilities.GenerateGuid(),
                            credentialCreationScript);

                        // Get the Credential list
                        var credListResponse = clientToUse.Catalog.ListCredentials(commonData.ResourceGroupName,
                            commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName);
                        Assert.Equal(HttpStatusCode.OK, credListResponse.StatusCode);
                        Assert.True(credListResponse.CredentialList.Value.Count >= 1);

                        // look for the credential we created
                        Assert.True(credListResponse.CredentialList.Value.Any(cred => cred.Name.Equals(commonData.CredentialName)));

                        // Get the specific credential as well
                        var credGetResponse = clientToUse.Catalog.GetCredential(commonData.ResourceGroupName,
                            commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, commonData.CredentialName);
                        Assert.Equal(HttpStatusCode.OK, credGetResponse.StatusCode);
                        Assert.Equal(commonData.CredentialName, credGetResponse.Credential.Name);

                        // Drop the credential (to enable secret deletion)
                        var credentialDropScript =
                            string.Format(
                                @"USE {0}; DROP CREDENTIAL {1};", commonData.DatabaseName, commonData.CredentialName);
                        commonData.CatalogManagementHelper.RunJobToCompletion(jobClient, commonData.ResourceGroupName,
                            commonData.DataLakeAnalyticsAccountName, TestUtilities.GenerateGuid(),
                            credentialDropScript);

                        // Delete the secret
                        var deleteSecretResponse = clientToUse.Catalog.DeleteSecret(commonData.ResourceGroupName,
                            commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, commonData.SecretName);

                        Assert.Equal(HttpStatusCode.OK, deleteSecretResponse.StatusCode);

                        // Try to get the secret which should throw
                        Assert.Throws<CloudException>(() => clientToUse.Catalog.GetSecret(commonData.ResourceGroupName,
                            commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, commonData.SecretName));
                    }

                }
            }
            finally
            {
                // we don't catch any exceptions, those should all be bubbled up.
                TestUtilities.EndTest();
            }
        }
    }
}
