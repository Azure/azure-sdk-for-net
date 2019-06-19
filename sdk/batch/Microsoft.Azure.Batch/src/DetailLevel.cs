// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using System;

namespace Microsoft.Azure.Batch
{
    /// <summary>
    /// Controls the amount of detail requested from the Azure Batch service when listing or
    /// retrieving resources.
    /// </summary>
    /// <remarks>The only supported implementation of DetailLevel is <see cref="ODATADetailLevel"/>.
    /// Other implementations are ignored.</remarks>
    public abstract class DetailLevel
    {
    }
}
