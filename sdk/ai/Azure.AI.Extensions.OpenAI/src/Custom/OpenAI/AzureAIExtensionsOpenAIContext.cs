// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI
{
    public partial class AzureAIExtensionsOpenAIContext
    {
        // Registers custom type builders that the source generator cannot emit:
        //  - ResponseItem / ResponseTool: dispatch polymorphic reads to concrete Azure subtypes (OpenAI's closed
        //    discriminator switches otherwise bucket them into opaque unknown fallbacks).
        //  - ResponseItemKind / ResponseToolKind: referenced extensible enums with no IPersistableModel
        //    implementation, which generated discriminator reads route through ModelReaderWriter.
        // These factories are consulted before the referenced OpenAI context, so they take precedence.
        partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
        {
            factories[typeof(ResponseItem)] = static () => new AzureResponseItemTypeBuilder();
            factories[typeof(ResponseItemKind)] = static () => new ResponseItemKindTypeBuilder();
            factories[typeof(ResponseTool)] = static () => new AzureResponseToolTypeBuilder();
            factories[typeof(ResponseToolKind)] = static () => new ResponseToolKindTypeBuilder();
        }
    }
}
