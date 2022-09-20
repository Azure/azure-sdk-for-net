// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Communication.Email.Models
{
    [CodeGenModel("EmailAttachment")]
    public partial class EmailAttachment
    {
        internal void ValidateAttachmentContent()
        {
            if (string.IsNullOrWhiteSpace(ContentBytesBase64))
            {
                throw new ArgumentException(ErrorMessages.InvalidAttachmentContent);
            }

            try
            {
                Convert.FromBase64String(ContentBytesBase64);
            }
            catch (FormatException)
            {
                throw new ArgumentException(ErrorMessages.InvalidAttachmentContent);
            }
        }
    }
}
