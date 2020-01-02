// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Billing.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using Xunit;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Test.HttpRecorder;
using System.IO;
using System.Reflection;
using Microsoft.Azure.Management.Billing.Models;

namespace Billing.Tests.ScenarioTests
{    
    public class AddressOperationsTest : TestBase
    {
        [Fact]
        public void ValidateAddressTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Address entity to validate
                var addressEntity = new AddressDetails
                {
                    AddressLine1 = "1 Microsoft Way",
                    City = "Redmond",
                    Region = "WA",
                    Country = "US",
                    PostalCode = "98052"
                };

                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Validate Address
                var validateAddressResponse = billingMgmtClient.Address.Validate(addressEntity);

                // Verify that address is valid
                Assert.NotNull(validateAddressResponse);
                Assert.True(validateAddressResponse.Status == AddressValidationStatus.Valid);
            }
        }
    }
}
