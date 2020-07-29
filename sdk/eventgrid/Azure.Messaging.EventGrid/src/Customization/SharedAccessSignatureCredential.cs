// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// SAS token used to authenticate to the Event Grid service.
    /// </summary>
    public class SharedAccessSignatureCredential
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharedAccessSignatureCredential"/> class.
        /// </summary>
        /// <param name="signature">SAS token used for authentication</param>
        public SharedAccessSignatureCredential(string signature)
        {
            Signature = signature;
        }
        /// <summary>
        /// SAS token used to authenticate to the Event Grid service.
        /// </summary>
        public string Signature { get; }
    }
}
