// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    /// <summary>
    /// Response containing the primary and secondary admin API keys for a given Azure Search service.
    /// </summary>
    public interface IAdminKeys  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the secondaryKey value.
        /// </summary>
        /// <summary>
        /// Gets the secondaryKey value.
        /// </summary>
        string SecondaryKey { get; }

        /// <summary>
        /// Gets the primaryKey value.
        /// </summary>
        /// <summary>
        /// Gets the primaryKey value.
        /// </summary>
        string PrimaryKey { get; }
    }
}