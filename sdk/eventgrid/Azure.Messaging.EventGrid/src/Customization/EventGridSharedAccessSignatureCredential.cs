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
    public class EventGridSharedAccessSignatureCredential
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridSharedAccessSignatureCredential"/> class.
        /// </summary>
        /// <param name="signature">SAS token used for authentication</param>
        public EventGridSharedAccessSignatureCredential(string signature)
        {
            Signature = signature;
        }
        /// <summary>
        /// SAS token used to authenticate to the Event Grid service.
        /// </summary>
        public string Signature { get; private set; }

        /// <summary>
        /// Updates the SAS token. This is intended to be used when you've regenerated the token and want to update long lived clients.
        /// </summary>
        /// <param name="signature">SAS token used for authentication</param>
        public void Update(string signature)
        {
            Signature = signature;
        }
    }
}
