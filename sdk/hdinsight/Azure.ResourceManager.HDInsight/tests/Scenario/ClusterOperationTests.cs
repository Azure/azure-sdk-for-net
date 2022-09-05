// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HDInsight.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HDInsight.Tests.Scenario
{
    internal class ClusterOperationTests : HDInsightManagementTestBase
    {
        private HDInsightClusterResource _cluster;
        private HDInsightApplicationCollection _applicationCollection => _cluster.GetHDInsightApplications();

        public ClusterOperationTests(bool isAsync) : base(isAsync)
        {
        }
    }
}
