// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.CoreWCF.Azure
{
    internal static class AzureClientCredentialTypeHelper
    {
        internal static bool IsDefined(AzureClientCredentialType value)
        {
            return (value == AzureClientCredentialType.Default ||
                value == AzureClientCredentialType.Sas ||
                value == AzureClientCredentialType.StorageSharedKey ||
                value == AzureClientCredentialType.Token ||
                value == AzureClientCredentialType.ConnectionString);
        }
    }
}