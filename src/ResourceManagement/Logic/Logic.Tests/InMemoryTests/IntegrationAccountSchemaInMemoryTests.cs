// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;        

    public class IntegrationAccountSchemaInMemoryTests : BaseInMemoryTests
    {
        public IntegrationAccountSchemaInMemoryTests()
        {
            var content = File.ReadAllText(@"TestData/IntegrationAccountSchemaResponseContent.json");

            this.SchemaList = new StringContent(string.Format(Constants.ListFormat,
                content, Constants.NextPageLink));
            this.Schema = new StringContent(content);
        }

        private StringContent SchemaList { get; set; }

        private StringContent Schema { get; set; }

        [Fact]
        public void IntegrationAccountSchema_ListByResourceGroup_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(
                () => client.IntegrationAccountSchemas.List(null, "IntegrationAccount"));
            Assert.Throws<CloudException>(() => client.IntegrationAccountSchemas.List(ResourceGroupName,"IntegrationAccount"));
        }

        [Fact]
        public void IntegrationAccountSchema_ListByResourceGroup_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.SchemaList
            };

            var result = client.IntegrationAccountSchemas.List(ResourceGroupName, "IntegrationAccount");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateSchemaList(result);
        }

        [Fact]
        public void IntegrationAccountSchema_ListByResourceGroupNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.ListNext(null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountSchemas.ListNext(Constants.NextPageLink));
        }

        [Fact]
        public void IntegrationAccountSchema_ListByResourceGroupNext_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.SchemaList
            };

            var result = client.IntegrationAccountSchemas.ListNext(Constants.NextPageLink);

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateSchemaList(result);
        }

        [Fact]
        public void IntegrationAccountSchema_CreateOrUpdate_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.CreateOrUpdate(null, "IntegrationAccountName", "SchemaName", new IntegrationAccountSchema()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.CreateOrUpdate(ResourceGroupName, null, "SchemaName", new IntegrationAccountSchema()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", null, new IntegrationAccountSchema()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "SchemaName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountSchemas.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "SchemaName", new IntegrationAccountSchema()));
        }

        [Fact]
        public void IntegrationAccountSchema_CreateOrUpdate_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Schema
            };

            var schema = client.IntegrationAccountSchemas.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "SchemaName", new IntegrationAccountSchema());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateSchema(schema);
        }

        [Fact]
        public void IntegrationAccountSchema_CreateOrUpdate_Created()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = this.Schema
            };

            var schema = client.IntegrationAccountSchemas.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "SchemaName", new IntegrationAccountSchema());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateSchema(schema);
        }

        [Fact]
        public void IntegrationAccountSchema_Delete_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.Delete(null, "IntegrationAccountName","SchemaName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.Delete(ResourceGroupName, null, "SchemaName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.Delete(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountSchemas.Delete(ResourceGroupName, "IntegrationAccountName","SchemaName"));
        }

        [Fact]
        public void IntegrationAccountSchema_Delete_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            client.IntegrationAccountSchemas.Delete(ResourceGroupName, "IntegrationAccountName", "SchemaName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountSchema_Delete_NoContent()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };

            client.IntegrationAccountSchemas.Delete(ResourceGroupName, "IntegrationAccountName","SchemaName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountSchema_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.Get(null, "IntegrationAccountName", "SchemaName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.Get(ResourceGroupName, null, "SchemaName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.Get(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountSchemas.Get(ResourceGroupName, "IntegrationAccountName", "SchemaName"));
        }

        [Fact]
        public void IntegrationAccountSchema_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Schema
            };

            var schema = client.IntegrationAccountSchemas.Get(ResourceGroupName, "IntegrationAccountName", "SchemaName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateSchema(schema);
        }

        private void ValidateSchemaList(IPage<IntegrationAccountSchema> result)
        {            
            Assert.Equal(1, result.Count());
            this.ValidateSchema(result.First());
            Assert.Equal(Constants.NextPageLink, result.NextPageLink);
        }

        private void ValidateSchema(IntegrationAccountSchema schema)
        {
            Assert.Equal("/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourceGroups/IntegrationAccountSdkTest/providers/Microsoft.Logic/integrationAccounts/IntegrationAccount1600/schemas/IntegrationAccountSchema2147", schema.Id);            
            Assert.Equal("IntegrationAccountSchema2147", schema.Name);
            Assert.Equal("Microsoft.Logic/integrationAccounts/schemas", schema.Type);

            Assert.Equal(SchemaType.Xml, schema.SchemaType);
            Assert.Equal("http://Inbound_EDI.OrderFile", schema.TargetNamespace);
            Assert.NotNull(schema.ContentLink.Uri);
            Assert.Equal("\"0x8D33E2EA259B235\"", schema.ContentLink.ContentVersion);
            Assert.Equal(7901, schema.ContentLink.ContentSize);
            Assert.Equal("md5", schema.ContentLink.ContentHash.Algorithm);
            Assert.NotNull(schema.ContentLink.ContentHash.Value);


            //"2016-02-25T21:57:21.3956457Z"
            Assert.Equal(2016, schema.CreatedTime.Value.Year);
            Assert.Equal(02, schema.CreatedTime.Value.Month);
            Assert.Equal(25, schema.CreatedTime.Value.Day);
            Assert.Equal(21, schema.CreatedTime.Value.Hour);
            Assert.Equal(57, schema.CreatedTime.Value.Minute);
            Assert.Equal(21, schema.CreatedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, schema.CreatedTime.Value.Kind);

            //{2/24/2016 7:49:39 PM}
            Assert.Equal(2016, schema.ChangedTime.Value.Year);
            Assert.Equal(02, schema.ChangedTime.Value.Month);
            Assert.Equal(25, schema.ChangedTime.Value.Day);
            Assert.Equal(21, schema.ChangedTime.Value.Hour);
            Assert.Equal(57, schema.ChangedTime.Value.Minute);
            Assert.Equal(21, schema.ChangedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, schema.ChangedTime.Value.Kind);

        }
    }
}