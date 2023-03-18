// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    public partial class CompletionsOptions
    {
        /// <summary>
        ///     Gets or sets the number of choices that should be generated per provided prompt.
        ///     Has a valid range of 1 to 128.
        /// </summary>
        /// <remarks>
        ///     Because this parameter generates many completions, it can quickly consume your token quota. Use
        ///     carefully and ensure reasonable settings for <see cref="MaxTokens"/> and <see cref="StopSequences"/>.
        ///
        ///     <see cref="ChoicesPerPrompt"/> is equivalent to 'n' in the REST request schema.
        /// </remarks>
        [CodeGenMember("N")]
        public int? ChoicesPerPrompt { get; set; }

        /// <summary>
        ///     Gets or sets a value specifying whether a completion should include its input prompt as a prefix to
        ///     its generated output.
        /// </summary>
        public bool? Echo { get; set; }

        /// <summary>
        ///     Gets or sets a value that influences the probability of generated tokens appearing based on their
        ///     cumulative frequency in generated text.
        ///     Has a valid range of -2.0 to 2.0.
        /// </summary>
        /// <remarks>
        ///     Positive values will make tokens less likely to appear as their frequency increases and decrease the
        ///     model's likelihood of repeating the same statements verbatim.
        /// </remarks>
        public float? FrequencyPenalty { get; set; }

        /// <summary>
        ///     Gets or sets a value that controls how many completions will be internally generated prior to response
        ///     formulation.
        /// </summary>
        /// <remarks>
        ///     When used together with <see cref="ChoicesPerPrompt"/>, <see cref="GenerationSampleCount"/> controls
        ///     the number of candidate completions and must be greater than <see cref="ChoicesPerPrompt"/>.
        ///
        ///     Because this parameter generates many completions, it can quickly consume your token quota. Use
        ///     carefully and ensure reasonable settings for <see cref="MaxTokens"/> and <see cref="StopSequences"/>.
        ///
        ///     <see cref="GenerationSampleCount"/> is equivalent to 'best_of' in the REST request schema.
        /// </remarks>.
        [CodeGenMember("BestOf")]
        public int? GenerationSampleCount { get; set; }

        /// <summary>
        ///     Gets or sets a value that controls generation of log probabilities on the
        ///     <see cref="LogProbabilityCount"/> most likely tokens.
        ///     Has a valid range of 0 to 5.
        /// </summary>
        /// <remarks>
        ///     <see cref="LogProbabilityCount"/> is equivalent to 'logprobs' in the REST request schema.
        /// </remarks>
        [CodeGenMember("Logprobs")]
        public int? LogProbabilityCount { get; set; }

        /// <summary> Gets the maximum number of tokens to generate. Has minimum of 0. </summary>
        /// <remarks>
        ///     <see cref="MaxTokens"/> is equivalent to 'max_tokens' in the REST request schema.
        /// </remarks>
        public int? MaxTokens { get; set; }

        /// <summary>
        ///     Gets or set a an alternative value to <see cref="Temperature"/>, called nucleus sampling, that causes
        ///     the model to consider the results of the tokens with <see cref="NucleusSamplingFactor"/> probability
        ///     mass.
        /// </summary>
        /// <remarks>
        ///     As an example, a value of 0.1 will cause only the tokens comprising the top 10% of probability mass to
        ///     be considered.
        ///
        ///     It is not recommended to modify <see cref="Temperature"/> and <see cref="NucleusSamplingFactor"/>
        ///     for the same completions request as the interaction of these two settings is difficult to predict.
        ///
        ///     <see cref="NucleusSamplingFactor"/> is equivalent to 'top_p' in the REST request schema.
        /// </remarks>
        [CodeGenMember("TopP")]
        public float? NucleusSamplingFactor { get; set; }

        /// <summary>
        ///     Gets or sets a value that influences the probability of generated tokens appearing based on their
        ///     existing presence in generated text.
        ///     Has a valid range of -2.0 to 2.0.
        /// </summary>
        /// <remarks>
        ///     Positive values will make tokens less likely to appear when they already exist and increase the
        ///     model's likelihood to output new topics.
        /// </remarks>
        public float? PresencePenalty { get; set; }

        /// <summary>
        ///     Gets the prompts to generate completions from. Defaults to a single prompt of &lt;|endoftext|&gt;
        ///     if not otherwise provided.
        /// </summary>
        /// <remarks>
        ///     <see cref="Prompts"/> is equivalent to 'prompt' in the REST request schema.
        /// </remarks>
        public IList<string> Prompts { get; }

        /// <summary>
        ///     Gets a list of textual sequences that will end completions generation.
        ///     A maximum of four stop sequences are allowed.
        /// </summary>
        /// <remarks>
        ///     <see cref="StopSequences"/> is equivalent to 'stop' in the REST request schema.
        /// </remarks>
        public IList<string> StopSequences { get; }

        /// <summary>
        ///     Gets or sets the sampling temperature to use that controls the apparent creativity of generated
        ///     completions.
        ///     Has a valid range of 0.0 to 2.0 and defaults to 1.0 if not otherwise specified.
        /// </summary>
        /// <remarks>
        ///     Higher values will make output more random while lower values will make results more focused and
        ///     deterministic.
        ///
        ///     It is not recommended to modify <see cref="Temperature"/> and <see cref="NucleusSamplingFactor"/>
        ///     for the same completions request as the interaction of these two settings is difficult to predict.
        /// </remarks>
        public float? Temperature { get; set; }

        /// <summary>
        ///     Gets a dictionary of modifications to the likelihood of specified GPT tokens appearing in a completions
        ///     result. Maps token IDs to associated bias scores from -100 to 100, with minimum and maximum values
        ///     corresponding to a ban or exclusive selection of that token, respectively.
        /// </summary>
        /// <remarks>
        ///     Token IDs are computed via external tokenizer tools.
        ///     The exact effect of specific bias values varies per model.
        ///
        ///     <see cref="TokenSelectionBiases"/> is equivalent to 'logit_bias' in the REST request schema.
        /// </remarks>
        public IDictionary<int, int> TokenSelectionBiases { get; }

        /// <summary> Gets or sets an identifier for a request for use in tracking and rate-limiting. </summary>
        public string User { get; set; }

        internal string NonAzureModel { get; set; }

        /// <summary> Initializes a new instance of CompletionsOptions. </summary>
        public CompletionsOptions()
        {
            Prompts = new ChangeTrackingList<string>();
            TokenSelectionBiases = new ChangeTrackingDictionary<int, int>();
            StopSequences = new ChangeTrackingList<string>();
        }

        internal CompletionsOptions(
            IList<string> prompts,
            int? maxTokens,
            float? temperature,
            float? nucleusSamplingFactor,
            IDictionary<int, int> tokenSelectionBiases,
            string user,
            int? choicesPerPrompt,
            int? logProbabilityCount,
            bool? echo,
            IList<string> stopSequences,
            float? presencePenalty,
            float? frequencyPenalty,
            int? generationSampleCount)
        {
            Prompts = prompts.ToList();
            MaxTokens = maxTokens;
            Temperature = temperature;
            NucleusSamplingFactor = nucleusSamplingFactor;
            TokenSelectionBiases = tokenSelectionBiases;
            User = user;
            ChoicesPerPrompt = choicesPerPrompt;
            LogProbabilityCount = logProbabilityCount;
            Echo = echo;
            StopSequences = stopSequences.ToList();
            PresencePenalty = presencePenalty;
            FrequencyPenalty = frequencyPenalty;
            GenerationSampleCount = generationSampleCount;
        }
    }
}
