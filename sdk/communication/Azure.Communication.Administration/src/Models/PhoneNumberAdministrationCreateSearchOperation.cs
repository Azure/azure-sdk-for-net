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
    public partial class PhoneNumberAdministrationCreateSearchOperation
    {
        //public PhoneNumberAdministrationCreateSearchOperation(PhoneNumberAdministrationClient client,
        //    string id)
        //{
        //    Id = id;
        //    _operation = new ArmOperationHelpers<Response>(this, client.ClientDiagnostics, client.HttpPipeline, request, response, OperationFinalStateVia.Location, "PhoneNumberAdministrationCreateSearchOperation");
        //}

        /// <inheritdoc />
        public override string Id { get; }
    }
}
