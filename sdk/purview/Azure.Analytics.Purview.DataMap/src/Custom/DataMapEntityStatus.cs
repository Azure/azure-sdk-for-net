// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Analytics.Purview.DataMap;

/// <summary>
/// Renames the generated <c>EntityStatus</c> model to <see cref="DataMapEntityStatus"/> to avoid an
/// AZC0034 collision with <c>Azure.Messaging.ServiceBus.Administration.EntityStatus</c>.
/// </summary>
[CodeGenType("EntityStatus")]
public readonly partial struct DataMapEntityStatus { }
