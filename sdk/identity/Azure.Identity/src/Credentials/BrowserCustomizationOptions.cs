// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Options to customize browser view.
    /// </summary>
    public class BrowserCustomizationOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserCustomizationOptions"/> class.
        /// </summary>
        public BrowserCustomizationOptions() { }

        internal BrowserCustomizationOptions(IConfigurationSection section)
        {
            if (section == null || !section.Exists())
            {
                return;
            }
            if (section[nameof(SuccessMessage)] is string successMessage)
            {
                SuccessMessage = successMessage;
            }
            if (section[nameof(ErrorMessage)] is string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
#pragma warning disable CS0618 // Type or member is obsolete
            if (bool.TryParse(section[nameof(UseEmbeddedWebView)], out bool useEmbeddedWebView))
            {
                UseEmbeddedWebView = useEmbeddedWebView;
            }
#pragma warning restore CS0618 // Type or member is obsolete
        }

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

        internal BrowserCustomizationOptions Clone()
        {
            var clone = new BrowserCustomizationOptions
            {
                ErrorMessage = ErrorMessage,
                SuccessMessage = SuccessMessage,
#pragma warning disable CS0618 // Type or member is obsolete
                UseEmbeddedWebView = UseEmbeddedWebView ?? false
#pragma warning restore CS0618 // Type or member is obsolete
            };
            return clone;
        }
    }
}
