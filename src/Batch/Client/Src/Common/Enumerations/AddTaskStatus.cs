// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The status of an individual task in an add task collection operation.
    /// </summary>
    public enum AddTaskStatus
    {
        /// <summary>
        /// The task addition was successful.
        /// </summary>
        Success,

        /// <summary>
        /// The task addition failed due to user error.
        /// </summary>
        ClientError,

        /// <summary>
        /// The task addition failed due to an unforseen server error.
        /// </summary>
        ServerError,

        /// <summary>
        /// The service reported an option that is not recognized by this
        /// version of the Batch client.
        /// </summary>
        Unmapped
    }
}
