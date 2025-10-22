// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Analytics.OnlineExperimentation.Tests;
using System;

namespace Azure.Analytics.OnlineExperimentation.Samples
{
    [LiveOnly]
    [NonParallelizable]
    public class OnlineExperimentationSamplesBase : SamplesBase<OnlineExperimentationClientTestEnvironment>
    {
        /// <summary>
        /// Redirects calls <see cref="Environment.GetEnvironmentVariable(string)"/> to <see cref="OnlineExperimentationClientTestEnvironment"/>.
        /// </summary>
        protected internal TestEnvironmentFacade Environment => new(TestEnvironment);

        protected internal readonly struct TestEnvironmentFacade(OnlineExperimentationClientTestEnvironment TestEnvironment)
        {
            public string GetEnvironmentVariable(string name)
            {
                return name?.ToUpperInvariant() switch
                {
                    "AZURE_ONLINEEXPERIMENTATION_ENDPOINT" => TestEnvironment.Endpoint,
                    _ => throw new ArgumentException($"Environment variable '{name}' not expected in samples.", nameof(name))
                };
            }
        }
    }
}
