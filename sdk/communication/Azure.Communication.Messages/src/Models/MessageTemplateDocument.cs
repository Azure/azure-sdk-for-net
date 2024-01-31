// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Messages
{
    /// <summary>  </summary>
    public class MessageTemplateDocument: MessageTemplateValue
    {
        /// <summary>  </summary>
        public MessageTemplateDocument(string name, Uri uri, string caption = null, string fileName = null) : base(name)
        {
            Uri = uri;
            Caption = caption;
            FileName = fileName;
        }

        /// <summary> The (public) URL of the document media. </summary>
        public Uri Uri { get; set; }
        /// <summary> The [optional] caption of the media object. </summary>
        public string Caption { get; set; }
        /// <summary> The [optional] filename of the media file. </summary>
        public string FileName { get; set; }

        internal override MessageTemplateValueInternal ToMessageTemplateValueInternal()
        {
            return new MessageTemplateValueInternal(MessageTemplateValueKind.Document)
            {
                Document = new MessageTemplateValueMedia {
                    Url = Uri,
                    Caption = Caption,
                    FileName = FileName
                }
            };
        }
    }
}
