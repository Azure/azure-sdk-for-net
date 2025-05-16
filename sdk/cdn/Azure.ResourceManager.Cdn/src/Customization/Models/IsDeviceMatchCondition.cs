// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class IsDeviceMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IsDeviceMatchCondition(IsDeviceMatchConditionType conditionType, IsDeviceOperator isDeviceOperator): this(isDeviceOperator)
        {
            ConditionType = conditionType;
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IsDeviceMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}