// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using NUnit.Framework.Constraints;

namespace Azure.AI.Personalizer.Tests
{
    internal class PersonalizerClientForTest : PersonalizerClient
    {
        private RlNetProcessor rlNetProcessor;

        public PersonalizerClientForTest(Uri endpoint, AzureKeyCredential credential, bool useLocalInference, RlNetProcessor rlNetProcessor, float subsampleRate = 1.0f, PersonalizerClientOptions options = null) :
            base(endpoint, credential, options)
        {
            this.rlNetProcessor = rlNetProcessor;
        }

        internal override RlNetProcessor GetConfigurationForRankProcessor(CancellationToken cancellationToken = default)
        {
            return rlNetProcessor;
        }
    }
}
