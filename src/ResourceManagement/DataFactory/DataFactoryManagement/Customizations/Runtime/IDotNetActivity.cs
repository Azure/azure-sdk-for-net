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

namespace Microsoft.Azure.Management.DataFactories.Runtime
{
    /// <summary>
    /// Used to implement an activity.
    /// </summary>
    [DotNetActivityApiVersion]
    public interface IDotNetActivity
    {
        /// <summary>
        /// Called to execute an instance of the activity.
        /// </summary>
        /// <param name="inputDataSets">Input data sets defined in the activity definition.</param>
        /// <param name="outputDataSets">Output data sets defined in the activity definition.</param>
        /// <param name="extendedProperties">Extended properties defined in the activity definition.</param>
        /// <param name="logger">Used to log messages during activity execution.</param>
        /// <returns>Properties that may be passed to down-stream activites.</returns>
        IDictionary<string, string> Execute(
            IEnumerable<DataSet> inputDataSets,
            IEnumerable<DataSet> outputDataSets,
            IDictionary<string, string> extendedProperties,
            IActivityLogger logger);
    }
}
