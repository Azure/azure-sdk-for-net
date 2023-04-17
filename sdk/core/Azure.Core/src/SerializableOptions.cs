// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

public class SerializableOptions
{
    public bool SerializeReadonlyProperties { get; set; } = true;
    public bool HandleUnknownElements { get; set; } = true;
    public bool PrettyPrint { get; set; } = false;
}
