// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading.Tasks;

using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Options to customize browser view.
    /// </summary>
    public class BrowserCustomizationOptions
    {
        /// <summary>
        /// Specifies if the public client application should used an embedded web browser
        /// or the system default browser
        /// </summary>
        [Obsolete("This option requires additional dependencies on Microsoft.Identity.Client.Desktop and is no longer supported. Consider using brokered authentication instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? UseEmbeddedWebView { get; set; }

        internal SystemWebViewOptions SystemBrowserOptions;

        private SystemWebViewOptions systemWebViewOptions
        {
            get
            {
                SystemBrowserOptions ??= new SystemWebViewOptions();
                return SystemBrowserOptions;
            }
        }

        /// <summary>
        /// Property to set HtmlMessageSuccess of SystemWebViewOptions from MSAL,
        /// which the browser will show to the user when the user finishes authenticating successfully.
        /// </summary>
        public string SuccessMessage
        {
            get
            {
                return systemWebViewOptions.HtmlMessageSuccess;
            }

            set
            {
                systemWebViewOptions.HtmlMessageSuccess = value;
            }
        }

        /// <summary>
        /// Property to set HtmlMessageError of SystemWebViewOptions from MSAL,
        /// which the browser will show to the user when the user finishes authenticating, but an error occurred.
        /// You can use a string format e.g. "An error has occurred: {0} details: {1}".
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return systemWebViewOptions.HtmlMessageError;
            }

            set
            {
                systemWebViewOptions.HtmlMessageError = value;
            }
        }
    }
}
