// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Azure.Storage
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
{
    /// <summary>
    /// This class is added to access protected static methods off of the base class
    /// that should not be exposed directly to customers.
    /// </summary>
    internal class StorageSharedKeyCredentialInternals : StorageSharedKeyCredential
    {
        #pragma warning disable IDE0051 // Remove unused private members
        private StorageSharedKeyCredentialInternals(string accountName, string accountKey) :
        #pragma warning restore IDE0051 // Remove unused private members
            base(accountName, accountKey)
        {
        }

        internal static new string ComputeSasSignature(StorageSharedKeyCredential credential, string message) =>
            StorageSharedKeyCredential.ComputeSasSignature(credential, message);
    }
}
