// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;

    public class IntegrationAccountAgreementInMemoryTests : InMemoryTestsBase
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
                () => client.Agreements.ListByIntegrationAccounts(null, "IntegrationAccount"));
            Assert.Throws<CloudException>(() => client.Agreements.ListByIntegrationAccounts(ResourceGroupName, "IntegrationAccount"));
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

            var result = client.Agreements.ListByIntegrationAccounts(ResourceGroupName, "IntegrationAccount");

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

            Assert.Throws<ValidationException>(() => client.Agreements.ListByIntegrationAccountsNext(null));
            Assert.Throws<CloudException>(() => client.Agreements.ListByIntegrationAccountsNext(Constants.NextPageLink));
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

            var result = client.Agreements.ListByIntegrationAccountsNext(Constants.NextPageLink);

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

            var agreeement = new IntegrationAccountAgreement(AgreementType.Edifact, "hostPartner", "guestPartner", new BusinessIdentity("a", "b"), new BusinessIdentity("a", "b"), new AgreementContent());
            Assert.Throws<ValidationException>(() => client.Agreements.CreateOrUpdate(null, "IntegrationAccountName", "AgreementName", new IntegrationAccountAgreement()));
            Assert.Throws<ValidationException>(() => client.Agreements.CreateOrUpdate(ResourceGroupName, null, "AgreementName", new IntegrationAccountAgreement()));
            Assert.Throws<ValidationException>(() => client.Agreements.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", null, new IntegrationAccountAgreement()));
            Assert.Throws<ValidationException>(() => client.Agreements.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "AgreementName", null));
            Assert.Throws<CloudException>(() => client.Agreements.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "AgreementName", agreeement));
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

            var result = client.Agreements.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "AgreementName", new IntegrationAccountAgreement(AgreementType.Edifact, "hostPartner", "guestPartner", new BusinessIdentity("a", "b"), new BusinessIdentity("a", "b"), new AgreementContent()));

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

            var result = client.Agreements.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "AgreementName", new IntegrationAccountAgreement(AgreementType.Edifact,"hostPartner", "guestPartner", new BusinessIdentity("a","b"),new BusinessIdentity("a","b"),new AgreementContent()));

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

            Assert.Throws<ValidationException>(() => client.Agreements.Delete(null, "IntegrationAccountName", "AgreementName"));
            Assert.Throws<ValidationException>(() => client.Agreements.Delete(ResourceGroupName, null, "AgreementName"));
            Assert.Throws<ValidationException>(() => client.Agreements.Delete(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.Agreements.Delete(ResourceGroupName, "IntegrationAccountName", "AgreementName"));
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

            client.Agreements.Delete(ResourceGroupName, "IntegrationAccountName", "AgreementName");

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

            client.Agreements.Delete(ResourceGroupName, "IntegrationAccountName", "AgreementName");

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

            Assert.Throws<ValidationException>(() => client.Agreements.Get(null, "IntegrationAccountName", "AgreementName"));
            Assert.Throws<ValidationException>(() => client.Agreements.Get(ResourceGroupName, null, "AgreementName"));
            Assert.Throws<ValidationException>(() => client.Agreements.Get(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.Agreements.Get(ResourceGroupName, "IntegrationAccountName", "AgreementName"));
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

            var result = client.Agreements.Get(ResourceGroupName, "IntegrationAccountName", "AgreementName");

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
            Assert.True(this.ValidateIdFormat(id: agreement.Id, entityTypeName: "integrationAccounts", entitySubtypeName: "agreements"));
            Assert.Equal("IntegrationAccountAgreement8906", agreement.Name);
            Assert.Equal("Microsoft.Logic/integrationAccounts/agreements", agreement.Type);
        }
    }
}