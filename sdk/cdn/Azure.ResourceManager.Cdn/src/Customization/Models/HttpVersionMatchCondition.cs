// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class HttpVersionMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HttpVersionMatchCondition(HttpVersionMatchConditionType conditionType, HttpVersionOperator httpVersionOperator) : this(httpVersionOperator)
        {
            HttpVersionMatchConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HttpVersionMatchConditionType HttpVersionMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}