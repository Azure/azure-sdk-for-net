// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasCookieBasedAffinity.UpdateDefinition
{
    /// <summary>
    /// The stage of a definition allowing to enable or disable cookie based affinity.
    /// </summary>
    /// <typeparam name="Return">The next stage of the definition.</typeparam>
    public interface IWithCookieBasedAffinity<ReturnT> 
    {
        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ReturnT WithoutCookieBasedAffinity();

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ReturnT WithCookieBasedAffinity();
    }
}