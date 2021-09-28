// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Communication.CallingServer
{
    internal class CallLocatorModelSerializer
    {
        internal static CallLocatorModel Serialize(CallLocator identifier)
            => identifier switch
            {
                ServerCallLocator serverCallLocator => new CallLocatorModel
                {
                    ServerCallLocator = new ServerCallLocatorModel(serverCallLocator.Id),
                },
                GroupCallLocator groupCallLocator => new CallLocatorModel
                {
                    GroupCallLocator = new GroupCallLocatorModel(groupCallLocator.Id),
                },
                _ => throw new NotSupportedException(),
            };

        public static CallLocator Deserialize(CallLocatorModel identifier)
        {
            AssertMaximumOneNestedModel(identifier);

            if (identifier.ServerCallLocator is ServerCallLocatorModel serverCallLocator)
                return new ServerCallLocator(AssertNotNull(serverCallLocator.ServerCallId, nameof(serverCallLocator.ServerCallId), nameof(ServerCallLocatorModel)));

            if (identifier.GroupCallLocator is GroupCallLocatorModel groupCallLocator)
                return new GroupCallLocator(AssertNotNull(groupCallLocator.GroupId, nameof(groupCallLocator.GroupId), nameof(GroupCallLocatorModel)));

            throw new JsonException("Unknown type present in CallLocatorModel");
        }

        private static void AssertMaximumOneNestedModel(CallLocatorModel identifier)
        {
            List<string> presentProperties = new List<string>();
            if (identifier.ServerCallLocator is not null)
                presentProperties.Add(nameof(identifier.ServerCallLocator));
            if (identifier.GroupCallLocator is not null)
                presentProperties.Add(nameof(identifier.GroupCallLocator));

            if (presentProperties.Count > 1)
                throw new JsonException($"Only one of the properties in {{{string.Join(", ", presentProperties)}}} should be present.");
        }

        private static T AssertNotNull<T>(T value, string name, string type) where T : class
            => value ?? throw new JsonException($"Property '{name}' is required for identifier of type `{type}`.");

        private static T AssertNotNull<T>(T? value, string name, string type) where T : struct
        {
            if (value is null)
                throw new JsonException($"Property '{name}' is required for identifier of type `{type}`.");

            return value.Value;
        }
    }
}
