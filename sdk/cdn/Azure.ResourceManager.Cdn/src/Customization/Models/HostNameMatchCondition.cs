// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
   public partial class HostNameMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HostNameMatchCondition(HostNameMatchConditionType type, HostNameOperator hostNameOperator) : this(hostNameOperator)
        {
            HostNameMatchConditionType = type;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HostNameMatchConditionType HostNameMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}