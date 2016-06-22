// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Scenario tests for the integration accounts map.
    /// </summary>
    [Collection("IntegrationAccountMapScenarioTests")]
    public class IntegrationAccountMapScenarioTests : BaseScenarioTests
    {

        /// <summary>
        /// Name of the test class
        /// </summary>
        private const string TestClass = "Test.Azure.Management.Logic.IntegrationAccountMapScenarioTests";

        /// <summary>
        /// Map content in string format
        /// </summary>
        private string MapContent { get; set; }

        /// <summary>
        ///Initializes a new instance of the <see cref="IntegrationAccountMapScenarioTests"/> class.
        /// </summary>
        public IntegrationAccountMapScenarioTests()
        {
            this.MapContent = File.ReadAllText(@"TestData/SampleXsltMap.xsl");
        }

        /// <summary>
        /// Tests the create and delete operations of the integration account map.
        /// </summary>
        [Fact]
        public void CreateAndDeleteIntegrationAccountMap()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountMapName = TestUtilities.GenerateName(Constants.IntegrationAccountMapPrefix);

                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var map = client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountMapName,
                    CreateIntegrationAccountMapInstance(integrationAccountMapName, integrationAccountName));

                Assert.Equal(map.Name, integrationAccountMapName);
                Assert.NotNull(map.ContentLink.Uri);

                client.IntegrationAccountMaps.Delete(Constants.DefaultResourceGroup, integrationAccountName,
                    integrationAccountMapName);
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the delete operations of the integration account map on account deletion.
        /// </summary>
        [Fact]
        public void DeleteIntegrationAccountMapOnAccountDeletion()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountMapName = TestUtilities.GenerateName(Constants.IntegrationAccountMapPrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var map = client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountMapName,
                    CreateIntegrationAccountMapInstance(integrationAccountMapName, integrationAccountName));

                Assert.Equal(map.Name, integrationAccountMapName);
                Assert.NotNull(map.ContentLink.Uri);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(
                    () =>
                        client.IntegrationAccountMaps.Get(Constants.DefaultResourceGroup, integrationAccountName,
                            integrationAccountMapName));
            }
        }

        /// <summary>
        /// Tests the create and Update operations of the integration account map.
        /// </summary>
        [Fact]
        public void CreateAndUpdateIntegrationAccountMap()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountMapName = TestUtilities.GenerateName(Constants.IntegrationAccountMapPrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    integrationAccountMapName,
                    CreateIntegrationAccountMapInstance(integrationAccountMapName, integrationAccountName));

                client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    integrationAccountMapName, new IntegrationAccountMap
                    {
                        ContentType = "application/xml",
                        Location = Constants.DefaultLocation,
                        Name = integrationAccountMapName,
                        MapType = MapType.Xslt,
                        Content = this.MapContent,
                        Metadata = "meta-data"
                    });

                var updatedMap = client.IntegrationAccountMaps.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountMapName);

                Assert.Equal(updatedMap.Name, integrationAccountMapName);
                Assert.NotNull(updatedMap.ContentLink.Uri);
                Assert.Equal(updatedMap.Metadata, "meta-data");

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and get operations of the integration account map.
        /// </summary>
        [Fact]
        public void CreateAndGetIntegrationAccountMap()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountMapName = TestUtilities.GenerateName(Constants.IntegrationAccountMapPrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var map = client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountMapName,
                    CreateIntegrationAccountMapInstance(integrationAccountMapName, integrationAccountName));

                Assert.Equal(map.Name, integrationAccountMapName);

                var getMap = client.IntegrationAccountMaps.Get(Constants.DefaultResourceGroup, integrationAccountName,
                    integrationAccountMapName);

                Assert.Equal(map.Name, getMap.Name);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and List operations of the integration account map.
        /// </summary>
        [Fact]
        public void ListIntegrationAccountMaps()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountMapName = TestUtilities.GenerateName(Constants.IntegrationAccountMapPrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    integrationAccountMapName,
                    CreateIntegrationAccountMapInstance(integrationAccountMapName, integrationAccountName));

                var maps = client.IntegrationAccountMaps.List(Constants.DefaultResourceGroup, integrationAccountName);

                Assert.True(maps.Any());

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        #region Private

        /// <summary>
        /// Creates an Integration account map.
        /// </summary>
        /// <param name="integrationAccountMapName">Name of the Map</param>
        /// <param name="integrationAccountName">Integration account name</param>        
        /// <returns>Map instance</returns>
        private IntegrationAccountMap CreateIntegrationAccountMapInstance(string integrationAccountMapName,
            string integrationAccountName
            )
        {
            var map = new IntegrationAccountMap
            {
                ContentType = "application/xml",
                Location = Constants.DefaultLocation,
                Name = integrationAccountMapName,
                Tags = new Dictionary<string, string>()
                {
                    {"integrationAccountMapName", integrationAccountMapName}
                },
                MapType = MapType.Xslt,
                Content = this.MapContent,
                Metadata = integrationAccountMapName
            };
            return map;
        }

        #endregion Private
    }
}