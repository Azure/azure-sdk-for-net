// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.QuestionAnswering
{
    internal readonly ref struct KnowledgebaseIdentifier
    {
        private KnowledgebaseIdentifier(Uri id, Uri endpoint, string version, string knowledgebaseId)
        {
            Id = id;
            Endpoint = endpoint;
            Version = version;
            KnowledgebaseId = knowledgebaseId;
        }

        public static bool TryParse(Uri endpoint, string location, out KnowledgebaseIdentifier identifier)
        {
            if (Uri.TryCreate(endpoint, location, out Uri result))
            {
                if (result.Segments.Length >= 5)
                {
                    // TODO: Should assert this is a version for older versions, or adjust as needed for newer Language pillar versions.
                    string version = result.Segments[2];

                    identifier = new KnowledgebaseIdentifier(
                        result,
                        new Uri(result.GetLeftPart(UriPartial.Authority), UriKind.Absolute),
                        version,
                        result.Segments[4]);

                    return true;
                }
            }

            identifier = default;
            return false;
        }

        public Uri Id { get; }

        public Uri Endpoint { get; }

        public string Version { get; }

        public string KnowledgebaseId { get; }
    }
}
