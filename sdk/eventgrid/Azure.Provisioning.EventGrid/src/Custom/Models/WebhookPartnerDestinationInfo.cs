// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

// TypeSpec intentionally declares ResourceMoveChangeHistory on both this derived model and its
// base type. Suppress the provisioning generator's shadowing copy so only the inherited released
// property is exposed.
[CodeGenSuppress("ResourceMoveChangeHistory")]
public partial class WebhookPartnerDestinationInfo;
