// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Compute.BulkActions.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.BulkActions.Tests
{
    public class ExecuteContentTests
    {
        [TestCase(typeof(ExecuteStartContent))]
        [TestCase(typeof(ExecuteDeallocateContent))]
        [TestCase(typeof(ExecuteDeleteContent))]
        [TestCase(typeof(ExecuteHibernateContent))]
        public void ConstructorInitializesRequiredProperties(Type contentType)
        {
            var executionParameters = new BulkActionExecutionParameterDetail();
            var resources = new UserRequestResources(Array.Empty<ResourceIdentifier>());
            var content = contentType.GetConstructor(new[] { typeof(BulkActionExecutionParameterDetail), typeof(UserRequestResources) })
                .Invoke(new object[] { executionParameters, resources });

            Assert.That(contentType.GetProperty("ExecutionParameters").GetValue(content), Is.SameAs(executionParameters));
            Assert.That(contentType.GetProperty("Resources").GetValue(content), Is.SameAs(resources));
        }

        [TestCase(typeof(ExecuteStartContent), true)]
        [TestCase(typeof(ExecuteStartContent), false)]
        [TestCase(typeof(ExecuteDeallocateContent), true)]
        [TestCase(typeof(ExecuteDeallocateContent), false)]
        [TestCase(typeof(ExecuteDeleteContent), true)]
        [TestCase(typeof(ExecuteDeleteContent), false)]
        [TestCase(typeof(ExecuteHibernateContent), true)]
        [TestCase(typeof(ExecuteHibernateContent), false)]
        public void ConstructorRejectsNullRequiredParameters(Type contentType, bool nullExecutionParameters)
        {
            var constructor = contentType.GetConstructor(new[] { typeof(BulkActionExecutionParameterDetail), typeof(UserRequestResources) });
            var executionParameters = nullExecutionParameters ? null : new BulkActionExecutionParameterDetail();
            var resources = nullExecutionParameters ? new UserRequestResources(Array.Empty<ResourceIdentifier>()) : null;

            var exception = Assert.Throws<System.Reflection.TargetInvocationException>(() =>
                constructor.Invoke(new object[] { executionParameters, resources }));

            Assert.That(exception.InnerException, Is.TypeOf<ArgumentNullException>());
            Assert.That(((ArgumentNullException)exception.InnerException).ParamName,
                Is.EqualTo(nullExecutionParameters ? "executionParameters" : "resources"));
        }
    }
}
