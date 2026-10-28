// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace OpenAILike.Responses
{
    [ModelReaderWriterBuildable(typeof(ResponseTool))]
    internal partial class ResponseToolsContext : ModelReaderWriterContext
    {
    }
}
