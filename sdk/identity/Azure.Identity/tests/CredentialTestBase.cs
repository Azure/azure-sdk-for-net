﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class CredentialTestBase : ClientTestBase
    {
        protected const string Scope = "https://vault.azure.net/.default";
        protected const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        protected const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        protected const string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        protected const string expectedUsername = "mockuser@mockdomain.com";
        protected string expectedToken;
        protected string expectedUserAssertion;
        protected string expectedTenantId;
        protected string expectedReplyUri;
        protected string authCode;
        protected const string ReplyUrl = "https://myredirect/";
        protected string clientSecret = Guid.NewGuid().ToString();
        protected DateTimeOffset expiresOn;
        internal MockMsalConfidentialClient mockConfidentialMsalClient;
        internal MockMsalPublicClient mockPublicMsalClient;
        protected TokenCredentialOptions options;
        protected AuthenticationResult result;
        protected string expectedCode;
        protected DeviceCodeResult deviceCodeResult;

        public CredentialTestBase(bool isAsync) : base(isAsync)
        { }

        public void TestSetup()
        {
            expectedTenantId = null;
            expectedReplyUri = null;
            authCode = Guid.NewGuid().ToString();
            options = new TokenCredentialOptions();
            expectedToken = Guid.NewGuid().ToString();
            expectedUserAssertion = Guid.NewGuid().ToString();
            expiresOn = DateTimeOffset.Now.AddHours(1);
            result = new AuthenticationResult(
                expectedToken,
                false,
                null,
                expiresOn,
                expiresOn,
                TenantId,
                new MockAccount("username"),
                null,
                new[] { Scope },
                Guid.NewGuid(),
                null,
                "Bearer");

            mockConfidentialMsalClient = new MockMsalConfidentialClient()
                .WithSilentFactory(
                    (_, _tenantId, _replyUri, _) =>
                    {
                        Assert.AreEqual(expectedTenantId, _tenantId);
                        Assert.AreEqual(expectedReplyUri, _replyUri);
                        return new ValueTask<AuthenticationResult>(result);
                    })
                .WithAuthCodeFactory(
                    (_, _tenantId, _replyUri, _) =>
                    {
                        Assert.AreEqual(expectedTenantId, _tenantId);
                        Assert.AreEqual(expectedReplyUri, _replyUri);
                        return result;
                    })
                .WithOnBehalfOfFactory(
                    (_, _, userAssertion, _, _) =>
                    {
                        Assert.AreEqual(expectedUserAssertion, userAssertion.Assertion);
                        return new ValueTask<AuthenticationResult>(result);
                    })
                .WithClientFactory(
                    (_, _tenantId) =>
                    {
                        Assert.AreEqual(expectedTenantId, _tenantId);
                        return result;
                    });

            expectedCode = Guid.NewGuid().ToString();
            mockPublicMsalClient = new MockMsalPublicClient();
            deviceCodeResult = MockMsalPublicClient.GetDeviceCodeResult(deviceCode: expectedCode);
            mockPublicMsalClient.DeviceCodeResult = deviceCodeResult;
            var publicResult = new AuthenticationResult(
                expectedToken,
                false,
                null,
                expiresOn,
                expiresOn,
                TenantId,
                new MockAccount("username"),
                null,
                new[] { Scope },
                Guid.NewGuid(),
                null,
                "Bearer");
            mockPublicMsalClient.SilentAuthFactory = (_, tId) =>
            {
                Assert.AreEqual(expectedTenantId, tId);
                return publicResult;
            };
            mockPublicMsalClient.DeviceCodeAuthFactory = (_, _) =>
            {
                // Assert.AreEqual(tenantId, tId);
                return publicResult;
            };
            mockPublicMsalClient.InteractiveAuthFactory = (_, _, _, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.SilentAuthFactory = (_, tenant) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.ExtendedSilentAuthFactory = (_, _, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.UserPassAuthFactory = (_, tenant) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.RefreshTokenFactory = (_, _, _, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
        }

        protected async Task<string> ReadMockRequestContent(MockRequest request)
        {
            if (request.Content == null)
            {
                return null;
            }
            using var memoryStream = new MemoryStream();
            request.Content.WriteTo(memoryStream, CancellationToken.None);
            memoryStream.Position = 0;
            using (var streamReader = new StreamReader(memoryStream))
            {
                return await streamReader.ReadToEndAsync().ConfigureAwait(false);
            }
        }

        protected MockResponse CreateMockMsalTokenResponse(int responseCode, string token, string tenantId, string userName)
        {
            var response = new MockResponse(responseCode);
            var idToken = CreateMsalIdToken(Guid.NewGuid().ToString(), userName, tenantId);
            response.SetContent(
                $"{{\"token_type\": \"Bearer\",\"access_token\": \"{token}\",\"refresh_token\": \"{token}\",\"scope\": null,\"client_info\": null,\"id_token\": null,\"expires_in\": 10000,\"ext_expires_in\": 100000,\"refresh_in\": 1000, \"correlation_id\": \"{Guid.NewGuid().ToString()}\", \"client_info\": \"{CreateMsalClientInfo()}\",\"id_token\": \"{idToken}\"}}");
            return response;
        }

        public static string CreateMsalClientInfo()
        {
            return MsalEncode("{\"uid\":\"myuid\",\"utid\":\"myutid\"}");
        }

        public static string CreateMsalIdToken(string uniqueId, string displayableId, string tenantId)
        {
            string id = "{\"aud\": \"e854a4a7-6c34-449c-b237-fc7a28093d84\"," +
                        "\"iss\": \"https://login.microsoftonline.com/6c3d51dd-f0e5-4959-b4ea-a80c4e36fe5e/v2.0/\"," +
                        "\"iat\": 1455833828," +
                        "\"nbf\": 1455833828," +
                        "\"exp\": 1455837728," +
                        "\"ipaddr\": \"131.107.159.117\"," +
                        "\"name\": \"Marrrrrio Bossy\"," +
                        "\"oid\": \"" + uniqueId + "\"," +
                        "\"preferred_username\": \"" + displayableId + "\"," +
                        "\"sub\": \"K4_SGGxKqW1SxUAmhg6C1F6VPiFzcx-Qd80ehIEdFus\"," +
                        "\"tid\": \"" + tenantId + "\"," +
                        "\"ver\": \"2.0\"}";
            return string.Format(CultureInfo.InvariantCulture, "someheader.{0}.somesignature", MsalEncode(id));
        }

         private const char base64PadCharacter = '=';
#if NET45
        private const string doubleBase64PadCharacter = "==";
#endif
        private const char base64Character62 = '+';
        private const char base64Character63 = '/';
        private const char base64UrlCharacter62 = '-';
        private const char base64UrlCharacter63 = '_';

        /// <summary>
        /// Encoding table
        /// </summary>
        internal static readonly char[] s_base64Table =
        {
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9',
            base64UrlCharacter62,
            base64UrlCharacter63
        };

        /// <summary>
        /// The following functions perform base64url encoding which differs from regular base64 encoding as follows
        /// * padding is skipped so the pad character '=' doesn't have to be percent encoded
        /// * the 62nd and 63rd regular base64 encoding characters ('+' and '/') are replace with ('-' and '_')
        /// The changes make the encoding alphabet file and URL safe.
        /// </summary>
        /// <param name="arg">string to encode.</param>
        /// <returns>Base64Url encoding of the UTF8 bytes.</returns>
        public static string MsalEncode(string arg)
        {
            if (arg == null)
                return null;

            return MsalEncode(Encoding.UTF8.GetBytes(arg));
        }

        // From https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/blob/master/src/client/Microsoft.Identity.Client/Utils/Base64UrlHelpers.cs

        /// <summary>
        /// Converts a subset of an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64-url digits. Parameters specify
        /// the subset as an offset in the input array, and the number of elements in the array to convert.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers.</param>
        /// <param name="length">An offset in inArray.</param>
        /// <param name="offset">The number of elements of inArray to convert.</param>
        /// <returns>The string representation in base 64 url encoding of length elements of inArray, starting at position offset.</returns>
        /// <exception cref="ArgumentNullException">'inArray' is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">offset or length is negative OR offset plus length is greater than the length of inArray.</exception>
        private static string MsalEncode(byte[] inArray, int offset, int length)
        {
            _ = inArray ?? throw new ArgumentNullException(nameof(inArray));

            if (length == 0)
                return string.Empty;

            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            if (offset < 0 || inArray.Length < offset)
                throw new ArgumentOutOfRangeException(nameof(offset));

            if (inArray.Length < offset + length)
                throw new ArgumentOutOfRangeException(nameof(length));

            int lengthmod3 = length % 3;
            int limit = offset + (length - lengthmod3);
            char[] output = new char[(length + 2) / 3 * 4];
            char[] table = s_base64Table;
            int i, j = 0;

            // takes 3 bytes from inArray and insert 4 bytes into output
            for (i = offset; i < limit; i += 3)
            {
                byte d0 = inArray[i];
                byte d1 = inArray[i + 1];
                byte d2 = inArray[i + 2];

                output[j + 0] = table[d0 >> 2];
                output[j + 1] = table[((d0 & 0x03) << 4) | (d1 >> 4)];
                output[j + 2] = table[((d1 & 0x0f) << 2) | (d2 >> 6)];
                output[j + 3] = table[d2 & 0x3f];
                j += 4;
            }

            //Where we left off before
            i = limit;

            switch (lengthmod3)
            {
                case 2:
                    {
                        byte d0 = inArray[i];
                        byte d1 = inArray[i + 1];

                        output[j + 0] = table[d0 >> 2];
                        output[j + 1] = table[((d0 & 0x03) << 4) | (d1 >> 4)];
                        output[j + 2] = table[(d1 & 0x0f) << 2];
                        j += 3;
                    }
                    break;

                case 1:
                    {
                        byte d0 = inArray[i];

                        output[j + 0] = table[d0 >> 2];
                        output[j + 1] = table[(d0 & 0x03) << 4];
                        j += 2;
                    }
                    break;

                    //default or case 0: no further operations are needed.
            }

            return new string(output, 0, j);
        }

        /// <summary>
        /// Converts a subset of an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64-url digits. Parameters specify
        /// the subset as an offset in the input array, and the number of elements in the array to convert.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers.</param>
        /// <returns>The string representation in base 64 url encoding of length elements of inArray, starting at position offset.</returns>
        /// <exception cref="ArgumentNullException">'inArray' is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">offset or length is negative OR offset plus length is greater than the length of inArray.</exception>
        public static string MsalEncode(byte[] inArray)
        {
            if (inArray == null)
                return null;

            return MsalEncode(inArray, 0, inArray.Length);
        }
    }
}
