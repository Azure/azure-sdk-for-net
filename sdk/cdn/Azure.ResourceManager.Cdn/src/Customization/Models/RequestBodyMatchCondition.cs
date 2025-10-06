// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class RequestBodyMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestBodyMatchCondition(RequestBodyMatchConditionType conditionType, RequestBodyOperator requestBodyOperator) : this(requestBodyOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestBodyMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}