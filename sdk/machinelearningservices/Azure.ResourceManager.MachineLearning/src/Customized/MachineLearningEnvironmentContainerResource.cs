// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.MachineLearning
{
    // Override the "ValidateResourceId" method since the resource id is not correctly formatted
    // Issue:https://github.com/Azure/azure-sdk-for-net/issues/45884
    public partial class MachineLearningEnvironmentContainerResource
    {
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
        }
    }
}
