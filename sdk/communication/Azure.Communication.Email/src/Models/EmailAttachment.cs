// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Communication.Email.Models
{
    [CodeGenModel("EmailAttachment")]
    [CodeGenSuppress("EmailAttachment", typeof(string), typeof(string), typeof(string))]
    public partial class EmailAttachment
    {
        /// <summary> Initializes a new instance of EmailAttachment. </summary>
        /// <param name="name"> Name of the attachment. </param>
        /// <param name="contentType"> MIME type of the content being attached. </param>
        /// <param name="content"> BinaryData representing the contents of the attachment. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="contentType"/> or <paramref name="content"/> is null. </exception>
        public EmailAttachment(string name, string contentType, BinaryData content)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(contentType, nameof(contentType));
            Argument.AssertNotNull(content, nameof(content));

            Name = name;
            ContentType = contentType;

            try
            {
                ContentBytesBase64 = Convert.ToBase64String(content.ToArray());
            }
            catch (Exception)
            {
                throw new ArgumentException(ErrorMessages.InvalidAttachmentContent);
            }
        }

        internal void ValidateAttachmentContent()
        {
            if (string.IsNullOrWhiteSpace(ContentBytesBase64))
            {
                throw new ArgumentException(ErrorMessages.InvalidAttachmentContent);
            }
        }
    }
}
