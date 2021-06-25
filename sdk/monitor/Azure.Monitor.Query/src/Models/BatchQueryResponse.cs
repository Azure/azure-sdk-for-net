// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    internal partial class BatchQueryResponse
    {
        /// <summary> Contains the tables, columns &amp; rows resulting from the query or the error details if the query failed. </summary>
        [CodeGenMember("Body")]
        private LogsBatchQueryResult _body;

        public LogsBatchQueryResult Body
        {
            get
            {
                _body.HasFailed = Status >= 400;
                _body.Id = Id;
                return _body;
            }
        }
    }
}