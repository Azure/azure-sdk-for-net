// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

// TODO: Look into writing a custom Parallelizable attribute that will run
// sequentially for record/playback but let us run in parallel for live tests.
// [assembly: Parallelizable(ParallelScope.Children)]

// Set per-test timeout to 20 minutes to prevent a single test from hanging the whole suite
[assembly: NUnit.Framework.Timeout(20 * 60 * 1000)]
