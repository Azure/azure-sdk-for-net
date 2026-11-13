// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DeviceRegistry
{
    // Todo: CodeGen should support remove operation instead of using customization code, https://github.com/Azure/autorest.csharp/issues/5191 opened
    [CodeGenSuppress("GetOperationStatuAsync", typeof(SubscriptionResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperationStatu", typeof(SubscriptionResource), typeof(string), typeof(string), typeof(CancellationToken))]
    public static partial class DeviceRegistryExtensions
    {
    }
}
