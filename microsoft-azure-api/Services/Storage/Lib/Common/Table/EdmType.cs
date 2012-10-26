// -----------------------------------------------------------------------------------------
// <copyright file="EdmType.cs" company="Microsoft">
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
    /// Enumeration containing the types of values that can be stored in
    /// a table entity property.
    /// </summary>
    public enum EdmType
    {
        /// <summary>
        /// Represents fixed- or variable-length character data.
        /// </summary>
        String,

        /// <summary>
        /// Represents fixed- or variable-length binary data.
        /// </summary>
        Binary,

        /// <summary>
        /// Represents the mathematical concept of binary-valued logic.
        /// </summary>
        Boolean,

        /// <summary>
        /// Represents date and time.
        /// </summary>
        DateTime,

        /// <summary>
        /// Represents a floating point number with 15 digits precision that can represent values with approximate range of +/- 2.23e -308 through +/- 1.79e +308.
        /// </summary>
        Double,

        /// <summary>
        /// Represents a 16-byte (128-bit) unique identifier value.
        /// </summary>
        Guid,

        /// <summary>
        /// Represents a signed 32-bit integer value.
        /// </summary>
        Int32,

        /// <summary>
        /// Represents a signed 64-bit integer value.
        /// </summary>
        Int64,
    }
}