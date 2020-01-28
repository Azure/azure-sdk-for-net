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
    public class ClientTestFixtureAttribute : NUnitAttribute, IFixtureBuilder2, IPreFilter, ITestAttribute
    {
        private readonly object[] _serviceVersions;
        private readonly int? _maxServiceVersion;

        public ClientTestFixtureAttribute(params object[] serviceVersions)
        {
            _serviceVersions = serviceVersions;
            _maxServiceVersion = _serviceVersions.Any() ? _serviceVersions.Max(Convert.ToInt32) : (int?)null;
        }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
        {
            return BuildFrom(typeInfo, this);
        }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo, IPreFilter filter)
            => BuildTestSuites(typeInfo, filter, true).Concat(BuildTestSuites(typeInfo, filter, false));

        public IEnumerable<TestSuite> BuildTestSuites(ITypeInfo typeInfo, IPreFilter filter, bool isAsync)
            => _serviceVersions.Any()
                ? _serviceVersions.SelectMany(v => BuildTestSuites(new TestFixtureAttribute(isAsync, v), typeInfo, filter, new TestProperties(isAsync, v)))
                // No service versions defined
                : BuildTestSuites(new TestFixtureAttribute(isAsync), typeInfo, filter, new TestProperties(isAsync, null));

        private IEnumerable<TestSuite> BuildTestSuites(TestFixtureAttribute fixture, ITypeInfo typeInfo, IPreFilter filter, TestProperties testProperties)
        {
            foreach (TestSuite testSuite in fixture.BuildFrom(typeInfo, filter))
            {
                Process(testSuite, testProperties);
                yield return testSuite;
            }
        }

        private void Process(TestSuite testSuite, TestProperties testProperties)
        {
            foreach (Test test in testSuite.Tests.OfType<Test>())
            {
                if (test is ParameterizedMethodSuite parameterizedMethodSuite)
                {
                    foreach (Test parameterizedTest in parameterizedMethodSuite.Tests.OfType<Test>())
                    {
                        ProcessTest(parameterizedTest, testProperties);
                    }
                }
                else
                {
                    ProcessTest(test, testProperties);
                }
            }
        }

        private void ProcessTest(Test test, TestProperties testProperties)
        {
            foreach (ITestAttribute testAttribute in GetAllTestAttributes(test))
            {
                testAttribute.Apply(test, testProperties);
            }
        }

        private static IEnumerable<ITestAttribute> GetAllTestAttributes(Test test)
        {
            if (test.TypeInfo != null)
            {
                if (test.TypeInfo.Assembly != null)
                {
                    foreach (ITestAttribute attribute in test.TypeInfo.Assembly.GetCustomAttributes(true).OfType<ITestAttribute>())
                    {
                        yield return attribute;
                    }
                }

                foreach (ITestAttribute attribute in test.TypeInfo.Type.GetCustomAttributes(true).OfType<ITestAttribute>())
                {
                    yield return attribute;
                }
            }

            if (test.Method != null)
            {
                foreach (ITestAttribute attribute in test.Method.MethodInfo.GetCustomAttributes(true).OfType<ITestAttribute>())
                {
                    yield return attribute;
                }
            }
        }

        bool IPreFilter.IsMatch(Type type) => true;

        bool IPreFilter.IsMatch(Type type, MethodInfo method)  => true;

        void ITestAttribute.Apply(Test test, TestProperties testProperties)
        {
            if (testProperties.ServiceVersion == null)
            {
                return;
            }

            if (Convert.ToInt32(testProperties.ServiceVersion) != _maxServiceVersion)
            {
                test.Properties.Add("SkipRecordings", $"Test is ignored when not running live because the service version {testProperties.ServiceVersion} is not the latest.");
            }
        }
    }
}
