// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

// The generated derived model redeclares ResourceMoveChangeHistory on the same wire path as the
// inherited property. Suppress the shadowing copy and preserve the single released base property.
[CodeGenSuppress("ResourceMoveChangeHistory")]
public partial class WebhookPartnerDestinationInfo;
