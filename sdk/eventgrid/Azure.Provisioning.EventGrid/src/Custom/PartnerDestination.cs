// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.Provisioning.EventGrid;

// TypeSpec now generates the complete resource. Preserve the released visibility because this
// resource was removed from preview before Azure.Provisioning.EventGrid 1.1.0 shipped.
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class PartnerDestination
{
}
