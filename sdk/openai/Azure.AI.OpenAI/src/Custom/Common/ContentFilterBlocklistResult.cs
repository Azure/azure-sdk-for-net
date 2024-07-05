// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

[CodeGenModel("AzureContentFilterBlocklistResult")]
public partial class ContentFilterBlocklistResult
{
    public IReadOnlyDictionary<string, bool> BlocklistFilterStatuses
    {
        get
        {
            if (_filteredByBlocklistId is null)
            {
                _filteredByBlocklistId = [];
                foreach (InternalAzureContentFilterBlocklistResultDetail internalDetail in InternalDetails ?? [])
                {
                    _filteredByBlocklistId[internalDetail.Id] = internalDetail.Filtered;
                }
            }
            return _filteredByBlocklistId;
        }
    }
    private Dictionary<string, bool> _filteredByBlocklistId;

    [CodeGenMember("Details")]
    private IReadOnlyList<InternalAzureContentFilterBlocklistResultDetail> InternalDetails { get; }
}
