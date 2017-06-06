// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure AD credential.
    /// </summary>
    public interface ICredential  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName
    {
        /// <summary>
        /// Gets end date.
        /// </summary>
        System.DateTime EndDate { get; }

        /// <summary>
        /// Gets key value.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Gets start date.
        /// </summary>
        System.DateTime StartDate { get; }
    }
}