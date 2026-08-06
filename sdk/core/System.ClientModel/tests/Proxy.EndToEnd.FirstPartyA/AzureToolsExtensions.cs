// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.OpenAILike;

namespace System.ClientModel.Tests.Proxy.FirstPartyA
{
    /// <summary>Registration helper the first-party library uses (internally) to register its proxy.</summary>
    public static class AzureToolsExtensions
    {
        public static ModelReaderWriterOptions AddAzureTools(this ModelReaderWriterOptions options)
        {
            options.AddProxy<ResponseTool>(new AzureSearchToolProxy());
            return options;
        }
    }
}
