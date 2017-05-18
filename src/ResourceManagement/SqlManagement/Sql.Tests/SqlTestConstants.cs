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
        public const string DefaultDatabaseEdition = DatabaseEdition.Basic;

        // Default elastic pool edition
        public const string DefaultElasticPoolEdition = ElasticPoolEdition.Basic;
    }
}
