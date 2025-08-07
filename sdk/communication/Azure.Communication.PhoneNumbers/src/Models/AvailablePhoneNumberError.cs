// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenSuppress("Code", typeof(string))]
    [CodeGenSuppress("Message", typeof(string))]
    [CodeGenSuppress("AvailablePhoneNumberError")]
    [CodeGenSuppress("AvailablePhoneNumberError", typeof(string), typeof(string))]
    internal partial class AvailablePhoneNumberError
    {
        internal AvailablePhoneNumberError(string code, string message)
        {
            // Intentional no-op to prevent failures with the generated client.
            // TODO: Find a way to fully suppress this type.
        }
    }
}
