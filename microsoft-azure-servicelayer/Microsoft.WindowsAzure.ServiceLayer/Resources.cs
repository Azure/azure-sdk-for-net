//
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// Accessor for resource strings.
    /// </summary>
    internal static class Resources
    {
        private static ResourceLoader _loader;              // Loader for resources

        /// <summary>
        /// Initializes static members of the class.
        /// </summary>
        static Resources()
        {
            string resourceFile = "Microsoft.WindowsAzure.ServiceLayer/Resources";
           _loader = new ResourceLoader(resourceFile);
        }

        private static string GetString(string resourceId)
        {
            return _loader.GetString(resourceId);
        }

        internal static string ErrorArgumentMustBeNonEmpty
        {
            get { return GetString("ErrorArgumentMustBeNonEmpty"); }
        }

        internal static string ErrorArgumentMustBeZeroOrPositive
        {
            get { return GetString("ErrorArgumentMustBeZeroOrPositive"); }
        }

        internal static string ErrorArgumentMustBePositive
        {
            get { return GetString("ErrorArgumentMustBePositive"); }
        }

        internal static string HttpDetails
        {
            get { return GetString("HttpDetails"); }
        }

        internal static string HttpErrorMessage
        {
            get { return GetString("HttpErrorMessage"); }
        }

        internal static string ErrorWrapAuthentication
        {
            get { return GetString("ErrorWrapAuthentication"); } 
        }

        internal static string ErrorNoContent
        {
            get { return GetString("ErrorNoContent"); }
        }

        internal static string ErrorFailedRequest
        {
            get { return GetString("ErrorFailedRequest"); }
        }

        internal static string ErrorUnsupportedPropertyType
        {
            get { return GetString("ErrorUnsupportedPropertyType"); }
        }

        internal static string ErrorArgumentInvalidComError
        {
            get { return GetString("ErrorArgumentInvalidComError"); }
        }

        internal static string ErrorNullFilterAndAction
        {
            get { return GetString("ErrorNullFilterAndAction"); }
        }

        internal static string ErrorItemNotFound
        {
            get { return GetString("ErrorItemNotFound"); }
        }
    }
}
