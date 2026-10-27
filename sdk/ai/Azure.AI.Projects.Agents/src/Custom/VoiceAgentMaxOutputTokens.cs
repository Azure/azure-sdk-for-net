// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;

namespace Azure.AI.Projects.Agents;

/// <summary>
/// The VoiceAgentMaxOutputTokens represents integer value, or infinity.
/// </summary>
public partial class VoiceAgentMaxOutputTokens
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
    public static VoiceAgentMaxOutputTokens CreateInfiniteMaxTokensOption()
        => new("inf");
    /// <summary>
    /// Creates an options class with the default number of possible tokens.
    /// </summary>
    /// <returns></returns>
    public static VoiceAgentMaxOutputTokens CreateDefaultMaxTokensOption()
        => new(isDefaultNullValue: true);
    /// <summary>
    /// Creates an options class with a fixed number of tokens.
    /// </summary>
    /// <param name="maxTokens"></param>
    /// <returns></returns>
    public static VoiceAgentMaxOutputTokens CreateNumericMaxTokensOption(int maxTokens)
        => new(numberValue: maxTokens);
    /// <summary>
    /// Creates an options class with a fixed number of tokens.
    /// </summary>
    /// <param name="numberValue"></param>
    public VoiceAgentMaxOutputTokens(int numberValue)
    {
        NumericValue = numberValue;
    }

    internal VoiceAgentMaxOutputTokens(string stringValue)
    {
        _stringValue = stringValue;
    }

    internal VoiceAgentMaxOutputTokens(bool isDefaultNullValue)
    {
        _isDefaultNullValue = true;
    }

    internal VoiceAgentMaxOutputTokens() { }

    /// <summary>
    /// Creates a ResponseMaxOutputTokensOptions class from an integer value.
    /// </summary>
    /// <param name="maxTokens"></param>
    public static implicit operator VoiceAgentMaxOutputTokens(int maxTokens)
        => CreateNumericMaxTokensOption(maxTokens);

    /// <summary>
    /// Equality operator.
    /// </summary>
    /// <param name="obj">The other</param>
    /// <returns>True is equal</returns>
    public override bool Equals(object obj)
    {
        if (obj is VoiceAgentMaxOutputTokens other)
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

    /// <summary>
    /// The convenience method to set VoiceAgentMaxOutputTokens to intfinity.
    /// </summary>
    public static VoiceAgentMaxOutputTokens Infinity { get; } = new VoiceAgentMaxOutputTokens("inf");
}
