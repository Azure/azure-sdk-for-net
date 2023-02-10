// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The regex key extra data kind. </summary>
    public partial class RegexKey : BaseExtraInformation
    {
        /// <summary> Initializes a new instance of RegexKey. </summary>
        internal RegexKey()
        {
            ExtraInformationKind = ExtraInformationKind.RegexKey;
        }

        /// <summary> Initializes a new instance of RegexKey. </summary>
        /// <param name="extraInformationKind"> The extra information object kind. </param>
        /// <param name="key"> The key of the regex pattern used in extracting the entity. </param>
        /// <param name="regexPattern"> The .NET regex pattern used in extracting the entity. Please visit https://docs.microsoft.com/dotnet/standard/base-types/regular-expressions for more information about .NET regular expressions. </param>
        internal RegexKey(ExtraInformationKind extraInformationKind, string key, string regexPattern) : base(extraInformationKind)
        {
            Key = key;
            RegexPattern = regexPattern;
            ExtraInformationKind = extraInformationKind;
        }

        /// <summary> The key of the regex pattern used in extracting the entity. </summary>
        public string Key { get; }
        /// <summary> The .NET regex pattern used in extracting the entity. Please visit https://docs.microsoft.com/dotnet/standard/base-types/regular-expressions for more information about .NET regular expressions. </summary>
        public string RegexPattern { get; }
    }
}
