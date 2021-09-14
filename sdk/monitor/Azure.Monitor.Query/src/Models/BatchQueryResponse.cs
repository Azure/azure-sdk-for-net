// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    internal partial class BatchQueryResponse
    {
        /// <summary> Contains the tables, columns &amp; rows resulting from the query or the error details if the query failed. </summary>
        [CodeGenMember("Body")]
        private readonly LogsBatchQueryResult _body;

        public LogsBatchQueryResult Body
        {
            get
            {
                _body.Status = Status switch
                {
                    >= 400 => LogsBatchQueryResultStatus.Failure,
                    _ when _body.Error != null => LogsBatchQueryResultStatus.PartialFailure,
                    _ => LogsBatchQueryResultStatus.Success
                };
                _body.Id = Id;
                return _body;
            }
        }
    }
}