// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;

using Payload.MultiPart;

namespace Payload.MultiPart.Models
{
    /// <summary> The JsonPartRequest. </summary>
    public partial class JsonPartRequest
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="JsonPartRequest"/> from a path on disk. </summary>
        public JsonPartRequest(Address address, string profileImagePath)
        {
            Argument.AssertNotNull(address, nameof(address));
            Argument.AssertNotNullOrEmpty(profileImagePath, nameof(profileImagePath));

            Address = address;
            ProfileImage = new(profileImagePath);
        }

        /// <summary> Initializes a new instance of <see cref="JsonPartRequest"/> from a stream. </summary>
        public JsonPartRequest(Address address, Stream profileImage)
        {
            Argument.AssertNotNull(address, nameof(address));
            Argument.AssertNotNull(profileImage, nameof(profileImage));

            Address = address;
            ProfileImage = new(profileImage);
        }

        /// <summary> Initializes a new instance of <see cref="JsonPartRequest"/> from in-memory data. </summary>
        public JsonPartRequest(Address address, BinaryData profileImage)
        {
            Argument.AssertNotNull(address, nameof(address));
            Argument.AssertNotNull(profileImage, nameof(profileImage));

            Address = address;
            ProfileImage = new(profileImage);
        }

        /// <summary> Initializes a new instance of <see cref="JsonPartRequest"/> from a pre-built <see cref="FileBinaryContent"/>. </summary>
        public JsonPartRequest(Address address, FileBinaryContent profileImage)
        {
            Argument.AssertNotNull(address, nameof(address));
            Argument.AssertNotNull(profileImage, nameof(profileImage));

            Address = address;
            ProfileImage = profileImage;
        }

        internal JsonPartRequest(Address address, FileBinaryContent profileImage, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Address = address;
            ProfileImage = profileImage;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Gets the address. </summary>
        public Address Address { get; }
        /// <summary> Gets the profile image. </summary>
        public FileBinaryContent ProfileImage { get; }
    }
}
