// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and ConditionType property to CookiesMatchCondition for backward API compatibility with the previous SDK.
    // Reason: The old SDK (AutoRest-generated) used the CookiesMatchConditionType struct as the polymorphic discriminator property (conditionType),
    // with the constructor signature (conditionType, operator). After the TypeSpec migration, the discriminator was changed to a string-typed TypeName property
    // and the constructor no longer includes the conditionType parameter. The old constructor and ConditionType property (bridging to TypeName) are preserved here,
    // marked as EditorBrowsable.Never.
    public partial class CookiesMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CookiesMatchCondition(CookiesMatchConditionType conditionType, CookiesOperator cookiesOperator) : this(cookiesOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CookiesMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
