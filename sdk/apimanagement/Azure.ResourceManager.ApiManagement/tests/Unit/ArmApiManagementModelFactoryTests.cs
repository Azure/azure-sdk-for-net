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
            var apiData = ArmApiManagementModelFactory.ApiData(termsOfServiceUri: uri, serviceUri: validateLink);
            Assert.IsNotNull(apiData.TermsOfServiceUri);
            Assert.IsNotNull(apiData.ServiceUri);
        }

        [Test]
        public void InvalidateApiData_ModelFactory_ByString()
        {
            var apiData = ArmApiManagementModelFactory.ApiData(serviceUri: invalidateLink);
            Assert.IsNotNull(apiData.ServiceUri);
        }

        [Test]
        public void ValidateApiData_ModelFactory_ByString()
        {
            var apiData = ArmApiManagementModelFactory.ApiData(serviceUri: validateLink);
            Assert.IsNotNull(apiData.ServiceUri);
        }

        [Test]
        public void ValidateApiEntityBaseContract_ModelFactory_ByUri()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract(termsOfServiceUri: uri);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceUri);
        }

        [Test]
        public void InvalidateApiEntityBaseContract_ModelFactory_ByString()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract();
            Assert.IsNull(apiEntityBaseContract.TermsOfServiceUri);
        }

        [Test]
        public void ValidateApiEntityBaseContract_ModelFactory_ByString()
        {
            var apiEntityBaseContract = ArmApiManagementModelFactory.ApiEntityBaseContract(termsOfServiceUri: uri);
            Assert.IsNotNull(apiEntityBaseContract.TermsOfServiceUri);
        }

        [Test]
        public void ValidateApiCreateOrUpdateContent_ModelFactory_ByUri()
        {
            var apiCreateOrUpdateContent = ArmApiManagementModelFactory.ApiCreateOrUpdateContent(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceUri: uri, null, null, null, null, serviceUri: uri, null, null, null, null, null, null, null);
            Assert.IsNotNull(apiCreateOrUpdateContent.TermsOfServiceUri);
            Assert.IsNotNull(apiCreateOrUpdateContent.ServiceUri);
        }

        [Test]
        public void InvalidateApiCreateOrUpdateContent_ModelFactory_ByString()
        {
            var apiCreateOrUpdateContent = ArmApiManagementModelFactory.ApiCreateOrUpdateContent(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceLink: invalidateLink, null, null, null, null, serviceLink: invalidateLink, null, null, null, null, null, null, null, null, null);
            Assert.IsNotNull(apiCreateOrUpdateContent.TermsOfServiceUri);
            Assert.IsNotNull(apiCreateOrUpdateContent.ServiceUri);
        }

        [Test]
        public void ValidateApiCreateOrUpdateContent_ModelFactory_ByString()
        {
            var apiCreateOrUpdateContent = ArmApiManagementModelFactory.ApiCreateOrUpdateContent(null, null, null, null, null, null, null, null, null, null, null, null, termsOfServiceLink: validateLink, null, null, null, null, serviceLink: validateLink, null, null, null, null, null, null, null, null, null);
            Assert.IsNotNull(apiCreateOrUpdateContent.TermsOfServiceUri);
            Assert.IsNotNull(apiCreateOrUpdateContent.ServiceUri);
        }
    }
}
