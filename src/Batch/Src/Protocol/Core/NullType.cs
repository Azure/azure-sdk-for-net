//-----------------------------------------------------------------------
// <copyright file="NullType.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.Azure.Batch.Protocol.Core
{
    /// <summary>
    /// A NullBatchReturn type.
    /// </summary>
    /// Make it to internal (no use so far)
    internal sealed class NullType
    {
        /// <summary>
        /// Represents a no-return from Batch.
        /// </summary>
        internal static readonly NullType Value = new NullType();

        /// <summary>
        /// Prevents a default instance of the <see cref="NullType"/> class from being created.
        /// </summary>
        private NullType()
        {
        }
    }    
}
