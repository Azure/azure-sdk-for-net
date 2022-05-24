// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Communication.Email.Models
{
    [CodeGenModel("EmailCustomHeader")]
    public partial class EmailCustomHeader
    {
        internal void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Value))
            {
                throw new ArgumentException(ErrorMessages.EmptyHeaderNameOrValue);
            }
        }
    }
}
