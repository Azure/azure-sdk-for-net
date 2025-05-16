// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class DeliveryRuleSslProtocolMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeliveryRuleSslProtocolMatchCondition(SslProtocolMatchConditionType sslProtocolMatchConditionType, SslProtocolOperator sslProtocolOperator) : this(sslProtocolOperator)
        {
            SslProtocolMatchConditionType = sslProtocolMatchConditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public SslProtocolMatchConditionType SslProtocolMatchConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
