// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    // Workaround for generator bug https://github.com/Azure/azure-sdk-for-net/issues/58204:
    // suppress DeleteSubnetServiceAssociationLink methods that were incorrectly generated on SubscriptionResource scope.
    [CodeGenSuppress("DeleteSubnetServiceAssociationLinkAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteSubnetServiceAssociationLink", typeof(WaitUntil), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class MockableContainerInstanceSubscriptionResource
    {
    }
}
