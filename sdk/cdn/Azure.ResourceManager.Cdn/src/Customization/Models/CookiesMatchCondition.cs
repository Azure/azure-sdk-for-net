// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
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