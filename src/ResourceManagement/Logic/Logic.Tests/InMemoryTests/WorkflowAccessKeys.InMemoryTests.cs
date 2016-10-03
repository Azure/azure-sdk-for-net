// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;
    using System;
    public class WorkflowAccessKeysInMemoryTests : BaseInMemoryTests
    {
        #region Constructor

        private StringContent Key { get; set; }

        private StringContent KeyListResponse { get; set; }

        private StringContent SecretKeyResponse { get; set; }

        public WorkflowAccessKeysInMemoryTests()
        {
            var key = @"{
    'id': '/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/accessKeys/default',
    'name': 'default'
}";
            var secretKeyResponse = @"{
    'primarySecretKey':'8aa2Wy7zVNteALvwVCA4PV9RRRyZKqMpR-cOsEDA098',
    'secondarySecretKey':'mZTJ0CxAyzZhfpVqW__i2Zz7inZkihMPJkkrwaxUthk'
}";

            var keyListResponseFormat = @"{{ 'value': [ {0} ], 'nextLink': 'http://management.azure.com/keyNextLink' }}";

            this.Key = new StringContent(key);
            this.SecretKeyResponse = new StringContent(secretKeyResponse);
            this.KeyListResponse = new StringContent(string.Format(keyListResponseFormat, key));
        }

        #endregion

        #region WorkflowAccessKeys_List

        [Fact]
        public void WorkflowAccessKeys_List_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.List(null, "wfName"));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.List("rgName", null));
            Assert.Throws<CloudException>(() => client.WorkflowAccessKeys.List("rgName", "wfName"));
        }

        [Fact]
        public void WorkflowAccessKeys_List_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.KeyListResponse
            };

            var response = client.WorkflowAccessKeys.List("rgName", "wfName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateKeyListResponse1(response);
        }

        #endregion

        #region WorkflowAccessKeys_ListNext

        [Fact]
        public void WorkflowAccessKeys_ListNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.ListNext(null));
            Assert.Throws<CloudException>(() => client.WorkflowAccessKeys.ListNext("http://management.azure.com/link"));
        }

        [Fact]
        public void WorkflowAccessKeys_ListNext_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.KeyListResponse
            };

            var response = client.WorkflowAccessKeys.ListNext("http://management.azure.com/link");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateKeyListResponse1(response);
        }

        #endregion

        #region WorkflowAccessKeys_Get

        [Fact]
        public void WorkflowAccessKeys_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.Get(null, "wfName", "accessKeyName"));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.Get("rgName", null, "accessKeyName"));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.Get("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.WorkflowAccessKeys.Get("rgName", "wfName", "accessKeyName"));
        }

        [Fact]
        public void WorkflowAccessKeys_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Key
            };

            var key = client.WorkflowAccessKeys.Get("rgName", "wfName", "accessKeyName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateKey1(key);
        }

        #endregion

        #region WorkflowAccessKeys_CreateOrUpdate

        [Fact]
        public void WorkflowAccessKeys_CreateOrUpdate_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.CreateOrUpdate(null, "wfName", "accessKeyName", new WorkflowAccessKey()));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.CreateOrUpdate("rgName", null, "accessKeyName", new WorkflowAccessKey()));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.CreateOrUpdate("rgName", "wfName", null, new WorkflowAccessKey()));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.CreateOrUpdate("rgName", "wfName", "accessKeyName", null));
            Assert.Throws<CloudException>(() => client.WorkflowAccessKeys.CreateOrUpdate("rgName", "wfName", "accessKeyName", new WorkflowAccessKey()));
        }

        [Fact]
        public void WorkflowAccessKeys_CreateOrUpdate_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Key
            };

            var key = client.WorkflowAccessKeys.CreateOrUpdate("rgName", "wfName", "accessKeyName", new WorkflowAccessKey());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateKey1(key);
        }

        [Fact]
        public void WorkflowAccessKeys_CreateOrUpdate_Created()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);            
            
            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = this.Key
            };

            var key = client.WorkflowAccessKeys.CreateOrUpdate("rgName", "wfName", "accessKeyName", new WorkflowAccessKey());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateKey1(key);
        }

        #endregion

        #region WorkflowAccessKeys_Delete

        [Fact]
        public void WorkflowAccessKeys_Delete_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.Delete(null, "wfName", "accessKeyName"));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.Delete("rgName", null, "accessKeyName"));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.Delete("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.WorkflowAccessKeys.Delete("rgName", "wfName", "accessKeyName"));
        }

        [Fact]
        public void WorkflowAccessKeys_Delete_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Empty
            };

            client.WorkflowAccessKeys.Delete("rgName", "wfName", "accessKeyName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void WorkflowAccessKeys_Delete_NoContent()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent,
                Content = this.Empty
            };

            client.WorkflowAccessKeys.Delete("rgName", "wfName", "accessKeyName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        #endregion

        #region WorkflowAccessKeys_ListSecretKeys

        [Fact]
        public void WorkflowAccessKeys_ListSecretKeys_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.ListSecretKeys(null, "wfName", "accessKeyName"));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.ListSecretKeys("rgName", null, "accessKeyName"));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.ListSecretKeys("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.WorkflowAccessKeys.ListSecretKeys("rgName", "wfName", "accessKeyName"));
        }

        [Fact]
        public void WorkflowAccessKeys_ListSecretKeys_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.SecretKeyResponse
            };

            var response = client.WorkflowAccessKeys.ListSecretKeys("rgName", "wfName", "accessKeyName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Post);

            this.ValidateSecretKeys1(response);
        }

        #endregion

        #region WorkflowAccessKeys_RegenerateSecretKey

        [Fact]
        public void WorkflowAccessKeys_RegenerateSecretKey_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.RegenerateSecretKey(null, "wfName", "accessKeyName", KeyType.Primary));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.RegenerateSecretKey("rgName", null, "accessKeyName", KeyType.Primary));
            Assert.Throws<ValidationException>(() => client.WorkflowAccessKeys.RegenerateSecretKey("rgName", "wfName", null, KeyType.Primary));            
            Assert.Throws<CloudException>(() => client.WorkflowAccessKeys.RegenerateSecretKey("rgName", "wfName", "accessKeyName", KeyType.Primary));
        }

        [Fact]
        public void WorkflowAccessKeys_RegenerateSecretKey_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.SecretKeyResponse
            };

            var response = client.WorkflowAccessKeys.RegenerateSecretKey("rgName", "wfName", "accessKeyName", KeyType.Primary );

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Post);

            this.ValidateSecretKeys1(response);
        }

        #endregion

        #region Validation

        private void ValidateKey1(WorkflowAccessKey key)
        {
            Assert.Equal("/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/accessKeys/default", key.Id);
            Assert.Equal("default", key.Name);
        }

        private void ValidateKeyListResponse1(IPage<WorkflowAccessKey> page)
        {
            Assert.Equal(1, page.Count());
            Assert.Equal("http://management.azure.com/keyNextLink", page.NextPageLink);
            this.ValidateKey1(page.First());
        }

        private void ValidateSecretKeys1(WorkflowSecretKeys response)
        {
            Assert.Equal("8aa2Wy7zVNteALvwVCA4PV9RRRyZKqMpR-cOsEDA098", response.PrimarySecretKey);
            Assert.Equal("mZTJ0CxAyzZhfpVqW__i2Zz7inZkihMPJkkrwaxUthk", response.SecondarySecretKey);
        }

        #endregion
    }
}
