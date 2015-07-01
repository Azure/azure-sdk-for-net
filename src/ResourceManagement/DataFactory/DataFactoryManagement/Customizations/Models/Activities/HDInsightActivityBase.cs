//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// HDInsight activity.
    /// </summary>
    public abstract class HDInsightActivityBase : ActivityTypeProperties
    {
        /// <summary>
        /// Storage linked services.
        /// </summary>
        public IList<string> StorageLinkedServices { get; set; }

        /// <summary>
        /// User specified arguments to HDInsightActivity.
        /// </summary>
        public IList<string> Arguments { get; set; }

        /// <summary>
        /// The <see cref="HDInsightActivityDebugInfoOption"/> settings to use.
        /// </summary>
        public string GetDebugInfo { get; set; }

        protected HDInsightActivityBase()
        {
            this.Arguments = new List<string>();
            this.StorageLinkedServices = new List<string>();
        }
    }
}
