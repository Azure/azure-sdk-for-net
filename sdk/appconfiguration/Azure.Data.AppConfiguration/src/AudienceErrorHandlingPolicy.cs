// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Pipeline policy that inspects <see cref="AuthenticationFailedException"/> instances for the Entra ID token audience error code (AADSTS500011) and rethrows a new exception with clearer guidance.
    /// </summary>
    internal class AudienceErrorHandlingPolicy : HttpPipelinePolicy
    {
        private bool _isAudienceConfigured;
        private const string AadAudienceErrorCode = "AADSTS500011";
        private const string NoAudienceErrorMessage = "Unable to authenticate to Azure App Configuration. No authentication token audience was provided. Please set ConfigurationClientOptions.Audience to the appropriate audience for the target cloud. For details on how to configure the authentication token audience visit https://aka.ms/appconfig/client-token-audience.";
        private const string WrongAudienceErrorMessage = "Unable to authenticate to Azure App Configuration. An incorrect token audience was provided. Please set ConfigurationClientOptions.Audience to the appropriate audience for the target cloud. For details on how to configure the authentication token audience visit https://aka.ms/appconfig/client-token-audience.";

        public AudienceErrorHandlingPolicy(bool isAudienceConfigured)
        {
            _isAudienceConfigured = isAudienceConfigured;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            try
            {
                ProcessNext(message, pipeline);
            }
            catch (AuthenticationFailedException ex)
            {
                HandleAuthenticationAudienceError(ex);
                throw;
            }
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            try
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            catch (AuthenticationFailedException ex)
            {
                HandleAuthenticationAudienceError(ex);
                throw;
            }
        }

        private void HandleAuthenticationAudienceError(AuthenticationFailedException ex)
        {
            // Message string matching is used because AAD error codes are embedded in the exception message.
            if (!ex.Message.Contains(AadAudienceErrorCode))
            {
                return;
            }

            string message = _isAudienceConfigured ? WrongAudienceErrorMessage : NoAudienceErrorMessage;
            throw new AuthenticationFailedException(message, ex);
        }
    }
}
