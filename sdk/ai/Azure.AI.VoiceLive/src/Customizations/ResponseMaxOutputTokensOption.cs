// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents the maximum number of tokens that may be generated in a response.
    /// </summary>
    public partial class ResponseMaxOutputTokensOption
    {
        /// <summary>
        /// The numeric equivlant for the number of tokens.
        /// </summary>
        public int? NumericValue { get; }
        private readonly bool? _isDefaultNullValue;
        private readonly string _stringValue;

        /// <summary>
        /// Creates an options class with infinite tokens possible.
        /// </summary>
        /// <returns></returns>
        public static ResponseMaxOutputTokensOption CreateInfiniteMaxTokensOption()
            => new("inf");
        /// <summary>
        /// Creates an options class with the default number of possible tokens.
        /// </summary>
        /// <returns></returns>
        public static ResponseMaxOutputTokensOption CreateDefaultMaxTokensOption()
            => new(isDefaultNullValue: true);
        /// <summary>
        /// Creates an options class with a fixed number of tokens.
        /// </summary>
        /// <param name="maxTokens"></param>
        /// <returns></returns>
        public static ResponseMaxOutputTokensOption CreateNumericMaxTokensOption(int maxTokens)
            => new(numberValue: maxTokens);
        /// <summary>
        /// Creates an options class with a fixed number of tokens.
        /// </summary>
        /// <param name="numberValue"></param>
        public ResponseMaxOutputTokensOption(int numberValue)
        {
            NumericValue = numberValue;
        }

        internal ResponseMaxOutputTokensOption(string stringValue)
        {
            _stringValue = stringValue;
        }

        internal ResponseMaxOutputTokensOption(bool isDefaultNullValue)
        {
            _isDefaultNullValue = true;
        }

        internal ResponseMaxOutputTokensOption() { }

        /// <summary>
        /// Creates a ResponseMaxOutputTokensOptions class from an integer value.
        /// </summary>
        /// <param name="maxTokens"></param>
        public static implicit operator ResponseMaxOutputTokensOption(int maxTokens)
            => CreateNumericMaxTokensOption(maxTokens);
    }
}
