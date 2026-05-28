// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class RequestUriMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestUriMatchCondition(RequestUriMatchConditionType conditionType, RequestUriOperator requestUriOperator) : this(requestUriOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestUriMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}