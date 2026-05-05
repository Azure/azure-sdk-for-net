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
    /// Request body for the <c>withWireName</c> multipart/form-data operation.
    /// The C# property names differ from the wire part names (<c>id</c> and
    /// <c>profileImage</c>).
    /// </summary>
    public partial class MultiPartRequestWithWireName
    {
        /// <summary> Initializes a new instance of <see cref="MultiPartRequestWithWireName"/>. </summary>
        /// <param name="identifier"> Identifier of the entity. Sent on the wire as <c>id</c>. </param>
        /// <param name="profileImagePath"> Path to the profile image file. Sent on the wire as <c>profileImage</c>. </param>
        public MultiPartRequestWithWireName(string identifier, string profileImagePath)
        {
            Argument.AssertNotNull(identifier, nameof(identifier));
            Argument.AssertNotNull(profileImagePath, nameof(profileImagePath));

            Identifier = identifier;
            Image = new(profileImagePath);
        }

        /// <summary> Initializes a new instance of <see cref="MultiPartRequestWithWireName"/>. </summary>
        public MultiPartRequestWithWireName(string identifier, Stream profileImage)
        {
            Argument.AssertNotNull(identifier, nameof(identifier));
            Argument.AssertNotNull(profileImage, nameof(profileImage));

            Identifier = identifier;
            Image = new(profileImage);
        }

        /// <summary> Initializes a new instance of <see cref="MultiPartRequestWithWireName"/>. </summary>
        public MultiPartRequestWithWireName(string identifier, BinaryData profileImage)
        {
            Argument.AssertNotNull(identifier, nameof(identifier));
            Argument.AssertNotNull(profileImage, nameof(profileImage));

            Identifier = identifier;
            Image = new(profileImage);
        }

        /// <summary> Initializes a new instance of <see cref="MultiPartRequestWithWireName"/>. </summary>
        public MultiPartRequestWithWireName(string identifier, FileBinaryContent profileImage)
        {
            Argument.AssertNotNull(identifier, nameof(identifier));
            Argument.AssertNotNull(profileImage, nameof(profileImage));

            Identifier = identifier;
            Image = profileImage;
        }

        /// <summary> Identifier of the entity (wire name: <c>id</c>). </summary>
        public string Identifier { get; }

        /// <summary> Profile image (wire name: <c>profileImage</c>). </summary>
        public FileBinaryContent Image { get; }
    }
}
