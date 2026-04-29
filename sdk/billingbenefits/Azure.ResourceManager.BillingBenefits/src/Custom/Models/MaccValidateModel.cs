// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.BillingBenefits.Models
{
    public partial class MaccValidateModel
    {
        /// <summary>
        /// Represents type of the object being operated on. Possible values are primary or contributor.
        /// </summary>
        // Backward-compatibility shim. Use MaccEntityType instead.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use MaccEntityType instead.")]
        public MaccEntityType EntityType
        {
            get => MaccEntityType.GetValueOrDefault();
            set => MaccEntityType = value;
        }
    }
}
