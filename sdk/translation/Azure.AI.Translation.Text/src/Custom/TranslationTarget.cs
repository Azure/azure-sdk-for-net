// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Translation.Text
{
    /// <summary> Translate targets parameters. </summary>
    // Custom convenience constructors for the generated TranslateTarget class
    public partial class TranslationTarget
    {
        /// <summary> Initializes a new instance of <see cref="TranslationTarget"/> with optional parameters. </summary>
        /// <param name="language">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. It's possible to translate to multiple languages simultaneously by including
        /// multiple string values in the targetsLanguage array.
        /// </param>
        /// <param name="script"> Specifies the script of the translated text. </param>
        /// <param name="profanityAction">
        /// Specifies how profanities should be treated in translations.
        /// Possible values are: NoAction (default), Marked or Deleted.
        /// </param>
        /// <param name="profanityMarker">
        /// Specifies how profanities should be marked in translations.
        /// Possible values are: Asterisk (default) or Tag.
        /// </param>
        /// <param name="deploymentName">
        /// Default is 'general', which uses NMT system.
        /// 'abc-inc-gpt-4o', and 'abc-inc-gpt-4o-mini' are examples of deployment names which use GPT-4o uses or
        /// GPT-4o-mini model. 'gpt-4o' uses GPT-4o model.
        ///
        /// '&lt;custom model id&gt;' uses the custom NMT model tuned by customer.
        /// 'best' system determines which is the best model to use for the request. This intelligence could be introduced
        /// in future. Customer should have deployed it in their resource.
        /// </param>
        /// <param name="allowFallback">
        /// In the case where a custom system is being used, specifies that the service is allowed to fall back to a
        /// general system when a custom system doesn't exist.
        /// In the case where a Large Language Model is being used, specifies that the service is allowed to fall
        /// back to a Small Language Model if an error occurs.
        /// Possible values are: true (default) or false.
        /// </param>
        /// <param name="grade"> Defines complexity of LLM prompts to provide high accuracy translation. </param>
        /// <param name="tone"> Desired tone of target translation. </param>
        /// <param name="gender"> Desired gender of target translation. </param>
        /// <param name="adaptiveDatasetId"> Reference dataset ID having sentence pair to generate adaptive customized translation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/> is null. </exception>
        public TranslationTarget(string language,
            string script = null,
            ProfanityAction? profanityAction = null,
            ProfanityMarker? profanityMarker = null,
            string deploymentName = null,
            bool? allowFallback = null,
            string grade = null,
            string tone = null,
            string gender = null,
            string adaptiveDatasetId = null)
            : this(language)
        {
            Script = script;
            ProfanityAction = profanityAction;
            ProfanityMarker = profanityMarker;
            DeploymentName = deploymentName;
            AllowFallback = allowFallback;
            Grade = grade;
            Tone = tone;
            Gender = gender;
            AdaptiveDatasetId = adaptiveDatasetId;
        }
    }
}
