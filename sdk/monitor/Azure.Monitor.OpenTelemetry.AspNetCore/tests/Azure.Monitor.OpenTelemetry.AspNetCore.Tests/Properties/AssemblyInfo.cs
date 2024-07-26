// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// OpenTelemery instruments the process.
// Several of these tests are End-to-End tests that require the process to be instrumented.
// Parallelization is disabled to prevent tests from interfering with each other.
[assembly: Xunit.CollectionBehavior(DisableTestParallelization = true)]
