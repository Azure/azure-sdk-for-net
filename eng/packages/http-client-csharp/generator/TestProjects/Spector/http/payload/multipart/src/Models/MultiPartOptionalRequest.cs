// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.IO;

using Payload.MultiPart;

namespace Payload.MultiPart.Models
{
    /// <summary>
    /// Request body for the <c>optionalParts</c> multipart/form-data operation.
    /// Both <see cref="Id"/> and <see cref="ProfileImage"/> are optional.
    /// </summary>
    public partial class MultiPartOptionalRequest
    {
        /// <summary> Initializes a new instance of <see cref="MultiPartOptionalRequest"/>. </summary>
        public MultiPartOptionalRequest()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MultiPartOptionalRequest"/> with both parts populated from a path on disk. </summary>
        public MultiPartOptionalRequest(string id, string profileImagePath)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(profileImagePath, nameof(profileImagePath));

            Id = id;
            ProfileImage = new(profileImagePath);
        }

        /// <summary> Initializes a new instance of <see cref="MultiPartOptionalRequest"/> with both parts populated from a stream. </summary>
        public MultiPartOptionalRequest(string id, Stream profileImage)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(profileImage, nameof(profileImage));

            Id = id;
            ProfileImage = new(profileImage);
        }

        /// <summary> Initializes a new instance of <see cref="MultiPartOptionalRequest"/> with both parts populated from in-memory data. </summary>
        public MultiPartOptionalRequest(string id, BinaryData profileImage)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(profileImage, nameof(profileImage));

            Id = id;
            ProfileImage = new(profileImage);
        }

        /// <summary> Initializes a new instance of <see cref="MultiPartOptionalRequest"/> with both parts populated from a pre-built <see cref="FileBinaryContent"/>. </summary>
        public MultiPartOptionalRequest(string id, FileBinaryContent profileImage)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(profileImage, nameof(profileImage));

            Id = id;
            ProfileImage = profileImage;
        }

        /// <summary> Optional identifier. </summary>
        public string Id { get; set; }

        /// <summary> Optional profile image. </summary>
        public FileBinaryContent ProfileImage { get; set; }
    }
}
