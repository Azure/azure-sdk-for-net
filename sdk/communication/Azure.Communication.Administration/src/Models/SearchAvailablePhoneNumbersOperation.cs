// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Administration
{
    [CodeGenModel("PhoneNumbersSearchAvailablePhoneNumbersOperation")]
    public partial class SearchAvailablePhoneNumbersOperation
    {
        ///// <summary>
        ///// Initializes a new <see cref="PhoneNumbersSearchAvailablePhoneNumbersOperation"/> instance
        ///// </summary>
        ///// <param name="client"></param>
        ///// <param name="id"></param>
        //public PhoneNumbersSearchAvailablePhoneNumbersOperation(PhoneNumbersClient client, string id)
        //{
        //    Id = id;

        //    _operation = new ArmOperationHelpers<PhoneNumberSearchResult>(this, client.ClientDiagnostics, client.HttpPipeline, request, response, OperationFinalStateVia.Location, "PhoneNumbersSearchAvailablePhoneNumbersOperation");

        //}

        /// <inheritdoc />
        public override string Id { get; }
    }
}
