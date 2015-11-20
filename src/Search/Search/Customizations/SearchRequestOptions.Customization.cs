// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Additional parameters for the Count operation.
    /// </summary>
    public partial class SearchRequestOptions
    {
        private Guid? _requestId;

        /// <summary>
        /// Initializes a new instance of the SearchRequestOptions class.
        /// </summary>
        public SearchRequestOptions(Guid? requestId = default(Guid?))
        {
            RequestId = requestId;
        }

        /// <summary>
        /// Tracking ID sent with the request to help with debugging.
        /// </summary>
        [JsonIgnore]
        public Guid? RequestId
        {
            get
            {
                return this._requestId;
            }

            set
            {
                this._requestId = value;
                this.ClientRequestId = this._requestId.HasValue ? this._requestId.Value.ToString() : null;
            }
        }
    }
}
