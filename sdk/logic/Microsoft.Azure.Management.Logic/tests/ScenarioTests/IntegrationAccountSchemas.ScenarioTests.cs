// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using System.IO;

    /// <summary>
    /// Scenario tests for the integration accounts schema.
    /// </summary>
    [Collection("IntegrationAccountSchemaScenarioTests")]
    public class IntegrationAccountSchemaScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void IntegrationAccountSchemas_Create_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var schemaName = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
                var schema = this.CreateIntegrationAccountSchema(schemaName);
                var createdSchema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName,
                    schema);

                this.ValidateSchema(schema, createdSchema);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountSchemas_Get_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var schemaName = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
                var schema = this.CreateIntegrationAccountSchema(schemaName);
                var createdSchema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName,
                    schema);

                var retrievedSchema = client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName);

                this.ValidateSchema(schema, retrievedSchema);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountSchemas_List_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var schemaName1 = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
                var schema1 = this.CreateIntegrationAccountSchema(schemaName1);
                var createdSchema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName1,
                    schema1);

                var schemaName2 = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
                var schema2 = this.CreateIntegrationAccountSchema(schemaName2);
                var createdSchema2 = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName2,
                    schema2);

                var schemaName3 = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
                var schema3 = this.CreateIntegrationAccountSchema(schemaName3);
                var createdSchema3 = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName3,
                    schema3);

                var schemas = client.IntegrationAccountSchemas.List(Constants.DefaultResourceGroup, integrationAccountName);

                Assert.Equal(3, schemas.Count());
                this.ValidateSchema(schema1, schemas.Single(x => x.Name == schema1.Name));
                this.ValidateSchema(schema2, schemas.Single(x => x.Name == schema2.Name));
                this.ValidateSchema(schema3, schemas.Single(x => x.Name == schema3.Name));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountSchemas_Update_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var schemaName = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
                var schema = this.CreateIntegrationAccountSchema(schemaName);
                var createdSchema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName,
                    schema);

                var newSchema = this.CreateIntegrationAccountSchema(schemaName);
                var updatedSchema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName,
                    newSchema);

                this.ValidateSchema(newSchema, updatedSchema);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountSchemas_Delete_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var schemaName = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
                var schema = this.CreateIntegrationAccountSchema(schemaName);
                var createdSchema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName,
                    schema);

                client.IntegrationAccountSchemas.Delete(Constants.DefaultResourceGroup, integrationAccountName, schemaName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup, integrationAccountName, schemaName));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountSchemas_DeleteWhenDeleteIntegrationAccount_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var schemaName = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
                var schema = this.CreateIntegrationAccountSchema(schemaName);
                var createdSchema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName,
                    schema);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup, integrationAccountName, schemaName));
            }
        }

        [Fact]
        public void IntegrationAccountSchemas_ListContentCallbackUrl_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var schemaName = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
                var schema = this.CreateIntegrationAccountSchema(schemaName);
                var createdSchema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName,
                    schema);

                var contentCallbackUrl = client.IntegrationAccountSchemas.ListContentCallbackUrl(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    schemaName,
                    new GetCallbackUrlParameters
                    {
                        KeyType = "Primary"
                    });

                Assert.Equal("GET", contentCallbackUrl.Method);
                Assert.Contains(schemaName, contentCallbackUrl.Value);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        #region Private

        private void ValidateSchema(IntegrationAccountSchema expected, IntegrationAccountSchema actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.SchemaType, actual.SchemaType);
            Assert.Equal(expected.TargetNamespace, actual.TargetNamespace);
            Assert.NotEmpty(actual.ContentLink.Uri);
            Assert.NotNull(actual.ContentLink.ContentSize);
            Assert.NotNull(actual.CreatedTime);
            Assert.NotNull(actual.ChangedTime);
        }

        private IntegrationAccountSchema CreateIntegrationAccountSchema(string schemaName)
        {
            return new IntegrationAccountSchema(
                SchemaType.Xml,
                name: schemaName,
                location: Constants.DefaultLocation,
                targetNamespace: "http://Inbound_EDI.OrderFile",
                content: File.ReadAllText(@"TestData/OrderFile.xsd"),
                contentType: "application/xml");
        }

        #endregion
    }
}
