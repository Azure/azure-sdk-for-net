// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Generator.Model
{
    [Flags]
    public enum PropertyHideLevel
    {
        DoNotHide = 0,
        HideProperty = 1,
        HideField = 2
    }
}
