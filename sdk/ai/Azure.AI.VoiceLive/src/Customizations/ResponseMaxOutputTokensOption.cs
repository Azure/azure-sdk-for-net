// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents the maximum number of tokens that may be generated in a response.
    /// </summary>
    public partial class MaxResponseOutputTokensOption
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
        public static MaxResponseOutputTokensOption CreateInfiniteMaxTokensOption()
            => new("inf");
        /// <summary>
        /// Creates an options class with the default number of possible tokens.
        /// </summary>
        /// <returns></returns>
        public static MaxResponseOutputTokensOption CreateDefaultMaxTokensOption()
            => new(isDefaultNullValue: true);
        /// <summary>
        /// Creates an options class with a fixed number of tokens.
        /// </summary>
        /// <param name="maxTokens"></param>
        /// <returns></returns>
        public static MaxResponseOutputTokensOption CreateNumericMaxTokensOption(int maxTokens)
            => new(numberValue: maxTokens);
        /// <summary>
        /// Creates an options class with a fixed number of tokens.
        /// </summary>
        /// <param name="numberValue"></param>
        public MaxResponseOutputTokensOption(int numberValue)
        {
            NumericValue = numberValue;
        }

        internal MaxResponseOutputTokensOption(string stringValue)
        {
            _stringValue = stringValue;
        }

        internal MaxResponseOutputTokensOption(bool isDefaultNullValue)
        {
            _isDefaultNullValue = true;
        }

        internal MaxResponseOutputTokensOption() { }

        /// <summary>
        /// Creates a ResponseMaxOutputTokensOptions class from an integer value.
        /// </summary>
        /// <param name="maxTokens"></param>
        public static implicit operator MaxResponseOutputTokensOption(int maxTokens)
            => CreateNumericMaxTokensOption(maxTokens);

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="obj">The other</param>
        /// <returns>True is equal</returns>
        public override bool Equals(object obj)
        {
            if (obj is MaxResponseOutputTokensOption other)
            {
                if (other._isDefaultNullValue.HasValue && _isDefaultNullValue.HasValue)
                {
                    return other._isDefaultNullValue.Value == _isDefaultNullValue.Value;
                }
                if (other._stringValue is not null && _stringValue is not null)
                {
                    return other._stringValue == _stringValue;
                }
                if (other.NumericValue.HasValue && NumericValue.HasValue)
                {
                    return other.NumericValue.Value == NumericValue.Value;
                }
                return false;
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// Hash Code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}
