// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class RequestBodyMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestBodyMatchCondition(RequestBodyMatchConditionType type, RequestBodyOperator requestBodyOperator) : this(requestBodyOperator)
        {
            RequestBodyMatchConditionType = type;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestBodyMatchConditionType RequestBodyMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}