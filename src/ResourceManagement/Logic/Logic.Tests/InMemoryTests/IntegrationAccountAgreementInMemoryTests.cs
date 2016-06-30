// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Linq;

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;
    using System.IO;

    public class IntegrationAccountAgreementInMemoryTests : BaseInMemoryTests
    {
        public IntegrationAccountAgreementInMemoryTests()
        {
            var content = File.ReadAllText(@"TestData/IntegrationAccountAgreementResponseContent.json");

            this.AgreementList = new StringContent(string.Format(Constants.ListFormat,
                content, Constants.NextPageLink));
            this.Agreement = new StringContent(content);
        }

        private StringContent AgreementList { get; set; }

        private StringContent Agreement { get; set; }

        [Fact]
        public void IntegrationAccountAgreement_ListByResourceGroup_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(
                () => client.IntegrationAccountAgreements.List(null, "IntegrationAccount"));
            Assert.Throws<CloudException>(() => client.IntegrationAccountAgreements.List(ResourceGroupName, "IntegrationAccount"));
        }

        [Fact]
        public void IntegrationAccountAgreement_ListByResourceGroup_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.AgreementList
            };

            var result = client.IntegrationAccountAgreements.List(ResourceGroupName, "IntegrationAccount");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateAgreementList(result);
        }

        [Fact]
        public void IntegrationAccountAgreement_ListByResourceGroupNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.ListNext(null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountAgreements.ListNext(Constants.NextPageLink));
        }

        [Fact]
        public void IntegrationAccountAgreement_ListByResourceGroupNext_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.AgreementList
            };

            var result = client.IntegrationAccountAgreements.ListNext(Constants.NextPageLink);

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateAgreementList(result);
        }

        [Fact]
        public void IntegrationAccountAgreement_CreateOrUpdate_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.CreateOrUpdate(null, "IntegrationAccountName", "AgreementName", new IntegrationAccountAgreement()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.CreateOrUpdate(ResourceGroupName, null, "AgreementName", new IntegrationAccountAgreement()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", null, new IntegrationAccountAgreement()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "AgreementName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountAgreements.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "AgreementName", new IntegrationAccountAgreement()));
        }

        [Fact]
        public void IntegrationAccountAgreement_CreateOrUpdate_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Agreement
            };

            var result = client.IntegrationAccountAgreements.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "AgreementName", new IntegrationAccountAgreement());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateAgreement(result);
        }

        [Fact]
        public void IntegrationAccountAgreement_CreateOrUpdate_Created()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = this.Agreement
            };

            var result = client.IntegrationAccountAgreements.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "AgreementName", new IntegrationAccountAgreement());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateAgreement(result);
        }

        [Fact]
        public void IntegrationAccountAgreement_Delete_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.Delete(null, "IntegrationAccountName", "AgreementName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.Delete(ResourceGroupName, null, "AgreementName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.Delete(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountAgreements.Delete(ResourceGroupName, "IntegrationAccountName", "AgreementName"));
        }

        [Fact]
        public void IntegrationAccountAgreement_Delete_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            client.IntegrationAccountAgreements.Delete(ResourceGroupName, "IntegrationAccountName", "AgreementName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountAgreement_Delete_NoContent()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };

            client.IntegrationAccountAgreements.Delete(ResourceGroupName, "IntegrationAccountName", "AgreementName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountAgreement_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.Get(null, "IntegrationAccountName", "AgreementName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.Get(ResourceGroupName, null, "AgreementName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.Get(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountAgreements.Get(ResourceGroupName, "IntegrationAccountName", "AgreementName"));
        }

        [Fact]
        public void IntegrationAccountAgreement_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Agreement
            };

            var result = client.IntegrationAccountAgreements.Get(ResourceGroupName, "IntegrationAccountName", "AgreementName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateAgreement(result);
        }

        private void ValidateAgreementList(IPage<IntegrationAccountAgreement> result)
        {
            Assert.Equal(1, result.Count());
            this.ValidateAgreement(result.First());
            Assert.Equal(Constants.NextPageLink, result.NextPageLink);
        }

        private void ValidateAgreement(IntegrationAccountAgreement agreement)
        {
            Assert.Equal("/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourceGroups/IntegrationAccountSdkTest/providers/Microsoft.Logic/integrationAccounts/IntegrationAccount3696/agreements/IntegrationAccountAgreement8906", agreement.Id);
            Assert.Equal("IntegrationAccountAgreement8906", agreement.Name);
            Assert.Equal("Microsoft.Logic/integrationAccounts/agreements", agreement.Type);
        }
    }
}