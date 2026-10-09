// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Activity.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

/// <summary>
/// Verifies the <see cref="PlatformErrorMarker"/> tagging convention that
/// <see cref="ActivityErrorSourceFilter"/> reads to classify an error as <c>platform</c>.
/// </summary>
[TestFixture]
public class PlatformErrorMarkerTests
{
    [Test]
    public void IsTagged_IsFalse_ForUntaggedException()
    {
        var ex = new InvalidOperationException("boom");
        Assert.That(PlatformErrorMarker.IsTagged(ex), Is.False);
    }

    [Test]
    public void Tag_MarksException_AsPlatformError()
    {
        var ex = new InvalidOperationException("boom");

        PlatformErrorMarker.Tag(ex);

        Assert.Multiple(() =>
        {
            Assert.That(PlatformErrorMarker.IsTagged(ex), Is.True);
            Assert.That(ex.Data.Contains(PlatformErrorMarker.DataKey), Is.True);
        });
    }

    [Test]
    public void DataKey_MatchesTheSharedConvention()
    {
        // The key is a cross-package convention; changing it would silently break classification.
        Assert.That(PlatformErrorMarker.DataKey, Is.EqualTo("Azure.AI.AgentServer.PlatformError"));
    }
}
