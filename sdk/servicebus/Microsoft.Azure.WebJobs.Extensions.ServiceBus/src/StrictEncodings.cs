// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    internal static class StrictEncodings
    {
        private static UTF8Encoding _utf8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false,
            throwOnInvalidBytes: true);

        public static UTF8Encoding Utf8
        {
            get { return _utf8; }
        }
    }
}
