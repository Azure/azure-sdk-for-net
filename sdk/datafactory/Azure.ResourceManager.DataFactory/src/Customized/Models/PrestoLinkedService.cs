// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization added as a workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298
// The TypeSpec @@alternateType identity-aliasing on SecretBase / LinkedServiceReference / SecureString
// causes properties whose type is one of those externally-aliased models to be silently dropped during
// code generation. This partial restores the public API surface so that downstream consumers continue
// to compile. Wire serialization for the restored members is NOT preserved here (the generator fix in
// https://github.com/Azure/azure-sdk-for-net/issues/59298 is required for full round-trip).

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
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
