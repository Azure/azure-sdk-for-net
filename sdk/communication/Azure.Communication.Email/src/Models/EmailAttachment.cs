// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text;
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
            if (string.IsNullOrWhiteSpace(ContentInBase64))
            {
                throw new ArgumentException(ErrorMessages.InvalidAttachmentContent);
            }
        }

        internal string ContentInBase64
        {
            get
            {
                string valueToReturn = Convert.ToBase64String(Encoding.UTF8.GetBytes(Content.ToString()));
                if (string.IsNullOrWhiteSpace(valueToReturn))
                {
                    throw new ArgumentException(ErrorMessages.InvalidAttachmentContent);
                }

                return valueToReturn;
            }
        }

        /// <summary>
        /// Contents of the attachment as BinaryData.
        /// </summary>
        public BinaryData Content { get; }
    }
}
