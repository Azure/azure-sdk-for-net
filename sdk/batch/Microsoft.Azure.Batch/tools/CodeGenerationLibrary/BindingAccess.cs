// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace CodeGenerationLibrary
{
    using System;

    /// <summary>
    /// Defines the access level for a particular property.
    /// </summary>
    [Flags]
    public enum BindingAccess
    {
        None = 0,
        Read = 1,
        Write = 2
    }
}
