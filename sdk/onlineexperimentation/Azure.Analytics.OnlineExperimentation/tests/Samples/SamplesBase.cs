// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Analytics.OnlineExperimentation.Tests;

namespace Azure.Analytics.OnlineExperimentation.Samples
{
    // Base class for samples that don't need test environment setup
    [NonParallelizable]
    public class SamplesBase : SamplesBase<OnlineExperimentationClientTestEnvironment>
    {
    }
}
