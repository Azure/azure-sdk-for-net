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
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

internal class ClientTestFixtureAttribute : NUnitAttribute, IFixtureBuilder2, IPreFilter
{
    public static readonly string SyncOnlyKey = "SyncOnly";
    public static readonly string RecordingDirectorySuffixKey = "RecordingDirectory";

    private readonly object[] _additionalParameters;

    /// <summary>
    /// Initializes an instance of the <see cref="ClientTestFixtureAttribute"/> accepting additional fixture parameters.
    /// </summary>
    /// <param name="additionalParameters">An array of additional parameters that will be passed to the test suite.</param>
    public ClientTestFixtureAttribute(params object[] additionalParameters)
    {
        _additionalParameters = additionalParameters ?? new object[] { };
    }

    public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
    {
        return BuildFrom(typeInfo, this);
    }

    public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo, IPreFilter filter)
    {
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

    private void Process(TestSuite testSuite, bool isAsync, object? parameter)
    {
        if (parameter != null)
        {
            testSuite.Properties.Set(RecordingDirectorySuffixKey, parameter.ToString()!);
        }

        ProcessTestList(testSuite, isAsync, parameter);
    }

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
                return false;
            }
        }

        // Handle async-only tests
        if (!isAsync && test.GetCustomAttributes<AsyncOnlyAttribute>(true).Any())
        {
            test.RunState = RunState.Ignored;
            test.Properties.Set("_SKIPREASON", $"Test ignored in sync run because it's marked with {nameof(AsyncOnlyAttribute)}");
            return false;
        }

        // Set properties to indicate this test can run in both modes
        test.Properties.Set("RunsRecorded", "These tests would run in Record mode.");
        test.Properties.Set("RunsLive", "These tests would run in Live mode.");

        return true;
    }

    bool IPreFilter.IsMatch(Type type) => true;

    bool IPreFilter.IsMatch(Type type, MethodInfo method) => true;
}