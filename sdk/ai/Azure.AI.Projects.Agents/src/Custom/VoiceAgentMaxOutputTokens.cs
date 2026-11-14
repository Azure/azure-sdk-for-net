// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;

namespace Azure.AI.Projects.Agents;

/// <summary>
/// An output-token limit, using a fixed number, no limit, or the service default.
/// </summary>
public partial class VoiceAgentMaxOutputTokens
{
    /// <summary>
    /// The numeric token limit, or null for a nonnumeric option.
    /// </summary>
    public int? NumericValue { get; }
    private readonly bool? _isDefaultNullValue;
    private readonly string _stringValue;

    /// <summary>
    /// Creates an option with no output-token limit.
    /// </summary>
    /// <returns>An unlimited token option.</returns>
    public static VoiceAgentMaxOutputTokens CreateInfiniteMaxTokensOption()
        => new("inf");
    /// <summary>
    /// Creates an option that uses the service's default output-token limit.
    /// </summary>
    /// <returns>A default token option.</returns>
    public static VoiceAgentMaxOutputTokens CreateDefaultMaxTokensOption()
        => new(isDefaultNullValue: true);
    /// <summary>
    /// Creates a fixed output-token limit.
    /// </summary>
    /// <param name="maxTokens">The maximum output tokens per response.</param>
    /// <returns>A numeric token option.</returns>
    public static VoiceAgentMaxOutputTokens CreateNumericMaxTokensOption(int maxTokens)
        => new(numberValue: maxTokens);
    /// <summary>
    /// Creates a fixed output-token limit.
    /// </summary>
    /// <param name="numberValue">The maximum output tokens per response.</param>
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
    /// Converts an integer to a fixed output-token limit.
    /// </summary>
    /// <param name="maxTokens">The maximum output tokens per response.</param>
    public static implicit operator VoiceAgentMaxOutputTokens(int maxTokens)
        => CreateNumericMaxTokensOption(maxTokens);

    /// <summary>
    /// Determines whether this token limit equals another value.
    /// </summary>
    /// <param name="obj">The value to compare.</param>
    /// <returns>True if the values are equal.</returns>
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
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>The instance's hash code.</returns>
    public override int GetHashCode() => base.GetHashCode();

    /// <summary>
    /// An option with no output-token limit.
    /// </summary>
    public static VoiceAgentMaxOutputTokens Infinity { get; } = new VoiceAgentMaxOutputTokens("inf");
}
