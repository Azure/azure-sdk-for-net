// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Messages
{
    /// <summary>  </summary>
    public class MessageTemplateVideo: MessageTemplateValue
    {
        /// <summary>  </summary>
        public MessageTemplateVideo(string name, Uri url, string caption = null, string filename = null) : base(name)
        {
            Url = url;
            Caption = caption;
            Filename = filename;
        }

        /// <summary> The (public) URL of the document media. </summary>
        public Uri Url { get; set; }
        /// <summary> The [optional] caption of the media object. </summary>
        public string Caption { get; set; }
        /// <summary> The [optional] filename of the media file. </summary>
        public string Filename { get; set; }

        internal override MessageTemplateValueInternal ToMessageTemplateValueInternal()
        {
            return new MessageTemplateValueInternal(MessageTemplateValueKind.Video)
            {
                Video = new MessageTemplateValueMedia {
                    Url = Url,
                    Caption = Caption,
                    Filename = Filename
                }
            };
        }
    }
}
