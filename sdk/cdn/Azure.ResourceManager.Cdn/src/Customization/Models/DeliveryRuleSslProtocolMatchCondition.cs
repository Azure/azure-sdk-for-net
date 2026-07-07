// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and SslProtocolMatchConditionType property to DeliveryRuleSslProtocolMatchCondition
    // for backward API compatibility with the previous SDK.
    // Reason: The old SDK used the SslProtocolMatchConditionType struct as the discriminator, with the constructor signature (conditionType, operator).
    // After the TypeSpec migration, the discriminator was changed to the string-typed TypeName property. The old API is preserved here and bridges to TypeName.
    public partial class DeliveryRuleSslProtocolMatchCondition
    {
        /// <summary> Backward-compatibility shim retained when the model was regenerated from TypeSpec; hidden from IntelliSense. See the file-level comment for details. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeliveryRuleSslProtocolMatchCondition(SslProtocolMatchConditionType sslProtocolMatchConditionType, SslProtocolOperator sslProtocolOperator) : this(sslProtocolOperator)
        {
            SslProtocolMatchConditionType = sslProtocolMatchConditionType;
        }

        /// <summary> Backward-compatibility shim retained when the model was regenerated from TypeSpec; hidden from IntelliSense. See the file-level comment for details. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SslProtocolMatchConditionType SslProtocolMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
