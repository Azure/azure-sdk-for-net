// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Inference.Tests
{
    public class QuestionAnsweringClientTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the master API key.
        /// </summary>
        public string ApiKey => GetRecordedVariable("QUESTIONANSWERING_KEY", options => options.IsSecret());

        /// <summary>
        /// Gets a <see cref="QuestionAnsweringProject"/> using the <see cref="ProjectName"/> and <see cref="DeploymentName"/>.
        /// </summary>
        public QuestionAnsweringProject Project => new QuestionAnsweringProject(ProjectName, DeploymentName);

        /// <summary>
        /// Gets the primary test project name.
        /// </summary>
        public string ProjectName => GetRecordedVariable("QUESTIONANSWERING_PROJECT");

        /// <summary>
        /// Gets the deployment name.
        /// </summary>
        public string DeploymentName => "test";

        /// <summary>
        /// Gets the endpoint.
        /// </summary>
        public Uri Endpoint => new(GetRecordedVariable("QUESTIONANSWERING_ENDPOINT"), UriKind.Absolute);
    }
}
