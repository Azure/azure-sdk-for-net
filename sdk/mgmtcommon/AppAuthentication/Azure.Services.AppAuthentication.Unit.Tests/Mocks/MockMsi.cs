// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
    internal class MockMsi : HttpMessageHandler
    {
        // HitCount is used to test if the cache is hit as expected.
        public int HitCount;

        // Response types
        internal enum MsiTestType
        {
            MsiAppServicesUnauthorized,
            MsiAppServicesSuccess,
            MsiUserAssignedIdentityAppServicesSuccess,
            MsiAppServicesFailure,
            MsiAzureVmSuccess,
            MsiUserAssignedIdentityAzureVmSuccess,
            MsiServiceFabricSuccess,
            MsiUserAssignedIdentityServiceFabricSuccess,
            MsiAppJsonParseFailure,
            MsiMissingToken,
            MsiAppServicesIncorrectRequest,
            MsiAzureVmImdsTimeout,
            MsiUnresponsive,
            MsiThrottled,
            MsiTransientServerError
        }

        private readonly MsiTestType _msiTestType;

        private const string _azureVmImdsInstanceEndpoint = "http://169.254.169.254/metadata/instance";
        private const string _azureVmImdsTokenEndpoint = "http://169.254.169.254/metadata/identity/oauth2/token";

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
            // HitCount is updated when this method gets called. This allows for testing of cache and retry logic.
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
                    if (!request.Headers.Contains(MsiAccessTokenProvider.AppServicesHeader))
                    {
                        throw new Exception("Did not see expected header for App Services MSI");
                    }

                    responseMessage = new HttpResponseMessage
                    {
                        Content = new StringContent(TokenHelper.GetMsiAppServicesTokenResponse(),
                            Encoding.UTF8,
                            Constants.JsonContentType)
                    };
                    break;

                case MsiTestType.MsiAzureVmSuccess:
                    // don't throw on first request (probe)
                    if (HitCount > 1 && !request.Headers.Contains(MsiAccessTokenProvider.AzureVMImdsHeader))
                    {
                        throw new Exception("Did not see expected header for Azure VM IMDS");
                    }

                    responseMessage = new HttpResponseMessage
                    {
                        Content = new StringContent(TokenHelper.GetMsiAzureVmTokenResponse(),
                            Encoding.UTF8,
                            Constants.JsonContentType)
                    };
                    break;

                case MsiTestType.MsiServiceFabricSuccess:
                    if (!request.Headers.Contains(MsiAccessTokenProvider.ServiceFabricHeader))
                    {
                        throw new Exception("Did not see expected header for Service Fabric MSI");
                    }

                    responseMessage = new HttpResponseMessage
                    {
                        // Service Fabric response similar to IMDS
                        Content = new StringContent(TokenHelper.GetMsiAzureVmTokenResponse(),
                            Encoding.UTF8,
                            Constants.JsonContentType)
                    };
                    break;

                case MsiTestType.MsiUserAssignedIdentityAppServicesSuccess:
                    if (!request.Headers.Contains(MsiAccessTokenProvider.AppServicesHeader))
                    {
                        throw new Exception("Did not see expected header for App Services MSI");
                    }

                    responseMessage = new HttpResponseMessage
                    {
                        Content = new StringContent(TokenHelper.GetManagedIdentityAppServicesTokenResponse(),
                            Encoding.UTF8,
                            Constants.JsonContentType)
                    };
                    break;

                case MsiTestType.MsiUserAssignedIdentityAzureVmSuccess:
                    // don't throw on first request (probe)
                    if (HitCount > 1 && !request.Headers.Contains(MsiAccessTokenProvider.AzureVMImdsHeader))
                    {
                        throw new Exception("Did not see expected header for Azure VM IMDS");
                    }

                    responseMessage = new HttpResponseMessage
                    {
                        Content = new StringContent(TokenHelper.GetManagedIdentityAzureVmTokenResponse(),
                            Encoding.UTF8,
                            Constants.JsonContentType)
                    };
                    break;

                case MsiTestType.MsiUserAssignedIdentityServiceFabricSuccess:
                    if (!request.Headers.Contains(MsiAccessTokenProvider.ServiceFabricHeader))
                    {
                        throw new Exception("Did not see expected header for Service Fabric MSI");
                    }

                    responseMessage = new HttpResponseMessage
                    {
                        // Service Fabric response similar to IMDS
                        Content = new StringContent(TokenHelper.GetManagedIdentityAzureVmTokenResponse(),
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

                case MsiTestType.MsiAzureVmImdsTimeout:
                    if (request.RequestUri.AbsoluteUri.StartsWith(_azureVmImdsInstanceEndpoint))
                    {
                        var start = DateTime.Now;
                        while (DateTime.Now - start < TimeSpan.FromSeconds(MsiAccessTokenProvider.AzureVmImdsProbeTimeoutInSeconds + 10))
                        {
                            if (cancellationToken.IsCancellationRequested)
                            {
                                throw new TaskCanceledException();
                            }
                        }
                        throw new Exception("Test fail");
                    }
                    break;

                case MsiTestType.MsiUnresponsive:
                case MsiTestType.MsiThrottled:
                case MsiTestType.MsiTransientServerError:
                    // give success response after max number of retries
                    if (HitCount == MsiRetryHelper.MaxRetries)
                    {
                        responseMessage = new HttpResponseMessage
                        {
                            Content = new StringContent(TokenHelper.GetMsiAppServicesTokenResponse(),
                                Encoding.UTF8,
                                Constants.JsonContentType)
                        };
                    }
                    else
                    {
                        // give error based on test type
                        if (_msiTestType == MsiTestType.MsiUnresponsive)
                        {
                            if (request.RequestUri.AbsoluteUri.StartsWith(_azureVmImdsInstanceEndpoint))
                            {
                                responseMessage = new HttpResponseMessage
                                {
                                    Content = new StringContent(TokenHelper.GetInstanceMetadataResponse(),
                                    Encoding.UTF8,
                                    Constants.JsonContentType)
                                };
                            }
                            else if (Environment.GetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv) != null
                                || request.RequestUri.AbsoluteUri.StartsWith(_azureVmImdsTokenEndpoint))
                            {
                                throw new HttpRequestException();
                            }
                        }
                        else
                        {
                            responseMessage = new HttpResponseMessage
                            {
                                StatusCode = (_msiTestType == MsiTestType.MsiThrottled)
                                    ? (HttpStatusCode)429
                                    : HttpStatusCode.InternalServerError,
                                Content = new StringContent($"test error {_msiTestType.ToString()}")
                            };
                        }
                    }
                    break;
            }
            return Task.FromResult(responseMessage);
        }

    }
}

