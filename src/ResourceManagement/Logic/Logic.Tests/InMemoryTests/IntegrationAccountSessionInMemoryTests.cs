// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;
    using Xunit;

    public class IntegrationAccountSessionInMemoryTests : InMemoryTestsBase
    {
        public IntegrationAccountSessionInMemoryTests()
        {
            var content = File.ReadAllText(path: @"TestData/IntegrationAccountSessionResponseContent.json");

            this.SessionList = new StringContent(string.Format(Constants.ListFormat, content, Constants.NextPageLink));
            this.Session = new StringContent(content);
        }

        private StringContent SessionList { get; set; }

        private StringContent Session { get; set; }

        [Fact]
        public void IntegrationAccountSession_ListByResourceGroup_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.Sessions.ListByIntegrationAccounts(null, "IntegrationAccount"));
            Assert.Throws<CloudException>(() => client.Sessions.ListByIntegrationAccounts(ResourceGroupName, "IntegrationAccount"));
        }

        [Fact]
        public void IntegrationAccountSession_ListByResourceGroup_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.SessionList
            };

            var result = client.Sessions.ListByIntegrationAccounts(resourceGroupName: ResourceGroupName, integrationAccountName: "IntegrationAccount");

            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            this.ValidateSessionList(result);
        }

        [Fact]
        public void IntegrationAccountSession_ListByResourceGroupNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.Sessions.ListByIntegrationAccountsNext(nextPageLink: null));
            Assert.Throws<CloudException>(() => client.Sessions.ListByIntegrationAccountsNext(nextPageLink: Constants.NextPageLink));
        }

        [Fact]
        public void IntegrationAccountSession_ListByResourceGroupNext_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.SessionList
            };

            var result = client.Sessions.ListByIntegrationAccountsNext(nextPageLink: Constants.NextPageLink);

            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            this.ValidateSessionList(result);
        }

        [Fact]
        public void IntegrationAccountSession_CreateOrUpdate_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.Sessions.CreateOrUpdate(
                resourceGroupName: null,
                integrationAccountName: "IntegrationAccountName",
                sessionName: "SessionName",
                session: new IntegrationAccountSession()));
            Assert.Throws<ValidationException>(() => client.Sessions.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: null,
                sessionName: "SessionName",
                session: new IntegrationAccountSession()));
            Assert.Throws<ValidationException>(() => client.Sessions.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: "IntegrationAccountName",
                sessionName: null,
                session: new IntegrationAccountSession()));
            Assert.Throws<ValidationException>(() => client.Sessions.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: "IntegrationAccountName",
                sessionName: "SessionName",
                session: null));
            Assert.Throws<CloudException>(() => client.Sessions.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: "IntegrationAccountName",
                sessionName: "SessionName",
                session: new IntegrationAccountSession()));
        }

        [Fact]
        public void IntegrationAccountSession_CreateOrUpdate_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Session
            };

            var result = client.Sessions.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: "IntegrationAccountName",
                sessionName: "SessionName",
                session: new IntegrationAccountSession());

            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            this.ValidateSession(result);
        }

        [Fact]
        public void IntegrationAccountSession_CreateOrUpdate_Created()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = this.Session
            };

            var result = client.Sessions.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: "IntegrationAccountName",
                sessionName: "SessionName",
                session: new IntegrationAccountSession());

            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            this.ValidateSession(result);
        }

        [Fact]
        public void IntegrationAccountSession_Delete_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            };

            Assert.Throws<ValidationException>(() => client.Sessions.Delete(
                resourceGroupName: null,
                integrationAccountName: "IntegrationAccountName",
                sessionName: "SessionName"));
            Assert.Throws<ValidationException>(() => client.Sessions.Delete(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: null,
                sessionName: "SessionName"));
            Assert.Throws<ValidationException>(() => client.Sessions.Delete(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: "IntegrationAccountName",
                sessionName: null));
            Assert.Throws<CloudException>(() => client.Sessions.Delete(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: "IntegrationAccountName",
                sessionName: "SessionName"));
        }

        [Fact]
        public void IntegrationAccountSession_Delete_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            client.Sessions.Delete(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: "IntegrationAccountName",
                sessionName: "SessionName");

            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountSession_Delete_NoContent()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };

            client.Sessions.Delete(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: "IntegrationAccountName",
                sessionName: "SessionName");

            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountSession_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            Assert.Throws<ValidationException>(() => client.Sessions.Get(
                resourceGroupName: null,
                integrationAccountName: "IntegrationAccountName",
                sessionName: "SessionName"));
            Assert.Throws<ValidationException>(() => client.Sessions.Get(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: null,
                sessionName: "SessionName"));
            Assert.Throws<ValidationException>(() => client.Sessions.Get(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: "IntegrationAccountName",
                sessionName: null));
        }

        [Fact]
        public void IntegrationAccountSession_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Session
            };

            var result = client.Sessions.Get(
                resourceGroupName: ResourceGroupName,
                integrationAccountName: "IntegrationAccountName",
                sessionName: "SessionName");

            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            this.ValidateSession(result as IntegrationAccountSession);
        }

        private void ValidateSessionList(IPage<IntegrationAccountSession> result)
        {
            Assert.Equal(1, result.Count());
            this.ValidateSession(result.First());
            Assert.Equal(Constants.NextPageLink, result.NextPageLink);
        }

        private void ValidateSession(IntegrationAccountSession session)
        {
            Assert.True(this.ValidateIdFormat(id: session.Id, entityTypeName: "integrationAccounts", entitySubtypeName: "sessions"));
            Assert.Equal("IntegrationAccountAgreement8906-ICN", session.Name);
            Assert.Equal("Microsoft.Logic/integrationAccounts/sessions", session.Type);
        }
    }
}
