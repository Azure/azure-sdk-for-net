// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Core.TestFramework
{
    public class ClientTestFixtureAttribute : NUnitAttribute, IFixtureBuilder2, IPreFilter
    {
        public static readonly string SyncOnlyKey = "SyncOnly";
        public static readonly string RecordingDirectorySuffixKey = "RecordingDirectory";

        private readonly object[] _additionalParameters;
        private readonly object[] _serviceVersions;
        private int? _actualPlaybackServiceVersion;
        private int[] _actualLiveServiceVersions;

        /// <summary>
        /// Specifies which service version is run during recording/playback runs.
        /// </summary>
        public object RecordingServiceVersion { get; set; }

        /// <summary>
        /// Specifies which service version is run during live runs.
        /// </summary>
        public object[] LiveServiceVersions { get; set; }

        /// <summary>
        /// Initializes an instance of the <see cref="ClientTestFixtureAttribute"/> accepting additional fixture parameters.
        /// </summary>
        /// <param name="serviceVersions">The set of service versions that will be passed to the test suite.</param>
        public ClientTestFixtureAttribute(params object[] serviceVersions) : this(serviceVersions: serviceVersions, default)
        { }

        /// <summary>
        /// Initializes an instance of the <see cref="ClientTestFixtureAttribute"/> accepting additional fixture parameters.
        /// </summary>
        /// <param name="serviceVersions">The set of service versions that will be passed to the test suite.</param>
        /// <param name="additionalParameters">An array of additional parameters that will be passed to the test suite.</param>
        public ClientTestFixtureAttribute(object[] serviceVersions, object[] additionalParameters)
        {
            _additionalParameters = additionalParameters ?? new object[] { };
            _serviceVersions = serviceVersions ?? new object[] { };
        }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
        {
            return BuildFrom(typeInfo, this);
        }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo, IPreFilter filter)
        {
            var latestVersion = _serviceVersions.Any() ? _serviceVersions.Max(Convert.ToInt32) : (int?)null;
            _actualPlaybackServiceVersion = RecordingServiceVersion != null ? Convert.ToInt32(RecordingServiceVersion) : latestVersion;

            int[] liveVersions = (LiveServiceVersions ?? _serviceVersions).Select(Convert.ToInt32).ToArray();

            if (liveVersions.Any())
            {
                if (TestEnvironment.GlobalTestOnlyLatestVersion)
                {
                    _actualLiveServiceVersions = new[] { liveVersions.Max() };
                }
                else if (TestEnvironment.GlobalTestServiceVersions is { Length: > 0 } globalTestServiceVersions &&
                         _serviceVersions is { Length: > 0 })
                {
                    var enumType = _serviceVersions[0].GetType();
                    var selectedVersions = new List<int>();

                    foreach (var versionString in globalTestServiceVersions)
                    {
                        try
                        {
                            selectedVersions.Add(Convert.ToInt32(Enum.Parse(enumType, versionString)));
                        }
                        catch
                        {
                        }
                    }

                    _actualLiveServiceVersions = selectedVersions.ToArray();
                }
                else
                {
                    _actualLiveServiceVersions = liveVersions.ToArray();
                }
            }

            var suitePermutations = GeneratePermutations();

            foreach (var (fixture, isAsync, serviceVersion, parameter) in suitePermutations)
            {
                foreach (TestSuite testSuite in fixture.BuildFrom(typeInfo, filter))
                {
                    Process(testSuite, serviceVersion, isAsync, parameter);
                    yield return testSuite;
                }
            }
        }

        private List<(TestFixtureAttribute Suite, bool IsAsync, object ServiceVersion, object Parameter)> GeneratePermutations()
        {
            var result = new List<(TestFixtureAttribute Suite, bool IsAsync, object ServiceVersion, object Parameter)>();

            if (_serviceVersions.Any())
            {
                foreach (object serviceVersion in _serviceVersions.Distinct())
                {
                    if (_additionalParameters.Any())
                    {
                        foreach (var parameter in _additionalParameters)
                        {
                            result.Add((new TestFixtureAttribute(false, serviceVersion, parameter), false, serviceVersion, parameter));
                            result.Add((new TestFixtureAttribute(true, serviceVersion, parameter), true, serviceVersion, parameter));
                        }
                    }
                    else
                    {
                        // No additional parameters defined
                        result.Add((new TestFixtureAttribute(false, serviceVersion), false, serviceVersion, null));
                        result.Add((new TestFixtureAttribute(true, serviceVersion), true, serviceVersion, null));
                    }
                }
            }
            else
            {
                if (_additionalParameters.Any())
                {
                    foreach (var parameter in _additionalParameters)
                    {
                        result.Add((new TestFixtureAttribute(false, parameter), false, null, parameter));
                        result.Add((new TestFixtureAttribute(true, parameter), true, null, parameter));
                    }
                }
                else
                {
                    // No additional parameters defined
                    result.Add((new TestFixtureAttribute(false), false, null, null));
                    result.Add((new TestFixtureAttribute(true), true, null, null));
                }
            }

            return result;
        }

        private void Process(TestSuite testSuite, object serviceVersion, bool isAsync, object parameter)
        {
            var serviceVersionNumber = Convert.ToInt32(serviceVersion);
            ApplyLimits(serviceVersionNumber, testSuite);

            ProcessTestList(testSuite, serviceVersion, isAsync, parameter, serviceVersionNumber);
        }

        private void ProcessTestList(TestSuite testSuite, object serviceVersion, bool isAsync, object parameter, int serviceVersionNumber)
        {
            List<Test> testsDoDelete = null;
            foreach (Test test in testSuite.Tests)
            {
                if (test is ParameterizedMethodSuite parameterizedMethodSuite)
                {
                    ProcessTestList(parameterizedMethodSuite, serviceVersion, isAsync, parameter, serviceVersionNumber);
                    if (parameterizedMethodSuite.Tests.Count == 0)
                    {
                        testsDoDelete ??= new List<Test>();
                        testsDoDelete.Add(test);
                    }
                }
                else
                {
                    if (!ProcessTest(serviceVersion, isAsync, serviceVersionNumber, parameter, test))
                    {
                        testsDoDelete ??= new List<Test>();
                        testsDoDelete.Add(test);
                    }
                }
            }

            // These tests won't run neither live nor recorded with current set of settings
            if (testsDoDelete != null)
            {
                foreach (var testDoDelete in testsDoDelete)
                {
                    testSuite.Tests.Remove(testDoDelete);
                }
            }
        }

        private bool ProcessTest(object serviceVersion, bool isAsync, int serviceVersionNumber, object parameter, Test test)
        {
            if (parameter != null)
            {
                test.Properties.Set(RecordingDirectorySuffixKey, parameter.ToString());
            }
            if (test.GetCustomAttributes<SyncOnlyAttribute>(true).Any())
            {
                test.Properties.Set(SyncOnlyKey, true);
                if (isAsync)
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", $"Test ignored in async run because it's marked with {nameof(SyncOnlyAttribute)}");
                }
            }

            if (!isAsync && test.GetCustomAttributes<AsyncOnlyAttribute>(true).Any())
            {
                test.RunState = RunState.Ignored;
                test.Properties.Set("_SKIPREASON", $"Test ignored in sync run because it's marked with {nameof(AsyncOnlyAttribute)}");
            }

            bool runsRecorded = true;
            bool runsLive = true;

            if (serviceVersion == null)
            {
                return true;
            }
            else
            {
                if (serviceVersionNumber != _actualPlaybackServiceVersion)
                {
                    test.Properties.Add("_SkipRecordings", $"Test is ignored when not running live because the service version {serviceVersion} is not {_actualPlaybackServiceVersion}.");
                    runsRecorded = false;
                }

                if (_actualLiveServiceVersions != null &&
                    !_actualLiveServiceVersions.Contains(serviceVersionNumber))
                {
                    test.Properties.Set("_SkipLive",
                        $"Test ignored when running live service version {serviceVersion} is not one of {string.Join(", " , _actualLiveServiceVersions)}.");
                    runsLive = false;
                }
                var passesVersionLimits = ApplyLimits(serviceVersionNumber, test);
                runsLive &= passesVersionLimits;
                runsRecorded &= passesVersionLimits;
            }

            if (runsRecorded)
            {
                test.Properties.Set("RunsRecorded", "These tests would run in Record mode.");
            }

            if (runsLive)
            {
                test.Properties.Set("RunsLive", "These tests would run in Live mode.");
            }

            return runsRecorded || runsLive;
        }

        private static bool ApplyLimits(int serviceVersionNumber, Test test)
        {
            var minServiceVersion = test.GetCustomAttributes<ServiceVersionAttribute>(true);
            foreach (ServiceVersionAttribute serviceVersionAttribute in minServiceVersion)
            {
                if (serviceVersionAttribute.Min != null &&
                    Convert.ToInt32(serviceVersionAttribute.Min) > serviceVersionNumber)
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", $"Test ignored because it's minimum service version is set to {serviceVersionAttribute.Min}");
                    return false;
                }

                if (serviceVersionAttribute.Max != null &
                    Convert.ToInt32(serviceVersionAttribute.Max) < serviceVersionNumber)
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", $"Test ignored because it's maximum service version is set to {serviceVersionAttribute.Max}");
                    return false;
                }
            }

            return true;
        }

        bool IPreFilter.IsMatch(Type type) => true;

        bool IPreFilter.IsMatch(Type type, MethodInfo method) => true;
    }
}
