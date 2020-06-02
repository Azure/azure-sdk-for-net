﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// General request options that are applicable, but optional, for many APIs.
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// A string representing a weak ETag for the entity that this request performs an operation against, as per RFC7232. The request's operation is performed
        /// only if this ETag matches the value maintained by the server, indicating that the entity has not been modified since it was last retrieved.
        /// To force the operation to execute only if the entity exists, set the ETag to the wildcard character '*'. To force the operation to execute unconditionally, leave this value null.
        /// </summary>
        public string IfMatchEtag { get; set; } = null;
    }
}
