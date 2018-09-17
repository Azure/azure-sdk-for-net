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
    using System;

    /// <summary>
    /// Scenario tests for the integration accounts schema.
    /// </summary>
    [Collection("IntegrationAccountSchemaScenarioTests")]
    public class IntegrationAccountSchemaScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;
        private readonly string integrationAccountName;
        private readonly IntegrationAccount integrationAccount;
        private readonly string schemaName;
        private readonly string schemaContent;

        public IntegrationAccountSchemaScenarioTests()
        {
            this.context = MockContext.Start(className: this.TestClassName);
            this.client = this.GetClient(this.context);

            this.integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
            this.integrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.CreateIntegrationAccount(this.integrationAccountName));

            this.schemaContent = File.ReadAllText(@"TestData/OrderFile.xsd");
            this.schemaName = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
        }


        public void Dispose()
        {
            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);

            this.client.Dispose();
            this.context.Dispose();
        }

        [Fact]
        public void IntegrationAccountSchemas_Create_OK()
        {
            var schema = this.CreateIntegrationAccountSchema(this.schemaName);
            var createdSchema = this.client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.schemaName,
                schema);

            this.ValidateSchema(schema, createdSchema);
        }

        [Fact]
        public void IntegrationAccountSchemas_Get_OK()
        {
            var schema = this.CreateIntegrationAccountSchema(this.schemaName);
            var createdSchema = this.client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.schemaName,
                schema);

            var retrievedSchema = this.client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.schemaName);

            this.ValidateSchema(schema, retrievedSchema);
        }

        [Fact]
        public void IntegrationAccountSchemas_List_OK()
        {
            var schema1 = this.CreateIntegrationAccountSchema(this.schemaName);
            var createdSchema = this.client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.schemaName,
                schema1);

            var schemaName2 = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
            var schema2 = this.CreateIntegrationAccountSchema(schemaName2);
            var createdSchema2 = this.client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                schemaName2,
                schema2);

            var schemaName3 = TestUtilities.GenerateName(Constants.IntegrationAccountSchemaPrefix);
            var schema3 = this.CreateIntegrationAccountSchema(schemaName3);
            var createdSchema3 = this.client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                schemaName3,
                schema3);

            var schemas = this.client.IntegrationAccountSchemas.List(Constants.DefaultResourceGroup, this.integrationAccountName);

            Assert.Equal(3, schemas.Count());
            this.ValidateSchema(schema1, schemas.Single(x => x.Name == schema1.Name));
            this.ValidateSchema(schema2, schemas.Single(x => x.Name == schema2.Name));
            this.ValidateSchema(schema3, schemas.Single(x => x.Name == schema3.Name));
        }

        [Fact]
        public void IntegrationAccountSchemas_Update_OK()
        {
            var schema = this.CreateIntegrationAccountSchema(this.schemaName);
            var createdSchema = this.client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.schemaName,
                schema);

            var newSchema = this.CreateIntegrationAccountSchema(this.schemaName);
            var updatedSchema = this.client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.schemaName,
                newSchema);

            this.ValidateSchema(newSchema, updatedSchema);
        }

        [Fact]
        public void IntegrationAccountSchemas_Delete_OK()
        {
            var schema = this.CreateIntegrationAccountSchema(this.schemaName);
            var createdSchema = this.client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.schemaName,
                schema);

            this.client.IntegrationAccountSchemas.Delete(Constants.DefaultResourceGroup, this.integrationAccountName, this.schemaName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.schemaName));
        }

        [Fact]
        public void IntegrationAccountSchemas_DeleteWhenDeleteIntegrationAccount_OK()
        {
            var schema = this.CreateIntegrationAccountSchema(this.schemaName);
            var createdSchema = this.client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.schemaName,
                schema);

            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.schemaName));
        }

        [Fact]
        public void IntegrationAccountSchemas_ListContentCallbackUrl_OK()
        {
            var schema = this.CreateIntegrationAccountSchema(this.schemaName);
            var createdSchema = this.client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.schemaName,
                schema);

            var contentCallbackUrl = this.client.IntegrationAccountSchemas.ListContentCallbackUrl(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.schemaName,
                new GetCallbackUrlParameters
                {
                    KeyType = "Primary"
                });

            Assert.Equal("GET", contentCallbackUrl.Method);
            Assert.Contains(this.schemaName, contentCallbackUrl.Value);
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
                content: this.schemaContent,
                contentType: "application/xml");
        }

        #endregion
    }
}