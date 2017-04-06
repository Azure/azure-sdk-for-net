// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
