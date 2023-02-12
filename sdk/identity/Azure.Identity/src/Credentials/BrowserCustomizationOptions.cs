// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public bool? UseEmbeddedWebView;

        internal SystemWebViewOptions SystemBrowserOptions;

        internal EmbeddedWebViewOptions EmbeddedBrowserOptions;

        private SystemWebViewOptions systemWebViewOptions
        {
            get
            {
                SystemBrowserOptions ??= new SystemWebViewOptions();
                return SystemBrowserOptions;
            }
        }

        private EmbeddedWebViewOptions embeddedWebViewOptions
        {
            get
            {
                EmbeddedBrowserOptions ??= new EmbeddedWebViewOptions();
                return EmbeddedBrowserOptions;
            }
        }

        /// <summary>
        /// Property to set HtmlMessageSuccess of SystemWebViewOptions.
        /// </summary>
        public string HtmlMessageSuccess
        {
            set
            {
                systemWebViewOptions.HtmlMessageSuccess = value;
            }
        }

        /// <summary>
        /// Property to set HtmlMessageError of SystemWebViewOptions.
        /// </summary>
        public string HtmlMessageError
        {
            set
            {
                systemWebViewOptions.HtmlMessageError = value;
            }
        }

        /// <summary>
        /// Default constructor for <see cref="BrowserCustomizationOptions"/>. Will keep the framework default behavior,
        /// when you use this constructor.
        /// </summary>
        public BrowserCustomizationOptions(bool useEmbeddedWebView = false)
        {
            UseEmbeddedWebView = null;
            SystemBrowserOptions = null;
            EmbeddedBrowserOptions = null;
        }
    }
}
