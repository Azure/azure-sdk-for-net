// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Developer.Playwright.Interface
{
    internal interface IPlaywrightVersion
    {
        void ValidatePlaywrightVersion();

        string GetPlaywrightVersion();
    }
}
