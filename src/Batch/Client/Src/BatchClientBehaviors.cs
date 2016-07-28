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

﻿namespace Microsoft.Azure.Batch
{
    using Common;

    /// <summary>
    /// Derived classes modify operational behaviors of a Azure Batch Service client.  Derived classes can be called out of order and simultaneously by several threads.  Implementations should be threadsafe.
    /// </summary>
    public abstract class BatchClientBehavior
    {
    }
}
