// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.JsonPatch
{
    internal readonly struct JsonPatchOperationKind
    {
        private readonly string _operation;

        private JsonPatchOperationKind(string operation)
        {
            _operation = operation;
        }

        public static JsonPatchOperationKind Add { get; } = new JsonPatchOperationKind("add");
        public static JsonPatchOperationKind Remove { get; } = new JsonPatchOperationKind("remove");
        public static JsonPatchOperationKind Replace { get; } = new JsonPatchOperationKind("replace");
        public static JsonPatchOperationKind Move { get; } = new JsonPatchOperationKind("move");
        public static JsonPatchOperationKind Copy { get; } = new JsonPatchOperationKind("copy");
        public static JsonPatchOperationKind Test { get; } = new JsonPatchOperationKind("test");

        public override string ToString()
        {
            return _operation;
        }
    }
}