// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Data.Tables.Models
{
    [CodeGenModel("DataTablesModelFactory")]
    public static partial class TableModelFactory
    {
        /// <summary> Initializes new instance of TableItem class. </summary>
        /// <param name="name"> The name of the table. </param>
        /// <param name="odataType"> The odata type of the table. </param>
        /// <param name="odataId"> The id of the table. </param>
        /// <param name="odataEditLink"> The edit link of the table. </param>
        /// <returns> A new <see cref="Models.TableItem"/> instance for mocking. </returns>
        public static TableItem TableItem(string name = default, string odataType = default, string odataId = default, string odataEditLink = default)
        {
            return new TableItem(name, odataType, odataId, odataEditLink);
        }

        /// <summary> Initializes new instance of TableServiceProperties class. </summary>
        /// <param name="logging"> Azure Analytics Logging settings. </param>
        /// <param name="hourMetrics"> A summary of request statistics grouped by API in hourly aggregates for tables. </param>
        /// <param name="minuteMetrics"> A summary of request statistics grouped by API in minute aggregates for tables. </param>
        /// <param name="cors"> The set of CORS rules. </param>
        /// <returns> A new <see cref="Models.TableServiceProperties"/> instance for mocking. </returns>
        public static TableServiceProperties TableServiceProperties(TableAnalyticsLoggingSettings logging = default, TableMetrics hourMetrics = default, TableMetrics minuteMetrics = default, IList<TableCorsRule> cors = default)
        {
            return new TableServiceProperties(logging, hourMetrics, minuteMetrics, cors);
        }
    }
}
