// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
