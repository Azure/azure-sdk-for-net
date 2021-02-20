// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Storage.Models
{
    [CodeGenModel("ManifestWrapper")]
    public partial class CombinedManifest
    {
        // This is a type that combines the properties of ManifestList, V1Manifest, V2Manifest, OCIIndex, and OCIManifest
        // TODO: explore polymorphic types here -- would it be useful for this to be replaced by a base class that each
        // of the schema-specific types could inherit from?
    }
}
