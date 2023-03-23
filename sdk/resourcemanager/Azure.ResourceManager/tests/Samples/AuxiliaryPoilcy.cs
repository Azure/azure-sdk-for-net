#region Snippet:Sample_Header_Policy
using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Tests.Samples
{
    public class AuxiliaryPoilcy : HttpPipelineSynchronousPolicy
    {
        private static String AUTHORIZATION_AUXILIARY_HEADER = "x-ms-authorization-auxiliary";
        private string Token { get; set; }

        public AuxiliaryPoilcy(string token)
        {
            Token = token;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            string token = "Bearer " + Token;
            if (!message.Request.Headers.TryGetValue(AUTHORIZATION_AUXILIARY_HEADER, out _))
            {
                message.Request.Headers.Add(AUTHORIZATION_AUXILIARY_HEADER, token);
            }
        }
    }
}
#endregion
