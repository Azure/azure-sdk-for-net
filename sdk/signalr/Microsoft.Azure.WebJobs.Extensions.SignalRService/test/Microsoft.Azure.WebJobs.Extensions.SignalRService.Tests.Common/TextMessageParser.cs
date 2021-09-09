// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Buffers;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Common
{
    /// <summary>
    /// The same as https://github.com/aspnet/SignalR/blob/release/2.2/src/Common/TextMessageParser.cs
    /// </summary>
    public static class TextMessageParser
    {
        public static readonly byte RecordSeparator = 0x1e;

        public static bool TryParseMessage(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> payload)
        {
            var position = buffer.PositionOf(RecordSeparator);
            if (position == null)
            {
                payload = default;
                return false;
            }

            payload = buffer.Slice(0, position.Value);

            // Skip record separator
            buffer = buffer.Slice(buffer.GetPosition(1, position.Value));

            return true;
        }
    }
}