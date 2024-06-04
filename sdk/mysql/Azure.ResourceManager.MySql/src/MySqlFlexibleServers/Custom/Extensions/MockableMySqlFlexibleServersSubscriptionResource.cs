// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.MySql.FlexibleServers.Models;

namespace Azure.ResourceManager.MySql.FlexibleServers.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    [CodeGenSuppress("GetOperationProgres", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperationProgresAsync", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    public partial class MockableMySqlFlexibleServersSubscriptionResource : ArmResource
    {
    }
}
