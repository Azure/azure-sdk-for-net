// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    internal class CallLocatorSerializer
    {
        internal static CallLocatorInternal Serialize(CallLocator identifier)
            => identifier switch
            {
                ServerCallLocator serverCallLocator => new CallLocatorInternal
                {
                    ServerCallId = serverCallLocator.Id,
                    Kind = CallLocatorKindInternal.ServerCallLocator,
                },
                GroupCallLocator groupCallLocator => new CallLocatorInternal
                {
                    GroupCallId = groupCallLocator.Id,
                    Kind = CallLocatorKindInternal.GroupCallLocator,
                },
                RoomCallLocator roomCallLocator => new CallLocatorInternal
                {
                    RoomId = roomCallLocator.Id,
                    Kind = CallLocatorKindInternal.RoomCallLocator,
                },
                _ => throw new NotSupportedException(),
            };

        public static CallLocator Deserialize(CallLocatorInternal identifier)
        {
            if (!identifier.Kind.HasValue)
            {
                throw new JsonException("No type present in CallLocatorModel");
            }

            if (identifier.Kind.Value == CallLocatorKindInternal.ServerCallLocator)
                return new ServerCallLocator(AssertNotNull(identifier.ServerCallId, nameof(identifier.ServerCallId), nameof(identifier.ServerCallId)));

            if (identifier.Kind.Value == CallLocatorKindInternal.GroupCallLocator)
                return new GroupCallLocator(AssertNotNull(identifier.GroupCallId, nameof(identifier.GroupCallId), nameof(identifier.GroupCallId)));

            if (identifier.Kind.Value == CallLocatorKindInternal.RoomCallLocator)
                return new RoomCallLocator(AssertNotNull(identifier.RoomId, nameof(identifier.RoomId), nameof(identifier.RoomId)));

            throw new JsonException("Unknown type present in CallLocatorModel");
        }

        private static T AssertNotNull<T>(T value, string name, string type) where T : class
            => value ?? throw new JsonException($"Property '{name}' is required for identifier of type `{type}`.");
    }
}
