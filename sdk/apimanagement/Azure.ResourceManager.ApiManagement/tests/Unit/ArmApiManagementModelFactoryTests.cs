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
            Assert.Multiple(() =>
            {
                Assert.That(apiData.TermsOfServiceUri, Is.Not.Null);
                Assert.That(apiData.ServiceUri, Is.Not.Null);
                Assert.That(apiData.TermsOfServiceLink, Is.Not.Null);
                Assert.That(apiData.ServiceLink, Is.Not.Null);
            });
            Assert.That(apiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiData.TermsOfServiceLink));
            Assert.That(apiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiData.ServiceLink));
        }

        [Test]
        public void InvalidateApiData_ModelFactory_ByString()
        {
            var apiData = ArmApiManagementModelFactory.ApiData(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.Multiple(() =>
            {
                Assert.That(apiData.TermsOfServiceUri, Is.Null);
                Assert.That(apiData.ServiceUri, Is.Null);
                Assert.That(apiData.TermsOfServiceLink, Is.Not.Null);
                Assert.That(apiData.ServiceLink, Is.Not.Null);
            });
        }

        [Test]
        public void ValidateApiData_ModelFactory_ByString()
        {
            var apiData = ArmApiManagementModelFactory.ApiData(termsOfServiceLink: validateLink, serviceLink: validateLink);
            Assert.Multiple(() =>
            {
                Assert.That(apiData.TermsOfServiceUri, Is.Not.Null);
                Assert.That(apiData.ServiceUri, Is.Not.Null);
                Assert.That(apiData.TermsOfServiceLink, Is.Not.Null);
                Assert.That(apiData.ServiceLink, Is.Not.Null);
            });
            Assert.That(apiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiData.TermsOfServiceLink));
            Assert.That(apiData.ServiceUri.AbsoluteUri, Is.EqualTo(apiData.ServiceLink));
        }

        [Test]
        public void ValidateApiEntityBaseContract_ModelFactory_ByUri()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri);
            Assert.Multiple(() =>
            {
                Assert.That(apiEntityBaseContract.TermsOfServiceUri, Is.Not.Null);
                Assert.That(apiEntityBaseContract.TermsOfServiceLink, Is.Not.Null);
            });
            Assert.That(apiEntityBaseContract.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiEntityBaseContract.TermsOfServiceLink));
        }

        [Test]
        public void InvalidateApiEntityBaseContract_ModelFactory_ByString()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract(termsOfServiceLink: invalidateLink);
            Assert.Multiple(() =>
            {
                Assert.That(apiEntityBaseContract.TermsOfServiceUri, Is.Null);
                Assert.That(apiEntityBaseContract.TermsOfServiceLink, Is.Not.Null);
            });
        }

        [Test]
        public void ValidateApiEntityBaseContract_ModelFactory_ByString()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract(termsOfServiceLink: validateLink);
            Assert.Multiple(() =>
            {
                Assert.That(apiEntityBaseContract.TermsOfServiceUri, Is.Not.Null);
                Assert.That(apiEntityBaseContract.TermsOfServiceLink, Is.Not.Null);
            });
            Assert.That(apiEntityBaseContract.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiEntityBaseContract.TermsOfServiceLink));
        }

        [Test]
        public void ValidateApiCreateOrUpdateContent_ModelFactory_ByUri()
        {
            var apiCreateOrUpdateContent = ArmApiManagementModelFactory.ApiCreateOrUpdateContent(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, serviceUri: uri);
            Assert.Multiple(() =>
            {
                Assert.That(apiCreateOrUpdateContent.TermsOfServiceUri, Is.Not.Null);
                Assert.That(apiCreateOrUpdateContent.ServiceUri, Is.Not.Null);
                Assert.That(apiCreateOrUpdateContent.TermsOfServiceLink, Is.Not.Null);
                Assert.That(apiCreateOrUpdateContent.ServiceLink, Is.Not.Null);
            });
            Assert.That(apiCreateOrUpdateContent.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiCreateOrUpdateContent.TermsOfServiceLink));
            Assert.That(apiCreateOrUpdateContent.ServiceUri.AbsoluteUri, Is.EqualTo(apiCreateOrUpdateContent.ServiceLink));
        }

        [Test]
        public void InvalidateApiCreateOrUpdateContent_ModelFactory_ByString()
        {
            var apiCreateOrUpdateContent = ArmApiManagementModelFactory.ApiCreateOrUpdateContent(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.Multiple(() =>
            {
                Assert.That(apiCreateOrUpdateContent.TermsOfServiceUri, Is.Null);
                Assert.That(apiCreateOrUpdateContent.ServiceUri, Is.Null);
                Assert.That(apiCreateOrUpdateContent.TermsOfServiceLink, Is.Not.Null);
                Assert.That(apiCreateOrUpdateContent.ServiceLink, Is.Not.Null);
            });
        }

        [Test]
        public void ValidateApiCreateOrUpdateContent_ModelFactory_ByString()
        {
            var apiCreateOrUpdateContent = ArmApiManagementModelFactory.ApiCreateOrUpdateContent(termsOfServiceLink: validateLink, serviceLink: validateLink);
            Assert.Multiple(() =>
            {
                Assert.That(apiCreateOrUpdateContent.TermsOfServiceUri, Is.Not.Null);
                Assert.That(apiCreateOrUpdateContent.ServiceUri, Is.Not.Null);
                Assert.That(apiCreateOrUpdateContent.TermsOfServiceLink, Is.Not.Null);
                Assert.That(apiCreateOrUpdateContent.ServiceLink, Is.Not.Null);
            });
            Assert.That(apiCreateOrUpdateContent.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiCreateOrUpdateContent.TermsOfServiceLink));
            Assert.That(apiCreateOrUpdateContent.ServiceUri.AbsoluteUri, Is.EqualTo(apiCreateOrUpdateContent.ServiceLink));
        }

        [Test]
        public void ValidateApiPatch_ModelFactory_ByUri()
        {
            var apiPatch = ArmApiManagementModelFactory.ApiPatch(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, serviceUri: uri);
            Assert.Multiple(() =>
            {
                Assert.That(apiPatch.TermsOfServiceUri, Is.Not.Null);
                Assert.That(apiPatch.ServiceUri, Is.Not.Null);
                Assert.That(apiPatch.TermsOfServiceLink, Is.Not.Null);
                Assert.That(apiPatch.ServiceLink, Is.Not.Null);
            });
            Assert.That(apiPatch.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiPatch.TermsOfServiceLink));
            Assert.That(apiPatch.ServiceUri.AbsoluteUri, Is.EqualTo(apiPatch.ServiceLink));
        }

        [Test]
        public void InvalidateApiPatch_ModelFactory_ByString()
        {
            var apiPatch = ArmApiManagementModelFactory.ApiPatch(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.Multiple(() =>
            {
                Assert.That(apiPatch.TermsOfServiceUri, Is.Null);
                Assert.That(apiPatch.ServiceUri, Is.Null);
                Assert.That(apiPatch.TermsOfServiceLink, Is.Not.Null);
                Assert.That(apiPatch.ServiceLink, Is.Not.Null);
            });
        }

        [Test]
        public void ValidateApiPatch_ModelFactory_ByString()
        {
            var apiPatch = ArmApiManagementModelFactory.ApiPatch(termsOfServiceLink: validateLink, serviceLink: validateLink);
            Assert.Multiple(() =>
            {
                Assert.That(apiPatch.TermsOfServiceUri, Is.Not.Null);
                Assert.That(apiPatch.ServiceUri, Is.Not.Null);
                Assert.That(apiPatch.TermsOfServiceLink, Is.Not.Null);
                Assert.That(apiPatch.ServiceLink, Is.Not.Null);
            });
            Assert.That(apiPatch.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(apiPatch.TermsOfServiceLink));
            Assert.That(apiPatch.ServiceUri.AbsoluteUri, Is.EqualTo(apiPatch.ServiceLink));
        }

        [Test]
        public void ValidateAssociatedApiProperties_ModelFactory_ByUri()
        {
            var associatedApiProperties = ArmApiManagementModelFactory.AssociatedApiProperties(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, null);
            Assert.Multiple(() =>
            {
                Assert.That(associatedApiProperties.TermsOfServiceUri, Is.Not.Null);
                Assert.That(associatedApiProperties.TermsOfServiceLink, Is.Not.Null);
            });
            Assert.That(associatedApiProperties.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(associatedApiProperties.TermsOfServiceLink));
        }

        [Test]
        public void InvalidateAssociatedApiProperties_ModelFactory_ByString()
        {
            var associatedApiProperties = ArmApiManagementModelFactory.AssociatedApiProperties(termsOfServiceLink: invalidateLink);
            Assert.Multiple(() =>
            {
                Assert.That(associatedApiProperties.TermsOfServiceUri, Is.Null);
                Assert.That(associatedApiProperties.TermsOfServiceLink, Is.Not.Null);
            });
        }

        [Test]
        public void ValidateAssociatedApiProperties_ModelFactory_ByString()
        {
            var associatedApiProperties = ArmApiManagementModelFactory.AssociatedApiProperties(termsOfServiceLink: validateLink);
            Assert.Multiple(() =>
            {
                Assert.That(associatedApiProperties.TermsOfServiceUri, Is.Not.Null);
                Assert.That(associatedApiProperties.TermsOfServiceLink, Is.Not.Null);
            });
            Assert.That(associatedApiProperties.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(associatedApiProperties.TermsOfServiceLink));
        }

        [Test]
        public void ValidateGatewayApiData_ModelFactory_ByUri()
        {
            var gatewayApiData = ArmApiManagementModelFactory.GatewayApiData(null, null, default, null, null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, serviceUri: uri);
            Assert.Multiple(() =>
            {
                Assert.That(gatewayApiData.TermsOfServiceUri, Is.Not.Null);
                Assert.That(gatewayApiData.ServiceUri, Is.Not.Null);
                Assert.That(gatewayApiData.TermsOfServiceLink, Is.Not.Null);
                Assert.That(gatewayApiData.ServiceLink, Is.Not.Null);
            });
            Assert.That(gatewayApiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(gatewayApiData.TermsOfServiceLink));
            Assert.That(gatewayApiData.ServiceUri.AbsoluteUri, Is.EqualTo(gatewayApiData.ServiceLink));
        }

        [Test]
        public void InvalidateGatewayApiData_ModelFactory_ByString()
        {
            var gatewayApiData = ArmApiManagementModelFactory.GatewayApiData(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.Multiple(() =>
            {
                Assert.That(gatewayApiData.TermsOfServiceUri, Is.Null);
                Assert.That(gatewayApiData.ServiceUri, Is.Null);
                Assert.That(gatewayApiData.TermsOfServiceLink, Is.Not.Null);
                Assert.That(gatewayApiData.ServiceLink, Is.Not.Null);
            });
        }

        [Test]
        public void ValidateGatewayApiData_ModelFactory_ByString()
        {
            var gatewayApiData = ArmApiManagementModelFactory.GatewayApiData(termsOfServiceLink: validateLink, serviceLink: validateLink);
            Assert.Multiple(() =>
            {
                Assert.That(gatewayApiData.TermsOfServiceUri, Is.Not.Null);
                Assert.That(gatewayApiData.ServiceUri, Is.Not.Null);
                Assert.That(gatewayApiData.TermsOfServiceLink, Is.Not.Null);
                Assert.That(gatewayApiData.ServiceLink, Is.Not.Null);
            });
            Assert.That(gatewayApiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(gatewayApiData.TermsOfServiceLink));
            Assert.That(gatewayApiData.ServiceUri.AbsoluteUri, Is.EqualTo(gatewayApiData.ServiceLink));
        }

        [Test]
        public void ValidateProductApiData_ModelFactory_ByUri()
        {
            var productApiData = ArmApiManagementModelFactory.ProductApiData(null, null, default, null, null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, serviceUri: uri);
            Assert.Multiple(() =>
            {
                Assert.That(productApiData.TermsOfServiceUri, Is.Not.Null);
                Assert.That(productApiData.ServiceUri, Is.Not.Null);
                Assert.That(productApiData.TermsOfServiceLink, Is.Not.Null);
                Assert.That(productApiData.ServiceLink, Is.Not.Null);
            });
            Assert.That(productApiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(productApiData.TermsOfServiceLink));
            Assert.That(productApiData.ServiceUri.AbsoluteUri, Is.EqualTo(productApiData.ServiceLink));
        }

        [Test]
        public void InvalidateProductApiData_ModelFactory_ByString()
        {
            var productApiData = ArmApiManagementModelFactory.GatewayApiData(termsOfServiceLink: invalidateLink, serviceLink: invalidateLink);
            Assert.Multiple(() =>
            {
                Assert.That(productApiData.TermsOfServiceUri, Is.Null);
                Assert.That(productApiData.ServiceUri, Is.Null);
                Assert.That(productApiData.TermsOfServiceLink, Is.Not.Null);
                Assert.That(productApiData.ServiceLink, Is.Not.Null);
            });
        }

        [Test]
        public void ValidateProductApiData_ModelFactory_ByString()
        {
            var productApiData = ArmApiManagementModelFactory.GatewayApiData(termsOfServiceLink: validateLink, serviceLink: validateLink);
            Assert.Multiple(() =>
            {
                Assert.That(productApiData.TermsOfServiceUri, Is.Not.Null);
                Assert.That(productApiData.ServiceUri, Is.Not.Null);
                Assert.That(productApiData.TermsOfServiceLink, Is.Not.Null);
                Assert.That(productApiData.ServiceLink, Is.Not.Null);
            });
            Assert.That(productApiData.TermsOfServiceUri.AbsoluteUri, Is.EqualTo(productApiData.TermsOfServiceLink));
            Assert.That(productApiData.ServiceUri.AbsoluteUri, Is.EqualTo(productApiData.ServiceLink));
        }
    }
}
