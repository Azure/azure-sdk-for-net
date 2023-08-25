// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary> The Security Settings of managed instance DTC. </summary>
    public partial class ManagedInstanceDtcSecuritySettings
    {
        /// <summary> Allow XA Transactions to managed instance DTC. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release, please use IsXATransactionsEnabled instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? XaTransactionsEnabled
        {
            get => IsXATransactionsEnabled;
            set => IsXATransactionsEnabled = value;
        }
    }
}
