// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.IO;

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;
    using Test.Azure.Management.Logic;    

    public class IntegrationAccountInMemoryTests : BaseInMemoryTests
    {
        public IntegrationAccountInMemoryTests()
        {
            var content = File.ReadAllText(@"TestData/IntegrationAccountResponseContent.json");
            var callbackUrlContent = File.ReadAllText(@"TestData/IntegrationAccountCallbackUrlResponseContent.json");            

            this.IntegrationAccountsList =
                new StringContent(string.Format(Constants.ListFormat,
                    content, Constants.NextPageLink));
            this.IntegrationAccount = new StringContent(content);
            this.IntegrationAccountCallbackUrl = new StringContent(callbackUrlContent);
        }

        private StringContent IntegrationAccountsList { get; set; }

        private StringContent IntegrationAccount { get; set; }

        private StringContent IntegrationAccountCallbackUrl { get; set; }

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

            Assert.Throws<CloudException>(() => client.IntegrationAccounts.ListBySubscription());
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
            Assert.Throws<CloudException>(() => client.IntegrationAccounts.ListBySubscriptionNext(Constants.NextPageLink));
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
            Assert.Throws<CloudException>(() => client.IntegrationAccounts.ListByResourceGroup(ResourceGroupName));
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

            var result = client.IntegrationAccounts.ListByResourceGroup(ResourceGroupName);

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
            Assert.Throws<CloudException>(() => client.IntegrationAccounts.ListByResourceGroupNext(Constants.NextPageLink));
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
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.CreateOrUpdate(ResourceGroupName, null, new IntegrationAccount()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccounts.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", new IntegrationAccount()));
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

            var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", new IntegrationAccount());

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

            var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", new IntegrationAccount());

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
                StatusCode = HttpStatusCode.NotFound
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Delete(null, "IntegrationAccountName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Delete(ResourceGroupName, null));
            Assert.Throws<CloudException>(() => client.IntegrationAccounts.Delete(ResourceGroupName, "IntegrationAccountName"));
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

            client.IntegrationAccounts.Delete(ResourceGroupName, "IntegrationAccountName");

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

            client.IntegrationAccounts.Delete(ResourceGroupName, "IntegrationAccountName");

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
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Get(ResourceGroupName, null));
            Assert.Throws<CloudException>(() => client.IntegrationAccounts.Get(ResourceGroupName, "IntegrationAccountName"));
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

            var result = client.IntegrationAccounts.Get(ResourceGroupName, "IntegrationAccountName");

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
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Update(ResourceGroupName, null, new IntegrationAccount()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.Update(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccounts.Update(ResourceGroupName, "IntegrationAccountName", new IntegrationAccount()));
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
            
            integrationAccount = client.IntegrationAccounts.Update(ResourceGroupName, "IntegrationAccountName", integrationAccount);

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

            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.ListCallbackUrl(null, "IntegrationAccountName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccounts.ListCallbackUrl(ResourceGroupName, null));            
            Assert.Throws<CloudException>(() => client.IntegrationAccounts.ListCallbackUrl(ResourceGroupName, "IntegrationAccountName"));
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

            var result = client.IntegrationAccounts.ListCallbackUrl(ResourceGroupName, "IntegrationAccountName" );

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Post);

            Assert.NotNull(result.Value);
            // Validates result.
            
        }

        private void ValidateIntegrationAccountList(IPage<IntegrationAccount> result)
        {            
            Assert.Equal(1, result.Count());
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
