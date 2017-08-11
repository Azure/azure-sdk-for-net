// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Search.Fluent.Models;

    internal partial class AdminKeysImpl 
    {
        /// <summary>
        /// Gets the primaryKey value.
        /// </summary>
        /// <summary>
        /// Gets the primaryKey value.
        /// </summary>
        string Microsoft.Azure.Management.Search.Fluent.IAdminKeys.PrimaryKey
        {
            get
            {
                return this.PrimaryKey();
            }
        }

        /// <summary>
        /// Gets the secondaryKey value.
        /// </summary>
        /// <summary>
        /// Gets the secondaryKey value.
        /// </summary>
        string Microsoft.Azure.Management.Search.Fluent.IAdminKeys.SecondaryKey
        {
            get
            {
                return this.SecondaryKey();
            }
        }
    }
}