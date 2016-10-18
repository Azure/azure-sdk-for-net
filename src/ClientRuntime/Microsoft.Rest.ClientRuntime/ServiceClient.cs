// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Rest.TransientFaultHandling;
#if net45
using Microsoft.Win32;
#endif
namespace Microsoft.Rest
{
    /// <summary>
    /// ServiceClient is the abstraction for accessing REST operations and their payload data types..
    /// </summary>
    /// <typeparam name="T">Type of the ServiceClient.</typeparam>
    public abstract class ServiceClient<T> : IDisposable
        where T : ServiceClient<T>
    {
        /// <summary>
        /// ProductName string to be used to set Framework Version in UserAgent
        /// </summary>
        private const string FXVERSION = "FxVersion";
        private const string OSNAME = "OSName";
        private const string OSVERSION = "OSVersion";

        /// <summary>
        /// Indicates whether the ServiceClient has been disposed. 
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Field used for ClientVersion property
        /// </summary>
        private string _clientVersion;
        
        /// <summary>
        /// Field used for Framework Version property
        /// </summary>
        private string _fxVersion;

#if net45
        /// <summary>
        /// Indicates OS Name
        /// </summary>
        private string _osName;

        /// <summary>
        /// Indicates OS Version
        /// </summary>
        private string _osVersion;

        /// <summary>
        /// Gets Os Information, OSName - OS Major.Minor.Build version
        /// e.g. Windows 10 Enterprise - 6.3.14393
        /// </summary>
        private string OsName
        {
            get
            {  
                if(string.IsNullOrEmpty(_osName))
                {
                    _osName = ReadHKLMRegistry(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
                }

                // If you want to log OsName in userAgent, it has to be without spaces
                if (!string.IsNullOrEmpty(_osName))
                {
                    _osName = _osName.Replace(" ", "_");
                }

                return _osName;
            }
        }
        
        /// <summary>
        /// Gets Os Major.Minor.Build version
        /// e.g. 6.3.14393
        /// </summary>
        private string OsVersion
        {
            get
            {
                if (string.IsNullOrEmpty(_osVersion))
                {   
                    string osMajorMinorVersion = ReadHKLMRegistry(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentVersion");
                    string osBuildNumber = ReadHKLMRegistry(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild");
                    _osVersion = string.Format("{0}.{1}", osMajorMinorVersion, osBuildNumber);
                }

                return _osVersion;
            }
        }

        /// <summary>
        /// Reads HKLM registry key from the provided path/key combination
        /// </summary>
        /// <param name="path">Path to HKLM key</param>
        /// <param name="key">HKLM key name</param>
        /// <returns>Value for provided HKLM key</returns>
        private string ReadHKLMRegistry(string path, string key)
        {
            try
            {
                using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(path))
                {
                    if (rk == null) return "";
                    return (string)rk.GetValue(key);
                }
            }
            catch { return ""; }
        }
#endif

        /// <summary>
        /// Gets the AssemblyInformationalVersion if available
        /// if not it gets the AssemblyFileVerion
        /// if neither are available it will default to the Assembly Version of a service client.
        /// </summary>
        private string ClientVersion
        {
            get
            {
                if (string.IsNullOrEmpty(_clientVersion))
                {
                    Type type = this.GetType();
                    Assembly assembly = type.GetTypeInfo().Assembly;

                    try
                    {
                        // try to get AssemblyInformationalVersion first
                        AssemblyInformationalVersionAttribute aivAttribute =
                                assembly.GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute;
                        _clientVersion = aivAttribute?.InformationalVersion;

                        // if not available try to get AssemblyFileVersion
                        if (String.IsNullOrEmpty(_clientVersion))
                        {
                            AssemblyFileVersionAttribute fvAttribute =
                                assembly.GetCustomAttribute(typeof(AssemblyFileVersionAttribute)) as AssemblyFileVersionAttribute;
                            _clientVersion = fvAttribute?.Version;
                        }
                    }
                    catch (AmbiguousMatchException)
                    {
                        // in case there are more then one attribute of the type
                    }

                    // no usable version attribute found so default to Assembly Version
                    if (String.IsNullOrEmpty(_clientVersion))
                    {
                        _clientVersion =
                            assembly
                                .FullName
                                .Split(',')
                                .Select(c => c.Trim())
                                .First(c => c.StartsWith("Version=", StringComparison.OrdinalIgnoreCase))
                                .Substring("Version=".Length);
                    }

                }
                return _clientVersion;
            }
        }

        /// <summary>
        /// Get file version for System.dll
        /// </summary>
        private string FrameworkVersion
        {
            get
            {
                if (string.IsNullOrEmpty(_fxVersion))
                {
                    Assembly assembly = typeof(Object).GetTypeInfo().Assembly;                    
                    AssemblyFileVersionAttribute fvAttribute =
                                assembly.GetCustomAttribute(typeof(AssemblyFileVersionAttribute)) as AssemblyFileVersionAttribute;
                    _fxVersion = fvAttribute?.Version;
                }
        
                return _fxVersion;
            }
        }

        /// <summary>
        /// Reference to the first HTTP handler (which is the start of send HTTP
        /// pipeline).
        /// </summary>
        protected HttpMessageHandler FirstMessageHandler { get; set; }

        /// <summary>
        /// Reference to the innermost HTTP handler (which is the end of send HTTP
        /// pipeline).
        /// </summary>
        protected HttpClientHandler HttpClientHandler { get; set; }

        /// <summary>
        /// Initializes a new instance of the ServiceClient class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "The created objects should be disposed on caller's side")]
        protected ServiceClient()
            : this(CreateRootHandler())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ServiceClient class.
        /// </summary>
        /// <param name="handlers">List of handlers from top to bottom (outer handler is the first in the list)</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "The created objects should be disposed on caller's side")]
        protected ServiceClient(params DelegatingHandler[] handlers)
            : this(CreateRootHandler(), handlers)
        {
        }

        /// <summary>
        /// Initializes ServiceClient using base HttpClientHandler and list of handlers.
        /// </summary>
        /// <param name="rootHandler">Base HttpClientHandler.</param>
        /// <param name="handlers">List of handlers from top to bottom (outer handler is the first in the list)</param>
        protected ServiceClient(HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            InitializeHttpClient(rootHandler, handlers);
        }

        /// <summary>
        /// Create a new instance of the root handler.
        /// </summary>
        /// <returns>HttpClientHandler created.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "The created objects should be disposed on caller's side")]
        protected static HttpClientHandler CreateRootHandler()
        {
            // Create our root handler
#if NET45
            return new WebRequestHandler();
#else
            return new HttpClientHandler();
#endif
        }

        /// <summary>
        /// Gets the HttpClient used for making HTTP requests.
        /// </summary>
        public HttpClient HttpClient { get; protected set; }

        /// <summary>
        /// Gets the UserAgent collection which can be augmented with custom
        /// user agent strings.
        /// </summary>
        public virtual HttpHeaderValueCollection<ProductInfoHeaderValue> UserAgent
        {
            get { return HttpClient.DefaultRequestHeaders.UserAgent; }
        }

        /// <summary>
        /// Get the HTTP pipelines for the given service client.
        /// </summary>
        /// <returns>The client's HTTP pipeline.</returns>
        public virtual IEnumerable<HttpMessageHandler> HttpMessageHandlers
        {
            get
            {
                var handler = FirstMessageHandler;

                while (handler != null)
                {
                    yield return handler;

                    DelegatingHandler delegating = handler as DelegatingHandler;
                    handler = delegating != null ? delegating.InnerHandler : null;
                }
            }
        }

        /// <summary>
        /// Sets retry policy for the client.
        /// </summary>
        /// <param name="retryPolicy">Retry policy to set.</param>
        public virtual void SetRetryPolicy(RetryPolicy retryPolicy)
        {
            if (retryPolicy == null)
            {
                retryPolicy = new RetryPolicy<TransientErrorIgnoreStrategy>(0);
            }

            RetryDelegatingHandler delegatingHandler =
                HttpMessageHandlers.OfType<RetryDelegatingHandler>().FirstOrDefault();
            if (delegatingHandler != null)
            {
                delegatingHandler.RetryPolicy = retryPolicy;
            }
            else
            {
                throw new InvalidOperationException(ClientRuntime.Properties.Resources.ExceptionRetryHandlerMissing);
            }
        }

        /// <summary>
        /// Dispose the ServiceClient.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose the HttpClient and Handlers.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to releases only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                // Dispose the client
                HttpClient.Dispose();
                HttpClient = null;
                FirstMessageHandler = null;
                HttpClientHandler = null;
            }
        }

        /// <summary>
        /// Initializes HttpClient using HttpClientHandler.
        /// </summary>
        /// <param name="httpClientHandler">Base HttpClientHandler.</param>
        /// <param name="handlers">List of handlers from top to bottom (outer handler is the first in the list)</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "We let HttpClient instance dispose")]
        protected void InitializeHttpClient(HttpClientHandler httpClientHandler, params DelegatingHandler[] handlers)
        {
            HttpClientHandler = httpClientHandler;
            DelegatingHandler currentHandler = new RetryDelegatingHandler();
            currentHandler.InnerHandler = HttpClientHandler;

            if (handlers != null)
            {
                for (int i = handlers.Length - 1; i >= 0; --i)
                {
                    DelegatingHandler handler = handlers[i];
                    // Non-delegating handlers are ignored since we always 
                    // have RetryDelegatingHandler as the outer-most handler
                    while (handler.InnerHandler is DelegatingHandler)
                    {
                        handler = handler.InnerHandler as DelegatingHandler;
                    }
                    handler.InnerHandler = currentHandler;
                    currentHandler = handlers[i];
                }
            }

            var newClient = new HttpClient(currentHandler, false);
            FirstMessageHandler = currentHandler;
            HttpClient = newClient;
            Type type = this.GetType();
            SetUserAgent(type.FullName, ClientVersion);
        }
        
        /// <summary>
        /// Sets the product name to be used in the user agent header when making requests
        /// </summary>
        /// <param name="productName">Name of the product to be used in the user agent</param>
        public bool SetUserAgent(string productName)
        {
            return SetUserAgent(productName, ClientVersion);
        }

        /// <summary>
        /// Sets the product name and version to be used in the user agent header when making requests
        /// </summary>
        /// <param name="productName">Name of the product to be used in the user agent</param>
        /// <param name="version">Version of the product to be used in the user agent</param>
        public bool SetUserAgent(string productName, string version)
        {
            if (!_disposed && HttpClient != null)
            {
                SetDefaultUserAgentInfo();
                HttpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productName, version));
                return true;
            }

            // Returns false if the HttpClient was disposed before invoking the method
            return false;
        }

        /// <summary>
        /// Set Default information in User Agent
        /// </summary>
        /// <returns></returns>
        private void SetDefaultUserAgentInfo()
        {
            HttpClient.DefaultRequestHeaders.UserAgent.Clear();
            HttpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(FXVERSION, FrameworkVersion));
#if net45
            // If you want to log ProductName in userAgent, it has to be without spaces
            HttpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(OsName, OsVersion));
#endif
        }
    }
}
