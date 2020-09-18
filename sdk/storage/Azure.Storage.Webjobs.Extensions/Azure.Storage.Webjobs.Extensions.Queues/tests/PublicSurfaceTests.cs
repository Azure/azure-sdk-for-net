// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests
{
    /// <summary>
    /// These tests help maintain our public surface area + dependencies. They will
    /// fail any time new dependencies or public surface area are added, ensuring
    /// we review such additions carefully.
    /// </summary>
    public class PublicSurfaceTests
    {
        [Fact]
        public void WebJobs_Extensions_Storage_VerifyAssemblyReferences()
        {
            var names = TestHelpers.GetAssemblyReferences(typeof(QueueTriggerAttribute).Assembly)
                .OrderBy(n => n);

            var expectedReferences = new string[]
            {
                "Azure.Core",
                "Azure.Storage.Queues",
                "Azure.Storage.Blobs",
                "Azure.WebJobs.Extensions.Storage.Common",
                "Microsoft.Azure.WebJobs",
                "Microsoft.Azure.WebJobs.Host",
                "Microsoft.Extensions.DependencyInjection.Abstractions",
                "Microsoft.Extensions.Hosting.Abstractions",
                "Microsoft.Extensions.Logging.Abstractions",
                "Microsoft.Extensions.Options",
                "netstandard",
                "Newtonsoft.Json"
            }.OrderBy(n => n);

            var namesString = string.Concat(names.Select(n => n.ToString() + ","));
            var expectedReferencesString = string.Concat(expectedReferences.Select(n => n.ToString() + ","));
            Assert.Equal(expectedReferencesString, namesString);
        }

        [Fact]
        public void WebJobs_Extensions_Storage_VerifyPublicSurfaceArea()
        {
            var assembly = typeof(QueueTriggerAttribute).Assembly;

            var expected = new[]
            {
                "QueueAttribute",
                "QueueParameterDescriptor",
                "QueueTriggerAttribute",
                "QueueTriggerParameterDescriptor",
                "StorageQueuesWebJobsBuilderExtensions"
            };

            TestHelpers.AssertPublicTypes(expected, assembly);
        }
    }
}
