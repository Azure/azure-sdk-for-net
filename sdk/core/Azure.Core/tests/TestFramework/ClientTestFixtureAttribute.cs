// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Core.Testing
{
    public class ClientTestFixtureAttribute : NUnitAttribute, IFixtureBuilder2, IPreFilter
    {
        private readonly object[] _serviceVersions;
        private readonly int? _maxServiceVersion;

        public ClientTestFixtureAttribute(params object[] serviceVersions)
        {
            _serviceVersions = serviceVersions;

            _maxServiceVersion = _serviceVersions.Any() ? _serviceVersions.Max(s => Convert.ToInt32(s)) : (int?)null;
        }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
        {
            return BuildFrom(typeInfo, this);
        }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo, IPreFilter filter)
        {
            if (_serviceVersions.Any())
            {
                foreach (object serviceVersion in _serviceVersions)
                {
                    var syncFixture = new TestFixtureAttribute(false, serviceVersion);
                    var asyncFixture = new TestFixtureAttribute(true, serviceVersion);

                    foreach (TestSuite testSuite in asyncFixture.BuildFrom(typeInfo, filter))
                    {
                        Process(testSuite, serviceVersion, true);
                        yield return testSuite;
                    }

                    foreach (TestSuite testSuite in syncFixture.BuildFrom(typeInfo, filter))
                    {
                        Process(testSuite, serviceVersion, false);
                        yield return testSuite;
                    }
                }
            }
            else
            {
                // No service versions defined
                var syncFixture = new TestFixtureAttribute(false);
                var asyncFixture = new TestFixtureAttribute(true);

                foreach (TestSuite testSuite in asyncFixture.BuildFrom(typeInfo, filter))
                {
                    Process(testSuite, null, true);
                    yield return testSuite;
                }

                foreach (TestSuite testSuite in syncFixture.BuildFrom(typeInfo, filter))
                {
                    Process(testSuite, null, false);
                    yield return testSuite;
                }
            }
        }

        private void Process(TestSuite testSuite, object serviceVersion, bool isAsync)
        {
            var serviceVersionNumber = Convert.ToInt32(serviceVersion);
            foreach (Test test in testSuite.Tests)
            {
                if (test is ParameterizedMethodSuite parameterizedMethodSuite)
                {
                    foreach (Test parameterizedTest in parameterizedMethodSuite.Tests)
                    {
                        ProcessTest(serviceVersion, isAsync, serviceVersionNumber, parameterizedTest);
                    }
                }
                else
                {
                    ProcessTest(serviceVersion, isAsync, serviceVersionNumber, test);
                }
            }
        }

        private void ProcessTest(object serviceVersion, bool isAsync, int serviceVersionNumber, Test test)
        {
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
