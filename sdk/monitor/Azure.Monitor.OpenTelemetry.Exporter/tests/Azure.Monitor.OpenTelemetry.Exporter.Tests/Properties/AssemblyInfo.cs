// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Xunit;

// Disable parallel test execution to prevent race conditions with static state in SdkVersionUtils.
// Tests that modify SdkVersionUtils.VersionType and SdkVersionUtils.SdkVersionPrefix must run sequentially.
[assembly: CollectionBehavior(DisableTestParallelization = true)]
