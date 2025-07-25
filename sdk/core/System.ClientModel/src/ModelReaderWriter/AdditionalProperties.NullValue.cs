// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public partial struct AdditionalProperties
{
    internal sealed class NullValue
    {
        public static readonly NullValue Instance = new();
        private NullValue() { }
        public override string ToString() => "null";
    }
}
