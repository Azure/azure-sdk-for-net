// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Data types in the ADT query language.
    /// </summary>
    public enum AdtDataType
    {
        /// <summary>
        /// Boolean type in the ADT query language.
        /// </summary>
        AdtBool = 1,

        /// <summary>
        /// Numeric type in the ADT query language.
        /// </summary>
        AdtNumber = 2,

        /// <summary>
        /// String in the ADT query language.
        /// </summary>
        AdtString = 3,

        /// <summary>
        /// Primative type (string, numeric, boolean, or null) in the ADT query language.
        /// </summary>
        AdtPrimative = 4,

        /// <summary>
        /// Object in the ADT query language.
        /// </summary>
        AdtObject = 5
    }
}
