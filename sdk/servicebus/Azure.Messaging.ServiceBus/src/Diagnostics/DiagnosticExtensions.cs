// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    internal static class DiagnosticExtensions
    {
        public static string GetAsciiString(this ArraySegment<byte> arraySegment)
        {
            return arraySegment.Array == null ? string.Empty : Encoding.ASCII.GetString(arraySegment.Array, arraySegment.Offset, arraySegment.Count);
        }
    }
}
