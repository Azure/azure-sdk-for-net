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
    /// The possible realationships between a client-side object and a server-side object.
    /// </summary>
    internal enum BindingState
    { 
        /// <summary>
        /// There is a consistency model between the current object and a server-side object.
        /// The client-side object is said to be "bound" to the server-side object.
        /// </summary>
        Bound = 1, 

        /// <summary>
        /// There is no server-side object.
        /// The client-side object is said to be "unbound".
        /// This is typically used to denote an object state used to "create" a server-side object
        /// </summary>
        Unbound = 2 
    };  
}
