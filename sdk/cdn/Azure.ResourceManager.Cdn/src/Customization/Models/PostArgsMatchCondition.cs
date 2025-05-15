// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class PostArgsMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostArgsMatchCondition(PostArgsMatchConditionType type, PostArgsOperator postArgsOperator) : this(postArgsOperator)
        {
            PostArgsMatchConditionType = type;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostArgsMatchConditionType PostArgsMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}