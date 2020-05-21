// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Data.Tables.Queryable
{
    internal static class CommonUtil
    {
        internal static bool IsClientType(Type t)
        {
            return typeof(ITableEntity).IsAssignableFrom(t);
        }
    }
}
