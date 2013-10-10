//-----------------------------------------------------------------------
// <copyright file="StorageEventSource.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core
{
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Diagnostics.Tracing;

    [EventSource(Name = Constants.LogSourceName)]
    internal class StorageEventSource : EventSource
    {
        internal StorageEventSource()
        {
        }

        [Event(1, Level = EventLevel.Error)]
        internal void Error(string message)
        {
            this.WriteEvent(1, message);
        }

        [Event(2, Level = EventLevel.Warning)]
        internal void Warning(string message)
        {
            this.WriteEvent(2, message);
        }

        [Event(3, Level = EventLevel.Informational)]
        internal void Informational(string message)
        {
            this.WriteEvent(3, message);
        }

        [Event(4, Level = EventLevel.Verbose)]
        internal void Verbose(string message)
        {
            this.WriteEvent(4, message);
        }
    }
}
