// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.Projects
{
    public partial class AIProjectConnectionCustomCredential
    {
        [CodeGenMember("AdditionalProperties")]
        public IReadOnlyDictionary<string, string> Keys => new ReadOnlyDictionary<string, string>(_additionalStringProperties);
    }
}
