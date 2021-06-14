// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Azure.Storage.Sas
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
{
    /// <summary>
    /// Defines the protocols permitted for Storage requests made with a shared
    /// access signature.
    /// </summary>
    public enum SasProtocol
    {
        /// <summary>
        /// No protocol has been specified. If no value is specified,
        /// the service will default to HttpsAndHttp.
        /// </summary>
        None = 0,

        /// <summary>
        /// Only requests issued over HTTPS or HTTP will be permitted.
        /// </summary>
        HttpsAndHttp = 1,

        /// <summary>
        /// Only requests issued over HTTPS will be permitted.
        /// </summary>
        Https = 2
    }
}
