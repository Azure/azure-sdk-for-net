// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage
{
    // TODO: Consider making public if there's ever a reason for developers to use this type
    [Obsolete("This type is only available for backwards compatibility with the 12.0.0 version of Storage libraries. It should not be used for new development.", true)]
    internal sealed class SharedAccessSignatureCredentials
    {
        /// <summary>
        /// Gets the SAS token used to authenticate requests to the Storage
        /// service.
        /// </summary>
        public string SasToken { get; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SharedAccessSignatureCredentials"/> class.
        /// </summary>
        /// <param name="sasToken">
        /// The SAS token used to authenticate requests to the Storage service.
        /// </param>
        public SharedAccessSignatureCredentials(string sasToken) =>
            SasToken = sasToken;
    }
}
