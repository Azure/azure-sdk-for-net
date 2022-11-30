// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class ServiceInfo
    {
        internal string OpenIdConnectionHost { get; set; }
        internal string TokenIssuerV1 { get; set; }
        internal string TokenIssuerV2 { get; set; }
        internal bool DefaultService { get; set; }
        public ServiceInfo(string openIdConnectionHost, string tokenIssuerV1, string tokenIssuerV2)
        {
            OpenIdConnectionHost = openIdConnectionHost;
            TokenIssuerV1 = tokenIssuerV1;
            TokenIssuerV2 = tokenIssuerV2;
        }
    }
}
