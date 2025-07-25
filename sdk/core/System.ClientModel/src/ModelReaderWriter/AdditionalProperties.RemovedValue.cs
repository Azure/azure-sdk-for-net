// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public partial struct AdditionalProperties
{
    internal sealed class RemovedValue
    {
        public static readonly RemovedValue Instance = new();
        private RemovedValue() { }
        public override string ToString() => "<removed>";
    }
}
