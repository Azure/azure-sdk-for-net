// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Communication.Email
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
            Content = content;
        }

        internal void ValidateAttachmentContent()
        {
            if (Content.ToMemory().IsEmpty)
            {
                throw new ArgumentException(ErrorMessages.InvalidAttachmentContent);
            }
        }

        /// <summary>
        /// Contents of the attachment as BinaryData.
        /// </summary>
        public BinaryData Content { get; }

        /// <summary>
        /// Optional unique identifier (CID) to reference an inline attachment.
        /// </summary>
        public string ContentId { get; set; }
    }
}
