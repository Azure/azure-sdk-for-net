// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: the TypeSpec shape is named ScopeElement, but the shipped SDK exposed SuppressionAlertsScopeElement.
    public partial class SuppressionAlertsScopeElement
    {
        /// <summary> Initializes a new instance of <see cref="SuppressionAlertsScopeElement"/>. </summary>
        public SuppressionAlertsScopeElement()
        {
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }
    }
}
