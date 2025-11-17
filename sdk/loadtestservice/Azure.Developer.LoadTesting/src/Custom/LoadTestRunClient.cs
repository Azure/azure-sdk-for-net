// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    public partial class LoadTestRunClient
    {
        /// <summary> Initializes a new instance of LoadTestRunClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LoadTestRunClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new LoadTestingClientOptions())
        {
        }

        /// <summary> Initializes a new instance of LoadTestRunClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LoadTestRunClient(Uri endpoint, TokenCredential credential, LoadTestingClientOptions options)
            : this(endpoint?.Host, credential, options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
        }
    }
}
