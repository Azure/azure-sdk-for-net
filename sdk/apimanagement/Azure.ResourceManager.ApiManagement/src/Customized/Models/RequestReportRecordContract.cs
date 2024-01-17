// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Net;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> Request Report data. </summary>
    public partial class RequestReportRecordContract
    {
        /// <summary> The HTTP status code received by the gateway as a result of forwarding this request to the backend. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by BackendResponseCodeInteger", false)]
        public string BackendResponseCode => BackendResponseCodeInteger.ToString();
    }
}
