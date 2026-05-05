// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Payload.MultiPart;

namespace Payload.MultiPart.Models
{
    /// <summary> The BinaryArrayPartsRequest. </summary>
    public partial class BinaryArrayPartsRequest
    {
        /// <summary> Initializes a new instance of <see cref="BinaryArrayPartsRequest"/> from a sequence of file paths. </summary>
        public BinaryArrayPartsRequest(string id, IEnumerable<string> picturePaths)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(picturePaths, nameof(picturePaths));

            Id = id;
            Pictures = picturePaths.Select(path => new FileBinaryContent(path)).ToList();
        }

        /// <summary> Initializes a new instance of <see cref="BinaryArrayPartsRequest"/> from a sequence of streams. </summary>
        public BinaryArrayPartsRequest(string id, IEnumerable<Stream> pictures)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(pictures, nameof(pictures));

            Id = id;
            Pictures = pictures.Select((stream, index) => new FileBinaryContent(stream) { Filename = $"pictures{index}" }).ToList();
        }

        /// <summary> Initializes a new instance of <see cref="BinaryArrayPartsRequest"/> from a sequence of <see cref="BinaryData"/> instances. </summary>
        public BinaryArrayPartsRequest(string id, IEnumerable<BinaryData> pictures)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(pictures, nameof(pictures));

            Id = id;
            Pictures = pictures.Select((data, index) => new FileBinaryContent(data) { Filename = $"pictures{index}" }).ToList();
        }

        /// <summary> Initializes a new instance of <see cref="BinaryArrayPartsRequest"/> from a sequence of pre-built <see cref="FileBinaryContent"/> instances. </summary>
        public BinaryArrayPartsRequest(string id, IEnumerable<FileBinaryContent> pictures)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(pictures, nameof(pictures));

            Id = id;
            Pictures = pictures.ToList();
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
        /// <summary> Gets the pictures. </summary>
        public IList<FileBinaryContent> Pictures { get; }
    }
}
