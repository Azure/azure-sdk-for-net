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
        private StringContent AgreementList { get; set; }

        private StringContent Agreement { get; set; }

        public IntegrationAccountAgreementInMemoryTests()
        {
            var content = File.ReadAllText(@"TestData/IntegrationAccountAgreementResponseContent.json");

            this.AgreementList = new StringContent(string.Format(Constants.ListFormat, content, Constants.NextPageLink));
            this.Agreement = new StringContent(content);
        }

        [Fact]
        public void IntegrationAccountAgreement_List_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.List(null, "IntegrationAccount"));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountAgreements.List(Constants.DefaultResourceGroup, "IntegrationAccount"));
        }

        [Fact]
        public void IntegrationAccountAgreement_List_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.AgreementList
            };

            var result = client.IntegrationAccountAgreements.List(Constants.DefaultResourceGroup, "IntegrationAccount");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateAgreementList(result);
        }

        [Fact]
        public void IntegrationAccountAgreement_ListNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.ListNext(null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountAgreements.ListNext(Constants.NextPageLink));
        }

        [Fact]
        public void IntegrationAccountAgreement_ListNext_Success()
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

            var agreeement = new IntegrationAccountAgreement(AgreementType.Edifact,
                "hostPartner",
                "guestPartner",
                new BusinessIdentity("a", "b"),
                new BusinessIdentity("a", "b"),
                new AgreementContent());

            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.CreateOrUpdate(null, "IntegrationAccountName", "AgreementName", new IntegrationAccountAgreement()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup, null, "AgreementName", new IntegrationAccountAgreement()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", null, new IntegrationAccountAgreement()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", "AgreementName", null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", "AgreementName", agreeement));
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

            var result = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup, 
                "IntegrationAccountName", 
                "AgreementName", 
                new IntegrationAccountAgreement(AgreementType.Edifact, 
                    "hostPartner", 
                    "guestPartner", 
                    new BusinessIdentity("a", "b"), 
                    new BusinessIdentity("a", "b"), 
                    new AgreementContent()));

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

            var result = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                "IntegrationAccountName",
                "AgreementName",
                new IntegrationAccountAgreement(AgreementType.Edifact,
                    "hostPartner",
                    "guestPartner",
                    new BusinessIdentity("a", "b"),
                    new BusinessIdentity("a", "b"),
                    new AgreementContent()));

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
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.Delete(null, "IntegrationAccountName", "AgreementName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.Delete(Constants.DefaultResourceGroup, null, "AgreementName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName", null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountAgreements.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName", "AgreementName"));
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

            client.IntegrationAccountAgreements.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName", "AgreementName");

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

            client.IntegrationAccountAgreements.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName", "AgreementName");

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
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.Get(Constants.DefaultResourceGroup, null, "AgreementName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountAgreements.Get(Constants.DefaultResourceGroup, "IntegrationAccountName", null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountAgreements.Get(Constants.DefaultResourceGroup, "IntegrationAccountName", "AgreementName"));
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

            var result = client.IntegrationAccountAgreements.Get(Constants.DefaultResourceGroup, "IntegrationAccountName", "AgreementName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateAgreement(result);
        }

        private void ValidateAgreementList(IPage<IntegrationAccountAgreement> result)
        {
            Assert.Single(result);
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