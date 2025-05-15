// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;

namespace Azure.AI.Agents.Persistent;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * This change allows us to complete the customization of hiding an unnecessary "Object" discriminator.
 */
public partial class PersistentAgent
{
    internal string Object { get; }
}
