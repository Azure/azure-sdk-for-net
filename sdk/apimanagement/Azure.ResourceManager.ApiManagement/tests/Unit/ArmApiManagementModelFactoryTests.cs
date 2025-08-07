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
            Assert.AreEqual(apiData.TermsOfServiceLink, apiData.TermsOfServiceUri.AbsoluteUri);
            Assert.AreEqual(apiData.ServiceLink, apiData.TermsOfServiceUri.AbsoluteUri);
        }

        [Test]
        public void InvalidateApiData_ModelFactory_ByString()
        {
            var apiData = ArmApiManagementModelFactory.ApiData(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.IsNull(apiData.TermsOfServiceUri);
            Assert.IsNull(apiData.ServiceUri);
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
            Assert.AreEqual(apiData.TermsOfServiceLink, apiData.TermsOfServiceUri.AbsoluteUri);
            Assert.AreEqual(apiData.ServiceLink, apiData.ServiceUri.AbsoluteUri);
        }

        [Test]
        public void ValidateApiEntityBaseContract_ModelFactory_ByUri()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceUri);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceLink);
            Assert.AreEqual(apiEntityBaseContract.TermsOfServiceLink, apiEntityBaseContract.TermsOfServiceUri.AbsoluteUri);
        }

        [Test]
        public void InvalidateApiEntityBaseContract_ModelFactory_ByString()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract(termsOfServiceLink: invalidateLink);
            Assert.IsNull(apiEntityBaseContract.TermsOfServiceUri);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceLink);
        }

        [Test]
        public void ValidateApiEntityBaseContract_ModelFactory_ByString()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract(termsOfServiceLink: validateLink);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceUri);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceLink);
            Assert.AreEqual(apiEntityBaseContract.TermsOfServiceLink, apiEntityBaseContract.TermsOfServiceUri.AbsoluteUri);
        }

        [Test]
        public void ValidateApiCreateOrUpdateContent_ModelFactory_ByUri()
        {
            var apiCreateOrUpdateContent = ArmApiManagementModelFactory.ApiCreateOrUpdateContent(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, serviceUri: uri);
            Assert.IsNotNull(apiCreateOrUpdateContent.TermsOfServiceUri);
            Assert.IsNotNull(apiCreateOrUpdateContent.ServiceUri);
            Assert.IsNotNull(apiCreateOrUpdateContent.TermsOfServiceLink);
            Assert.IsNotNull(apiCreateOrUpdateContent.ServiceLink);
            Assert.AreEqual(apiCreateOrUpdateContent.TermsOfServiceLink, apiCreateOrUpdateContent.TermsOfServiceUri.AbsoluteUri);
            Assert.AreEqual(apiCreateOrUpdateContent.ServiceLink, apiCreateOrUpdateContent.ServiceUri.AbsoluteUri);
        }

        [Test]
        public void InvalidateApiCreateOrUpdateContent_ModelFactory_ByString()
        {
            var apiCreateOrUpdateContent = ArmApiManagementModelFactory.ApiCreateOrUpdateContent(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.IsNull(apiCreateOrUpdateContent.TermsOfServiceUri);
            Assert.IsNull(apiCreateOrUpdateContent.ServiceUri);
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
            Assert.AreEqual(apiCreateOrUpdateContent.TermsOfServiceLink, apiCreateOrUpdateContent.TermsOfServiceUri.AbsoluteUri);
            Assert.AreEqual(apiCreateOrUpdateContent.ServiceLink, apiCreateOrUpdateContent.ServiceUri.AbsoluteUri);
        }

        [Test]
        public void ValidateApiPatch_ModelFactory_ByUri()
        {
            var apiPatch = ArmApiManagementModelFactory.ApiPatch(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, serviceUri: uri);
            Assert.IsNotNull(apiPatch.TermsOfServiceUri);
            Assert.IsNotNull(apiPatch.ServiceUri);
            Assert.IsNotNull(apiPatch.TermsOfServiceLink);
            Assert.IsNotNull(apiPatch.ServiceLink);
            Assert.AreEqual(apiPatch.TermsOfServiceLink, apiPatch.TermsOfServiceUri.AbsoluteUri);
            Assert.AreEqual(apiPatch.ServiceLink, apiPatch.ServiceUri.AbsoluteUri);
        }

        [Test]
        public void InvalidateApiPatch_ModelFactory_ByString()
        {
            var apiPatch = ArmApiManagementModelFactory.ApiPatch(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.IsNull(apiPatch.TermsOfServiceUri);
            Assert.IsNull(apiPatch.ServiceUri);
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
            Assert.AreEqual(apiPatch.TermsOfServiceLink, apiPatch.TermsOfServiceUri.AbsoluteUri);
            Assert.AreEqual(apiPatch.ServiceLink, apiPatch.ServiceUri.AbsoluteUri);
        }

        [Test]
        public void ValidateAssociatedApiProperties_ModelFactory_ByUri()
        {
            var associatedApiProperties = ArmApiManagementModelFactory.AssociatedApiProperties(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, null);
            Assert.IsNotNull(associatedApiProperties.TermsOfServiceUri);
            Assert.IsNotNull(associatedApiProperties.TermsOfServiceLink);
            Assert.AreEqual(associatedApiProperties.TermsOfServiceLink, associatedApiProperties.TermsOfServiceUri.AbsoluteUri);
        }

        [Test]
        public void InvalidateAssociatedApiProperties_ModelFactory_ByString()
        {
            var associatedApiProperties = ArmApiManagementModelFactory.AssociatedApiProperties(termsOfServiceLink: invalidateLink);
            Assert.IsNull(associatedApiProperties.TermsOfServiceUri);
            Assert.IsNotNull(associatedApiProperties.TermsOfServiceLink);
        }

        [Test]
        public void ValidateAssociatedApiProperties_ModelFactory_ByString()
        {
            var associatedApiProperties = ArmApiManagementModelFactory.AssociatedApiProperties(termsOfServiceLink: validateLink);
            Assert.IsNotNull(associatedApiProperties.TermsOfServiceUri);
            Assert.IsNotNull(associatedApiProperties.TermsOfServiceLink);
            Assert.AreEqual(associatedApiProperties.TermsOfServiceLink, associatedApiProperties.TermsOfServiceUri.AbsoluteUri);
        }

        [Test]
        public void ValidateGatewayApiData_ModelFactory_ByUri()
        {
            var gatewayApiData = ArmApiManagementModelFactory.GatewayApiData(null, null, default, null, null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, serviceUri: uri);
            Assert.IsNotNull(gatewayApiData.TermsOfServiceUri);
            Assert.IsNotNull(gatewayApiData.ServiceUri);
            Assert.IsNotNull(gatewayApiData.TermsOfServiceLink);
            Assert.IsNotNull(gatewayApiData.ServiceLink);
            Assert.AreEqual(gatewayApiData.TermsOfServiceLink, gatewayApiData.TermsOfServiceUri.AbsoluteUri);
            Assert.AreEqual(gatewayApiData.ServiceLink, gatewayApiData.ServiceUri.AbsoluteUri);
        }

        [Test]
        public void InvalidateGatewayApiData_ModelFactory_ByString()
        {
            var gatewayApiData = ArmApiManagementModelFactory.GatewayApiData(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.IsNull(gatewayApiData.TermsOfServiceUri);
            Assert.IsNull(gatewayApiData.ServiceUri);
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
            Assert.AreEqual(gatewayApiData.TermsOfServiceLink, gatewayApiData.TermsOfServiceUri.AbsoluteUri);
            Assert.AreEqual(gatewayApiData.ServiceLink, gatewayApiData.ServiceUri.AbsoluteUri);
        }

        [Test]
        public void ValidateProductApiData_ModelFactory_ByUri()
        {
            var productApiData = ArmApiManagementModelFactory.ProductApiData(null, null, default, null, null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, serviceUri: uri);
            Assert.IsNotNull(productApiData.TermsOfServiceUri);
            Assert.IsNotNull(productApiData.ServiceUri);
            Assert.IsNotNull(productApiData.TermsOfServiceLink);
            Assert.IsNotNull(productApiData.ServiceLink);
            Assert.AreEqual(productApiData.TermsOfServiceLink, productApiData.TermsOfServiceUri.AbsoluteUri);
            Assert.AreEqual(productApiData.ServiceLink, productApiData.ServiceUri.AbsoluteUri);
        }

        [Test]
        public void InvalidateProductApiData_ModelFactory_ByString()
        {
            var productApiData = ArmApiManagementModelFactory.GatewayApiData(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.IsNull(productApiData.TermsOfServiceUri);
            Assert.IsNull(productApiData.ServiceUri);
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
            Assert.AreEqual(productApiData.TermsOfServiceLink, productApiData.TermsOfServiceUri.AbsoluteUri);
            Assert.AreEqual(productApiData.ServiceLink, productApiData.ServiceUri.AbsoluteUri);
        }
    }
}
