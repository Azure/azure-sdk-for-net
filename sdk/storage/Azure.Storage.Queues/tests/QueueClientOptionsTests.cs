// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using NUnit.Framework;

namespace Azure.Storage.Queues.Test
{
    public class QueueClientOptionsTests
    {
        [Test]
        public void TryGetServiceVersion_ParsesAllServiceVersions()
        {
            var serviceVersions = Enum.GetValues(typeof(QueueClientOptions.ServiceVersion))
                .Cast<QueueClientOptions.ServiceVersion>();

            foreach (QueueClientOptions.ServiceVersion expected in serviceVersions)
            {
                string versionString = expected.ToVersionString();

                bool parsed = QueueClientOptions.TryGetServiceVersion(versionString, out QueueClientOptions.ServiceVersion actual);

                Assert.IsTrue(parsed, $"TryGetServiceVersion failed to parse \"{versionString}\" for {expected}.");
                Assert.AreEqual(expected, actual, $"TryGetServiceVersion returned {actual} instead of {expected} for \"{versionString}\".");
            }
        }
    }
}
