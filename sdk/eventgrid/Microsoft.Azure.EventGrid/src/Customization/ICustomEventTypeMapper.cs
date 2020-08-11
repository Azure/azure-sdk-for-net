// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.EventGrid
{
    public interface ICustomEventTypeMapper
    {
        void AddOrUpdateCustomEventMapping(string eventType, Type eventDataType);

        bool TryRemoveCustomEventMapping(string eventType, out Type eventDataType);

        bool TryGetCustomEventMapping(string eventType, out Type eventDataType);

        IEnumerable<KeyValuePair<string, Type>> ListAllCustomEventMappings();
    }
}
