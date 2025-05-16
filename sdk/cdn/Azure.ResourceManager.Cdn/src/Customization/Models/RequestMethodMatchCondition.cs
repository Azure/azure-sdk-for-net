// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class RequestMethodMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestMethodMatchCondition(RequestMethodMatchConditionType conditionType, RequestMethodOperator requestMethodOperator) : this(requestMethodOperator)
        {
            RequestMethodMatchConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestMethodMatchConditionType RequestMethodMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}