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
    /// Scenario tests for the integration accounts schema.
    /// </summary>
    [Collection("IntegrationAccountSchemaScenarioTests")]
    public class IntegrationAccountSchemaScenarioTests : BaseScenarioTests
    {
        /// <summary>
        /// Name of the test class
        /// </summary>
        private const string TestClass = "Test.Azure.Management.Logic.IntegrationAccountSchemaScenarioTests";

        /// <summary>
        /// Schema content in string format
        /// </summary>
        private string SchemaContent { get; set; }

        /// <summary>
        /// TargetNamespace of the schema
        /// </summary>
        private string SchemaTargetNamespace { get; set; }

        /// <summary>
        ///Initializes a new instance of the <see cref="IntegrationAccountSchemaScenarioTests"/> class.
        /// </summary>
        public IntegrationAccountSchemaScenarioTests()
        {
            this.SchemaContent = File.ReadAllText(@"TestData/OrderFile.xsd");
            this.SchemaTargetNamespace = "http://Inbound_EDI.OrderFile";
        }

        /// <summary>
        /// Tests the create and delete operations of the integration account schema.
        /// </summary>
        [Fact]
        public void CreateAndDeleteIntegrationAccountSchema()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountSchemaName = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);

                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var schema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSchemaName,
                    CreateIntegrationAccountSchemaInstance(integrationAccountSchemaName, integrationAccountName));

                Assert.Equal(schema.Name, integrationAccountSchemaName);
                //Assert.Equal(schema.TargetNamespace, this.SchemaTargetNamespace);
                Assert.NotNull(schema.ContentLink.Uri);

                client.IntegrationAccountSchemas.Delete(Constants.DefaultResourceGroup, integrationAccountName,
                    integrationAccountSchemaName);
                Assert.Throws<CloudException>(
                    () =>
                        client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup, integrationAccountName,
                            integrationAccountSchemaName));
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the deletion of the integration account schema on account deletion.
        /// </summary>
        [Fact]
        public void DeleteIntegrationAccountSchemaOnAccountDeletion()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountSchemaName = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);

                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var schema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSchemaName,
                    CreateIntegrationAccountSchemaInstance(integrationAccountSchemaName, integrationAccountName));

                Assert.Equal(schema.Name, integrationAccountSchemaName);
                //Assert.Equal(schema.TargetNamespace, this.SchemaTargetNamespace);
                Assert.NotNull(schema.ContentLink.Uri);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(
                    () =>
                        client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup, integrationAccountName,
                            integrationAccountSchemaName));
            }
        }

        /// <summary>
        /// Tests the create and Update operations of the integration account schema.
        /// </summary>
        [Fact]
        public void CreateAndUpdateIntegrationAccountSchema()
        {
            using (MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountSchemaName =TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);

                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var schema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSchemaName,
                    CreateIntegrationAccountSchemaInstance(integrationAccountSchemaName, integrationAccountName));

                var updatedSchema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountSchemaName, new IntegrationAccountSchema
                    {
                        ContentType = "application/xml",
                        Location = Constants.DefaultLocation,
                        Name = integrationAccountSchemaName,
                        SchemaType = SchemaType.Xml,
                        Content = this.SchemaContent
                    });

                Assert.Equal(updatedSchema.Name, integrationAccountSchemaName);
                Assert.NotNull(updatedSchema.ContentLink.Uri);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and get operations of the integration account schema.
        /// </summary>
        [Fact]
        public void CreateAndGetIntegrationAccountSchema()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountSchemaName = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);

                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var schema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSchemaName,
                    CreateIntegrationAccountSchemaInstance(integrationAccountSchemaName, integrationAccountName));

                Assert.Equal(schema.Name, integrationAccountSchemaName);
                //Assert.Equal(schema.TargetNamespace, this.SchemaTargetNamespace);

                var getSchema = client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountSchemaName);

                Assert.Equal(schema.Name, getSchema.Name);                

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and List operations of the integration account schema.
        /// </summary>
        [Fact]
        public void ListIntegrationAccountSchemas()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountSchemaName = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);

                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var createdSchema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSchemaName,
                    CreateIntegrationAccountSchemaInstance(integrationAccountSchemaName, integrationAccountName));

                var schemas = client.IntegrationAccountSchemas.List(Constants.DefaultResourceGroup,
                    integrationAccountName);

                Assert.True(schemas.Any());

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        /// <summary>
        /// Creates an Integration account schema
        /// </summary>
        /// <param name="integrationAccountSchemaName">Name of the schema</param>
        /// <param name="integrationAccountName">Name of the integration account</param>        
        /// <returns>Schema instance</returns>
        private IntegrationAccountSchema CreateIntegrationAccountSchemaInstance(string integrationAccountSchemaName,
            string integrationAccountName)
        {
            IDictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("integrationAccountSchemaName", integrationAccountSchemaName);

            var schema = new IntegrationAccountSchema
            {
                ContentType = "application/xml",
                Location = Constants.DefaultLocation,
                Name = integrationAccountSchemaName,
                Tags = tags,
                SchemaType = SchemaType.Xml,                
                Content = this.SchemaContent,
                Metadata = integrationAccountSchemaName
            };

            return schema;
        }
    }
}