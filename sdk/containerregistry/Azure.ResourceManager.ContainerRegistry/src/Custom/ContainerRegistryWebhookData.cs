// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    public partial class ContainerRegistryWebhookData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryWebhookData"/>. </summary>
        /// <param name="location"> The location of the webhook. </param>
        public ContainerRegistryWebhookData(AzureLocation location) : base(default, default, default, default, default, location)
        {
        }
    }
}
