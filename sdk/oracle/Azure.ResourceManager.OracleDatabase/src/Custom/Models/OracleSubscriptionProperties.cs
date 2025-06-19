// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> Oracle Subscription resource model. </summary>
    public partial class OracleSubscriptionProperties
    {
        /// <summary> Cloud Account Id. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier CloudAccountId { get => new ResourceIdentifier(CloudAccountOcid); }
    }
}
