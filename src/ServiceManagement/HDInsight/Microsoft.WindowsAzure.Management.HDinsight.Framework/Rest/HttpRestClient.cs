namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Reflection;
    using Microsoft.HDInsight.Net.Http.Formatting;

    /// <summary>
    /// An abstract class to inherit from to write a rest proxy against a service interface. 
    /// internal class DeploymentServiceProxy : RestProxy&lt;IDeploymentService &gt;.
    /// </summary>
    /// <typeparam name="TServiceInterface">The type of the service interface for which you need the proxy for.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1012:AbstractTypesShouldNotHaveConstructors", Justification = "This is so that the concrete types can have them.")]
    public abstract class HttpRestClient<TServiceInterface>
    {
        private readonly Uri _baseServiceUri;
        private readonly IDictionary<string, HttpRequestParameters> _methodToRequestParametersMap = new Dictionary<string, HttpRequestParameters>();
        private readonly HttpRestClientConfiguration _configuration;

        /// <summary>
        /// Gets the base service URI.
        /// </summary>
        /// <value>The base service URI.</value>
        public Uri BaseServiceUri
        {
            get { return this._baseServiceUri; }
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public HttpRestClientConfiguration Configuration
        {
            get { return this._configuration; }
        }
        
        private static string GetUniqueInterfaceMethodSignature(MethodInfo info)
        {
            var allNames = new List<string>();
            allNames.Add(info.Name);
            allNames.AddRange(info.GetParameters().Select(pInfo => pInfo.ParameterType.FullName));
            return string.Join("_", allNames);
        }

        private static IDictionary<string, HttpRequestParameters> BuildInterfaceMethodToParametersDictionary()
        {
            IEnumerable<MethodInfo> interfaceMethods = typeof(TServiceInterface).GetMethods()
                    .Where(method => HttpRestInterfaceValidator.ValidateInterfaceMethod(method));
            Dictionary<string, HttpRequestParameters> dictionary = interfaceMethods.ToDictionary(
                GetUniqueInterfaceMethodSignature, HttpRequestParameters.FromMethodInfo);
            return dictionary;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRestClient{TServiceInterface}"/> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="configuration">The configuration.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Validated", MessageId = "0")]
        public HttpRestClient(Uri baseUri, HttpRestClientConfiguration configuration)
        {
            Contract.Requires<ArgumentNullException>(baseUri != null);
            Contract.Requires<ArgumentNullException>(baseUri.IsAbsoluteUri);
            Contract.Requires<ArgumentException>(baseUri.Scheme.Equals(Uri.UriSchemeHttp) || baseUri.Scheme.Equals(Uri.UriSchemeHttps));

            this._baseServiceUri = baseUri;
            this._methodToRequestParametersMap = BuildInterfaceMethodToParametersDictionary();
            this._configuration = configuration;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "No need")]
        private HttpRequestMessage CreateHttpRequestMessage(HttpRequestParameters parameters, MethodInfo method, out CancellationToken cancellationToken, object[] methodArgumentsInOrder)
        {
            List<string> parameterNamesBoundToUri;
            var requestUri = parameters.BindUri(this._baseServiceUri, method, methodArgumentsInOrder, out parameterNamesBoundToUri, out cancellationToken);
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod(parameters.HttpMethod), requestUri);
           
            //The arguments when not used for uri binding either the request body or the cancellation token
            // the request body is serialized into the stream as the request body
            if (methodArgumentsInOrder.Length > parameterNamesBoundToUri.Count)
            {
                //This ordered as they appear in the method signature
                var parameterInfos = method.GetParameters();
                for (int i = 0; i < parameterInfos.Length; i++)
                {
                    var parameterName = parameterInfos[i].Name;
                    if (
                        !parameterNamesBoundToUri.Any(
                            paramName => paramName.Equals(parameterName, StringComparison.OrdinalIgnoreCase)))
                    {
                        if (parameterInfos[i].ParameterType != typeof(CancellationToken))
                        {
                            //Pick the unbound argument for request stream data
                            object dataToSerialize = methodArgumentsInOrder[i];
                            //serialize the data using the specified serializer into the request message
                            requestMessage.Content = new ObjectContent(dataToSerialize.GetType(), dataToSerialize, parameters.RequestFormatter.RequestFormatter);
                        }
                    }
                }
            }

            foreach (var formatter in parameters.ResponseFormatter.ResponseFormatters)
            {
                foreach (var mediaType in formatter.SupportedMediaTypes)
                {
                    requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType.MediaType));
                }
            }
            return requestMessage;
        }

        /// <summary>
        /// Creates the HTTP client by chaining all the handlers found in the interface method attributes and the http
        /// client configuration.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>An instance of HttpClient.</returns>
        private HttpClient CreateHttpClient(HttpRequestParameters parameters)
        {
            HttpMessageHandler rootHandler = this.Configuration.RootHandler;
            if (parameters.CutomMessageProcessingHandlers.Any())
            {
                IList<DelegatingHandler> handlers =
                    parameters.CutomMessageProcessingHandlers.Select(c => c.CreateHandler()).ToList();
                for (int i = 0; i < handlers.Count - 1; i++)
                {
                    handlers[i].InnerHandler = handlers[i + 1];
                }

                handlers.Last().InnerHandler = this.Configuration.RootHandler;
                rootHandler = handlers.First();
            }
            else
            {
                rootHandler = this.Configuration.RootHandler;
            }

            return new HttpClient(rootHandler, false);
        }

        /// <summary>
        /// Creates the and invoke rest request for caller based of its interface implementation.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="classMethod">The class verb.</param>
        /// <param name="methodArgumentsInOrder">The verb arguments in order.</param>
        /// <returns>A task.</returns>
        private async Task<T> InvokeHttpRestRequest<T>(MethodInfo classMethod, object[] methodArgumentsInOrder)
        {
            Contract.Requires<ArgumentNullException>(methodArgumentsInOrder != null);

            //Transform the reflected attributes from the method
            //Pull that information from the cache we created on construction
            var requestParametersFromMethod = this._methodToRequestParametersMap[GetUniqueInterfaceMethodSignature(classMethod)];
            Type returnType = null;
            if (classMethod.ReturnType.IsGenericType && classMethod.ReturnType.BaseType == typeof(Task))
            {
                returnType = classMethod.ReturnType.GetGenericArguments().Single();
            }
            else if (classMethod.ReturnType == typeof(void) || classMethod.ReturnType == typeof(Task))
            {
                returnType = typeof(void);
            }
            else
            {
                returnType = classMethod.ReturnType;
            }

            T retVal = default(T);
            for (int attempt = 1;; attempt++)
            {
                Exception lastException = null;
                TimeSpan delay = TimeSpan.MinValue;

                //Create the request message from the request parameters,i.e. set the headers and serialize the request
                CancellationToken cancellationToken;
                var requestMessage = this.CreateHttpRequestMessage(requestParametersFromMethod, classMethod, out cancellationToken, methodArgumentsInOrder);

                HttpClient client = this.CreateHttpClient(requestParametersFromMethod);
                client.Timeout = this.Configuration.HttpRequestTimeout;

                try
                {
                    using (var resp = await client.SendAsync(requestMessage, cancellationToken))
                    {
                        if (returnType == typeof(HttpResponseMessage))
                        {
                            return (T)(object)resp;
                        }

                        if (returnType != typeof(void))
                        {
                            retVal = (T)await resp.Content.ReadAsAsync(returnType, requestParametersFromMethod.ResponseFormatter.ResponseFormatters);
                            return retVal;
                        }

                        return default(T);
                    }
                }
                catch (Exception e)
                {
                    if (e is OperationCanceledException)
                    {
                        throw;
                    }

                    lastException = e;

                    if (!this.Configuration.RetryPolicy.ShouldRetry(e, attempt, out delay))
                    {
                        throw;
                    }
                }

                if (lastException != null)
                {
                    await Task.Delay(delay);
                }
            }
        }

        /// <summary>
        /// Creates and invokes the rest request for caller based of its interface definition.
        /// </summary>
        /// <param name="orderedArgumentsOfTheParentMethod">The ordered arguments of the parent verb.</param>
        /// <returns>A task.</returns>
        /// <remarks>Please be sure to dispose the HttpWebResponseObject after you are done with it.</remarks>
        protected Task<T> CreateAndInvokeRestRequestForParentMethodAsync<T>(params object[] orderedArgumentsOfTheParentMethod)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            //Get parent from the stackframe
            MethodInfo classMethod = (MethodInfo)stackFrame.GetMethod();
            return this.InvokeHttpRestRequest<T>(classMethod, orderedArgumentsOfTheParentMethod);
        }

        /// <summary>
        /// Creates and invokes the rest request for caller based of its interface definition.
        /// </summary>
        /// <param name="orderedArgumentsOfTheParentMethod">The ordered arguments of the parent verb.</param>
        /// <returns>A task.</returns>
        /// <remarks>Please be sure to dispose the HttpWebResponseObject after you are done with it.</remarks>
        protected Task CreateAndInvokeRestRequestForParentMethodAsync(params object[] orderedArgumentsOfTheParentMethod)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            //Get parent from the stackframe
            MethodInfo classMethod = (MethodInfo)stackFrame.GetMethod();
            return this.InvokeHttpRestRequest<object>(classMethod, orderedArgumentsOfTheParentMethod);
        }

        /// <summary>
        /// Creates and invokes the rest request for caller based of its interface definition.
        /// </summary>
        /// <param name="orderedArgumentsOfTheParentMethod">The ordered arguments of the parent verb.</param>
        /// <returns>A task.</returns>
        /// <remarks>Please be sure to dispose the HttpWebResponseObject after you are done with it.</remarks>
        protected object CreateAndInvokeRestRequestForParentMethod(params object[] orderedArgumentsOfTheParentMethod)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            //Get parent from the stackframe
            MethodInfo classMethod = (MethodInfo)stackFrame.GetMethod();
            return this.InvokeHttpRestRequest<object>(classMethod, orderedArgumentsOfTheParentMethod).GetAwaiter().GetResult();
        }
    }
}
