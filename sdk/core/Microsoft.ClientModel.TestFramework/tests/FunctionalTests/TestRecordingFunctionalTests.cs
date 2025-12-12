// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.TestProxy.Admin;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests;

/// <summary>
/// Functional tests for the RemoveDefaultSanitizers feature in RecordedTestBase.
/// </summary>
public class RemoveDefaultSanitizersTests : RecordedTestBase
{
    public RemoveDefaultSanitizersTests(bool isAsync) : base(isAsync)
    {
        RemoveDefaultSanitizers = true;
    }

    [RecordedTest]
    public async Task RemoveDefaultSanitizers_RemovesDefaultSanitizersFromTestProxy()
    {
        Assert.That(RemoveDefaultSanitizers, Is.True, "RemoveDefaultSanitizers should be set to true");
        Assert.That(Recording, Is.Not.Null, "Recording should be initialized");

        var adminClient = TestProxy?.AdminClient;
        Assert.That(adminClient, Is.Not.Null, "AdminClient should be available");

        // Try to remove some default sanitizers that should have already been removed
        var sanitizersToRemove = new SanitizerList(new List<string> { "AZSDK1000", "AZSDK2001", "AZSDK3400" });
        var result = await adminClient.RemoveSanitizersAsync(sanitizersToRemove, Recording.RecordingId);

        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value.Removed, Is.Not.Null);

        // The removed list should not contain these sanitizers because they were already removed
        Assert.That(result.Value.Removed, Does.Not.Contain("AZSDK1000"),
            "AZSDK1000 should have already been removed by RemoveDefaultSanitizers");
        Assert.That(result.Value.Removed, Does.Not.Contain("AZSDK2001"),
            "AZSDK2001 should have already been removed by RemoveDefaultSanitizers");
        Assert.That(result.Value.Removed, Does.Not.Contain("AZSDK3400"),
            "AZSDK3400 should have already been removed by RemoveDefaultSanitizers");
    }

    [RecordedTest]
    public async Task RemoveDefaultSanitizers_AuthorizationHeaderSanitizerIsNotRemoved()
    {
        Assert.That(RemoveDefaultSanitizers, Is.True);
        Assert.That(Recording, Is.Not.Null);

        var adminClient = TestProxy?.AdminClient;
        Assert.That(adminClient, Is.Not.Null);

        // This one should not have been removed by RemoveDefaultSanitizers
        var authSanitizer = new SanitizerList(new List<string> { "AZSDK0000" });
        var result = await adminClient.RemoveSanitizersAsync(authSanitizer, Recording.RecordingId);

        // Assert - AZSDK0000 should still be present and can be removed now
        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value.Removed, Is.Not.Null);
        Assert.That(result.Value.Removed, Does.Contain("AZSDK0000"),
            "Authorization header sanitizer (AZSDK0000) should still be present since RemoveDefaultSanitizers doesn't remove it");
    }
}
