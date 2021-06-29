// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// <see href="https://docs.microsoft.com/en-us/azure/digital-twins/concepts-models#schema">Data types</see> in the ADT query language.
    /// </summary>
    public enum AdtDataType
    {
        /// <summary>
        /// Boolean type in the ADT query language.
        /// </summary>
        AdtBool,

        /// <summary>
        /// Numeric type in the ADT query language.
        /// </summary>
        AdtNumber,

        /// <summary>
        /// String in the ADT query language.
        /// </summary>
        AdtString,

        /// <summary>
        /// Primative type (string, numeric, boolean, or null) in the ADT query language.
        /// </summary>
        AdtPrimative,

        /// <summary>
        /// Object in the ADT query language.
        /// </summary>
        AdtObject
    }
}
