// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.Email
{
    /// <summary> Model factory for models. </summary>
    [CodeGenModel("EmailModelFactory")]
    public static partial class EmailModelFactory
    {
        /// <summary>
        /// Initializes a new instance of EmailSendResult
        /// </summary>
        /// <param name="id">OperationId of an email send operation.</param>
        /// <param name="status">Status of the email send operation.</param>
        /// <param name="error">Error details when status is a non-success terminal state.</param>
        /// <returns></returns>
        public static EmailSendResult EmailSendResult(string id = default, EmailSendStatus status = default, ErrorDetail error = default )
        {
            return new EmailSendResult(id, status, error);
        }
    }
}
