// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI;

/// <summary> Representation of a log probabilities model for a completions generation. </summary>
public partial class CompletionsLogProbabilityModel
{
    /// <summary> Initializes a new instance of CompletionsLogProbabilityModel. </summary>
    /// <param name="tokens"> The textual forms of tokens evaluated in this probability model. </param>
    /// <param name="tokenLogProbabilities"> A collection of log probability values for the tokens in this completions data. </param>
    /// <param name="topLogProbabilities"> A mapping of tokens to maximum log probability values in this completions data. </param>
    /// <param name="textOffsets"> The text offsets associated with tokens in this completions data. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="tokens"/>, <paramref name="tokenLogProbabilities"/>, <paramref name="topLogProbabilities"/> or <paramref name="textOffsets"/> is null. </exception>
    internal CompletionsLogProbabilityModel(IEnumerable<string> tokens, IEnumerable<float?> tokenLogProbabilities, IEnumerable<IDictionary<string, float?>> topLogProbabilities, IEnumerable<int> textOffsets)
    {
        if (tokens is null) throw new ArgumentNullException(nameof(tokens));
        if (tokenLogProbabilities is null) throw new ArgumentNullException(nameof(tokenLogProbabilities));
        if (topLogProbabilities is null) throw new ArgumentNullException(nameof(topLogProbabilities));
        if (textOffsets is null) throw new ArgumentNullException(nameof(textOffsets));

        Tokens = tokens.ToList();
        TokenLogProbabilities = tokenLogProbabilities.ToList();
        TopLogProbabilities = topLogProbabilities.ToList();
        TextOffsets = textOffsets.ToList();
    }

    /// <summary> Initializes a new instance of CompletionsLogProbabilityModel. </summary>
    /// <param name="tokens"> The textual forms of tokens evaluated in this probability model. </param>
    /// <param name="tokenLogProbabilities"> A collection of log probability values for the tokens in this completions data. </param>
    /// <param name="topLogProbabilities"> A mapping of tokens to maximum log probability values in this completions data. </param>
    /// <param name="textOffsets"> The text offsets associated with tokens in this completions data. </param>
    internal CompletionsLogProbabilityModel(IReadOnlyList<string> tokens, IReadOnlyList<float?> tokenLogProbabilities, IReadOnlyList<IDictionary<string, float?>> topLogProbabilities, IReadOnlyList<int> textOffsets)
    {
        Tokens = tokens;
        TokenLogProbabilities = tokenLogProbabilities;
        TopLogProbabilities = topLogProbabilities;
        TextOffsets = textOffsets;
    }

    /// <summary> The textual forms of tokens evaluated in this probability model. </summary>
    public IReadOnlyList<string> Tokens { get; }
    /// <summary> A collection of log probability values for the tokens in this completions data. </summary>
    public IReadOnlyList<float?> TokenLogProbabilities { get; }
    /// <summary> A mapping of tokens to maximum log probability values in this completions data. </summary>
    public IReadOnlyList<IDictionary<string, float?>> TopLogProbabilities { get; }
    /// <summary> The text offsets associated with tokens in this completions data. </summary>
    public IReadOnlyList<int> TextOffsets { get; }
}
