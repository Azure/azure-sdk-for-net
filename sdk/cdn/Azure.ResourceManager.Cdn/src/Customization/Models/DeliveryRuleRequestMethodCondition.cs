// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class DeliveryRuleRequestMethodCondition
    {
        // Backward compatibility: old API used Properties, new uses Parameters
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestMethodMatchCondition Properties
        {
            get => Parameters;
            set => Parameters = value;
        }
    }
}
