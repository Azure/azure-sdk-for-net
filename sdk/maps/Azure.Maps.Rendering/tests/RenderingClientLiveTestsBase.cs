// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Maps.Rendering.Tests
{
    public class RenderingClientLiveTestsBase : RecordedTestBase<RenderingClientTestEnvironment>
    {
        public RenderingClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected MapsRenderingClient CreateClient()
        {
            return InstrumentClient(new MapsRenderingClient(
                credential: new AzureKeyCredential("<My Subscription Key>"),
                options: InstrumentClientOptions(new MapsRenderingClientOptions())
            ));
        }
    }
}
