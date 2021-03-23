// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Data.Tables
{
    /// <summary>
    /// Create exceptions for common error cases.
    /// </summary>
    internal partial class Errors
    {
        public static ArgumentNullException ArgumentNull(string paramName)
            => new ArgumentNullException(paramName);

        public static ArgumentOutOfRangeException InvalidSasProtocol(string protocol, string sasProtocol)
            => new ArgumentOutOfRangeException(protocol, $"Invalid {sasProtocol} value");
        public static ArgumentException InvalidResourceType(char s)
            => new ArgumentException($"Invalid resource type: '{s}'");

        public static InvalidOperationException SasMissingData(string paramName)
            => new InvalidOperationException($"SAS is missing required parameter: {paramName}");
    }
}
