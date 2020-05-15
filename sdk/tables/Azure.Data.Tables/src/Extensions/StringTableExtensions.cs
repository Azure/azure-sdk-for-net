// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables
{
    internal static class StringTableExtensions
    {
        internal static string ToOdataTypeString(this string name)
        {
            return $"{name}{TableConstants.Odata.OdataTypeString}";
        }
    }
}
