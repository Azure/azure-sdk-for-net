// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Chat
{
    /// <summary> A member of the chat thread. </summary>
    public partial class ChatAttachment
    {
        /// <summary> Initializes a new instance of ChatAttachmentInternal. </summary>
        /// <param name="id"> Id of the attachment. </param>
        /// <param name="attachmentType"> The type of attachment. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        internal ChatAttachment(string id, AttachmentType attachmentType)
        {
            Id = id;
            AttachmentType = attachmentType;
        }

        /// <summary> Initializes a new instance of ChatAttachmentInternal. </summary>
        /// <param name="id"> Id of the attachment. </param>
        /// <param name="attachmentType"> The type of attachment. </param>
        /// <param name="extension"> The file extension of the attachment, if available. </param>
        /// <param name="name"> The name of the attachment content. </param>
        /// <param name="url"> The URL where the attachment can be downloaded. </param>
        /// <param name="previewUrl"> The URL where the preview of attachment can be downloaded. </param>
        internal ChatAttachment(string id, AttachmentType attachmentType, string extension, string name, string url, string previewUrl)
        {
            Id = id;
            AttachmentType = attachmentType;
            Extension = extension;
            Name = name;
            Url = url;
            PreviewUrl = previewUrl;
        }

        internal ChatAttachment(ChatAttachmentInternal chatAttachmentInternal)
        {
            Id = chatAttachmentInternal.Id;
            AttachmentType = chatAttachmentInternal.AttachmentType;
            Extension = chatAttachmentInternal.Extension;
            Name = chatAttachmentInternal.Name;
            Url = chatAttachmentInternal.Url;
            PreviewUrl = chatAttachmentInternal.PreviewUrl;
        }

        /// <summary> Id of the attachment. </summary>
        public string Id { get; }
        /// <summary> The type of attachment. </summary>
        public AttachmentType AttachmentType { get; }
        /// <summary> The file extension of the attachment, if available. </summary>
        public string Extension { get; }
        /// <summary> The name of the attachment content. </summary>
        public string Name { get; }
        /// <summary> The URL where the attachment can be downloaded. </summary>
        public string Url { get; }
        /// <summary> The URL where the preview of attachment can be downloaded. </summary>
        public string PreviewUrl { get; }

        internal ChatAttachmentInternal ToChatAttachmentInternal()
        {
            return new ChatAttachmentInternal(Id, AttachmentType, Extension, Name, Url, PreviewUrl);
        }
    }
}
