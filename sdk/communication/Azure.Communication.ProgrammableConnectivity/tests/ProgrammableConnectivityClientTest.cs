// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Communication.ProgrammableConnectivity;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.Communication.ProgrammableConnectivity.Tests
{
    public class ProgrammableConnectivityClientTest : RecordedTestBase
    {
        private TokenCredential _credential;

        public ProgrammableConnectivityClientTest(bool isAsync) : base(isAsync, RecordedTestMode.Playback)
        {
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("apc-gateway-id", "**********/resourceGroups") { Regex = @"[A-Za-z0-9-\-]*/resourceGroups" });
            _credential = new DefaultAzureCredential();
        }

        [RecordedTest]
        public void SimSwapVerifyTest()
        {
            #region Snippet:APC_Sample_SimSwapVerifyTest
            string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
            Uri _endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential _credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(_endpoint, _credential, clientOptions));
#endif
            var client = baseClient.GetSimSwapClient();
            var content = new SimSwapVerificationContent(new NetworkIdentifier("NetworkCode", "Orange_Spain"))
            {
                PhoneNumber = "+50000000000",
                MaxAgeHours = 120,
            };

            Response<SimSwapVerificationResult> response = client.Verify(ApcGatewayId, content);
            Console.WriteLine(response.Value.VerificationResult);
            #endregion Snippet:APC_Sample_SimSwapVerifyTest

            Assert.IsFalse(response.Value.VerificationResult);
        }

        [RecordedTest]
        public void SimSwapVerifyHeaderRetrievalTest()
        {
            string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
            Uri _endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential _credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(_endpoint, _credential, clientOptions));
#endif
            var client = baseClient.GetSimSwapClient();
            var content = new SimSwapVerificationContent(new NetworkIdentifier("NetworkCode", "Orange_Spain"))
            {
                PhoneNumber = "+50000000000",
                MaxAgeHours = 120,
            };

            #region Snippet:SimSwapVerifyHeaderRetrievalTest
            Response<SimSwapVerificationResult> response = client.Verify(ApcGatewayId, content);
            var xMsResponseId = response.GetRawResponse().Headers.TryGetValue("x-ms-response-id", out var responseId) ? responseId : "not found";
            Console.WriteLine($"x-ms-response-id: {xMsResponseId}");
            #endregion Snippet:SimSwapVerifyHeaderRetrievalTest

            Assert.IsNotEmpty(xMsResponseId);
        }

        [RecordedTest]
        public void SimSwapVerifyBadResponseTest()
        {
            string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
            Uri _endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential _credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(_endpoint, _credential, clientOptions));
#endif
            var client = baseClient.GetSimSwapClient();
            var content = new SimSwapVerificationContent(new NetworkIdentifier("NetworkCode", "Orange_Spain"))
            {
                PhoneNumber = "+50000000000",
                MaxAgeHours = -10,
            };

            try
            {
                Response<SimSwapVerificationResult> response = client.Verify(ApcGatewayId, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine($"Caught exception of type: {ex.GetType()}");
            }
        }

        [RecordedTest]
        public void SimSwapRetrieveTest()
        {
            #region Snippet:APC_Sample_SimSwapRetrieveTest
            string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
            Uri _endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential _credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(_endpoint, _credential, clientOptions));
#endif
            var client = baseClient.GetSimSwapClient();
            var content = new SimSwapRetrievalContent(new NetworkIdentifier("NetworkCode", "Orange_Spain"))
            {
                PhoneNumber = "+50000000000",
            };

            Response<SimSwapRetrievalResult> response = client.Retrieve(ApcGatewayId, content);
            Console.WriteLine(response.Value.Date);
            #endregion Snippet:APC_Sample_SimSwapRetrieveTest

            DateTimeOffset expectedDate = DateTimeOffset.Parse("2023-11-16 14:43:05+00:00", null, System.Globalization.DateTimeStyles.RoundtripKind);
            Assert.AreEqual(expectedDate, response.Value.Date, "The dates should match.");
        }

        [RecordedTest]
        public void LocationVerifyTest()
        {
            #region Snippet:APC_Sample_LocationVerifyTest
            string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
            Uri _endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential _credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(_endpoint, _credential, clientOptions));
#endif
            var client = baseClient.GetDeviceLocationClient();
            var deviceLocationVerificationContent = new DeviceLocationVerificationContent(new NetworkIdentifier("NetworkCode", "Telefonica_Brazil"), 80.0, 85.1, 50, new LocationDevice
            {
                PhoneNumber = "+8000000000000",
            });

            Response<DeviceLocationVerificationResult> result = client.Verify(ApcGatewayId, deviceLocationVerificationContent);

            Console.WriteLine(result.Value.VerificationResult);
            #endregion Snippet:APC_Sample_LocationVerifyTest

            Assert.IsFalse(result.Value.VerificationResult);
        }

        [RecordedTest]
        public void NetworkRetrievalTest()
        {
            #region Snippet:APC_Sample_NetworkRetrievalTest
            string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
            Uri _endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential _credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(_endpoint, _credential, clientOptions));
#endif
            var client = baseClient.GetDeviceNetworkClient();
            var networkIdentifier = new NetworkIdentifier("IPv4", "127.0.0.1");

            Response<NetworkRetrievalResult> response = client.Retrieve(ApcGatewayId, networkIdentifier);
            Console.WriteLine(response.Value.NetworkCode);
            #endregion Snippet:APC_Sample_NetworkRetrievalTest

            Assert.AreEqual(response.Value.NetworkCode, "Claro_Brazil");
        }

        [RecordedTest]
        public void NetworkRetrievalBadIdentifierTest()
        {
            #region Snippet:APC_Sample_NetworkRetrievalBadIdentifierTest
            string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
            Uri _endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential _credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(_endpoint, _credential, clientOptions));
#endif
            var client = baseClient.GetDeviceNetworkClient();
            var networkIdentifier = new NetworkIdentifier("IPv5", "127.0.0.1");
            try
            {
                Response<NetworkRetrievalResult> response = client.Retrieve(ApcGatewayId, networkIdentifier);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Exception Message: {ex.Message}");
                Console.WriteLine($"Status Code: {ex.Status}");
                Console.WriteLine($"Error Code: {ex.ErrorCode}");
#if !SNIPPET
                Assert.AreEqual(400, ex.Status);
#endif
            }
            #endregion Snippet:APC_Sample_NetworkRetrievalBadIdentifierTest
        }
    }
}
