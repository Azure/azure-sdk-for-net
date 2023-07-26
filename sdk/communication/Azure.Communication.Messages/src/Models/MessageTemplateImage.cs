// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Messages
{
    /// <summary>  </summary>
    public class MessageTemplateImage: MessageTemplateValue
    {
        /// <summary>  </summary>
        public MessageTemplateImage(string name, Uri uri, string caption = null, string filename = null) : base(name)
        {
            Uri = uri;
            Caption = caption;
            Filename = filename;
        }

        /// <summary> The (public) URL of the document media. </summary>
        public Uri Uri { get; set; }
        /// <summary> The [optional] caption of the media object. </summary>
        public string Caption { get; set; }
        /// <summary> The [optional] filename of the media file. </summary>
        public string Filename { get; set; }

        internal override MessageTemplateValueInternal ToMessageTemplateValueInternal()
        {
            return new MessageTemplateValueInternal(MessageTemplateValueKind.Image)
            {
                Image = new MessageTemplateValueMedia
                {
                    Uri = Uri,
                    Caption = Caption,
                    Filename = Filename
                }
            };
        }
    }
}
