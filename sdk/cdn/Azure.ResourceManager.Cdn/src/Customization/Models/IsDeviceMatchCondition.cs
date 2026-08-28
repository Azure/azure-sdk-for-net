// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and ConditionType property to IsDeviceMatchCondition for backward API compatibility with the previous SDK.
    // Reason: The old SDK (AutoRest-generated) used the IsDeviceMatchConditionType struct as the polymorphic discriminator property (conditionType),
    // with the constructor signature (conditionType, operator). After the TypeSpec migration, the discriminator was changed to a string-typed TypeName property
    // and the constructor no longer includes the conditionType parameter. The old constructor and ConditionType property (bridging to TypeName) are preserved here,
    // marked as EditorBrowsable.Never.
    public partial class IsDeviceMatchCondition
    {
        /// <summary> Backward-compatibility shim retained when the model was regenerated from TypeSpec; hidden from IntelliSense. See the file-level comment for details. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IsDeviceMatchCondition(IsDeviceMatchConditionType conditionType, IsDeviceOperator isDeviceOperator) : this(isDeviceOperator)
        {
            ConditionType = conditionType;
        }
        /// <summary> Backward-compatibility shim retained when the model was regenerated from TypeSpec; hidden from IntelliSense. See the file-level comment for details. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IsDeviceMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
