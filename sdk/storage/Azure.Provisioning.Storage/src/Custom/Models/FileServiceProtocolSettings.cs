// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Storage;

public partial class FileServiceProtocolSettings
{
    // TypeSpec prefixes the flattened NFS property with its model name. Preserve the shorter
    // name shipped by the previous provisioning generator.
    /// <summary> Gets or sets whether NFS encryption in transit is required. </summary>
    public BicepValue<bool> IsRequired
    {
        get { return NfsEncryptionInTransitIsRequired; }
        set { NfsEncryptionInTransitIsRequired = value; }
    }
}
