// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.OpenAILike;

namespace System.ClientModel.Tests.Proxy.ThirdPartyA
{
    /// <summary>Registration helper a consumer calls when configuring its client, mirroring "register the proxy on setup".</summary>
    public static class AzureToolsExtensions
    {
        public static ModelReaderWriterOptions AddAzureTools(this ModelReaderWriterOptions options)
        {
            options.AddProxy<ResponseTool>(new AzureSearchToolProxy());
            return options;
        }
    }
}
