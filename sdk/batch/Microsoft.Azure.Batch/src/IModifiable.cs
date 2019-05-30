// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch
{

    /// <summary>
    /// An interface to manage objects that can be modified.
    /// 
    /// Please use "Explicit Interface Implementation" to hide these methods on public classes.
    /// </summary>
    internal interface IModifiable
    {
        /// <summary>
        /// Returns true if the object has been modified.
        /// This is recursive through complex child properties.
        /// 
        /// Note special care must be take for "administrative" property writes as they
        /// might trigger a false positive on this test.
        /// </summary>
        /// <returns></returns>
        bool HasBeenModified { get; }
    }
}
