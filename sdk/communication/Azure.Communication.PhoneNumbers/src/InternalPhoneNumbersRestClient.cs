// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("InternalPhoneNumbersRestClient")]
    [CodeGenSuppress("ListAreaCodesAsync", typeof(string), typeof(PhoneNumberType), typeof(int?), typeof(int?), typeof(PhoneNumberAssignmentType?), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListAreaCodes", typeof(string), typeof(PhoneNumberType), typeof(int?), typeof(int?), typeof(PhoneNumberAssignmentType?), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListAvailableCountriesAsync", typeof(int?), typeof(int?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListAvailableCountries", typeof(int?), typeof(int?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListAvailableLocalitiesAsync", typeof(string), typeof(int?), typeof(int?), typeof(string), typeof(string), typeof(PhoneNumberType?), typeof(CancellationToken))]
    [CodeGenSuppress("ListAvailableLocalities", typeof(string), typeof(int?), typeof(int?), typeof(string), typeof(string), typeof(PhoneNumberType?), typeof(CancellationToken))]
    [CodeGenSuppress("ListOfferingsAsync", typeof(string), typeof(int?), typeof(int?), typeof(PhoneNumberType?), typeof(PhoneNumberAssignmentType?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListOfferings", typeof(string), typeof(int?), typeof(int?), typeof(PhoneNumberType?), typeof(PhoneNumberAssignmentType?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListPhoneNumbersAsync", typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("ListPhoneNumbers", typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("ListReservationsAsync", typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("ListReservations", typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("ListAreaCodesNextPageAsync", typeof(string), typeof(string), typeof(PhoneNumberType), typeof(int?), typeof(int?), typeof(PhoneNumberAssignmentType?), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListAreaCodesNextPage", typeof(string), typeof(string), typeof(PhoneNumberType), typeof(int?), typeof(int?), typeof(PhoneNumberAssignmentType?), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListAvailableCountriesNextPageAsync", typeof(string), typeof(int?), typeof(int?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListAvailableCountriesNextPage", typeof(string), typeof(int?), typeof(int?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListAvailableLocalitiesNextPageAsync", typeof(string), typeof(string), typeof(int?), typeof(int?), typeof(string), typeof(string), typeof(PhoneNumberType?), typeof(CancellationToken))]
    [CodeGenSuppress("ListAvailableLocalitiesNextPage", typeof(string), typeof(string), typeof(int?), typeof(int?), typeof(string), typeof(string), typeof(PhoneNumberType?), typeof(CancellationToken))]
    [CodeGenSuppress("ListOfferingsNextPageAsync", typeof(string), typeof(string), typeof(int?), typeof(int?), typeof(PhoneNumberType?), typeof(PhoneNumberAssignmentType?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListOfferingsNextPage", typeof(string), typeof(string), typeof(int?), typeof(int?), typeof(PhoneNumberType?), typeof(PhoneNumberAssignmentType?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListPhoneNumbersNextPageAsync", typeof(string), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("ListPhoneNumbersNextPage", typeof(string), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("ListReservationsNextPageAsync", typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("ListReservationsNextPage", typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperationAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperation", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CancelOperationAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CancelOperation", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CreateGetOperationRequest", typeof(string))]
    [CodeGenSuppress("CreateCancelOperationRequest", typeof(string))]
    internal partial class InternalPhoneNumbersRestClient
    {
    }
}
