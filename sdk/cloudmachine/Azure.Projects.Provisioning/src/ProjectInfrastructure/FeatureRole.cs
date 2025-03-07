// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Projects.Core;

public struct FeatureRole
{
    public FeatureRole(string name, string id)
    {
        Name = name;
        Id = id;
    }

    public string Name { get; }
    public string Id { get; }
}
