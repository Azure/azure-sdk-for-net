// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Sql.Models;

namespace Sql.Tests
{
    public static class SqlTestConstants
    {
        // Default database collation
        public const string DefaultCollation = "SQL_Latin1_General_CP1_CI_AS";

        // Default database edition
        public static readonly string DefaultDatabaseEdition = "Basic";

        public static Sku DefaultDatabaseSku()
        {
            return new Sku(ServiceObjectiveName.Basic);
        }

        public static Sku DefaultDataWarehouseSku()
        {
            return new Sku(ServiceObjectiveName.DW100);
        }
    }
}
