// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class RemoteAddressMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RemoteAddressMatchCondition(RemoteAddressMatchConditionType conditionType, RemoteAddressOperator remoteAddressOperator) : this(remoteAddressOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RemoteAddressMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}