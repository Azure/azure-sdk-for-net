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
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;

    public class IntegrationAccountPartnerInMemoryTests : InMemoryTestsBase
    {
        private StringContent PartnerList { get; set; }

        private StringContent Partner { get; set; }

        public IntegrationAccountPartnerInMemoryTests()
        {
            var content = File.ReadAllText(@"TestData/IntegrationAccountPartnerResponseContent.json");

            this.PartnerList = new StringContent(string.Format(Constants.ListFormat, content, Constants.NextPageLink));
            this.Partner = new StringContent(content);
        }

        [Fact]
        public void IntegrationAccountPartner_List_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.List(null, "IntegrationAccount"));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountMaps.List(Constants.DefaultResourceGroup, "IntegrationAccount"));
        }

        [Fact]
        public void IntegrationAccountPartner_List_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.PartnerList
            };

            var result = client.IntegrationAccountPartners.List(Constants.DefaultResourceGroup, "IntegrationAccount");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidatePartnerList(result);
        }

        [Fact]
        public void IntegrationAccountPartner_ListNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.ListNext(null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountPartners.ListNext(Constants.NextPageLink));
        }

        [Fact]
        public void IntegrationAccountPartner_ListNext_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.PartnerList
            };

            var result = client.IntegrationAccountPartners.ListNext(Constants.NextPageLink);

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidatePartnerList(result);
        }

        [Fact]
        public void IntegrationAccountPartner_CreateOrUpdate_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent("Test")
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.CreateOrUpdate(null, "IntegrationAccountName", "PartnerName", new IntegrationAccountPartner()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup, null, "PartnerName", new IntegrationAccountPartner()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", null, new IntegrationAccountPartner()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", "PartnerName", null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", "PartnerName", new IntegrationAccountPartner(PartnerType.B2B, new PartnerContent())));
        }

        [Fact]
        public void IntegrationAccountPartner_CreateOrUpdate_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Partner
            };

            var result = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", "PartnerName", new IntegrationAccountPartner(PartnerType.B2B, new PartnerContent()));

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidatePartner(result);
        }

        [Fact]
        public void IntegrationAccountPartner_CreateOrUpdate_Created()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = this.Partner
            };

            var result = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup, "IntegrationAccountName", "PartnerName", new IntegrationAccountPartner(PartnerType.B2B, new PartnerContent()));

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidatePartner(result);
        }

        [Fact]
        public void IntegrationAccountPartner_Delete_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.Delete(null, "IntegrationAccountName", "PartnerName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.Delete(Constants.DefaultResourceGroup, null, "PartnerName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName", null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountPartners.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName", "PartnerName"));
        }

        [Fact]
        public void IntegrationAccountPartner_Delete_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            client.IntegrationAccountPartners.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName", "PartnerName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountPartner_Delete_NoContent()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };

            client.IntegrationAccountPartners.Delete(Constants.DefaultResourceGroup, "IntegrationAccountName", "PartnerName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountPartner_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.Get(null, "IntegrationAccountName", "PartnerName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup, null, "PartnerName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup, "IntegrationAccountName", null));
            Assert.Throws<ErrorResponseException>(() => client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup, "IntegrationAccountName", "PartnerName"));
        }

        [Fact]
        public void IntegrationAccountPartner_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Partner
            };

            var result = client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup, "IntegrationAccountName", "PartnerName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidatePartner(result);
        }

        private void ValidatePartnerList(IPage<IntegrationAccountPartner> result)
        {
            Assert.Single(result);
            this.ValidatePartner(result.First());
            Assert.Equal(Constants.NextPageLink, result.NextPageLink);
        }

        private void ValidatePartner(IntegrationAccountPartner partner)
        {
            Assert.True(this.ValidateIdFormat(id: partner.Id, entityTypeName: "integrationAccounts", entitySubtypeName: "partners"));
            Assert.Equal("IntegrationAccountPartner7353", partner.Name);
            Assert.Equal("Microsoft.Logic/integrationAccounts/partners", partner.Type);

            //"2016-03-09T22:17:17.2828074Z"
            Assert.Equal(2016, partner.CreatedTime.Value.Year);
            Assert.Equal(03, partner.CreatedTime.Value.Month);
            Assert.Equal(09, partner.CreatedTime.Value.Day);
            Assert.Equal(22, partner.CreatedTime.Value.Hour);
            Assert.Equal(17, partner.CreatedTime.Value.Minute);
            Assert.Equal(17, partner.CreatedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, partner.CreatedTime.Value.Kind);

            //"2016-03-09T22:17:17.2828074Z"
            Assert.Equal(2016, partner.ChangedTime.Value.Year);
            Assert.Equal(03, partner.ChangedTime.Value.Month);
            Assert.Equal(09, partner.ChangedTime.Value.Day);
            Assert.Equal(22, partner.ChangedTime.Value.Hour);
            Assert.Equal(17, partner.ChangedTime.Value.Minute);
            Assert.Equal(17, partner.ChangedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, partner.ChangedTime.Value.Kind);

        }
    }
}