// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

[assembly: LiveParallelizable(ParallelScope.Fixtures)]

// Set per-test timeout to 20 minutes to prevent a single test from hanging the whole suite
[assembly: NUnit.Framework.Timeout(20 * 60 * 1000)]
