// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Tests.Identity.Samples.DocSnippets
{
    /// <summary>
    /// Placeholder client type used by the configuration / DI documentation snippets.
    /// </summary>
    internal class MyClient
    {
        public MyClient(MyClientSettings settings)
        {
            Settings = settings;
        }

        public MyClientSettings Settings { get; }
    }
}
