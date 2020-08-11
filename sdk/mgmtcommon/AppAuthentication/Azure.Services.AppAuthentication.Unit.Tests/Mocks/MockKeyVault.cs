// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    internal class MockKeyVault : HttpMessageHandler
    {
        internal const string SecretNotFoundErrorMessage = "{\"error\":{\"code\":\"SecretNotFound\",\"message\":\"Secret not found: testcrt\"}}";

        internal enum KeyVaultClientTestType
        {
            HttpBearerChallengMissing,
            HttpBearerChallengeInvalid,
            KeyVaultUnavailable,

            CertificateSecretIdentifierSuccess,
            PasswordSecretIdentifierSuccess,
            SecretNotFound
        }

        private readonly KeyVaultClientTestType _keyVaultClientTestType;

        internal MockKeyVault(KeyVaultClientTestType keyVaultClientTestType)
        {
            _keyVaultClientTestType = keyVaultClientTestType;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;

            if (!request.Headers.Contains("Authorization"))
            {
                response = GetUnauthenticatedKeyVaultResponse();
            }
            else
            {
                response = GetAuthenticatedKeyVaultResponse();
            }

            response.RequestMessage = request;
            return Task.FromResult(response);
        }

        private HttpResponseMessage GetUnauthenticatedKeyVaultResponse()
        {
            HttpResponseMessage response = null;

            switch (_keyVaultClientTestType)
            {
                case KeyVaultClientTestType.HttpBearerChallengeInvalid:
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Headers.Add("WWW-Authenticate", "Bearer param1=\"value1\", param2=\"value2\"");
                    break;

                case KeyVaultClientTestType.HttpBearerChallengMissing:
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    break;

                case KeyVaultClientTestType.KeyVaultUnavailable:
                    throw new HttpRequestException();

                default:
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Headers.Add("WWW-Authenticate", "Bearer authorization=\"https://login.windows.net/72f988bf-86f1-41af-91ab-2d7cd011db47\", resource=\"https://vault.azure.net\"");
                    break;
            }

            return response;
        }

        private HttpResponseMessage GetAuthenticatedKeyVaultResponse()
        {
            HttpResponseMessage response = null;

            switch (_keyVaultClientTestType)
            {
                case KeyVaultClientTestType.CertificateSecretIdentifierSuccess:
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("{\"value\":\"" + Constants.TestCert + "\",\"contentType\":\"application/x-pkcs12\",\"id\":\"dummyId\",\"managed\":true,\"attributes\":{\"enabled\":true,\"nbf\":1531943910,\"exp\":1595102910,\"created\":1531944510,\"updated\":1531944510,\"recoveryLevel\":\"Purgeable\"},\"kid\":\"dummyKid\"}",
                        Encoding.UTF8,
                        Constants.JsonContentType);
                    break;

                case KeyVaultClientTestType.PasswordSecretIdentifierSuccess:
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("{\"value\":\"aBadPassword\",\"id\":\"dummyId\",\"attributes\":{\"enabled\":true,\"created\":1531175956,\"updated\":1531175956,\"recoveryLevel\":\"Purgeable\"}}",
                        Encoding.UTF8,
                        Constants.JsonContentType);
                    break;

                case KeyVaultClientTestType.SecretNotFound:
                    response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    response.Content = new StringContent(SecretNotFoundErrorMessage);
                    break;
            }

            return response;
        }
    }
}
