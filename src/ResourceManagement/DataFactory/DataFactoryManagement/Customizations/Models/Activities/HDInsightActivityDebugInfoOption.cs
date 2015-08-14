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

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// All available options on how to get the YARN logs for HDInsight activities
    /// </summary>
    public static class HDInsightActivityDebugInfoOption
    {
        /// <summary>
        /// Don't bring YARN logs
        /// </summary>
        public const string None = "None";

        /// <summary>
        /// Always bring YARN logs
        /// </summary>
        public const string Always = "Always";

        /// <summary>
        /// Bring logs only on execution failure
        /// </summary>
        public const string Failure = "Failure";
    }
}
