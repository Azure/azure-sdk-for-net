// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
