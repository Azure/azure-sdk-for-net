// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Tests.Samples
{
    #region Snippet:Sample_Header_Policy
    internal class AuxiliaryPoilcy : HttpPipelineSynchronousPolicy
    {
        private static string AUTHORIZATION_AUXILIARY_HEADER = "x-ms-authorization-auxiliary";
        private string _token;

        internal AuxiliaryPoilcy(string token)
        {
            _token = token;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            string token = "Bearer " + _token;
            if (!message.Request.Headers.TryGetValue(AUTHORIZATION_AUXILIARY_HEADER, out _))
            {
                message.Request.Headers.Add(AUTHORIZATION_AUXILIARY_HEADER, token);
            }
        }
    }
    #endregion
}
