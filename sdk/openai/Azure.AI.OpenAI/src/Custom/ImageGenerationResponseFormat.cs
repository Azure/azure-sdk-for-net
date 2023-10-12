// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.OpenAI
{
    // Custom code note: we explicitly pre-set the visibility of the response format "enum-like" to internal as
    // response format will be handled by separate method signatures for URL/b64/etc..

    internal readonly partial struct ImageGenerationResponseFormat : IEquatable<ImageGenerationResponseFormat>
    {
    }
}
