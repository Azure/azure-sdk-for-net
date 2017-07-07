// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.DocumentDB.Fluent;
using Microsoft.Azure.Management.DocumentDB.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Fluent.Tests
{
    public class DocumentDB
    {
        [Fact]
        public void DocumentDBCRUD()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = TestUtilities.GenerateName("db");
                var saName = TestUtilities.GenerateName("dbsa");
                var rgName = TestUtilities.GenerateName("ddbRg");
                var manager = TestHelper.CreateDocumentDB();
                var resourceManager = TestHelper.CreateResourceManager();
                IDocumentDBAccount databaseAccount = null;

                try
                {
                    databaseAccount = manager.DocumentDBAccounts.Define(dbName)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup(rgName)
                            .WithKind(DatabaseAccountKind.GlobalDocumentDB)
                            .WithSessionConsistency()
                            .WithWriteReplication(Region.USWest)
                            .WithReadReplication(Region.USCentral)
                            .WithIpRangeFilter("")
                            .Create();

                    Assert.Equal(databaseAccount.Name, dbName.ToLower());
                    Assert.Equal(databaseAccount.Kind, DatabaseAccountKind.GlobalDocumentDB);
                    Assert.Equal(databaseAccount.WritableReplications.Count, 1);
                    Assert.Equal(databaseAccount.ReadableReplications.Count, 2);
                    Assert.Equal(databaseAccount.DefaultConsistencyLevel, DefaultConsistencyLevel.Session);

                    databaseAccount = databaseAccount.Update()
                            .WithReadReplication(Region.AsiaSouthEast)
                            .WithoutReadReplication(Region.USEast)
                            .WithoutReadReplication(Region.USCentral)
                            .Apply();

                    databaseAccount = databaseAccount.Update()
                            .WithEventualConsistency()
                            .WithTag("tag2", "value2")
                            .WithTag("tag3", "value3")
                            .WithoutTag("tag1")
                            .Apply();
                    Assert.Equal(databaseAccount.DefaultConsistencyLevel, DefaultConsistencyLevel.Eventual);
                    Assert.True(databaseAccount.Tags.ContainsKey("tag2"));
                    Assert.True(!databaseAccount.Tags.ContainsKey("tag1"));
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }

            }
        }
    }
}
