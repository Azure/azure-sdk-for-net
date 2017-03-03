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
