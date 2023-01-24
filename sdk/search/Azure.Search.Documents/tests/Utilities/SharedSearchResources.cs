// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
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
        private static readonly AutoResetEvent s_event = new AutoResetEvent(true);
        private static readonly TimeSpan s_timeout = TimeSpan.FromMinutes(1);

        /// <summary>
        /// The shared hotels search index for tests.
        /// </summary>
        public static SearchResources SearchResourcesForTests { get; private set; }

        /// <summary>
        /// The shared hotels search index for samples.
        /// </summary>
        public static SearchResources SearchResourcesForSamples { get; private set; }

        /// <summary>
        /// Initializes the <see cref="Search"/> shared index if necessary.
        /// </summary>
        /// <param name="factory">The method to create the shared search index if necessary.</param>
        /// <returns>A <see cref="ValueTask"/> that the method has completed.</returns>
        public static async ValueTask EnsureInitialized(Func<Task<SearchResources>> factory, bool isSample)
        {
            if (isSample)
            {
                if (SearchResourcesForSamples is null)
                {
                    // Use AutoResetEvents around async tasks since lock() doesn't work and Monitor.Pulse can deadlock.
                    s_event.WaitOne(s_timeout);
                    try
                    {
                        if (SearchResourcesForSamples is null)
                        {
                            SearchResourcesForSamples = await factory();
                        }
                    }
                    finally
                    {
                        s_event.Set();
                    }
                }
            }
            else
            {
                if (SearchResourcesForTests is null)
                {
                    // Use AutoResetEvents around async tasks since lock() doesn't work and Monitor.Pulse can deadlock.
                    s_event.WaitOne(s_timeout);
                    try
                    {
                        if (SearchResourcesForTests is null)
                        {
                            SearchResourcesForTests = await factory();
                        }
                    }
                    finally
                    {
                        s_event.Set();
                    }
                }
            }
        }

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
            if (SearchResourcesForSamples != null)
            {
                await SearchResourcesForSamples.DisposeAsync();
                SearchResourcesForSamples = null;
            }
            if (SearchResourcesForTests != null)
            {
                await SearchResourcesForTests.DisposeAsync();
                SearchResourcesForTests = null;
            }
        }
    }
}
