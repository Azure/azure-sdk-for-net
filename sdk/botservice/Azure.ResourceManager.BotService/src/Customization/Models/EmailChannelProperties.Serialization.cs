// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.BotService.Models
{
    [CodeGenSerialization(nameof(AuthMethod), SerializationValueHook = nameof(WriteAuthMethod))]
   public partial class EmailChannelProperties : IUtf8JsonSerializable, IJsonModel<EmailChannelProperties>
   {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteAuthMethod(Utf8JsonWriter writer)
        {
            writer.WriteStringValue(AuthMethod.Value.ToString());
        }
   }
}
