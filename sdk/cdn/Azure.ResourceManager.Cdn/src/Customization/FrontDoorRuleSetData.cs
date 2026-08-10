// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Cdn
{
    // Customization: This file adds a parameterless constructor to FrontDoorRuleSetData to maintain backward API compatibility with the previous SDK.
    // Reason: The old SDK (AutoRest-generated) allowed creating FrontDoorRuleSetData instances via a parameterless constructor,
    // but the TypeSpec generator treats this class as read-only resource data and no longer generates a public parameterless constructor.
    // This constructor is manually preserved to avoid breaking user code.
    public partial class FrontDoorRuleSetData
    {
        /// <summary> Initializes a new instance of <see cref="FrontDoorRuleSetData"/>. </summary>
        public FrontDoorRuleSetData()
        {
        }
    }
}
