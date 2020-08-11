// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;

    public class IntegrationAccountSchemaInMemoryTests : InMemoryTestsBase
    {
        private StringContent SchemaList { get; set; }

        private StringContent Schema { get; set; }

        public IntegrationAccountSchemaInMemoryTests()
        {
            var content = File.ReadAllText(@"TestData/IntegrationAccountSchemaResponseContent.json");

            this.SchemaList = new StringContent(string.Format(Constants.ListFormat, content, Constants.NextPageLink));
            this.Schema = new StringContent(content);
        }

        [Fact]
        public void IntegrationAccountSchema_List_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.List(null, "IntegrationAccount"));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountSchemas.List(Constants.DefaultResourceGroup,"IntegrationAccount"));
        }

        [Fact]
        public void IntegrationAccountSchema_List_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.SchemaList
            };

            var result = client.IntegrationAccountSchemas.List(Constants.DefaultResourceGroup, "IntegrationAccount");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateSchemaList(result);
        }

        [Fact]
        public void IntegrationAccountSchema_ListNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.ListNext(null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountSchemas.ListNext(Constants.NextPageLink));
        }

        [Fact]
        public void IntegrationAccountSchema_ListNext_Success()
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

            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.CreateOrUpdate(null, "IntegrationAccountName", "SchemaName", new IntegrationAccountSchema(SchemaType.Xml)));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup, null, "SchemaName", new IntegrationAccountSchema(SchemaType.Xml)));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", null, new IntegrationAccountSchema(SchemaType.Xml)));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", "SchemaName", null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", "SchemaName", new IntegrationAccountSchema(SchemaType.Xml)));
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

            var schema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", "SchemaName", new IntegrationAccountSchema(SchemaType.Xml));

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

            var schema = client.IntegrationAccountSchemas.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", "SchemaName", new IntegrationAccountSchema(SchemaType.Xml));

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
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.Delete(null, "IntegrationAccountName","SchemaName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.Delete(Constants.DefaultResourceGroup, null, "SchemaName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName", null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountSchemas.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName","SchemaName"));
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

            client.IntegrationAccountSchemas.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName", "SchemaName");

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

            client.IntegrationAccountSchemas.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName","SchemaName");

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
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup, null, "SchemaName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup, "IntegrationAccountName", null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup, "IntegrationAccountName", "SchemaName"));
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

            var schema = client.IntegrationAccountSchemas.Get(Constants.DefaultResourceGroup, "IntegrationAccountName", "SchemaName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateSchema(schema);
        }

        private void ValidateSchemaList(IPage<IntegrationAccountSchema> result)
        {            
            Assert.Single(result);
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