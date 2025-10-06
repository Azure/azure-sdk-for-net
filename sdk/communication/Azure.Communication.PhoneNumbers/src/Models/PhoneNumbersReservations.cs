// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("PhoneNumbersReservations")]
    [CodeGenSuppress("PhoneNumbersReservations", typeof(IEnumerable<PhoneNumbersReservation>))]
    [CodeGenSuppress("PhoneNumbersReservations", typeof(IReadOnlyList<PhoneNumbersReservation>), typeof(string))]
    [CodeGenSuppress("Reservations", typeof(IReadOnlyList<PhoneNumberAreaCode>))]
    [CodeGenSuppress("NextLink", typeof(string))]
    [CodeGenSuppress("DeserializePhoneNumbersReservations", typeof(JsonElement))]
    [CodeGenSuppress("FromResponse", typeof(Response))]
    internal partial class PhoneNumbersReservations
    {
    }
}
