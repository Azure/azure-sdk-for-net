// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Maps.Render.Tests
{
    public class RenderClientLiveTestsBase : RecordedTestBase<RenderClientTestEnvironment>
    {
        public RenderClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected MapsRenderClient CreateClient()
        {
            return InstrumentClient(new MapsRenderClient(
                endpoint: TestEnvironment.Endpoint,
                credential: TestEnvironment.Credential,
                clientId: TestEnvironment.MapAccountClientId,
                options: InstrumentClientOptions(new MapsRenderClientOptions())
            ));
        }
    }
}
