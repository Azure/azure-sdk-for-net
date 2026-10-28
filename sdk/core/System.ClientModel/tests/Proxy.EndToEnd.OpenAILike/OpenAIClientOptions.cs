// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace OpenAILike
{
    /// <summary>
    /// Options for <see cref="OpenAIClient"/>. Proxies registered here are inherited by the subclients the
    /// root client creates.
    /// </summary>
    public class OpenAIClientOptions : ClientPipelineOptions
    {
    }
}
