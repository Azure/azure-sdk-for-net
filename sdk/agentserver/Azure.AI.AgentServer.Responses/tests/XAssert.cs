// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests;

/// <summary>
/// Bridge helpers for xUnit assertion patterns that have no direct NUnit equivalent.
/// These methods preserve xUnit semantics (parameter order, return values) while
/// delegating to NUnit constraint-model assertions underneath.
/// </summary>
internal static class XAssert
{
    /// <summary>
    /// Asserts that the collection contains exactly one element and returns it.
    /// xUnit equivalent: Assert.Single(collection)
    /// </summary>
    public static T Single<T>(IEnumerable<T> collection)
    {
        var list = collection.ToList();
        Assert.That(list, Has.Exactly(1).Items);
        return list[0];
    }

    /// <summary>
    /// Asserts that the object is exactly the specified type (not a derived type) and returns the cast value.
    /// xUnit equivalent: Assert.IsType&lt;T&gt;(obj)
    /// </summary>
    public static T IsType<T>(object obj)
    {
        Assert.That(obj, Is.TypeOf<T>());
        return (T)obj;
    }

    /// <summary>
    /// Asserts that the object is assignable to the specified type and returns the cast value.
    /// xUnit equivalent: Assert.IsAssignableFrom&lt;T&gt;(obj)
    /// </summary>
    public static T IsAssignableFrom<T>(object obj)
    {
        Assert.That(obj, Is.InstanceOf<T>());
        return (T)obj;
    }

    /// <summary>
    /// Asserts that a string contains the expected substring.
    /// xUnit equivalent: Assert.Contains(expected, actual) for strings
    /// </summary>
    public static void Contains(string expected, string actual)
    {
        Assert.That(actual, Does.Contain(expected));
    }

    /// <summary>
    /// Asserts that a collection contains the expected element.
    /// xUnit equivalent: Assert.Contains(expected, collection)
    /// </summary>
    public static void Contains<T>(T expected, IEnumerable<T> collection)
    {
        Assert.That(collection, Does.Contain(expected));
    }

    /// <summary>
    /// Asserts that a collection contains an element matching the predicate.
    /// xUnit equivalent: Assert.Contains(collection, predicate)
    /// </summary>
    public static void Contains<T>(IEnumerable<T> collection, Func<T, bool> predicate)
    {
        Assert.That(collection.Any(predicate), Is.True, "Expected collection to contain a matching element.");
    }

    /// <summary>
    /// Asserts that a string does not contain the expected substring.
    /// xUnit equivalent: Assert.DoesNotContain(expected, actual)
    /// </summary>
    public static void DoesNotContain(string expected, string actual)
    {
        Assert.That(actual, Does.Not.Contain(expected));
    }

    /// <summary>
    /// Asserts that a string does not contain the expected substring (with comparison).
    /// xUnit equivalent: Assert.DoesNotContain(expected, actual, comparisonType)
    /// </summary>
    public static void DoesNotContain(string expected, string actual, StringComparison comparisonType)
    {
        Assert.That(actual.IndexOf(expected, comparisonType) < 0, Is.True,
            $"Expected string not to contain '{expected}' (comparison: {comparisonType}).");
    }

    /// <summary>
    /// Asserts that a collection does not contain the expected element.
    /// xUnit equivalent: Assert.DoesNotContain(expected, collection)
    /// </summary>
    public static void DoesNotContain<T>(T expected, IEnumerable<T> collection)
    {
        Assert.That(collection, Does.Not.Contain(expected));
    }

    /// <summary>
    /// Asserts that a collection does not contain an element matching the predicate.
    /// xUnit equivalent: Assert.DoesNotContain(collection, predicate)
    /// </summary>
    public static void DoesNotContain<T>(IEnumerable<T> collection, Func<T, bool> predicate)
    {
        Assert.That(collection.Any(predicate), Is.False, "Expected collection not to contain a matching element.");
    }

    /// <summary>
    /// Asserts that a string starts with the expected prefix.
    /// xUnit equivalent: Assert.StartsWith(expected, actual)
    /// </summary>
    public static void StartsWith(string expected, string actual)
    {
        Assert.That(actual, Does.StartWith(expected));
    }

    /// <summary>
    /// Asserts that a string ends with the expected suffix.
    /// xUnit equivalent: Assert.EndsWith(expected, actual)
    /// </summary>
    public static void EndsWith(string expected, string actual)
    {
        Assert.That(actual, Does.EndWith(expected));
    }

    /// <summary>
    /// Asserts that a string matches the specified regex pattern.
    /// xUnit equivalent: Assert.Matches(pattern, actual)
    /// </summary>
    public static void Matches(string pattern, string actual)
    {
        Assert.That(actual, Does.Match(pattern));
    }

    /// <summary>
    /// Asserts that a value is within the specified range (inclusive).
    /// xUnit equivalent: Assert.InRange(actual, low, high)
    /// </summary>
    public static void InRange<T>(T actual, T low, T high) where T : IComparable<T>
    {
        Assert.That(actual, Is.InRange(low, high));
    }
}

/// <summary>
/// Bridge for xUnit's Record class which captures exceptions without asserting.
/// </summary>
internal static class Record
{
    /// <summary>
    /// Executes an async delegate and returns the exception thrown, or null if no exception.
    /// xUnit equivalent: Record.ExceptionAsync(Func&lt;Task&gt;)
    /// </summary>
    public static async Task<Exception?> ExceptionAsync(Func<Task> testCode)
    {
        try
        {
            await testCode();
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
