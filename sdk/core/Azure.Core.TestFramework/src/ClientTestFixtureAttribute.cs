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
        public static readonly string OnlyTestLatestServiceVersionKey = "AZURE_ONLY_TEST_LATEST_SERVICE_VERSION";

        private static readonly Lazy<bool> OnlyTestLatestServiceVersionLazy = new Lazy<bool>(() =>
        {
            bool.TryParse(Environment.GetEnvironmentVariable(OnlyTestLatestServiceVersionKey), out bool onlyTestLatestServiceVersion);
            return onlyTestLatestServiceVersion;
        });

        private readonly object[] _additionalParameters;
        private readonly object[] _serviceVersions;
        private readonly int? _maxServiceVersion;

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

            _maxServiceVersion = _serviceVersions.Any() ? _serviceVersions.Max(s => Convert.ToInt32(s)) : (int?)null;
        }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
        {
            return BuildFrom(typeInfo, this);
        }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo, IPreFilter filter)
        {
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

        private List<(TestFixtureAttribute suite, bool isAsync, object serviceVersion, object parameter)> GeneratePermutations()
        {
            var result = new List<(TestFixtureAttribute suite, bool isAsync, object serviceVersion, object parameter)>();

            if (_serviceVersions.Any())
            {
                foreach (object serviceVersion in _serviceVersions)
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
            foreach (Test test in testSuite.Tests)
            {
                if (test is ParameterizedMethodSuite parameterizedMethodSuite)
                {
                    foreach (Test parameterizedTest in parameterizedMethodSuite.Tests)
                    {
                        ProcessTest(serviceVersion, isAsync, serviceVersionNumber, parameter, parameterizedTest);
                    }
                }
                else
                {
                    ProcessTest(serviceVersion, isAsync, serviceVersionNumber, parameter, test);
                }
            }
        }

        private void ProcessTest(object serviceVersion, bool isAsync, int serviceVersionNumber, object parameter, Test test)
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

            if (serviceVersion == null)
            {
                return;
            }

            if (serviceVersionNumber != _maxServiceVersion)
            {
                test.Properties.Add("SkipRecordings", $"Test is ignored when not running live because the service version {serviceVersion} is not the latest.");
            }

            if (OnlyTestLatestServiceVersionLazy.Value && serviceVersionNumber != _maxServiceVersion)
            {
                test.RunState = RunState.Ignored;
                test.Properties.Set("_SKIPREASON",
                    $"Test ignored because {OnlyTestLatestServiceVersionKey} is set in the environment and version {serviceVersion} is not the latest.");
            }

            var minServiceVersion = test.GetCustomAttributes<ServiceVersionAttribute>(true);
            foreach (ServiceVersionAttribute serviceVersionAttribute in minServiceVersion)
            {
                if (serviceVersionAttribute.Min != null &&
                    Convert.ToInt32(serviceVersionAttribute.Min) > serviceVersionNumber)
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", $"Test ignored because it's minimum service version is set to {serviceVersionAttribute.Min}");
                }

                if (serviceVersionAttribute.Max != null &&
                    Convert.ToInt32(serviceVersionAttribute.Max) < serviceVersionNumber)
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", $"Test ignored because it's maximum service version is set to {serviceVersionAttribute.Max}");
                }
            }
        }

        bool IPreFilter.IsMatch(Type type) => true;

        bool IPreFilter.IsMatch(Type type, MethodInfo method) => true;
    }
}
