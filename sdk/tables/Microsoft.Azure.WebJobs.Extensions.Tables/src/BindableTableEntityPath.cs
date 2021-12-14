// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Bindings.Path;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal static class BindableTableEntityPath
    {
        public static IBindableTableEntityPath Create(string tableNamePattern, string partitionKeyPattern,
            string rowKeyPattern)
        {
            BindingTemplate tableNameTemplate = BindingTemplate.FromString(tableNamePattern);
            BindingTemplate partitionKeyTemplate = BindingTemplate.FromString(partitionKeyPattern);
            BindingTemplate rowKeyTemplate = BindingTemplate.FromString(rowKeyPattern);
            if (tableNameTemplate.HasParameters ||
                partitionKeyTemplate.HasParameters ||
                rowKeyTemplate.HasParameters)
            {
                return new ParameterizedTableEntityPath(tableNameTemplate, partitionKeyTemplate, rowKeyTemplate);
            }

            TableClient.ValidateAzureTableName(tableNamePattern);
            TableClient.ValidateAzureTableKeyValue(partitionKeyPattern);
            TableClient.ValidateAzureTableKeyValue(rowKeyPattern);
            TableEntityPath innerPath = new TableEntityPath(tableNamePattern, partitionKeyPattern, rowKeyPattern);
            return new BoundTableEntityPath(innerPath);
        }
    }
}