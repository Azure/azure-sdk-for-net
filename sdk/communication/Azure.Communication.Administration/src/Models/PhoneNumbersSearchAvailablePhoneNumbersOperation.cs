// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Communication.Administration.Models;
using Azure.Core;

namespace Azure.Communication.Administration
{
    /// <summary> Creates a phone number search. </summary>
    public partial class PhoneNumbersSearchAvailablePhoneNumbersOperation
    {
        /// <summary>
        /// Initializes a new <see cref="PhoneNumbersSearchAvailablePhoneNumbersOperation"/> instance
        /// </summary>
        /// <param name="client"></param>
        /// <param name="id"></param>
        public PhoneNumbersSearchAvailablePhoneNumbersOperation(PhoneNumbersClient client,
            string id) : this(client.ClientDiagnostics, client.HttpPipeline, null, null)
        {
            Id = id;
        }

        /// <inheritdoc />
        public override string Id { get; }
    }
}
