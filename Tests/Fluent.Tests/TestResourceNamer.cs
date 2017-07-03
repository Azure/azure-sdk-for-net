// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System.Reflection;

namespace Azure.Tests
{
    public class TestResourceNamer : ResourceNamer
    {
        private AssetNames assetNames;
        private string testName;

        public TestResourceNamer(string name, string methodName) : base(name)
        {
            var namesField = typeof(HttpMockServer).GetField("names", BindingFlags.NonPublic | BindingFlags.Static);
            assetNames = ((AssetNames)namesField.GetValue(null));
            this.testName = methodName;
        }

        public override string RandomName(string prefix, int maxLen)
        {
            lock (assetNames)
            {
                if (HttpMockServer.Mode == HttpRecorderMode.Playback)
                {
                    return assetNames[testName].Dequeue();
                }

                var randomName = base.RandomName(prefix, maxLen);

                assetNames.Enqueue(testName, randomName);

                return randomName;
            }
        }

        public override string RandomGuid()
        {
            lock (assetNames)
            {
                if (HttpMockServer.Mode == HttpRecorderMode.Playback)
                {
                    return assetNames[testName].Dequeue();
                }

                var randomName = base.RandomGuid();

                assetNames.Enqueue(testName, randomName);

                return randomName;
            }
        }
    }
}
