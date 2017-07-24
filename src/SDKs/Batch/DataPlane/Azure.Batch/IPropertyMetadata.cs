// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch
{
    internal interface IPropertyMetadata : IModifiable, IReadOnly
    {
        //Serves as an aggregator for all the properties we are interested in
    }
}
