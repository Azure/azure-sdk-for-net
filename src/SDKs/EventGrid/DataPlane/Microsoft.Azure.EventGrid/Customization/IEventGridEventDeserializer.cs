// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.EventGrid.Models;
using Newtonsoft.Json;
using System.IO;

namespace Microsoft.Azure.EventGrid
{
    public interface IEventGridEventDeserializer
    {
        EventGridEvent[] DeserializeEventGridEvents(string requestContent);

        EventGridEvent[] DeserializeEventGridEvents(string requestContent, JsonSerializer jsonSerializer);

        EventGridEvent[] DeserializeEventGridEvents(Stream requestStream);

        EventGridEvent[] DeserializeEventGridEvents(Stream requestStream, JsonSerializer jsonSerializer);
    }
}
