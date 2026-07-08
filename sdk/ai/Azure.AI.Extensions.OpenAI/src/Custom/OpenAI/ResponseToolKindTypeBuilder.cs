// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary>
    /// A <see cref="ModelReaderWriterTypeBuilder"/> for the referenced extensible enum
    /// <see cref="ResponseToolKind"/>, so generated tool discriminator reads that route through
    /// <see cref="ModelReaderWriter"/> can resolve a builder. See <see cref="ResponseToolKindModel"/>.
    /// </summary>
    internal sealed class ResponseToolKindTypeBuilder : ModelReaderWriterTypeBuilder
    {
        protected override Type BuilderType => typeof(ResponseToolKind);

        protected override object CreateInstance() => new ResponseToolKindModel();
    }
}
