// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    /// <summary>
    /// Represents an external child resource.
    /// @param <FluentModelT> external child resource fluent interface
    /// @param <IParentT> the parent fluent interface
    /// </summary>
    public interface IExternalChildResource<FluentModelT, IParentT> : IChildResource<IParentT>, IRefreshable<FluentModelT>
    {
        /// <returns>the id of the external child resource</returns>
        string Id { get; }
    }
}
