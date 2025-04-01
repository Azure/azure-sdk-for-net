// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HDInsight.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HDInsight.Tests
{
    public class HDInsightManagementTestCluster : HDInsightManagementTestBase
    {
        protected HDInsightManagementTestCluster(bool isAsync) : base(isAsync)
        {
        }

        protected HDInsightManagementTestCluster(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        //public void createCluster()
        //{
        //    CreateCommonClient();
        //}
    }
}
