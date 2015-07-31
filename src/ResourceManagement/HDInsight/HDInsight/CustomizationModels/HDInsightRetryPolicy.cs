// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using Hyak.Common;
using Hyak.Common.TransientFaultHandling;

namespace Microsoft.Azure.Management.HDInsight
{
    public partial class HDInsightManagementClient : ServiceClient<HDInsightManagementClient>, IHDInsightManagementClient
    {
        private static readonly TimeSpan MinBackOff = TimeSpan.FromMinutes(0);
        private static readonly TimeSpan MaxBackOff = TimeSpan.FromMinutes(8);
        private const int RetryCount = 5;
        private static readonly TimeSpan DeltaBackOff = TimeSpan.FromMinutes(1);

        /// <summary>
        /// Gets the recommended Retry Policy for the HDInsight Management Client.
        /// </summary>
        public static RetryPolicy HDInsightRetryPolicy
        {
            get
            {
                return new RetryPolicy(new DefaultHttpErrorDetectionStrategy(),
                    RetryCount, MinBackOff,
                    MaxBackOff, DeltaBackOff);
            }
        }
    }
}
