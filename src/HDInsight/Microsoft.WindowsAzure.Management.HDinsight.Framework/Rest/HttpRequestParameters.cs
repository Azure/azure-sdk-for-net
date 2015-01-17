namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    /// <summary>
    /// An internal class to store the parameters of a request obtained via reflection on the interface methods.
    /// </summary>
    internal class HttpRequestParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestParameters" /> class.
        /// </summary>
        /// <param name="verb">The verb.</param>
        /// <param name="template">The template.</param>
        /// <param name="requestFormatter">The request formatter.</param>
        /// <param name="responseFormatter">The response formatter.</param>
        /// <param name="cutomMessageProcessingHandler">The cutom message processing handler.</param>
        internal HttpRequestParameters(string verb, UriTemplate template, IRequestFormatter requestFormatter, IResponseFormatter responseFormatter, IEnumerable<IHttpMessageProcessingHandler> cutomMessageProcessingHandler)
        {
            Contract.Requires<ArgumentNullException>(verb != null);
            Contract.Requires<ArgumentNullException>(template != null);
            Contract.Requires<ArgumentNullException>(requestFormatter != null);
            Contract.Requires<ArgumentNullException>(responseFormatter != null);

            this.HttpMethod = verb;
            this.UriTemplate = template;
            this.RequestFormatter = requestFormatter;
            this.ResponseFormatter = responseFormatter;
            this.CutomMessageProcessingHandlers = new ReadOnlyCollection<IHttpMessageProcessingHandler>((
                cutomMessageProcessingHandler ?? Enumerable.Empty<IHttpMessageProcessingHandler>()).ToList());
            
        }

        /// <summary>
        /// Gets the HTTP method.
        /// </summary>
        /// <value>
        /// The HTTP method.
        /// </value>
        public string HttpMethod { get; private set; }

        /// <summary>
        /// Gets the URI template.
        /// </summary>
        /// <value>
        /// The URI template.
        /// </value>
        public UriTemplate UriTemplate { get; private set; }

        /// <summary>
        /// Gets the request serializer.
        /// </summary>
        /// <value>
        /// The request serializer.
        /// </value>
        public IRequestFormatter RequestFormatter { get; private set; }

        /// <summary>
        /// Gets the response serializer.
        /// </summary>
        /// <value>
        /// The response serializer.
        /// </value>
        public IResponseFormatter ResponseFormatter { get; private set; }

        /// <summary>
        /// Gets the cutom message processing handler.
        /// </summary>
        /// <value>
        /// The cutom message processing handler.
        /// </value>
        public IReadOnlyList<IHttpMessageProcessingHandler> CutomMessageProcessingHandlers { get; private set; }

        /// <summary>
        /// Froms the method info.
        /// </summary>
        /// <param name="interFaceMethod">The inter face method.</param>
        /// <returns>Creates an HttpRequestParameters from an instance.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "It's an error message.", MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Contract.Requires<System.ArgumentException>(System.Boolean,System.String)"), 
        System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", Justification = "Spelled correctly", MessageId = "MethodInfo"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "interfaceMethod", Justification = "Spelled correctly")]
        public static HttpRequestParameters FromMethodInfo(MethodInfo interFaceMethod)
        {
            Contract.Requires<ArgumentNullException>(interFaceMethod != null);
            Contract.Requires<ArgumentException>(interFaceMethod.DeclaringType.IsInterface, "interfaceMethod must be a MethodInfo of an interface");
            return CreateRequestParametersUsingReflection(interFaceMethod);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "It's an error message.", MessageId = "System.String.Format(System.String,System.Object)")]
        private static HttpRestInvoke ExtractHttpRestInvokeAttribute(MethodInfo interfacMethod)
        {
            var retVal = (HttpRestInvoke)interfacMethod.GetCustomAttributes(typeof(HttpRestInvoke), false).SingleOrDefault();
            if (retVal == null)
            {
                throw new ArgumentException(string.Format("HttpRestInvoke undefined on method {0}. Please define one", interfacMethod.Name));
            }
            return retVal;
        }

        private static T GetImplemention<T>(MethodInfo interfaceMethod)
            where T : class 
        {
            var methodRequestSerializer = interfaceMethod.GetCustomAttributes().OfType<T>().SingleOrDefault();
            if (methodRequestSerializer == null)
            {
                methodRequestSerializer =
                    interfaceMethod.DeclaringType.GetCustomAttributes().OfType<T>().SingleOrDefault();
            }
            return methodRequestSerializer;
        }

        /// <summary>
        /// Gets the request parameters from attribute.
        /// </summary>
        /// <param name="interfaceMethod">The class verb.</param>
        /// <returns>
        /// The target uri to execute the get or invoke against.
        /// </returns>
        private static HttpRequestParameters CreateRequestParametersUsingReflection(MethodInfo interfaceMethod)
        {
            var restInvokeAttr = ExtractHttpRestInvokeAttribute(interfaceMethod);

            //Look for the custom attributes that inhert from IHttpMessageprocessingHandler
            var customHttpMessageHanders = (IHttpMessageProcessingHandler[])interfaceMethod.GetCustomAttributes(typeof(IHttpMessageProcessingHandler), false);
            var requestParameters = new HttpRequestParameters(
                restInvokeAttr.HttpMethod,
                new UriTemplate(restInvokeAttr.UriTemplate),
                GetImplemention<IRequestFormatter>(interfaceMethod),
                GetImplemention<IResponseFormatter>(interfaceMethod), 
                customHttpMessageHanders);
            return requestParameters;
        }

        /// <summary>
        /// Binds the URI Template to a Uri based off the binding parameters.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="method">The verb.</param>
        /// <param name="methodArgumentsInOrder">The verb arguments in order.</param>
        /// <param name="methodParamsUseForUriBinding">The method params use for URI binding.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// A full uri with the parameters substituted.
        /// </returns>
        /// <exception cref="System.ArgumentException">Not all uri template variables were bound.</exception>
        public Uri BindUri(Uri baseUri, MethodInfo method, object[] methodArgumentsInOrder, out List<string> methodParamsUseForUriBinding, out CancellationToken token)
        {
            Contract.Requires<ArgumentNullException>(baseUri != null);
            Contract.Requires<ArgumentException>(baseUri.IsAbsoluteUri);
            Contract.Requires<ArgumentException>(methodArgumentsInOrder != null);

            IDictionary<string, string> parameterArgumentDictionary = GetParameterArgumentDictionary(method, this.UriTemplate, out token, methodArgumentsInOrder);
            methodParamsUseForUriBinding = parameterArgumentDictionary.Keys.ToList();

            //Check if every variable defined in the uri template found a corresponding parameter in the verb by the same name
            //This if should theoreticall be false always because ServiceInterfaceValidator is invoked in the construtor which does the
            //same validation and it provides more descriptive errors
            if (methodParamsUseForUriBinding.Count != this.UriTemplate.PathSegmentVariableNames.Count + this.UriTemplate.QueryValueVariableNames.Count)
            {
                throw new ArgumentException("Not all uri template variables were bound");
            }

            return this.UriTemplate.BindByName(baseUri, parameterArgumentDictionary);
        }

        private static IDictionary<string, string> GetParameterArgumentDictionary(MethodInfo info, UriTemplate uriTemplate, out CancellationToken token, object[] methodArgumentsInOrder)
        {
            IDictionary<string, string> retVal = new Dictionary<string, string>();
            ParameterInfo[] methodParametersInOrder = info.GetParameters();
            token = new CancellationToken(false);
            for (int i = 0; i < methodArgumentsInOrder.Length; i++)
            {
                if (uriTemplate.PathSegmentVariableNames.Any(variableName => methodParametersInOrder[i].Name.Equals(variableName, StringComparison.OrdinalIgnoreCase))
                    || uriTemplate.QueryValueVariableNames.Any(variableName => methodParametersInOrder[i].Name.Equals(variableName, StringComparison.OrdinalIgnoreCase)))
                {
                    retVal.Add(methodParametersInOrder[i].Name, (methodArgumentsInOrder[i] ?? string.Empty).ToString());
                }
                
                if (methodParametersInOrder[i].ParameterType == typeof(CancellationToken))
                {
                    if (methodArgumentsInOrder[i] == null)
                    {
                        throw new ArgumentNullException(methodParametersInOrder[i].Name, "Cancellation token cannot be null");
                    }

                    token = (CancellationToken)methodArgumentsInOrder[i];
                }
            }

            return retVal;
        }
        
    }
}
