// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    /// <summary>
    /// Common interface that enables initialization of test fixtures that need mock service clients.
    /// </summary>
    public interface IResourceFixture
    {
        /// <summary>
        /// Initializes the test fixture.
        /// </summary>
        /// <param name="context">Mock context used by the fixture to obtain service clients that it needs for
        /// initialization.</param>
        void Initialize(MockContext context);

        /// <summary>
        /// Cleans up any resources used by the test fixture.
        /// </summary>
        void Cleanup();
    }
}
