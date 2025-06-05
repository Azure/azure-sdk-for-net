// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class ClientPortMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClientPortMatchCondition(ClientPortMatchConditionType conditionType, ClientPortOperator clientPortOperator) : this(clientPortOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClientPortMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}