// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    internal interface IKeyVaultDefault
    {
        /// <summary>
        /// Category name that defines what category does the defaults belongs to
        /// </summary>
        string DefaultCategoryName { get; }
    }
}
