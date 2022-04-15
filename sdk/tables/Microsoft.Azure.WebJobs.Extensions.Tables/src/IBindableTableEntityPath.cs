// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal interface IBindableTableEntityPath : IBindablePath<TableEntityPath>
    {
        string TableNamePattern { get; }
        string PartitionKeyPattern { get; }
        string RowKeyPattern { get; }
    }
}