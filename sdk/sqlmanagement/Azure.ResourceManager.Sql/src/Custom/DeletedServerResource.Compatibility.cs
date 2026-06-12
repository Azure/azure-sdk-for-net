// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    public partial class DeletedServerResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, AzureLocation locationName, string deletedServerName)
            => CreateResourceIdentifier(subscriptionId, locationName.ToString(), deletedServerName);
    }
}
