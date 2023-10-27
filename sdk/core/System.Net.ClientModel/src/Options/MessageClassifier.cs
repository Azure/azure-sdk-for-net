// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Net.ClientModel.Core
{
    public class MessageClassifier
    {
        protected internal MessageClassifier() { }

        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsErrorResponse(PipelineMessage message)
        {
            if (message.Response is null)
            {
                throw new InvalidOperationException("IsErrorResponse must be called on a message where the Result is populated.");
            }

            int statusKind = message.Response.Status / 100;
            return statusKind == 4 || statusKind == 5;
        }
    }
}
