// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // identity-aliased Azure.Core.Expressions.DataFactory model types can be omitted from generated
    // model surfaces. This partial restores the GA API surface for compatibility.
    // TODO: remove once the generator preserves members whose types use @@alternateType identity (#59298).
    public partial class PrestoLinkedService
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactorySecret Password { get; set; }

        /// <summary> Back-compat constructor restoring the previously published 4-arg shape (with required serverVersion). </summary>
        /// <param name="host"> The IP address or host name of the Presto server. </param>
        /// <param name="serverVersion"> The version of the Presto server. </param>
        /// <param name="catalog"> The catalog context for all request against the server. </param>
        /// <param name="authenticationType"> The authentication mechanism used to connect to the Presto server. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PrestoLinkedService(DataFactoryElement<string> host, DataFactoryElement<string> serverVersion, DataFactoryElement<string> catalog, PrestoAuthenticationType authenticationType)
            : this(host, catalog, authenticationType)
        {
            ServerVersion = serverVersion;
        }
    }
}
