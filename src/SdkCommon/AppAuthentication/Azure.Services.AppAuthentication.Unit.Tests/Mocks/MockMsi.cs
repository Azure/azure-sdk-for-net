// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// Mocks responses from Azure VM and App Services Managed service identity protocols
    /// https://docs.microsoft.com/en-us/azure/app-service/app-service-managed-service-identity
    /// https://docs.microsoft.com/en-us/azure/active-directory/msi-overview
    /// </summary>
    class MockMsi : HttpMessageHandler
    {
        // HitCount is used to test if the cache is hit as expected.
        public int HitCount;

        // Response types
        internal enum MsiTestType
        {
            MsiAppServicesUnauthorized,
            MsiAppServicesSuccess,
            MsiAppServicesFailure,
            MsiAzureVmSuccess,
            MsiAppJsonParseFailure,
            MsiMissingToken,
            MsiAppServicesIncorrectRequest
        }

        private readonly MsiTestType _msiTestType;

        internal MockMsi(MsiTestType msiTestType)
        {
            _msiTestType = msiTestType;
        }

        /// <summary>
        /// Returns a response based on the response type. 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // HitCount is updated when this method gets called. This allows for testing of cache. 
            HitCount++;

            HttpResponseMessage responseMessage = null;

            switch (_msiTestType)
            {
                case MsiTestType.MsiAppServicesUnauthorized:
                    responseMessage = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Forbidden,
                        Content = new StringContent(Constants.IncorrectSecretError,
                            Encoding.UTF8,
                            Constants.JsonContentType)
                    };
                    break;
                case MsiTestType.MsiAppServicesFailure:
                    throw new HttpRequestException();

                case MsiTestType.MsiMissingToken:
                    responseMessage = new HttpResponseMessage
                    {
                        Content = new StringContent(TokenHelper.GetMsiMissingTokenResponse(),
                            Encoding.UTF8,
                            Constants.JsonContentType)
                    };
                    break;

                case MsiTestType.MsiAppJsonParseFailure:
                    responseMessage = new HttpResponseMessage
                    {
                        Content = new StringContent(TokenHelper.GetInvalidMsiTokenResponse(),
                            Encoding.UTF8,
                            Constants.JsonContentType)
                    };
                    break;
                case MsiTestType.MsiAppServicesSuccess:
                case MsiTestType.MsiAzureVmSuccess:
                    responseMessage = new HttpResponseMessage
                    {
                        Content = new StringContent(TokenHelper.GetMsiTokenResponse(),
                            Encoding.UTF8,
                            Constants.JsonContentType)
                    };
                    break;

                case MsiTestType.MsiAppServicesIncorrectRequest:
                    responseMessage = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent(Constants.IncorrectFormatError,
                            Encoding.UTF8,
                            Constants.JsonContentType)
                    };
                    break;
            }
            return Task.FromResult(responseMessage);
        }

    }
}

