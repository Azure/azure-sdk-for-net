// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class SocketAddressMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SocketAddressMatchCondition(SocketAddressMatchConditionType type, SocketAddressOperator socketAddressOperator) : this(socketAddressOperator)
        {
            SocketAddressMatchConditionType = type;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public SocketAddressMatchConditionType SocketAddressMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}