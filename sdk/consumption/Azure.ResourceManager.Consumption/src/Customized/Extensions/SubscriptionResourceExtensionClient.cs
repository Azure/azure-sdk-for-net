// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Consumption.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Consumption
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    [CodeGenSuppress("GetPriceSheetAsync", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetPriceSheet", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(CancellationToken))]
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
    }
}
