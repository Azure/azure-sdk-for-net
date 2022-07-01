// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceLinker.Models;
using Azure.ResourceManager.Sql;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceLinker.Tests.Tests
{
    [TestFixture]
    public class WebAppSqlConnectionTests : ServiceLinkerTestBase
    {
        public WebAppSqlConnectionTests() : base(true)
        {
        }

        [SetUp]
        public async Task Init()
        {
            await InitializeClients();
        }

        [TestCase]
        [Ignore("Sql Database Creation Failed")]
        public async Task WebAppSqlConnectionCRUD()
        {
            string resourceGroupName = Recording.GenerateAssetName("SdkRg");
            string webAppName = Recording.GenerateAssetName("SdkWeb");
            string sqlServerName = Recording.GenerateAssetName("SdkSql");
            string sqlDatabaseName = Recording.GenerateAssetName("SdkSql");
            string sqlUserName = Recording.GenerateAssetName("SdkSql");
            string sqlPassword = Recording.GenerateAssetName("SdkPa5$");
            string linkerName = Recording.GenerateAssetName("SdkLinker");

            // create resource group
            await ResourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new Resources.ResourceGroupData(DefaultLocation));
            ResourceGroupResource resourceGroup = await ResourceGroups.GetAsync(resourceGroupName);

            // // create web app
            WebSiteCollection webSites = resourceGroup.GetWebSites();
            await webSites.CreateOrUpdateAsync(WaitUntil.Completed, webAppName, new WebSiteData(DefaultLocation));
            WebSiteResource webapp = await webSites.GetAsync(webAppName);

            // create sql database
            SqlServerCollection sqlServers = resourceGroup.GetSqlServers();
            SqlServerData sqlServerData = new SqlServerData(DefaultLocation)
            {
                AdministratorLogin = sqlUserName,
                AdministratorLoginPassword = sqlPassword,
            };
            await sqlServers.CreateOrUpdateAsync(WaitUntil.Completed, sqlServerName, sqlServerData);
            SqlServerResource sqlServer = await sqlServers.GetAsync(sqlServerName);

            SqlDatabaseCollection sqlDatabases = sqlServer.GetSqlDatabases();
            await sqlDatabases.CreateOrUpdateAsync(WaitUntil.Completed, sqlDatabaseName, new SqlDatabaseData(DefaultLocation));
            SqlDatabaseResource sqlDatabase = await sqlDatabases.GetAsync(sqlDatabaseName);

            // create service linker
            LinkerResourceCollection linkers = webapp.GetLinkerResources();
            var linkerData = new LinkerResourceData
            {
                TargetService = new Models.AzureResourceInfo
                {
                    Id = sqlDatabase.Id,
                },
                AuthInfo = new SecretAuthInfo
                {
                    Name = sqlUserName,
                    SecretInfo = new RawValueSecretInfo
                    {
                        Value = sqlPassword,
                    },
                },
                ClientType = LinkerClientType.Dotnet,
            };
            await linkers.CreateOrUpdateAsync(WaitUntil.Completed, linkerName, linkerData);

            // list service linker
            var linkerResources = await linkers.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, linkerResources.Count);
            Assert.AreEqual(linkerName, linkerResources[0].Data.Name);

            // get service linker
            LinkerResource linker = await linkers.GetAsync(linkerName);
            Assert.IsTrue(linker.Id.ToString().StartsWith(webapp.Id.ToString(), StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(sqlDatabase.Id, (linker.Data.TargetService as AzureResourceInfo).Id);
            Assert.AreEqual(LinkerAuthType.Secret, linker.Data.AuthInfo.AuthType);

            // get service linker configurations
            SourceConfigurationResult configurations = await linker.GetConfigurationsAsync();
            foreach (var configuration in configurations.Configurations)
            {
                Assert.IsNotNull(configuration.Name);
                Assert.IsNotNull(configuration.Value);
            }

            // delete service linker
            var operation = await linker.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(operation.HasCompleted);
        }
    }
}
