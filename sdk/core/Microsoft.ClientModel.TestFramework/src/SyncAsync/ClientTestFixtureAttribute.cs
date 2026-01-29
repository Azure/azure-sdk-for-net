// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// A test fixture attribute that automatically generates both synchronous and asynchronous variants of test classes.
/// This attribute creates separate test suites for sync and async execution modes, allowing tests to validate
/// both synchronous and asynchronous code paths without duplicating test logic.
/// </summary>
public class ClientTestFixtureAttribute : NUnitAttribute, IFixtureBuilder2, IPreFilter
{
    /// <summary>
    /// Property key used to mark tests that should only run synchronously.
    /// This is set when a test or class is decorated with <see cref="SyncOnlyAttribute"/>.
    /// </summary>
    public static readonly string SyncOnlyKey = "SyncOnly";

    /// <summary>
    /// Property key used to store the recording directory suffix for tests with additional parameters.
    /// This helps organize test recordings when multiple parameter variations exist.
    /// </summary>
    public static readonly string RecordingDirectorySuffixKey = "RecordingDirectory";

    private readonly object[] _additionalParameters;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientTestFixtureAttribute"/> class.
    /// </summary>
    /// <param name="additionalParameters">
    /// Optional additional parameters that will be passed to the test class constructor.
    /// When provided, creates separate test fixtures for each parameter value combined with sync/async modes.
    /// This is useful for testing different client configurations or service versions.
    /// </param>
    public ClientTestFixtureAttribute(params object[] additionalParameters)
    {
        _additionalParameters = additionalParameters ?? new object[] { };
    }

    /// <summary>
    /// Builds test suites from the specified type information using this attribute as the filter.
    /// </summary>
    /// <param name="typeInfo">The type information for the test class.</param>
    /// <returns>An enumerable collection of test suites generated for sync and async execution modes.</returns>
    public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
    {
        return BuildFrom(typeInfo, this);
    }

    /// <summary>
    /// Builds test suites from the specified type information, creating separate fixtures for synchronous
    /// and asynchronous execution modes based on the class and method attributes.
    /// </summary>
    /// <param name="typeInfo">The type information for the test class.</param>
    /// <param name="filter">The pre-filter to apply when building test suites.</param>
    /// <returns>
    /// An enumerable collection of test suites. Each suite represents either synchronous or asynchronous
    /// execution mode, potentially combined with additional parameter variations.
    /// </returns>
    public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo, IPreFilter filter)
    {
        if (typeInfo == null)
            throw new ArgumentNullException(nameof(typeInfo));

        bool includeSync = !typeInfo.GetCustomAttributes<AsyncOnlyAttribute>(true).Any();
        bool includeAsync = !typeInfo.GetCustomAttributes<SyncOnlyAttribute>(true).Any();

        Debug.Assert(includeSync || includeAsync);

        Debug.Assert(includeSync || includeAsync);

        var suitePermutations = GeneratePermutations(includeSync, includeAsync);

        foreach (var (fixture, isAsync, parameter) in suitePermutations)
        {
            foreach (TestSuite testSuite in fixture.BuildFrom(typeInfo, filter))
            {
                Process(testSuite, isAsync, parameter);
                yield return testSuite;
            }
        }
    }

    /// <summary>
    /// Generates all possible combinations of test fixtures based on sync/async modes and additional parameters.
    /// </summary>
    /// <param name="includeSync">Whether to include synchronous test fixtures.</param>
    /// <param name="includeAsync">Whether to include asynchronous test fixtures.</param>
    /// <returns>
    /// A list of tuples containing the test fixture attribute, execution mode, and parameter value
    /// for each combination that should be generated.
    /// </returns>
    private List<(TestFixtureAttribute Suite, bool IsAsync, object? Parameter)> GeneratePermutations(bool includeSync, bool includeAsync)
    {
        var result = new List<(TestFixtureAttribute Suite, bool IsAsync, object? Parameter)>();

        void AddResult(object? parameter)
        {
            List<object> parameters =[ true ];

            if (parameter != null)
            {
                parameters.Add(parameter);
            }

            if (includeAsync)
            {
                result.Add((new TestFixtureAttribute(parameters.ToArray()), true, parameter));
            }

            if (includeSync)
            {
                parameters[0] = false;
                result.Add((new TestFixtureAttribute(parameters.ToArray()), false, parameter));
            }
        }

        if (_additionalParameters.Length > 0)
        {
            foreach (var parameter in _additionalParameters)
            {
                AddResult(parameter);
            }
        }
        else
        {
            // Generate base sync/async permutations when no additional parameters
            AddResult(null);
        }

        return result;
    }

    /// <summary>
    /// Processes a test suite by setting properties and recursively processing all contained tests.
    /// </summary>
    /// <param name="testSuite">The test suite to process.</param>
    /// <param name="isAsync">Whether this test suite is for asynchronous execution.</param>
    /// <param name="parameter">The additional parameter value associated with this test suite, if any.</param>
    private void Process(TestSuite testSuite, bool isAsync, object? parameter)
    {
        if (parameter != null)
        {
            testSuite.Properties.Set(RecordingDirectorySuffixKey, parameter.ToString()!);
        }

        ProcessTestList(testSuite, isAsync, parameter);
    }

    /// <summary>
    /// Recursively processes all tests within a test suite, handling both individual tests and parameterized test suites.
    /// Removes tests that are not applicable for the current execution mode.
    /// </summary>
    /// <param name="testSuite">The test suite containing tests to process.</param>
    /// <param name="isAsync">Whether this is an asynchronous execution mode.</param>
    /// <param name="parameter">The additional parameter value, if any.</param>
    private void ProcessTestList(TestSuite testSuite, bool isAsync, object? parameter)
    {
        List<Test>? testsToDelete = null;
        foreach (Test test in testSuite.Tests)
        {
            if (test is ParameterizedMethodSuite parameterizedMethodSuite)
            {
                ProcessTestList(parameterizedMethodSuite, isAsync, parameter);
                if (parameterizedMethodSuite.Tests.Count == 0)
                {
                    testsToDelete ??= new List<Test>();
                    testsToDelete.Add(test);
                }
            }
            else
            {
                if (!ProcessTest(isAsync, parameter, test))
                {
                    testsToDelete ??= new List<Test>();
                    testsToDelete.Add(test);
                }
            }
        }

        // Remove tests that won't run in either live or recorded mode
        if (testsToDelete != null)
        {
            foreach (var testToDelete in testsToDelete)
            {
                testSuite.Tests.Remove(testToDelete);
            }
        }
    }

    /// <summary>
    /// Processes an individual test, applying execution mode restrictions and setting appropriate properties.
    /// </summary>
    /// <param name="isAsync">Whether this test is running in asynchronous mode.</param>
    /// <param name="parameter">The additional parameter value associated with this test, if any.</param>
    /// <param name="test">The test to process.</param>
    /// <returns>
    /// <c>true</c> if the test should be included in the test suite; <c>false</c> if it should be removed.
    /// </returns>
    private bool ProcessTest(bool isAsync, object? parameter, Test test)
    {
        if (parameter != null)
        {
            test.Properties.Set(RecordingDirectorySuffixKey, parameter.ToString()!);
        }

        // Handle sync-only tests
        if (test.GetCustomAttributes<SyncOnlyAttribute>(true).Any())
        {
            test.Properties.Set(SyncOnlyKey, true);
            if (isAsync)
            {
                test.RunState = RunState.Ignored;
                test.Properties.Set("_SKIPREASON", $"Test ignored in async run because it's marked with {nameof(SyncOnlyAttribute)}");
            }
        }

        // Handle async-only tests
        if (!isAsync && test.GetCustomAttributes<AsyncOnlyAttribute>(true).Any())
        {
            test.RunState = RunState.Ignored;
            test.Properties.Set("_SKIPREASON", $"Test ignored in sync run because it's marked with {nameof(AsyncOnlyAttribute)}");
        }

        // Set properties to indicate this test can run in both modes
        test.Properties.Set("RunsRecorded", "These tests would run in Record mode.");
        test.Properties.Set("RunsLive", "These tests would run in Live mode.");

        return true;
    }

    /// <summary>
    /// Determines if a type is suitable for test fixture generation.
    /// </summary>
    /// <param name="type">The type to evaluate.</param>
    /// <returns>Always returns <c>true</c> as all types are considered suitable for fixture generation.</returns>
    bool IPreFilter.IsMatch(Type type) => true;

    /// <summary>
    /// Determines if a method is suitable for test generation.
    /// </summary>
    /// <param name="type">The containing type of the method.</param>
    /// <param name="method">The method to evaluate.</param>
    /// <returns>Always returns <c>true</c> as all methods are considered suitable for test generation.</returns>
    bool IPreFilter.IsMatch(Type type, MethodInfo method) => true;
}