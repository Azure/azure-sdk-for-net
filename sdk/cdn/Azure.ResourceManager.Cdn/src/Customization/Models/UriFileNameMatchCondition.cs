// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class UriFileNameMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriFileNameMatchCondition(UriFileNameMatchConditionType type, UriFileNameOperator uriFileNameOperator) : this(uriFileNameOperator)
        {
            UriFileNameMatchConditionType = type;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriFileNameMatchConditionType UriFileNameMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}