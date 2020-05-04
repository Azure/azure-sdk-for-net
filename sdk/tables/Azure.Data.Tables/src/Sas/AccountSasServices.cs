// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// Specifies the services accessible from an account level shared access
    /// signature.
    /// </summary>
    [Flags]
    public enum AccountSasServices
    {
        /// <summary>
        /// Indicates whether Azure Table Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Tables = 8,
    }
}
