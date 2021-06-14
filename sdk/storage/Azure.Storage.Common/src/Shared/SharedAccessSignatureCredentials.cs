// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Azure.Storage
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
{
    // TODO: Consider making public if there's ever a reason for developers to use this type
    internal sealed class SharedAccessSignatureCredentials
    {
        /// <summary>
        /// Gets the SAS token used to authenticate requests to the Storage
        /// service.
        /// </summary>
        public string SasToken { get; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SharedAccessSignatureCredentials"/> class.
        /// </summary>
        /// <param name="sasToken">
        /// The SAS token used to authenticate requests to the Storage service.
        /// </param>
        public SharedAccessSignatureCredentials(string sasToken) =>
            SasToken = sasToken;
    }
}
