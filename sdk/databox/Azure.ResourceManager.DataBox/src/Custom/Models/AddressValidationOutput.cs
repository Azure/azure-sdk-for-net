// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.DataBox.Models
{
    /// <summary> Output of the address validation api. </summary>
    public partial class AddressValidationOutput
    {
        /// <summary> Error code and message of validation response. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResponseError Error { get => Properties?.Error; }
        /// <summary> The address validation status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AddressValidationStatus? ValidationStatus { get => Properties?.ValidationStatus; }
        /// <summary> List of alternate addresses. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<DataBoxShippingAddress> AlternateAddresses { get => Properties?.AlternateAddresses; }
    }
}
