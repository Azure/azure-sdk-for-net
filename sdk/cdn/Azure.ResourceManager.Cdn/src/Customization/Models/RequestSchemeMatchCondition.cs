// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class RequestSchemeMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestSchemeMatchCondition(RequestSchemeMatchConditionType conditionType, RequestSchemeOperator requestSchemeOperator) : this(requestSchemeOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestSchemeMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}