// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class ServerPortMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ServerPortMatchCondition(ServerPortMatchConditionType conditionType, ServerPortOperator serverPortOperator) : this(serverPortOperator)
        {
            ServerPortMatchConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ServerPortMatchConditionType ServerPortMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}