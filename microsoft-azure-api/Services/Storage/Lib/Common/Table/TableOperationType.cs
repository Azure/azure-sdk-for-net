// -----------------------------------------------------------------------------------------
// <copyright file="TableOperationType.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
{
    /// <summary>
    /// Enumeration containing the types of operations that can be
    /// performed by a <see cref="TableOperation" />.
    /// </summary>
    public enum TableOperationType
    {
        /// <summary>
        /// Represents an insert operation.
        /// </summary>
        Insert,
        /// <summary>
        /// Represents a delete operation.
        /// </summary>
        Delete,
        /// <summary>
        /// Represents a replace operation.
        /// </summary>
        Replace,
        /// <summary>
        /// Represents a merge operation.
        /// </summary>
        Merge,
        /// <summary>
        /// Represents an insert or replace operation.
        /// </summary>
        InsertOrReplace,
        /// <summary>
        /// Represents an insert or merge operation.
        /// </summary>
        InsertOrMerge,
        /// <summary>
        /// Represents a retrieve operation.
        /// </summary>
        Retrieve
    }
}