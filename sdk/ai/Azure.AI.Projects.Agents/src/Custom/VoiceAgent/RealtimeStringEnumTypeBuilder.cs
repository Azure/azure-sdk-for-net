// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.AI.Projects.Agents
{
    internal sealed class RealtimeStringEnumTypeBuilder<T>(Func<string, T> create) : ModelReaderWriterTypeBuilder
    {
        protected override Type BuilderType => typeof(T);

        protected override object CreateInstance() => new RealtimeStringEnumModel<T>(create);
    }
}
