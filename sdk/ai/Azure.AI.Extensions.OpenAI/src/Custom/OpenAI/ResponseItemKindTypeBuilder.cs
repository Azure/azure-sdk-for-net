// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary>
    /// A <see cref="ModelReaderWriterTypeBuilder"/> for the referenced extensible enum
    /// <see cref="ResponseItemKind"/>, so generated discriminator reads that route through
    /// <see cref="ModelReaderWriter"/> can resolve a builder. See <see cref="ResponseItemKindModel"/>.
    /// </summary>
    internal sealed class ResponseItemKindTypeBuilder : ModelReaderWriterTypeBuilder
    {
        protected override Type BuilderType => typeof(ResponseItemKind);

        protected override object CreateInstance() => new ResponseItemKindModel();
    }
}
