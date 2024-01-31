// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("PhoneNumbersClient")]
    [CodeGenSuppress("GetOperationAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperation", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CancelOperationAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CancelOperation", typeof(string), typeof(CancellationToken))]
    internal partial class InternalPhoneNumbersClient
    {
    }
}
