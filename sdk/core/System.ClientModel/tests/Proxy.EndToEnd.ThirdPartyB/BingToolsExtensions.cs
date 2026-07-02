// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.OpenAILike;

namespace System.ClientModel.Tests.Proxy.ThirdPartyB
{
    /// <summary>Registration helper a consumer calls when configuring its client.</summary>
    public static class BingToolsExtensions
    {
        public static ModelReaderWriterOptions AddBingTools(this ModelReaderWriterOptions options)
        {
            options.AddProxy<ResponseTool>(new BingGroundingToolProxy());
            return options;
        }
    }
}
