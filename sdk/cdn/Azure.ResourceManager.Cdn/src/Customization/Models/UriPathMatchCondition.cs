// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class UriPathMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriPathMatchCondition(UriPathMatchConditionType conditionType, UriPathOperator uriPathOperator) : this(uriPathOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriPathMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}