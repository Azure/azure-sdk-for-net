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
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriFileExtensionMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}