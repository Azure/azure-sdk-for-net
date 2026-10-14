// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class TagHelperCompatibilityTests
    {
        private static readonly Type[] ResourceTypes =
        {
            typeof(CassandraKeyspaceResource),
            typeof(CassandraKeyspaceThroughputSettingResource),
            typeof(CassandraTableResource),
            typeof(CassandraTableThroughputSettingResource),
            typeof(CosmosDBSqlContainerResource),
            typeof(CosmosDBSqlContainerThroughputSettingResource),
            typeof(CosmosDBSqlDatabaseResource),
            typeof(CosmosDBSqlDatabaseThroughputSettingResource),
            typeof(CosmosDBSqlStoredProcedureResource),
            typeof(CosmosDBSqlTriggerResource),
            typeof(CosmosDBSqlUserDefinedFunctionResource),
            typeof(CosmosDBTableResource),
            typeof(CosmosTableThroughputSettingResource),
            typeof(GremlinDatabaseResource),
            typeof(GremlinDatabaseThroughputSettingResource),
            typeof(GremlinGraphResource),
            typeof(GremlinGraphThroughputSettingResource),
            typeof(MongoDBCollectionResource),
            typeof(MongoDBCollectionThroughputSettingResource),
            typeof(MongoDBDatabaseResource),
            typeof(MongoDBDatabaseThroughputSettingResource),
        };

        [TestCaseSource(nameof(ResourceTypes))]
        public void TagHelpersRetainGaSignatures(Type resourceType)
        {
            foreach (bool isAsync in new[] { false, true })
            {
                string suffix = isAsync ? "Async" : "";
                Type responseType = typeof(Response<>).MakeGenericType(resourceType);
                Type returnType = isAsync ? typeof(Task<>).MakeGenericType(responseType) : responseType;
                AssertSignature(resourceType, "AddTag" + suffix, returnType, typeof(string), typeof(string), typeof(CancellationToken));
                AssertSignature(resourceType, "SetTags" + suffix, returnType, typeof(IDictionary<string, string>), typeof(CancellationToken));
                AssertSignature(resourceType, "RemoveTag" + suffix, returnType, typeof(string), typeof(CancellationToken));
            }
        }

        private static void AssertSignature(Type resourceType, string name, Type returnType, params Type[] parameterTypes)
        {
            MethodInfo method = resourceType.GetMethod(name, parameterTypes);
            Assert.That(method, Is.Not.Null, $"{resourceType.Name}.{name}");
            Assert.That(method.DeclaringType, Is.EqualTo(resourceType));
            Assert.That(method.IsVirtual, Is.True);
            Assert.That(method.ReturnType, Is.EqualTo(returnType));
            Assert.That(method.GetParameters()[parameterTypes.Length - 1].IsOptional, Is.True);
        }

        private static IEnumerable NullArgumentCases()
        {
            foreach (Type resourceType in ResourceTypes)
            {
                foreach (bool isAsync in new[] { false, true })
                {
                    string suffix = isAsync ? "Async" : "";
                    yield return new TestCaseData(resourceType, "AddTag" + suffix, new object[] { null, "value", CancellationToken.None }, "key");
                    yield return new TestCaseData(resourceType, "AddTag" + suffix, new object[] { "key", null, CancellationToken.None }, "value");
                    yield return new TestCaseData(resourceType, "SetTags" + suffix, new object[] { null, CancellationToken.None }, "tags");
                    yield return new TestCaseData(resourceType, "RemoveTag" + suffix, new object[] { null, CancellationToken.None }, "key");
                }
            }
        }

        [TestCaseSource(nameof(NullArgumentCases))]
        public void TagHelpersRejectNullArguments(Type resourceType, string methodName, object[] arguments, string parameterName)
        {
            // The protected mocking constructor is sufficient: validation must run before any service call.
            object resource = Activator.CreateInstance(resourceType, nonPublic: true);
            MethodInfo method = resourceType.GetMethod(methodName);
            if (methodName.EndsWith("Async", StringComparison.Ordinal))
            {
                var exception = Assert.ThrowsAsync<ArgumentNullException>(async () =>
                    await (Task)method.Invoke(resource, arguments));
                Assert.That(exception.ParamName, Is.EqualTo(parameterName));
            }
            else
            {
                var exception = Assert.Throws<TargetInvocationException>(() => method.Invoke(resource, arguments));
                Assert.That(exception.InnerException, Is.TypeOf<ArgumentNullException>());
                Assert.That(((ArgumentNullException)exception.InnerException).ParamName, Is.EqualTo(parameterName));
            }
        }
    }
}
