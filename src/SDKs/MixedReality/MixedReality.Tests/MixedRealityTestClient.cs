// <copyright file="MixedRealityCmdletClient.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>

namespace Microsoft.Azure.Management.MixedReality
{
    using Properties;
    using System.Net;

    internal sealed class MixedRealityTestClient : MixedRealityClient
    {
        static MixedRealityTestClient()
        {
            // Mixed Reality cloud service resource provider doesn't support SSL.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        internal MixedRealityTestClient()
            : base(Settings.Default.ResourceProviderEndpoint, NoCredentials.Instance)
        {
            this.SubscriptionId = Settings.Default.SubscriptionId.ToString();
        }
    }
}
