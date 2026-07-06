// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary>
    /// A <see cref="ModelReaderWriterTypeBuilder"/> that materializes <see cref="ResponseItem"/> instances through
    /// <see cref="UnknownAzureResponseItem"/>, which re-dispatches polymorphic reads to the correct Azure subtype
    /// based on the payload's <c>type</c> discriminator.
    /// </summary>
    internal sealed class AzureResponseItemTypeBuilder : ModelReaderWriterTypeBuilder
    {
        protected override Type BuilderType => typeof(ResponseItem);

        protected override object CreateInstance() => new UnknownAzureResponseItem();
    }
}
