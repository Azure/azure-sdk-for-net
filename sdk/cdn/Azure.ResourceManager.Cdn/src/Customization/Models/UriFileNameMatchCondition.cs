// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class UriFileNameMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriFileNameMatchCondition(UriFileNameMatchConditionType conditionType, UriFileNameOperator uriFileNameOperator) : this(uriFileNameOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriFileNameMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}