﻿//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// Shared constants.
    /// </summary>
    internal static class Constants
    {
        internal const string ServiceBusServiceUri          = "https://{0}.servicebus.windows.net/";
        internal const string ServiceBusAuthenticationUri   = "https://{0}-sb.accesscontrol.windows.net/wrapv0.9/";
        internal const string ServiceBusScopeUri            = "http://{0}.servicebus.windows.net/";

        internal const string WrapTokenAuthenticationString = "WRAP access_token=\"{0}\"";

        internal const string SerializationContentType      = "application/xml";
        internal const string BodyContentType               = "application/atom+xml";
        internal const string WrapAuthenticationContentType = "application/x-www-form-urlencoded";
    }
}
