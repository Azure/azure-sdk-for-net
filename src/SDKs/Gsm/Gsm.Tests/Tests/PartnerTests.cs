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
        private const string partnerId = "d14e8666-b43e-4f12-aa78-06c49c4859de";

        private void ValidatePartner(PartnerResponse partner)
        {
            Assert.NotNull(partner);
            Assert.NotNull(partner.Id);
            Assert.NotNull(partner.Etag);
            Assert.NotNull(partner.Name);
            Assert.NotNull(partner.ObjectId);
            Assert.NotNull(partner.TenantId);
            Assert.NotNull(partner.PartnerId);
            Assert.NotNull(partner.CreatedDateTime);
            Assert.NotNull(partner.DeletedDateTime);
            Assert.NotNull(partner.ModifiedDateTime);
        }
        
        [Fact]
        public void TestGetPartner()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var gsmClient = GsmTestUtilities.GetACEProvisioningGSMAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var partner = gsmClient.Partner.GetAsync(partnerId).Result;
                //ValidatePartner(partner);
            }
        }
        
 
        private static string GetSessionsDirectoryPath()
        {
            System.Type something = typeof(Gsm.Tests.PartnerTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }

        private string CreateResourceId(string ReservationOrderId, string ReservationId)
        {
            return string.Format("/providers/Microsoft.Capacity/reservationOrders/{0}/reservations/{1}", ReservationOrderId, ReservationId);
        }
    }
}