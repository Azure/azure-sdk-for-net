// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;    
    using System.IO;

    public class IntegrationAccountCertificateInMemoryTests : BaseInMemoryTests
    {
        public IntegrationAccountCertificateInMemoryTests()
        {
            var content = File.ReadAllText(@"TestData/IntegrationAccountCertificateResponseContent.json");

            this.CertificateList = new StringContent(string.Format(Constants.ListFormat,
                content, Constants.NextPageLink));
            this.Certificate = new StringContent(content);
        }

        private StringContent CertificateList { get; set; }

        private StringContent Certificate { get; set; }

        [Fact]
        public void IntegrationAccountCertificate_ListByResourceGroup_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(
                () => client.IntegrationAccountCertificates.List(null, "IntegrationAccount",null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountCertificates.List(ResourceGroupName, "IntegrationAccount"));
        }

        [Fact]
        public void IntegrationAccountCertificate_ListByResourceGroup_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.CertificateList
            };

            var result = client.IntegrationAccountCertificates.List(ResourceGroupName, "IntegrationAccount");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateCertificateList(result);
        }

        [Fact]
        public void IntegrationAccountCertificate_ListByResourceGroupNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountCertificates.ListNext(null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountCertificates.ListNext(Constants.NextPageLink));
        }

        [Fact]
        public void IntegrationAccountCertificate_ListByResourceGroupNext_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.CertificateList
            };

            var result = client.IntegrationAccountCertificates.ListNext(Constants.NextPageLink);

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateCertificateList(result);
        }

        [Fact]
        public void IntegrationAccountCertificate_CreateOrUpdate_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountCertificates.CreateOrUpdate(null, "IntegrationAccountName", "IntegrationAccountCertificate", new IntegrationAccountCertificate()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountCertificates.CreateOrUpdate(ResourceGroupName, null, "IntegrationAccountCertificate", new IntegrationAccountCertificate()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountCertificates.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", null, new IntegrationAccountCertificate()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountCertificates.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "IntegrationAccountCertificate", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountCertificates.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "IntegrationAccountCertificate", new IntegrationAccountCertificate()));
        }

        [Fact]
        public void IntegrationAccountCertificate_CreateOrUpdate_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Certificate
            };

            var result = client.IntegrationAccountCertificates.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "IntegrationAccountCertificate", new IntegrationAccountCertificate());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateCertificate(result);
        }

        [Fact]
        public void IntegrationAccountCertificate_CreateOrUpdate_Created()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = this.Certificate
            };

            var result = client.IntegrationAccountCertificates.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "IntegrationAccountCertificate", new IntegrationAccountCertificate());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateCertificate(result);
        }

        [Fact]
        public void IntegrationAccountCertificate_Delete_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountCertificates.Delete(null, "IntegrationAccountName", "IntegrationAccountCertificate"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountCertificates.Delete(ResourceGroupName, null, "IntegrationAccountCertificate"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountCertificates.Delete(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountCertificates.Delete(ResourceGroupName, "IntegrationAccountName", "IntegrationAccountCertificate"));
        }

        [Fact]
        public void IntegrationAccountCertificate_Delete_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            client.IntegrationAccountCertificates.Delete(ResourceGroupName, "IntegrationAccountName", "IntegrationAccountCertificate");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountCertificate_Delete_NoContent()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };

            client.IntegrationAccountCertificates.Delete(ResourceGroupName, "IntegrationAccountName", "IntegrationAccountCertificate");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountCertificate_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountCertificates.Get(null, "IntegrationAccountName", "IntegrationAccountCertificate"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountCertificates.Get(ResourceGroupName, null, "IntegrationAccountCertificate"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountCertificates.Get(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountCertificates.Get(ResourceGroupName, "IntegrationAccountName", "IntegrationAccountCertificate"));
        }

        [Fact]
        public void IntegrationAccountCertificate_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Certificate
            };

            var result = client.IntegrationAccountCertificates.Get(ResourceGroupName, "IntegrationAccountName", "IntegrationAccountCertificate");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateCertificate(result);
        }

        private void ValidateCertificateList(IPage<IntegrationAccountCertificate> result)
        {            
            Assert.Equal(1, result.Count());
            this.ValidateCertificate(result.First());
            Assert.Equal(Constants.NextPageLink, result.NextPageLink);
        }

        private void ValidateCertificate(IntegrationAccountCertificate certificate)
        {
            Assert.Equal("/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourceGroups/IntegrationAccountSdkTest/providers/Microsoft.Logic/integrationAccounts/IntegrationAccount2241/certificates/IntegrationAccountCertificate304", certificate.Id);
            Assert.Equal("IntegrationAccountCertificate304", certificate.Name);
            Assert.Equal("Microsoft.Logic/integrationAccounts/certificates", certificate.Type);

            Assert.Equal("PRIVATEKEY", certificate.Key.KeyName);
            Assert.Equal("2f08fc1455374280912e7fa24258ecdb", certificate.Key.KeyVersion);            
            Assert.Equal("/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourcegroups/IntegrationAccountSdkTest/providers/microsoft.keyvault/vaults/IntegrationAccountVault", certificate.Key.KeyVault.Id);
            Assert.Equal("IntegrationAccountVault", certificate.Key.KeyVault.Name);
            Assert.Equal("Microsoft.KeyVault/vaults", certificate.Key.KeyVault.Type);

            //2016-03-18T22:32:43.5867431Z
            Assert.Equal(2016, certificate.CreatedTime.Value.Year);
            Assert.Equal(03, certificate.CreatedTime.Value.Month);
            Assert.Equal(18, certificate.CreatedTime.Value.Day);
            Assert.Equal(23, certificate.CreatedTime.Value.Hour);
            Assert.Equal(11, certificate.CreatedTime.Value.Minute);
            Assert.Equal(08, certificate.CreatedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, certificate.CreatedTime.Value.Kind);

            //2016-03-18T22:32:43.5867431Z
            Assert.Equal(2016, certificate.ChangedTime.Value.Year);
            Assert.Equal(03, certificate.ChangedTime.Value.Month);
            Assert.Equal(18, certificate.ChangedTime.Value.Day);
            Assert.Equal(23, certificate.ChangedTime.Value.Hour);
            Assert.Equal(11, certificate.ChangedTime.Value.Minute);
            Assert.Equal(08, certificate.ChangedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, certificate.ChangedTime.Value.Kind);

        }
    }
}