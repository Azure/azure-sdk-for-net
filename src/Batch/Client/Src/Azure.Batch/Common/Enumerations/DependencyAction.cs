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

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// An action that the Batch service should take on tasks that depend on the task specifying the action.
    /// </summary>
    public enum DependencyAction
    {
        /// <summary>
        /// The dependency is satisfied. Once all of a dependent task's dependencies are satisfied, the dependent task is eligible to run. 
        /// </summary>
        Satisfy,

        /// <summary>
        /// The dependency is not satisfied. Dependent tasks will not become eligible to run. 
        /// </summary>
        Block,
    }
}
