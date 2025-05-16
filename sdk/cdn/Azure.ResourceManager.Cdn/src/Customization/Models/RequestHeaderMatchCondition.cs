// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class RequestHeaderMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestHeaderMatchCondition(RequestHeaderMatchConditionType conditionType, RequestHeaderOperator requestHeaderOperator) : this(requestHeaderOperator)
        {
            RequestHeaderMatchConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestHeaderMatchConditionType RequestHeaderMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}