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
        internal ChatAttachment(string id, ChatAttachmentType attachmentType)
        {
            Id = id;
            AttachmentType = attachmentType;
        }

        /// <summary> Initializes a new instance of ChatAttachmentInternal. </summary>
        /// <param name="id"> Id of the attachment. </param>
        /// <param name="attachmentType"> The type of attachment. </param>
        /// <param name="name"> The name of the attachment content. </param>
        /// <param name="uri"> The URI where the attachment can be downloaded. </param>
        /// <param name="previewUri"> The URI where the preview of attachment can be downloaded. </param>
        internal ChatAttachment(string id, ChatAttachmentType attachmentType, string name, Uri uri, Uri previewUri)
        {
            Id = id;
            AttachmentType = attachmentType;
            Name = name;
            Uri = uri;
            PreviewUri = previewUri;
        }

        internal ChatAttachment(ChatAttachmentInternal chatAttachmentInternal)
        {
            Id = chatAttachmentInternal.Id;
            AttachmentType = chatAttachmentInternal.AttachmentType;
            Name = chatAttachmentInternal.Name;
            Uri = chatAttachmentInternal.Url;
            PreviewUri = chatAttachmentInternal.PreviewUrl;
        }

        /// <summary> Id of the attachment. </summary>
        public string Id { get; }
        /// <summary> The type of attachment. </summary>
        public ChatAttachmentType AttachmentType { get; }
        /// <summary> The name of the attachment content. </summary>
        public string Name { get; }
        /// <summary> The URL where the attachment can be downloaded. </summary>
        public Uri Uri { get; }
        /// <summary> The URL where the preview of attachment can be downloaded. </summary>
        public Uri PreviewUri { get; }

        internal ChatAttachmentInternal ToChatAttachmentInternal()
        {
            return new ChatAttachmentInternal(Id, AttachmentType, Name, Uri, PreviewUri);
        }
    }
}
