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
