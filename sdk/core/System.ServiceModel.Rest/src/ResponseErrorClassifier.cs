// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest.Core
{
    /// <summary>
    /// TBD.
    /// </summary>
    public class ResponseErrorClassifier
    {
        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsErrorResponse(PipelineMessage message)
        {
            int statusKind = message.Response.Status / 100;
            return statusKind == 4 || statusKind == 5;
        }
    }
}
