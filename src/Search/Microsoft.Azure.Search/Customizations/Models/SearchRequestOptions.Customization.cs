// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class SearchRequestOptions
    {
        /// <summary>
        /// Tracking ID sent with the request to help with debugging.
        /// </summary>
        /// <remarks>
        /// This property is deprecated. Please use ClientRequestId instead.
        /// </remarks>
        [JsonIgnore]
        [Obsolete("This property is deprecated. Please use ClientRequestId instead.")]
        public Guid? RequestId
        {
            get
            {
                return this.ClientRequestId;
            }

            set
            {
                this.ClientRequestId = value;
            }
        }
    }
}
