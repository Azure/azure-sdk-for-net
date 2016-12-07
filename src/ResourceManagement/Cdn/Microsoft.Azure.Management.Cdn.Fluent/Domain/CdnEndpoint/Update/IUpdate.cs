// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Update
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The set of configurations that can be updated for all endpoint irrespective of their type.
    /// </summary>
    public interface IUpdate  :
        ISettable<CdnProfile.Update.IUpdate>
    {
    }
}