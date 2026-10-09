// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Activity.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

[TestFixture]
public class ActivityIdSanitizerTests
{
    [TestCase("abc123")]
    [TestCase("ABCdef")]
    [TestCase("id-with-dash")]
    [TestCase("id_with_underscore")]
    [TestCase("id.with.dot")]
    [TestCase("id:with:colon")]
    [TestCase("a1-b2_c3.d4:e5")]
    public void Sanitize_ReturnsOriginal_ForValidValue(string value)
    {
        var result = ActivityIdSanitizer.Sanitize(value);

        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void Sanitize_ReturnsOriginal_AtExactMaxLength()
    {
        var value = new string('a', 256);

        var result = ActivityIdSanitizer.Sanitize(value);

        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void Sanitize_GeneratesGuid_WhenTooLong()
    {
        var value = new string('a', 257);

        var result = ActivityIdSanitizer.Sanitize(value);

        Assert.That(result, Is.Not.EqualTo(value));
        Assert.That(Guid.TryParse(result, out _), Is.True);
    }

    [TestCase("has space")]
    [TestCase("has/slash")]
    [TestCase("has\\backslash")]
    [TestCase("has\ttab")]
    [TestCase("has\nnewline")]
    [TestCase("has;semicolon")]
    [TestCase("has<angle>")]
    [TestCase("emoji😀")]
    public void Sanitize_GeneratesGuid_ForUnsafeCharacters(string value)
    {
        var result = ActivityIdSanitizer.Sanitize(value);

        Assert.That(result, Is.Not.EqualTo(value));
        Assert.That(Guid.TryParse(result, out _), Is.True);
    }

    [Test]
    public void Sanitize_GeneratesGuid_WhenNull()
    {
        var result = ActivityIdSanitizer.Sanitize(null);

        Assert.That(Guid.TryParse(result, out _), Is.True);
    }

    [Test]
    public void Sanitize_GeneratesGuid_WhenEmpty()
    {
        var result = ActivityIdSanitizer.Sanitize(string.Empty);

        Assert.That(Guid.TryParse(result, out _), Is.True);
    }

    [Test]
    public void Sanitize_GeneratesUniqueGuids_OnSuccessiveInvalidCalls()
    {
        var first = ActivityIdSanitizer.Sanitize(null);
        var second = ActivityIdSanitizer.Sanitize(null);

        Assert.That(first, Is.Not.EqualTo(second));
    }
}
