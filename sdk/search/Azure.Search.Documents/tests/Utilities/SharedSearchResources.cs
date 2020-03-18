// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Test fixture that allows us to share a single hotels search index
    /// between all of the tests that don't mutate the data.
    /// </summary>
    [SetUpFixture]
    public class SharedSearchResources
    {
        /// <summary>
        /// The shared hotels search index.
        /// </summary>
        public static SearchResources Search { get; set; }

        // NUnit requires a public .ctor for SetUpFixtures.
        public SharedSearchResources() { }

        // NUnit won't run TearDowns that didn't also have SetUps
        [OneTimeSetUp]
        public static void CreateSharedSearchResources() { }

        /// <summary>
        /// Dispose of any shared test resources that were created during this
        /// test pass.
        /// </summary>
        [OneTimeTearDown]
        public static async Task DeleteSharedSearchResources()
        {
            if (Search != null)
            {
                await Search.DisposeAsync();
                Search = null;
            }
        }
    }
}
