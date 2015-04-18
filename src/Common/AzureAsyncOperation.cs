// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure
{
    /// <summary>
    /// The response body contains the status of the specified
    /// asynchronous operation, indicating whether it has succeeded, is i
    /// progress, or has failed. Note that this status is distinct from the
    /// HTTP status code returned for the Get Operation Status operation
    /// itself.  If the asynchronous operation succeeded, the response body
    /// includes the HTTP status code for the successful request.  If the
    /// asynchronous operation failed, the response body includes the HTTP
    /// status code for the failed request, and also includes error
    /// information regarding the failure.
    /// </summary>
    public class AzureAsyncOperation
    {
        public static readonly string[] AzureAsyncOperationTerminalStates = { "Succeeded", "Failed", "Canceled" };

        /// <summary>
        /// The status of the asynchronous request.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// If the asynchronous operation failed, the response body includes
        /// the HTTP status code for the failed request, and also includes
        /// error information regarding the failure.
        /// </summary>
        public CloudError Error { get; set; }

        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken statusValue = inputObject["status"];
                if (statusValue != null && statusValue.Type != JTokenType.Null)
                {
                    this.Status = ((string)statusValue);
                }
                JToken errorValue = inputObject["error"];
                if (errorValue != null && errorValue.Type != JTokenType.Null)
                {
                    this.Error = new CloudError();
                    this.Error.DeserializeJson(errorValue);
                }
            }
        }
    }
}
