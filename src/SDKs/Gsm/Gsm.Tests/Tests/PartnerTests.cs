// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Gsm.Tests.Helpers;
using Microsoft.Azure.Management.Gsm;
using Microsoft.Azure.Management.Gsm.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Net;
using System.Reflection;
using Xunit;

namespace Gsm.Tests
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var gsmClient = GsmTestUtilities.GetACEProvisioningGSMAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var partnerResponse = gsmClient.Partner.GetAsync(partnerId).Result;
                ValidatePartner(partnerResponse);
            }
        }

        [Fact]
        public void TestCreatePartner()
        {
            string partnerId = "123456";
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var gsmClient = GsmTestUtilities.GetACEProvisioningGSMAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var partner = gsmClient.Partner.CreateAsync(partnerId).Result;
                ValidatePartner(partner);
                Assert.NotNull(partner.PartnerId);
            }
        }

        [Fact]
        public void TestUpdatePartner()
        {
            string partnerId = "123457";
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var gsmClient = GsmTestUtilities.GetACEProvisioningGSMAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var partner = gsmClient.Partner.UpdateAsync(partnerId).Result;
                ValidatePartner(partner);
                Assert.NotNull(partner.PartnerId);
            }
        }

        [Fact]
        public void TestDeletePartner()
        {
            string partnerId = "123457";
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var gsmClient = GsmTestUtilities.GetACEProvisioningGSMAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                gsmClient.Partner.DeleteAsync(partnerId).Wait();
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            System.Type something = typeof(Gsm.Tests.PartnerTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}