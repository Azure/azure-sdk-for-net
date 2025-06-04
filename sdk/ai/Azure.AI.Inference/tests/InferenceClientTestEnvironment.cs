// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Inference.Tests
{
    public class InferenceClientTestEnvironment : TestEnvironment
    {
        public string MistralSmallEndpoint => GetRecordedVariable("AZUREAI_MISTRAL_SMALL_URL");
        public string MistralSmallApiKey => GetRecordedVariable("AZUREAI_MISTRAL_SMALL_KEY", options => options.IsSecret());
        public string CohereEmbeddingEndpoint => GetRecordedVariable("AZUREAI_COHERE_EMBEDDING_URL");
        public string CohereEmbeddingApiKey => GetRecordedVariable("AZUREAI_COHERE_EMBEDDING_KEY", options => options.IsSecret());
        public string GithubEndpoint => GetRecordedVariable("AZUREAI_GITHUB_URL");
        public string GithubToken => GetRecordedVariable("AZUREAI_GITHUB_TOKEN", options => options.IsSecret());
        public string AoaiEndpoint => GetRecordedVariable("AOAI_CHAT_COMPLETIONS_ENDPOINT");
        public string AoaiKey => GetRecordedVariable("AOAI_CHAT_COMPLETIONS_KEY", options => options.IsSecret());
        public string AoaiEmbeddingsEndpoint => GetRecordedVariable("AOAI_EMBEDDINGS_ENDPOINT");
        public string AoaiEmbeddingsKey => GetRecordedVariable("AOAI_EMBEDDINGS_KEY", options => options.IsSecret());
        public string TestImagePngInputPath => GetRecordedVariable("AZUREAI_TEST_IMAGE_PNG_INPUT_PATH");
        public string AoaiAudioEndpoint => GetRecordedVariable("AOAI_AUDIO_ENDPOINT");
        public string AoaiAudioKey => GetRecordedVariable("AOAI_AUDIO_KEY", options => options.IsSecret());
        public string PhiAudioEndpoint => GetRecordedVariable("PHI_AUDIO_ENDPOINT");
        public string PhiAudioKey => GetRecordedVariable("PHI_AUDIO_KEY", options => options.IsSecret());
        public string TestAudioMp3InputPath => GetRecordedVariable("AZUREAI_TEST_AUDIO_MP3_INPUT_PATH");
        // Add other client paramters here as above.
    }
}
