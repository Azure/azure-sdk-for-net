// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class SocketAddressMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SocketAddressMatchCondition(SocketAddressMatchConditionType conditionType, SocketAddressOperator socketAddressOperator) : this(socketAddressOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public SocketAddressMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}