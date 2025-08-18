// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.Core.TestFramework;
using Azure.AI.Projects.Tests.Utils;

namespace Azure.AI.Projects.Tests
{
    /// <summary>
    /// Base class for recorded tests that use System.ClientModel.ClientPipelineOptions.
    /// This provides recording capabilities for clients that use System.ClientModel instead of Azure.Core.
    /// </summary>
    public abstract class RecordedProjectsTestBase<TEnvironment> : RecordedTestBase<TEnvironment>
        where TEnvironment : TestEnvironment, new()
    {
        protected RecordedProjectsTestBase(bool isAsync) : base(isAsync)
        {
            // Apply sanitizers to protect sensitive information in recordings
            ProjectsTestSanitizers.ApplySanitizers(this);
        }

        protected RecordedProjectsTestBase(bool isAsync, RecordedTestMode? mode) : base(isAsync, mode)
        {
            // Apply sanitizers to protect sensitive information in recordings
            ProjectsTestSanitizers.ApplySanitizers(this);
        }

        /// <summary>
        /// Configures System.ClientModel client options for test recording/playback.
        /// This method injects the appropriate transport to enable recording when not in Live mode.
        /// </summary>
        /// <typeparam name="TClientOptions">The type of client options (must inherit from ClientPipelineOptions).</typeparam>
        /// <param name="options">The client options to configure.</param>
        /// <returns>The configured client options.</returns>
        public virtual TClientOptions ConfigureClientOptionsForRecording<TClientOptions>(TClientOptions options)
            where TClientOptions : ClientPipelineOptions
        {
            if (Mode == RecordedTestMode.Live || Recording == null)
            {
                return options;
            }

            // Don't override if transport is already set
            if (options.Transport != null)
            {
                return options;
            }

            // Configure retry policy for playback mode to reduce delays
            if (Mode == RecordedTestMode.Playback)
            {
                // Use a simple retry policy with minimal delays during playback
                options.RetryPolicy = new TestClientRetryPolicy(delay: TimeSpan.FromMilliseconds(10));
            }

            // Set up the proxy transport for recording/playback
            options.Transport = new ProjectsProxyTransport(Recording);

            return options;
        }
    }
}
