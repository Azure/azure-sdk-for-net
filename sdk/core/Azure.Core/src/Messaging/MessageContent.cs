// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging
{
    /// <summary>
    /// The content of a message containing a content type along with the message data.
    /// </summary>
    public class MessageContent
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public virtual BinaryData? Data { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public virtual ContentType? ContentType
        {
            get => ContentTypeCore;
            set => ContentTypeCore = value;
        }

        /// <summary>
        /// For inheriting types that have a string ContentType property, this property should be overriden to forward
        /// the <see cref="ContentType"/> property into the inheriting type's string property, and vice versa.
        /// For types that have a <see cref="Azure.Core.ContentType"/> ContentType property, it is not necessary to override this member.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ContentType? ContentTypeCore { get; set; }

        /// <summary>
        /// Gets whether the message is read only or not. This
        /// can be overriden by inheriting classes to specify whether or
        /// not the message can be modified.
        /// </summary>
        public virtual bool IsReadOnly { get; }
    }
}