// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.MachineLearning
{
    // Override the "ValidateResourceId" method since the resource id is not correctly formatted
    // Issue:https://github.com/Azure/azure-sdk-for-net/issues/45884
    public partial class MachineLearningDataContainerResource
    {
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
        }
    }
}
