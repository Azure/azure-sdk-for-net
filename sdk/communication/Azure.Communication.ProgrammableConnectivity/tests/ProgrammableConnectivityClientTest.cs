// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Communication.ProgrammableConnectivity;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.ProgrammableConnectivity.Tests
{
    public class ProgrammableConnectivityClientTest : RecordedTestBase<ProgrammableConnectivityClientTestEnvironment>
    {
        private TokenCredential credential;

        public ProgrammableConnectivityClientTest(bool isAsync) : base(isAsync, RecordedTestMode.Playback)
        {
            HeaderRegexSanitizers.Add(
                new HeaderRegexSanitizer("apc-gateway-id")
                {
                    Regex = @"[A-Za-z0-9-\-]+/resourceGroups",
                    Value = "**********/resourceGroups"
                });
            credential = TestEnvironment.Credential;
        }

        [RecordedTest]
        public async Task SimSwapVerifyTest()
        {
            #region Snippet:APC_Sample_SimSwapVerifyTest
            string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
            Uri endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(endpoint, credential, clientOptions));
#endif
            SimSwap client = baseClient.GetSimSwapClient();

            SimSwapVerificationContent content = new SimSwapVerificationContent(
                new NetworkIdentifier("NetworkCode", "Orange_Spain"))
            {
                PhoneNumber = "+50000000000",
                MaxAgeHours = 120,
            };

            Response<SimSwapVerificationResult> response = await client.VerifyAsync(apcGatewayId, content);
            Console.WriteLine(response.Value.VerificationResult);
            #endregion Snippet:APC_Sample_SimSwapVerifyTest

            Assert.IsFalse(response.Value.VerificationResult);
        }

        [RecordedTest]
        public async Task SimSwapVerifyHeaderRetrievalTest()
        {
            string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
            Uri endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(endpoint, credential, clientOptions));
#endif
            SimSwap client = baseClient.GetSimSwapClient();

            SimSwapVerificationContent content = new SimSwapVerificationContent(
                new NetworkIdentifier("NetworkCode", "Orange_Spain"))
            {
                PhoneNumber = "+50000000000",
                MaxAgeHours = 120,
            };

            #region Snippet:SimSwapVerifyHeaderRetrievalTest
            Response<SimSwapVerificationResult> response = await client.VerifyAsync(apcGatewayId, content);
            string xMsResponseId = response.GetRawResponse().Headers.TryGetValue("x-ms-response-id", out var responseId)
                ? responseId
                : "not found";
            Console.WriteLine($"x-ms-response-id: {xMsResponseId}");
            #endregion Snippet:SimSwapVerifyHeaderRetrievalTest

            Assert.IsNotEmpty(xMsResponseId);
        }

        [RecordedTest]
        public async Task SimSwapVerifyBadResponseTest()
        {
            string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
            Uri endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(endpoint, credential, clientOptions));
#endif
            SimSwap client = baseClient.GetSimSwapClient();

            SimSwapVerificationContent content = new SimSwapVerificationContent(
                new NetworkIdentifier("NetworkCode", "Orange_Spain"))
            {
                PhoneNumber = "+50000000000",
                MaxAgeHours = -10,
            };

            try
            {
                Response<SimSwapVerificationResult> response = await client.VerifyAsync(apcGatewayId, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine($"Caught exception of type: {ex.GetType()}");
#if !SNIPPET
                Assert.AreEqual(400, ex.Status);
#endif
            }
        }

        [RecordedTest]
        public async Task SimSwapRetrieveTest()
        {
            #region Snippet:APC_Sample_SimSwapRetrieveTest
            string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
            Uri endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(endpoint, credential, clientOptions));
#endif
            SimSwap client = baseClient.GetSimSwapClient();

            SimSwapRetrievalContent content = new SimSwapRetrievalContent(
                new NetworkIdentifier("NetworkCode", "Orange_Spain"))
            {
                PhoneNumber = "+50000000000",
            };

            Response<SimSwapRetrievalResult> response = await client.RetrieveAsync(apcGatewayId, content);
            Console.WriteLine(response.Value.Date);
            #endregion Snippet:APC_Sample_SimSwapRetrieveTest

            DateTimeOffset expectedDate = DateTimeOffset.Parse(
                "2023-11-16 14:43:05+00:00", null, System.Globalization.DateTimeStyles.RoundtripKind);

            Assert.AreEqual(expectedDate, response.Value.Date, "The dates should match.");
        }

        [RecordedTest]
        public async Task LocationVerifyTest()
        {
            #region Snippet:APC_Sample_LocationVerifyTest
            string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
            Uri endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(endpoint, credential, clientOptions));
#endif
            DeviceLocation client = baseClient.GetDeviceLocationClient();

            DeviceLocationVerificationContent content = new DeviceLocationVerificationContent(
                networkIdentifier: new NetworkIdentifier("NetworkCode", "Telefonica_Brazil"),
                latitude: 80.0,
                longitude: 85.0,
                accuracy: 50,
                device: new LocationDevice
                {
                    PhoneNumber = "+8000000000000"
                }
            );

            Response<DeviceLocationVerificationResult> result = await client.VerifyAsync(apcGatewayId, content);

            Console.WriteLine(result.Value.VerificationResult);
            #endregion Snippet:APC_Sample_LocationVerifyTest

            Assert.IsFalse(result.Value.VerificationResult);
        }

        [RecordedTest]
        public async Task NetworkRetrievalTest()
        {
            #region Snippet:APC_Sample_NetworkRetrievalTest
            string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
            Uri endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(endpoint, credential, clientOptions));
#endif
            DeviceNetwork client = baseClient.GetDeviceNetworkClient();

            NetworkIdentifier networkIdentifier = new NetworkIdentifier("IPv4", "127.0.0.1");

            Response<NetworkRetrievalResult> response = await client.RetrieveAsync(apcGatewayId, networkIdentifier);
            Console.WriteLine(response.Value.NetworkCode);
            #endregion Snippet:APC_Sample_NetworkRetrievalTest

            Assert.AreEqual(response.Value.NetworkCode, "Claro_Brazil");
        }

        [RecordedTest]
        public async Task NetworkRetrievalBadIdentifierTest()
        {
            #region Snippet:APC_Sample_NetworkRetrievalBadIdentifierTest
            string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
            Uri endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(endpoint, credential, clientOptions));
#endif
            DeviceNetwork client = baseClient.GetDeviceNetworkClient();

            NetworkIdentifier networkIdentifier = new NetworkIdentifier("IPv5", "127.0.0.1");
            try
            {
                Response<NetworkRetrievalResult> response = await client.RetrieveAsync(apcGatewayId, networkIdentifier);
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

        [RecordedTest]
        public async Task NumberVerificationWithoutCodeTest()
        {
            #region Snippet:APC_Sample_NumberVerificationWithoutCodeTest
            string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
            Uri endpoint = new Uri("https://your-endpoint-here.com");
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
#endif
            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);

#if !SNIPPET
            await SetProxyOptionsAsync(new ProxyOptions { Transport = new ProxyOptionsTransport { AllowAutoRedirect = false } });

            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(endpoint, credential, clientOptions));
#endif
            NumberVerification client = baseClient.GetNumberVerificationClient();

            NumberVerificationWithoutCodeContent content = new NumberVerificationWithoutCodeContent(
                new NetworkIdentifier("NetworkCode", "Orange_Spain"),
                new Uri("https://somefakebackend.com"))
            {
                PhoneNumber = "+8000000000000",
            };

            Response response = await client.VerifyWithoutCodeAsync(apcGatewayId, content);
#if !SNIPPET
            Assert.AreEqual(response.Status, 302);
#endif
            string locationUrl = response.Headers.TryGetValue("location", out var location) ? location : "Not found";

            Console.WriteLine(locationUrl);

            #endregion Snippet:APC_Sample_NumberVerificationWithoutCodeTest
            Assert.AreEqual(locationUrl, "https://test/.../authcallback");
        }

        [RecordedTest]
        public async Task NumberVerificationWithCodeTest()
        {
            #region Snippet:APC_Sample_NumberVerificationWithCodeTest
            string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
            Uri endpoint = new Uri("https://your-endpoint-here.com");

            ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
#if !SNIPPET
            var clientOptions = InstrumentClientOptions(new ProgrammableConnectivityClientOptions());
            baseClient = InstrumentClient(new ProgrammableConnectivityClient(endpoint, credential, clientOptions));
#endif
            NumberVerification client = baseClient.GetNumberVerificationClient();

            NumberVerificationWithCodeContent content = new NumberVerificationWithCodeContent("apc_1231231231232");

            Response<NumberVerificationResult> response = await client.VerifyWithCodeAsync(apcGatewayId, content);
            Console.WriteLine(response.Value.VerificationResult);
            #endregion Snippet:APC_Sample_NumberVerificationWithCodeTest
            Assert.IsTrue(response.Value.VerificationResult);
        }
    }
}
