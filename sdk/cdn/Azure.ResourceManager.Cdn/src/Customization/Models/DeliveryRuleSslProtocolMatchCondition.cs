// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class DeliveryRuleSslProtocolMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeliveryRuleSslProtocolMatchCondition(SslProtocolMatchConditionType conditionType, SslProtocolOperator sslProtocolOperator) : this(sslProtocolOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public SslProtocolMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
