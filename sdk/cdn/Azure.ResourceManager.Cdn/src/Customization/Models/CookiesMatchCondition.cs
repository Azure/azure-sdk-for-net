// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CookiesMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CookiesMatchCondition(CookiesMatchConditionType type, CookiesOperator cookiesOperator) : this(cookiesOperator)
        {
            CookiesMatchConditionType = type;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CookiesMatchConditionType CookiesMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}