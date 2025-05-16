// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class UriFileExtensionMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriFileExtensionMatchCondition(UriFileExtensionMatchConditionType conditionType, UriFileExtensionOperator uriFileExtensionOperator) : this(uriFileExtensionOperator)
        {
            UriFileExtensionMatchConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriFileExtensionMatchConditionType UriFileExtensionMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}