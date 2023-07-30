// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class ApiCollectionsTests : TestBase
    {
        #region Test setup

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var securityCenterClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityCenterClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityCenterClient>(handlers: handler);

            securityCenterClient.AscLocation = "eastus";

            return securityCenterClient;
        }

        private const string ApiServiceName = "demoApimService2";
        private const string ResourceGroupName = "apicollectionstests";
        private const string ApiCollectionId = "echo-api";

        #endregion

        #region ApiCollections Tests

        [Fact]
        public async Task ApiCollections_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var apiCollections = await securityCenterClient.APICollections.ListAsync(resourceGroupName: ResourceGroupName, ApiServiceName);
                ValidateApiCollections(apiCollections);
            }
        }

        [Fact]
        public async Task ApiCollections_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var apiCollection = await securityCenterClient.APICollections.GetAsync(ResourceGroupName, ApiServiceName, ApiCollectionId);
                ValidateApiCollection(apiCollection);
            }
        }

        [Fact]
        public async Task ApiCollections_Create()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var apiCollection = await securityCenterClient.APICollections.CreateAsync(ResourceGroupName, ApiServiceName, ApiCollectionId);
                ValidateApiCollection(apiCollection);
            }
        }

        #endregion

        #region Validations

        private void ValidateApiCollections(IPage<ApiCollection> ApiCollections)
        {
            Assert.NotEmpty(ApiCollections);

            ApiCollections.ForEach(ValidateApiCollection);
        }

        private void ValidateApiCollection(ApiCollection apiCollection)
        {
            Assert.NotNull(apiCollection);
        }

        #endregion
    }
}
