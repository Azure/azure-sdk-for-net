// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Net.Http.Headers;

    // This type is instanciated by frequently called comparison methods so is very performance sensitive
    internal struct ParsedMediaTypeHeaderValue
    {
        private const char MediaRangeAsterisk = '*';
        private const char MediaTypeSubtypeDelimiter = '/';

        private readonly string _mediaType;
        private readonly int _delimiterIndex;
        private readonly bool _isAllMediaRange;
        private readonly bool _isSubtypeMediaRange;

        public ParsedMediaTypeHeaderValue(MediaTypeHeaderValue mediaTypeHeaderValue)
        {
            Contract.Assert(mediaTypeHeaderValue != null);
            string mediaType = this._mediaType = mediaTypeHeaderValue.MediaType;
            this._delimiterIndex = mediaType.IndexOf(MediaTypeSubtypeDelimiter);
            Contract.Assert(this._delimiterIndex > 0, "The constructor of the MediaTypeHeaderValue would have failed if there wasn't a type and subtype.");

            this._isAllMediaRange = false;
            this._isSubtypeMediaRange = false;
            int mediaTypeLength = mediaType.Length;
            if (this._delimiterIndex == mediaTypeLength - 2)
            {
                if (mediaType[mediaTypeLength - 1] == MediaRangeAsterisk)
                {
                    this._isSubtypeMediaRange = true;
                    if (this._delimiterIndex == 1 && mediaType[0] == MediaRangeAsterisk)
                    {
                        this._isAllMediaRange = true;
                    }
                }
            }
        }

        public bool IsAllMediaRange 
        { 
            get { return this._isAllMediaRange; } 
        }

        public bool IsSubtypeMediaRange 
        { 
            get { return this._isSubtypeMediaRange; } 
        }

        public bool TypesEqual(ref ParsedMediaTypeHeaderValue other)
        {
            if (this._delimiterIndex != other._delimiterIndex)
            {
                return false;
            }
            return String.Compare(this._mediaType, 0, other._mediaType, 0, this._delimiterIndex, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public bool SubTypesEqual(ref ParsedMediaTypeHeaderValue other)
        {
            int _subTypeLength = this._mediaType.Length - this._delimiterIndex - 1;
            if (_subTypeLength != other._mediaType.Length - other._delimiterIndex - 1)
            {
                return false;
            }
            return String.Compare(this._mediaType, this._delimiterIndex + 1, other._mediaType, other._delimiterIndex + 1, _subTypeLength, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
