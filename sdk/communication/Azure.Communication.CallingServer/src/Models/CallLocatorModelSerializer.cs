// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Communication.CallingServer.Models
{
    internal class CallLocatorModelSerializer
    {
        internal static CallLocatorModel Serialize(CallLocator identifier)
            => identifier switch
            {
                ServerCallLocator serverCallLocator => new CallLocatorModel
                {
                    ServerCallId = serverCallLocator.Id,
                    Kind = CallLocatorKindModel.ServerCallLocator,
                },
                GroupCallLocator groupCallLocator => new CallLocatorModel
                {
                    GroupCallId = groupCallLocator.Id,
                    Kind = CallLocatorKindModel.GroupCallLocator,
                },
                _ => throw new NotSupportedException(),
            };

        public static CallLocator Deserialize(CallLocatorModel identifier)
        {
            if (!identifier.Kind.HasValue)
            {
                throw new JsonException("No type present in CallLocatorModel");
            }

            if (identifier.Kind.Value == CallLocatorKindModel.ServerCallLocator)
                return new ServerCallLocator(AssertNotNull(identifier.ServerCallId, nameof(identifier.ServerCallId), nameof(identifier.ServerCallId)));

            if (identifier.Kind.Value == CallLocatorKindModel.GroupCallLocator)
                return new GroupCallLocator(AssertNotNull(identifier.GroupCallId, nameof(identifier.GroupCallId), nameof(identifier.GroupCallId)));

            throw new JsonException("Unknown type present in CallLocatorModel");
        }

        private static T AssertNotNull<T>(T value, string name, string type) where T : class
            => value ?? throw new JsonException($"Property '{name}' is required for identifier of type `{type}`.");
    }
}
