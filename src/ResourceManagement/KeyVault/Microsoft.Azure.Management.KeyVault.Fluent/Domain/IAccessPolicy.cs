// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{

    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    /// <summary>
    /// An immutable client-side representation of a key vault access policy.
    /// </summary>
    public interface IAccessPolicy  :
        IChildResource<Microsoft.Azure.Management.KeyVault.Fluent.IVault>,
        IWrapper<Microsoft.Azure.Management.KeyVault.Fluent.Models.AccessPolicyEntry>
    {
        /// <returns>The Azure Active Directory tenant ID that should be used for</returns>
        /// <returns>authenticating requests to the key vault.</returns>
        string TenantId { get; }

        /// <returns>The object ID of a user or service principal in the Azure Active</returns>
        /// <returns>Directory tenant for the vault.</returns>
        string ObjectId { get; }

        /// <returns>Application ID of the client making request on behalf of a principal.</returns>
        string ApplicationId { get; }

        /// <returns>Permissions the identity has for keys and secrets.</returns>
        Permissions Permissions { get; }

    }
}