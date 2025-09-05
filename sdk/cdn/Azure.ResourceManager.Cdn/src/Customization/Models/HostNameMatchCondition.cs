// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
   public partial class HostNameMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HostNameMatchCondition(HostNameMatchConditionType conditionType, HostNameOperator hostNameOperator) : this(hostNameOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HostNameMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}