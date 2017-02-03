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

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Management.DataLake.Store
{
    /// <summary>
    /// Defines various states that a segment transfer can have
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]    
    public enum SegmentTransferStatus
    {

        /// <summary>
        /// Indicates that the segment is currently scheduled for transfer.
        /// </summary>
        [EnumMember(Value = "Pending")]
        Pending = 0,

        /// <summary>
        /// Indicates that the segment is currently being transferred.
        /// </summary>
        [EnumMember(Value = "InProgress")]
        InProgress = 1,

        /// <summary>
        /// Indicates that the segment was not transferred successfully.
        /// </summary>
        [EnumMember(Value = "Failed")]
        Failed = 2,

        /// <summary>
        /// Indicates that the segment was successfully transferred.
        /// </summary>
        [EnumMember(Value = "Complete")]
        Complete = 3
    }
}
