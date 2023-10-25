// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Azure.Data.Tables;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    // Functions for working with azure tables.
    // See http://msdn.microsoft.com/en-us/library/windowsazure/dd179338.aspx
    //
    // Naming rules:
    // RowKey  - no \,/, #, ?, less than 1 kb in size
    // Table name is restrictive, must match: "^[A-Za-z][A-Za-z0-9]{2,62}$"
    internal static class TableClientHelpers
    {
        private static readonly char[] InvalidKeyValueCharacters = GetInvalidTableKeyValueCharacters();

        public static string GetAccountName(TableServiceClient client)
        {
            return client?.AccountName;
        }

        // http://msdn.microsoft.com/en-us/library/windowsazure/dd179338.aspx
        private static char[] GetInvalidTableKeyValueCharacters()
        {
            List<char> invalidCharacters = new List<char>(new char[] { '/', '\\', '#', '?' });
            // U+0000 through U+001F, inclusive
            for (char invalidCharacter = '\x0000'; invalidCharacter <= '\x001F'; invalidCharacter++)
            {
                invalidCharacters.Add(invalidCharacter);
            }

            // U+007F through U+009F, inclusive
            for (char invalidCharacter = '\x007F'; invalidCharacter <= '\x009F'; invalidCharacter++)
            {
                invalidCharacters.Add(invalidCharacter);
            }

            return invalidCharacters.ToArray();
        }
        public static void VerifyDefaultConstructor(Type entityType)
        {
            if (!entityType.IsValueType && entityType.GetConstructor(Type.EmptyTypes) == null)
            {
                throw new InvalidOperationException("Table entity types must provide a default constructor.");
            }
        }

        public static void VerifyContainsProperty(Type entityType, string propertyName)
        {
            if (entityType.GetProperty(propertyName) == null)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, "Table entity types must implement the property {0}.", propertyName));
            }
        }

        // Azure table names are very restrictive, so sanity check upfront to give a useful error.
        // http://msdn.microsoft.com/en-us/library/windowsazure/dd179338.aspx
        public static void ValidateAzureTableName(string tableName)
        {
            if (!IsValidAzureTableName(tableName))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "'{0}' is not a valid name for an Azure table", tableName));
            }
        }

        public static bool IsValidAzureTableName(string tableName)
        {
            // Table Name Rules are summerized in this page https://msdn.microsoft.com/en-us/library/azure/dd179338.aspx
            // Table names may contain only alphanumeric characters, can not start with a numeric character and must be
            // 3 to 63 characters long
            return Regex.IsMatch(tableName, "^[A-Za-z][A-Za-z0-9]{2,62}$");
        }

        // Azure table partition key and row key values are restrictive, so sanity check upfront to give a useful error.
        public static void ValidateAzureTableKeyValue(string value)
        {
            if (!IsValidAzureTableKeyValue(value))
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture,
                    "'{0}' is not a valid value for a partition key or row key. " +
                    "Ensure that the table entity contains valid 'PartitionKey' and 'RowKey' values.", value));
            }
        }

        public static bool IsValidAzureTableKeyValue(string value)
        {
            // Empty strings and whitespace are valid partition keys and row keys, but null is invalid.
            if (value == null)
            {
                return false;
            }

            return value.IndexOfAny(InvalidKeyValueCharacters) == -1;
        }
    }
}