// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// <see href="https://docs.microsoft.com/azure/digital-twins/concepts-models#schema">Data types</see>in the ADT query language.
    /// </summary>
    public enum DigitalTwinsDataType
    {
        /// <summary>
        /// Boolean type in the ADT query language.
        /// </summary>
        DigitalTwinsBool,

        /// <summary>
        /// Numeric type in the ADT query language.
        /// </summary>
        DigitalTwinsNumber,

        /// <summary>
        /// String in the ADT query language.
        /// </summary>
        DigitalTwinsString,

        /// <summary>
        /// Primitive type (string, numeric, boolean, or null) in the ADT query language.
        /// </summary>
        DigitalTwinsPrimative,

        /// <summary>
        /// Object in the ADT query language.
        /// </summary>
        DigitalTwinsObject
    }
}
