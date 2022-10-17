// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Azure.ResourceManager.ResourceGraph.Tests
{
    public enum ColumnDataType
    {
        [EnumMember(Value = "string")]
        String,
        [EnumMember(Value = "integer")]
        Integer,
        [EnumMember(Value = "number")]
        Number,
        [EnumMember(Value = "boolean")]
        Boolean,
        [EnumMember(Value = "object")]
        Object
    }
}
