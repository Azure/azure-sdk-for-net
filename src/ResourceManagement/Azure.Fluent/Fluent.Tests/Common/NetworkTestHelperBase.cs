// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Azure.Tests.Common
{
    public class NetworkTestHelperBase
    {
        public NetworkTestHelperBase(string testId)
        {
            this.TestId = testId;
            PipNames = new[] { "pipa" + TestId, "pipb" + TestId };
            GroupName = "rg" + TestId;
        }

        public Region Region = Region.USEast;

        public string TestId { get; private set; }

        public string GroupName { get; private set; }


        public string[] PipNames { get; private set; }
    }
}
