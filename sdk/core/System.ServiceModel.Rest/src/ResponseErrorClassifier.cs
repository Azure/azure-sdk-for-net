// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace System.ServiceModel.Rest.Core
{
    public class ResponseErrorClassifier
    {
        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsErrorResponse(RestMessage message)
        {
            var statusKind = message.Result.Status / 100;
            return statusKind == 4 || statusKind == 5;
        }
    }
}
