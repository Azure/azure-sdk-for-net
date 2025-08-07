// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.DeviceRegistry.Models;

namespace Azure.ResourceManager.DeviceRegistry.Mocking
{
    // Todo: CodeGen should support remove operation instead of using customization code, https://github.com/Azure/autorest.csharp/issues/5191 opened
    [CodeGenSuppress("GetOperationStatuAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperationStatu", typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class MockableDeviceRegistrySubscriptionResource : ArmResource
    {
    }
}
