// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class PostArgsMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostArgsMatchCondition(PostArgsMatchConditionType conditionType, PostArgsOperator postArgsOperator) : this(postArgsOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostArgsMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}