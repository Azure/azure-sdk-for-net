// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.ApiManagement.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ArmApiManagementModelFactoryTests
    {
        private readonly Uri uri = new Uri("http://newechoapi.cloudapp.net/api");
        private const string invalidateLink = "n/a";
        private const string validateLink = "http://newechoapi.cloudapp.net/api";

        [Test]
        public void ValidateApiData_ModelFactory_ByUri()
        {
            var apiData = ArmApiManagementModelFactory.ApiData(null, null, default, null, null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, serviceUri: uri);
            Assert.IsNotNull(apiData.TermsOfServiceUri);
            Assert.IsNotNull(apiData.ServiceUri);
            Assert.IsNotNull(apiData.TermsOfServiceLink);
            Assert.IsNotNull(apiData.ServiceLink);
            Assert.That(apiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiData.TermsOfServiceLink));
            Assert.That(apiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiData.ServiceLink));
        }

        [Test]
        public void InvalidateApiData_ModelFactory_ByString()
        {
            var apiData = ArmApiManagementModelFactory.ApiData(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.That(apiData.TermsOfServiceUri, Is.Null);
            Assert.That(apiData.ServiceUri, Is.Null);
            Assert.IsNotNull(apiData.TermsOfServiceLink);
            Assert.IsNotNull(apiData.ServiceLink);
        }

        [Test]
        public void ValidateApiData_ModelFactory_ByString()
        {
            var apiData = ArmApiManagementModelFactory.ApiData(termsOfServiceLink: validateLink, serviceLink: validateLink);
            Assert.IsNotNull(apiData.TermsOfServiceUri);
            Assert.IsNotNull(apiData.ServiceUri);
            Assert.IsNotNull(apiData.TermsOfServiceLink);
            Assert.IsNotNull(apiData.ServiceLink);
            Assert.That(apiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiData.TermsOfServiceLink));
            Assert.That(apiData.ServiceUri.AbsoluteUri, Is.EqualTo(apiData.ServiceLink));
        }

        [Test]
        public void ValidateApiEntityBaseContract_ModelFactory_ByUri()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceUri);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceLink);
            Assert.That(apiEntityBaseContract.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiEntityBaseContract.TermsOfServiceLink));
        }

        [Test]
        public void InvalidateApiEntityBaseContract_ModelFactory_ByString()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract(termsOfServiceLink: invalidateLink);
            Assert.That(apiEntityBaseContract.TermsOfServiceUri, Is.Null);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceLink);
        }

        [Test]
        public void ValidateApiEntityBaseContract_ModelFactory_ByString()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract(termsOfServiceLink: validateLink);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceUri);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceLink);
            Assert.That(apiEntityBaseContract.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiEntityBaseContract.TermsOfServiceLink));
        }

        [Test]
        public void ValidateApiCreateOrUpdateContent_ModelFactory_ByUri()
        {
            var apiCreateOrUpdateContent = ArmApiManagementModelFactory.ApiCreateOrUpdateContent(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, serviceUri: uri);
            Assert.IsNotNull(apiCreateOrUpdateContent.TermsOfServiceUri);
            Assert.IsNotNull(apiCreateOrUpdateContent.ServiceUri);
            Assert.IsNotNull(apiCreateOrUpdateContent.TermsOfServiceLink);
            Assert.IsNotNull(apiCreateOrUpdateContent.ServiceLink);
            Assert.That(apiCreateOrUpdateContent.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiCreateOrUpdateContent.TermsOfServiceLink));
            Assert.That(apiCreateOrUpdateContent.ServiceUri.AbsoluteUri, Is.EqualTo(apiCreateOrUpdateContent.ServiceLink));
        }

        [Test]
        public void InvalidateApiCreateOrUpdateContent_ModelFactory_ByString()
        {
            var apiCreateOrUpdateContent = ArmApiManagementModelFactory.ApiCreateOrUpdateContent(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.That(apiCreateOrUpdateContent.TermsOfServiceUri, Is.Null);
            Assert.That(apiCreateOrUpdateContent.ServiceUri, Is.Null);
            Assert.IsNotNull(apiCreateOrUpdateContent.TermsOfServiceLink);
            Assert.IsNotNull(apiCreateOrUpdateContent.ServiceLink);
        }

        [Test]
        public void ValidateApiCreateOrUpdateContent_ModelFactory_ByString()
        {
            var apiCreateOrUpdateContent = ArmApiManagementModelFactory.ApiCreateOrUpdateContent(termsOfServiceLink: validateLink, serviceLink: validateLink);
            Assert.IsNotNull(apiCreateOrUpdateContent.TermsOfServiceUri);
            Assert.IsNotNull(apiCreateOrUpdateContent.ServiceUri);
            Assert.IsNotNull(apiCreateOrUpdateContent.TermsOfServiceLink);
            Assert.IsNotNull(apiCreateOrUpdateContent.ServiceLink);
            Assert.That(apiCreateOrUpdateContent.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiCreateOrUpdateContent.TermsOfServiceLink));
            Assert.That(apiCreateOrUpdateContent.ServiceUri.AbsoluteUri, Is.EqualTo(apiCreateOrUpdateContent.ServiceLink));
        }

        [Test]
        public void ValidateApiPatch_ModelFactory_ByUri()
        {
            var apiPatch = ArmApiManagementModelFactory.ApiPatch(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, serviceUri: uri);
            Assert.IsNotNull(apiPatch.TermsOfServiceUri);
            Assert.IsNotNull(apiPatch.ServiceUri);
            Assert.IsNotNull(apiPatch.TermsOfServiceLink);
            Assert.IsNotNull(apiPatch.ServiceLink);
            Assert.That(apiPatch.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiPatch.TermsOfServiceLink));
            Assert.That(apiPatch.ServiceUri.AbsoluteUri, Is.EqualTo(apiPatch.ServiceLink));
        }

        [Test]
        public void InvalidateApiPatch_ModelFactory_ByString()
        {
            var apiPatch = ArmApiManagementModelFactory.ApiPatch(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.That(apiPatch.TermsOfServiceUri, Is.Null);
            Assert.That(apiPatch.ServiceUri, Is.Null);
            Assert.IsNotNull(apiPatch.TermsOfServiceLink);
            Assert.IsNotNull(apiPatch.ServiceLink);
        }

        [Test]
        public void ValidateApiPatch_ModelFactory_ByString()
        {
            var apiPatch = ArmApiManagementModelFactory.ApiPatch(termsOfServiceLink: validateLink, serviceLink: validateLink);
            Assert.IsNotNull(apiPatch.TermsOfServiceUri);
            Assert.IsNotNull(apiPatch.ServiceUri);
            Assert.IsNotNull(apiPatch.TermsOfServiceLink);
            Assert.IsNotNull(apiPatch.ServiceLink);
            Assert.That(apiPatch.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiPatch.TermsOfServiceLink));
            Assert.That(apiPatch.ServiceUri.AbsoluteUri, Is.EqualTo(apiPatch.ServiceLink));
        }

        [Test]
        public void ValidateAssociatedApiProperties_ModelFactory_ByUri()
        {
            var associatedApiProperties = ArmApiManagementModelFactory.AssociatedApiProperties(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, null);
            Assert.IsNotNull(associatedApiProperties.TermsOfServiceUri);
            Assert.IsNotNull(associatedApiProperties.TermsOfServiceLink);
            Assert.That(associatedApiProperties.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(associatedApiProperties.TermsOfServiceLink));
        }

        [Test]
        public void InvalidateAssociatedApiProperties_ModelFactory_ByString()
        {
            var associatedApiProperties = ArmApiManagementModelFactory.AssociatedApiProperties(termsOfServiceLink: invalidateLink);
            Assert.That(associatedApiProperties.TermsOfServiceUri, Is.Null);
            Assert.IsNotNull(associatedApiProperties.TermsOfServiceLink);
        }

        [Test]
        public void ValidateAssociatedApiProperties_ModelFactory_ByString()
        {
            var associatedApiProperties = ArmApiManagementModelFactory.AssociatedApiProperties(termsOfServiceLink: validateLink);
            Assert.IsNotNull(associatedApiProperties.TermsOfServiceUri);
            Assert.IsNotNull(associatedApiProperties.TermsOfServiceLink);
            Assert.That(associatedApiProperties.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(associatedApiProperties.TermsOfServiceLink));
        }

        [Test]
        public void ValidateGatewayApiData_ModelFactory_ByUri()
        {
            var gatewayApiData = ArmApiManagementModelFactory.GatewayApiData(null, null, default, null, null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, serviceUri: uri);
            Assert.IsNotNull(gatewayApiData.TermsOfServiceUri);
            Assert.IsNotNull(gatewayApiData.ServiceUri);
            Assert.IsNotNull(gatewayApiData.TermsOfServiceLink);
            Assert.IsNotNull(gatewayApiData.ServiceLink);
            Assert.That(gatewayApiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(gatewayApiData.TermsOfServiceLink));
            Assert.That(gatewayApiData.ServiceUri.AbsoluteUri, Is.EqualTo(gatewayApiData.ServiceLink));
        }

        [Test]
        public void InvalidateGatewayApiData_ModelFactory_ByString()
        {
            var gatewayApiData = ArmApiManagementModelFactory.GatewayApiData(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.That(gatewayApiData.TermsOfServiceUri, Is.Null);
            Assert.That(gatewayApiData.ServiceUri, Is.Null);
            Assert.IsNotNull(gatewayApiData.TermsOfServiceLink);
            Assert.IsNotNull(gatewayApiData.ServiceLink);
        }

        [Test]
        public void ValidateGatewayApiData_ModelFactory_ByString()
        {
            var gatewayApiData = ArmApiManagementModelFactory.GatewayApiData(termsOfServiceLink: validateLink, serviceLink: validateLink);
            Assert.IsNotNull(gatewayApiData.TermsOfServiceUri);
            Assert.IsNotNull(gatewayApiData.ServiceUri);
            Assert.IsNotNull(gatewayApiData.TermsOfServiceLink);
            Assert.IsNotNull(gatewayApiData.ServiceLink);
            Assert.That(gatewayApiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(gatewayApiData.TermsOfServiceLink));
            Assert.That(gatewayApiData.ServiceUri.AbsoluteUri, Is.EqualTo(gatewayApiData.ServiceLink));
        }

        [Test]
        public void ValidateProductApiData_ModelFactory_ByUri()
        {
            var productApiData = ArmApiManagementModelFactory.ProductApiData(null, null, default, null, null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, serviceUri: uri);
            Assert.IsNotNull(productApiData.TermsOfServiceUri);
            Assert.IsNotNull(productApiData.ServiceUri);
            Assert.IsNotNull(productApiData.TermsOfServiceLink);
            Assert.IsNotNull(productApiData.ServiceLink);
            Assert.That(productApiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(productApiData.TermsOfServiceLink));
            Assert.That(productApiData.ServiceUri.AbsoluteUri, Is.EqualTo(productApiData.ServiceLink));
        }

        [Test]
        public void InvalidateProductApiData_ModelFactory_ByString()
        {
            var productApiData = ArmApiManagementModelFactory.GatewayApiData(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.That(productApiData.TermsOfServiceUri, Is.Null);
            Assert.That(productApiData.ServiceUri, Is.Null);
            Assert.IsNotNull(productApiData.TermsOfServiceLink);
            Assert.IsNotNull(productApiData.ServiceLink);
        }

        [Test]
        public void ValidateProductApiData_ModelFactory_ByString()
        {
            var productApiData = ArmApiManagementModelFactory.GatewayApiData(termsOfServiceLink: validateLink, serviceLink: validateLink);
            Assert.IsNotNull(productApiData.TermsOfServiceUri);
            Assert.IsNotNull(productApiData.ServiceUri);
            Assert.IsNotNull(productApiData.TermsOfServiceLink);
            Assert.IsNotNull(productApiData.ServiceLink);
            Assert.That(productApiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(productApiData.TermsOfServiceLink));
            Assert.That(productApiData.ServiceUri.AbsoluteUri, Is.EqualTo(productApiData.ServiceLink));
        }
    }
}
