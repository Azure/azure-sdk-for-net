using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
