// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Azure.Tests.Common
{
    public class NetworkTestHelperBase
    {
        public NetworkTestHelperBase(string testId)
        {
            this.TEST_ID = testId;
            PIP_NAMES = new[] { "pipa" + TEST_ID, "pipb" + TEST_ID };
            GROUP_NAME = "rg" + TEST_ID;
        }

        public Region REGION = Region.US_WEST;

        public string TEST_ID { get; private set; }

        public string GROUP_NAME { get; private set; }


        public string[] PIP_NAMES { get; private set; }
    }
}
