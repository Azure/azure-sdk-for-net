// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.Authorization.Models;

namespace Azure.ResourceManager.Authorization
{
#pragma warning disable CS0618 // Register the obsolete GA model for ModelReaderWriter compatibility.
    [ModelReaderWriterBuildable(typeof(PolicyAssignmentProperties))]
    public partial class AzureResourceManagerAuthorizationContext
    {
    }
#pragma warning restore CS0618
}
