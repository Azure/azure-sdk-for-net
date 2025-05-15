// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class RequestUriMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestUriMatchCondition(RequestUriMatchConditionType type, RequestUriOperator requestUriOperator) : this(requestUriOperator)
        {
            RequestUriMatchConditionType = type;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestUriMatchConditionType RequestUriMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}