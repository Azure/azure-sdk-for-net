// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The template for update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Update.IUpdate>
    {
    }
}