// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class SuppressionAlertsScopeElement
    {
        /// <summary> Initializes a new instance of <see cref="SuppressionAlertsScopeElement"/>. </summary>
        public SuppressionAlertsScopeElement()
            : this(null, new ChangeTrackingDictionary<string, BinaryData>())
        {
        }
    }
}
