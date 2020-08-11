// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ManagementPartner.Tests.Helpers;
using Microsoft.Azure.Management.ManagementPartner;
using Microsoft.Azure.Management.ManagementPartner.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Net;
using System.Reflection;
using Xunit;

namespace ManagementPartner.Tests
{
    public class PartnerTests : TestBase
    {

        private void ValidatePartner(PartnerResponse partnerResponse)
        {
            Assert.NotNull(partnerResponse);
            Assert.NotNull(partnerResponse.ObjectId);
            Assert.NotNull(partnerResponse.TenantId);
            Assert.NotNull(partnerResponse.CreatedTime);
            Assert.NotNull(partnerResponse.UpdatedTime);
            Assert.NotNull(partnerResponse.Version);
            Assert.NotNull(partnerResponse.Type);
        }
        
        [Fact]
        public void TestGetPartner()
        {
            string partnerId = "123457";
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementPartnerClient = ManagementPartnerTestUtilities.GetACEProvisioningManagementPartnerAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var partnerResponse = managementPartnerClient.Partner.GetAsync(partnerId).Result;
                ValidatePartner(partnerResponse);
            }
        }

        [Fact]
        public void TestCreatePartner()
        {
            string partnerId = "123456";
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementPartnerClient = ManagementPartnerTestUtilities.GetACEProvisioningManagementPartnerAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var partner = managementPartnerClient.Partner.CreateAsync(partnerId).Result;
                ValidatePartner(partner);
                Assert.NotNull(partner.PartnerId);
            }
        }

        [Fact]
        public void TestUpdatePartner()
        {
            string partnerId = "123457";
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementPartnerClient = ManagementPartnerTestUtilities.GetACEProvisioningManagementPartnerAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var partner = managementPartnerClient.Partner.UpdateAsync(partnerId).Result;
                ValidatePartner(partner);
                Assert.NotNull(partner.PartnerId);
            }
        }

        [Fact]
        public void TestDeletePartner()
        {
            string partnerId = "123457";
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementPartnerClient = ManagementPartnerTestUtilities.GetACEProvisioningManagementPartnerAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                managementPartnerClient.Partner.DeleteAsync(partnerId).Wait();
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            System.Type something = typeof(ManagementPartner.Tests.PartnerTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}
