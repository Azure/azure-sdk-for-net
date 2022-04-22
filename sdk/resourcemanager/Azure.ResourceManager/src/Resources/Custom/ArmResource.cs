// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary> A class representing the operations that can be performed over a specific resource. </summary>
    [CodeGenSuppress("GetTagResource")] // suppress due to error CA1721: The property name 'TagResource' is confusing given the existence of method 'GetTagResource'. Rename or remove one of these members.
    public abstract partial class ArmResource
    {
    }
}
