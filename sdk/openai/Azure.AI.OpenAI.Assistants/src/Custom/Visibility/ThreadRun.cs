// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI.Assistants;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * This change allows us to complete the customization of hiding an unnecessary "Object" discriminator.
 */

public partial class ThreadRun
{
    internal string Object { get; }
}
