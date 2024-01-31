// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Core.TestFramework
{
    public class ClientTestFixtureAttribute : NUnitAttribute, IFixtureBuilder2, IPreFilter
    {
        public const string VersionQualifierProperty = "VersionQualifier";

        private readonly struct TestVersion : IComparable
        {
            private readonly IComparable _comparable;
            public object Object { get; }
            public TestVersion(object obj)
            {
                Object = obj;
                if (obj.GetType().IsEnum)
                {
                    _comparable = Convert.ToInt32(obj);
                }
                else if (obj is string)
                {
                    _comparable = new ApiVersionString(obj as string);
                }
                else
                {
                    throw new InvalidOperationException("The items in the serviceVersions array must be an enum convertable to Int32 or a string in date format with an optional preview string");
                }
            }
            public TestVersion(IComparable comparable, object obj)
            {
                _comparable = comparable;
                Object = obj;
            }

            public int CompareTo(object obj)
            {
                if (obj is not TestVersion other)
                    return 1;

                return _comparable.CompareTo(other._comparable);
            }
        }

        public static readonly string SyncOnlyKey = "SyncOnly";
        public static readonly string RecordingDirectorySuffixKey = "RecordingDirectory";

        private readonly object[] _additionalParameters;
        private readonly object[] _serviceVersions;
        private readonly bool _recordAllVersions;
        private object _actualPlaybackServiceVersion;
        private object[] _actualLiveServiceVersions;

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
        public ClientTestFixtureAttribute(params object[] serviceVersions) : this(serviceVersions: serviceVersions, additionalParameters: default)
        { }

        /// <summary>
        /// Initializes an instance of the <see cref="ClientTestFixtureAttribute"/> accepting additional fixture parameters.
        /// </summary>
        /// <param name="serviceVersions">The set of service versions that will be passed to the test suite.</param>
        public ClientTestFixtureAttribute(bool recordAllVersions, params object[] serviceVersions) : this(serviceVersions: serviceVersions, additionalParameters: default, recordAllVersions)
        { }

        /// <summary>
        /// Initializes an instance of the <see cref="ClientTestFixtureAttribute"/> accepting additional fixture parameters.
        /// </summary>
        /// <param name="serviceVersions">The set of service versions that will be passed to the test suite.</param>
        /// <param name="additionalParameters">An array of additional parameters that will be passed to the test suite.</param>
        /// <param name="recordAllVersions">True if you want all versions in serviceVersions to be recorded and used for playback, false otherwise.</param>
        public ClientTestFixtureAttribute(object[] serviceVersions, object[] additionalParameters, bool recordAllVersions = false)
        {
            _additionalParameters = additionalParameters ?? new object[] { };
            _serviceVersions = serviceVersions ?? Array.Empty<object>();
            if (_serviceVersions.Length > 0)
            {
                var first = _serviceVersions[0];
                if (!_serviceVersions.All(x => x.GetType() == first.GetType()))
                    throw new InvalidOperationException("All service versions must be the same type and must be an enum convertable to Int32 or a string in date format with an optional preview string");
            }
            _recordAllVersions = recordAllVersions;
        }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
        {
            return BuildFrom(typeInfo, this);
        }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo, IPreFilter filter)
        {
            object latestVersion = GetMax(_serviceVersions);
            _actualPlaybackServiceVersion = RecordingServiceVersion ?? latestVersion;

            object[] liveVersions = (LiveServiceVersions ?? _serviceVersions).ToArray();

            if (liveVersions.Any())
            {
                if (TestEnvironment.GlobalTestOnlyLatestVersion)
                {
                    _actualLiveServiceVersions = new[] { GetMax(liveVersions) };
                }
                else if (TestEnvironment.GlobalTestServiceVersions is { Length: > 0 } globalTestServiceVersions &&
                            _serviceVersions is { Length: > 0 })
                {
                    var enumType = _serviceVersions[0].GetType();
                    var selectedVersions = new List<object>();

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

            bool includeSync = !typeInfo.GetCustomAttributes<AsyncOnlyAttribute>(true).Any();
            bool includeAsync = !typeInfo.GetCustomAttributes<SyncOnlyAttribute>(true).Any();

            Debug.Assert(includeSync || includeAsync);

            var suitePermutations = GeneratePermutations(includeSync, includeAsync);

            foreach (var (fixture, isAsync, serviceVersion, parameter) in suitePermutations)
            {
                foreach (TestSuite testSuite in fixture.BuildFrom(typeInfo, filter))
                {
                    Process(testSuite, serviceVersion, isAsync, parameter);
                    yield return testSuite;
                }
            }
        }

        internal static object GetMax(object[] array)
        {
            if (array == null || array.Length == 0)
                return null;
            return array.Max(v => new TestVersion(v)).Object;
        }

        private List<(TestFixtureAttribute Suite, bool IsAsync, object ServiceVersion, object Parameter)> GeneratePermutations(bool includeSync, bool includeAsync)
        {
            var result = new List<(TestFixtureAttribute Suite, bool IsAsync, object ServiceVersion, object Parameter)>();

            void AddResult(object serviceVersion, object parameter)
            {
                var parameters = new List<object>();
                parameters.Add(true);
                if (serviceVersion != null)
                {
                    parameters.Add(serviceVersion);
                }

                if (parameter != null)
                {
                    parameters.Add(parameter);
                }

                if (includeAsync)
                {
                    result.Add((new TestFixtureAttribute(parameters.ToArray()), true, serviceVersion, parameter));
                }

                if (includeSync)
                {
                    parameters[0] = false;
                    result.Add((new TestFixtureAttribute(parameters.ToArray()), false, serviceVersion, parameter));
                }
            }

            var serviceVersions = _serviceVersions.Any() ? _serviceVersions : new object[] { null };
            var parameters = _additionalParameters.Any() ? _additionalParameters : new object[] { null };
            foreach (object serviceVersion in serviceVersions.Distinct())
            {
                foreach (var parameter in parameters)
                {
                    AddResult(serviceVersion, parameter);
                }
            }

            return result;
        }

        private void Process(TestSuite testSuite, object serviceVersion, bool isAsync, object parameter)
        {
            if (parameter != null)
            {
                testSuite.Properties.Set(RecordingDirectorySuffixKey, parameter.ToString());
            }

            if (serviceVersion != null)
                ApplyLimits(serviceVersion, testSuite);

            ProcessTestList(testSuite, serviceVersion, isAsync, parameter);
        }

        private void ProcessTestList(TestSuite testSuite, object serviceVersion, bool isAsync, object parameter)
        {
            List<Test> testsDoDelete = null;
            foreach (Test test in testSuite.Tests)
            {
                if (test is ParameterizedMethodSuite parameterizedMethodSuite)
                {
                    ProcessTestList(parameterizedMethodSuite, serviceVersion, isAsync, parameter);
                    if (parameterizedMethodSuite.Tests.Count == 0)
                    {
                        testsDoDelete ??= new List<Test>();
                        testsDoDelete.Add(test);
                    }
                }
                else
                {
                    if (!ProcessTest(serviceVersion, isAsync, parameter, test))
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

        private bool ProcessTest(object serviceVersion, bool isAsync, object parameter, Test test)
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
                if (!_recordAllVersions && !serviceVersion.Equals(_actualPlaybackServiceVersion))
                {
                    test.Properties.Add("_SkipRecordings", $"Test is ignored when not running live because the service version {serviceVersion} is not {_actualPlaybackServiceVersion}.");
                    runsRecorded = false;
                }

                if (_actualLiveServiceVersions != null &&
                    !_actualLiveServiceVersions.Contains(serviceVersion))
                {
                    test.Properties.Set("_SkipLive",
                        $"Test ignored when running live service version {serviceVersion} is not one of {string.Join(", ", _actualLiveServiceVersions)}.");
                    runsLive = false;
                }
                var passesVersionLimits = ApplyLimits(serviceVersion, test);
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

            if (_recordAllVersions)
                test.Properties.Set(VersionQualifierProperty, serviceVersion.ToString());

            return runsRecorded || runsLive;
        }

        private static bool ApplyLimits(object serviceVersionNumber, Test test)
        {
            var minServiceVersion = test.GetCustomAttributes<ServiceVersionAttribute>(true);
            TestVersion testVersion = new TestVersion(serviceVersionNumber);
            foreach (ServiceVersionAttribute serviceVersionAttribute in minServiceVersion)
            {
                if (serviceVersionAttribute.Min != null &&
                    testVersion.CompareTo(new TestVersion(serviceVersionAttribute.Min)) < 0)
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", $"Test ignored because it's minimum service version is set to {serviceVersionAttribute.Min}");
                    return false;
                }

                if (serviceVersionAttribute.Max != null &&
                    testVersion.CompareTo(new TestVersion(serviceVersionAttribute.Max)) > 0)
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
