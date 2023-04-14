// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// Describes the type of phone number as defined by the phone number's operator
    /// </summary>
    public enum OperatorPhoneType
    {
        /// <summary> TODO: follow up with PM for better definitions of number types </summary>
        Geographic,
        /// <summary> Mobile telephone number, likely to be capable of receiving SMS </summary>
        Mobile,
        /// <summary> TODO: follow up with PM for better definitions of number types </summary>
        Paging,
        /// <summary> TODO: follow up with PM for better definitions of number types </summary>
        Freephone,
        /// <summary> TODO: follow up with PM for better definitions of number types </summary>
        SpecialServices,
        /// <summary> TODO: follow up with PM for better definitions of number types </summary>
        TestNumber,
        /// <summary> TODO: follow up with PM for better definitions of number types </summary>
        Voip
    }
}
