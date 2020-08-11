﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;

    public class IntegrationAccountInMemoryTests : InMemoryTestsBase
    {
        private StringContent IntegrationAccountsList { get; set; }

        private StringContent IntegrationAccount { get; set; }

        private StringContent IntegrationAccountCallbackUrl { get; set; }

        public IntegrationAccountInMemoryTests()
        {
            var content = File.ReadAllText(@"TestData/IntegrationAccountResponseContent.json");
            var callbackUrlContent = File.ReadAllText(@"TestData/IntegrationAccountCallbackUrlResponseContent.json");

            this.IntegrationAccountsList = new StringContent(string.Format(Constants.ListFormat, content, Constants.NextPageLink));
            this.IntegrationAccount = new StringContent(content);
            this.IntegrationAccountCallbackUrl = new StringContent(callbackUrlContent);
        }

        [Fact]
        public void IntegrationAccounts_ListBySubscription_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.IntegrationAccountsList
            };

            var result = client.IntegrationAccounts.ListBySubscription();

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateIntegrationAccountList(result);
        }

        [Fact]
        public void IntegrationAccounts_ListBySubscription_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccounts.ListBySubscription());
        }

        [Fact]
        public void IntegrationAccounts_ListBySubscriptionNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.ListBySubscriptionNext(null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccounts.ListBySubscriptionNext(Constants.NextPageLink));
        }

        [Fact]
        public void IntegrationAccounts_ListBySubscriptionNext_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.IntegrationAccountsList
            };
            
            var result = client.IntegrationAccounts.ListBySubscriptionNext(Constants.NextPageLink);

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateIntegrationAccountList( result);
        }

        [Fact]
        public void IntegrationAccounts_ListByResourceGroup_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.ListByResourceGroup(null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccounts.ListByResourceGroup(Constants.DefaultResourceGroup));
        }

        [Fact]
        public void IntegrationAccounts_ListByResourceGroup_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.IntegrationAccountsList
            };

            var result = client.IntegrationAccounts.ListByResourceGroup(Constants.DefaultResourceGroup);

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateIntegrationAccountList(result);
        }

        [Fact]
        public void IntegrationAccounts_ListByResourceGroupNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.ListByResourceGroupNext(null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccounts.ListByResourceGroupNext(Constants.NextPageLink));
        }

        [Fact]
        public void IntegrationAccounts_ListByResourceGroupNext_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.IntegrationAccountsList
            };

            var result = client.IntegrationAccounts.ListByResourceGroupNext(Constants.NextPageLink);

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateIntegrationAccountList(result);
        }

        [Fact]
        public void IntegrationAccounts_CreateOrUpdate_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.CreateOrUpdate(null, "IntegrationAccountName", new IntegrationAccount()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, null, new IntegrationAccount()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", new IntegrationAccount()));
        }

        [Fact]
        public void IntegrationAccounts_CreateOrUpdate_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.IntegrationAccount
            };

            var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", new IntegrationAccount());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateIntegrationAccount(integrationAccount);
        }

        [Fact]
        public void IntegrationAccounts_CreateOrUpdate_Created()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = this.IntegrationAccount
            };

            var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", new IntegrationAccount());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateIntegrationAccount(integrationAccount);
        }

        [Fact]
        public void IntegrationAccounts_Delete_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Delete(null, "IntegrationAccountName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName"));
        }

        [Fact]
        public void IntegrationAccounts_Delete_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccounts_Delete_NoContent()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };

            client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccounts_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Get(null, "IntegrationAccountName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Get(Constants.DefaultResourceGroup, null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccounts.Get(Constants.DefaultResourceGroup, "IntegrationAccountName"));
        }

        [Fact]
        public void IntegrationAccounts_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.IntegrationAccount
            };

            var result = client.IntegrationAccounts.Get(Constants.DefaultResourceGroup, "IntegrationAccountName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateIntegrationAccount(result);
        }

        [Fact]
        public void IntegrationAccounts_Update_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Update(null, "IntegrationAccountName", new IntegrationAccount()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Update(Constants.DefaultResourceGroup, null, new IntegrationAccount()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Update(Constants.DefaultResourceGroup, "IntegrationAccountName", null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccounts.Update(Constants.DefaultResourceGroup, "IntegrationAccountName", new IntegrationAccount()));
        }

        [Fact]
        public void IntegrationAccounts_Update_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.IntegrationAccount
            };

            var integrationAccount = new IntegrationAccount()
            {                
                Tags = new Dictionary<string, string>()
            };
            
            integrationAccount = client.IntegrationAccounts.Update(Constants.DefaultResourceGroup, "IntegrationAccountName", integrationAccount);

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(new HttpMethod("PATCH"));

            // Validates result.
            this.ValidateIntegrationAccount(integrationAccount);
        }


        [Fact]
        public void IntegrationAccounts_ListCallbackUrl_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.ListCallbackUrl(null, "IntegrationAccountName", new GetCallbackUrlParameters()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.ListCallbackUrl(Constants.DefaultResourceGroup, null, new GetCallbackUrlParameters()));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccounts.ListCallbackUrl(Constants.DefaultResourceGroup, "IntegrationAccountName", new GetCallbackUrlParameters()));
        }

        [Fact]
        public void IntegrationAccounts_ListCallbackUrl_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.IntegrationAccountCallbackUrl
            };

            var result = client.IntegrationAccounts.ListCallbackUrl(Constants.DefaultResourceGroup, "IntegrationAccountName", new GetCallbackUrlParameters());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Post);

            // Validates result.
            Assert.NotNull(result.Value);
        }

        private void ValidateIntegrationAccountList(IPage<IntegrationAccount> result)
        {            
            Assert.Single(result);
            this.ValidateIntegrationAccount(result.First());
            Assert.Equal(Constants.NextPageLink, result.NextPageLink);
        }

        private void ValidateIntegrationAccount(IntegrationAccount account)
        {
            Assert.Equal("/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourceGroups/IntegrationAccountSdkTest/providers/Microsoft.Logic/integrationAccounts/IntegrationAccount8391", account.Id);
            Assert.Equal("brazilsouth", account.Location);
            Assert.Equal("IntegrationAccount8391", account.Name);
            Assert.Equal("Microsoft.Logic/integrationAccounts", account.Type);
        }
    }
}
