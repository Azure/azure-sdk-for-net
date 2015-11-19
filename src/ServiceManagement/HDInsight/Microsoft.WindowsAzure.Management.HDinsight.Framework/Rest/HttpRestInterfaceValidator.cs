namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    /// <summary>
    /// A class to validate the interface for which a proxy would be generated for.
    /// </summary>
    internal static class HttpRestInterfaceValidator
    {
        /// <summary>
        /// Writes the error message to list.
        /// </summary>
        /// <param name="isNotError">If set to <c>true</c> [is not error].</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="messages">The messages.</param>
        /// <param name="throwOnError">If set to <c>true</c> [throw on error].</param>
        /// <exception cref="Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.HttpRestInterfaceValidationException">When throwOnError is true and isNotError is false.</exception>
        private static void WriteErrorMessageToList(bool isNotError, HttpRestInterfaceValidationErrorCode errorCode, string errorMessage, List<string> messages, bool throwOnError)
        {
            if (!isNotError)
            {
                messages.Add(errorMessage);
            }
            if (throwOnError && !isNotError)
            {
                throw new HttpRestInterfaceValidationException(errorCode, errorMessage);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Not localized", MessageId = "System.String.Format(System.String,System.Object)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Not localized", MessageId = "System.String.Format(System.String,System.Object,System.Object)")]
        private static bool ValidateUriTemplate(UriTemplate template, string httpMethod, MethodInfo interfaceMethod, List<string> validationErrorMessages, bool throwOnError)
        {
            IEnumerable<string> variableNames = template.PathSegmentVariableNames.Concat(template.QueryValueVariableNames);
            ParameterInfo[] parameters = interfaceMethod.GetParameters();
            bool retVal = true;
            foreach (string variableName in variableNames)
            {
                //Case insensitive comparison because this could be used within VB, and in VB the parameters have an option to case insensitive
                var parameter =
                    parameters.SingleOrDefault(
                        param => param.Name.Equals(variableName, StringComparison.OrdinalIgnoreCase));
                bool variableIsBound = parameter != null;
                WriteErrorMessageToList(variableIsBound, HttpRestInterfaceValidationErrorCode.MethodHasAnUnboundUriParameterInTemplate,  string.Format("The operation '{0}' has a uri template variable '{1}' that does not have a matching variable name", interfaceMethod.Name, variableName), validationErrorMessages, throwOnError);
                retVal &= variableIsBound;

                if (parameter != null)
                {
                    bool uriBindingParameterIsStringType = parameter.ParameterType == typeof(string);
                    WriteErrorMessageToList(
                        uriBindingParameterIsStringType,
                        HttpRestInterfaceValidationErrorCode
                                                .RestInvokeAttributeHasANonStringParamUsedForUriBinding, 
                                                string.Format("The operation '{0}' has a uri template variable '{1}' that is not string type used for binding uri template variable names. You can only use string types in query strings or Uri fragments", interfaceMethod.Name, variableName), validationErrorMessages, throwOnError);
                    retVal &= uriBindingParameterIsStringType;
                }
            }
            int numUnboundParametersAllowed = httpMethod == "GET" ? 0 : 1;

            var unboundParameters =
                interfaceMethod.GetParameters()
                               .Where(
                                   param =>
                                   !variableNames.Any(
                                       v => v.Equals(param.Name, StringComparison.OrdinalIgnoreCase)))
                                       .Where(v => v.ParameterType != typeof(CancellationToken)).ToList();
            
            bool atmostonerequestparambound = unboundParameters.Count() <= numUnboundParametersAllowed;
            WriteErrorMessageToList(atmostonerequestparambound,
                                            HttpRestInterfaceValidationErrorCode
                                                .MethodHasUnboundParameters,
                                            string.Format(
                                                "The operation '{0}' has  uri template variables '{1}' can have at most 1 variable that is not bound to the Uri and isn't a cancellation token",
                                                interfaceMethod.Name, string.Join(",", unboundParameters.Select(p => p.Name))), 
                                                validationErrorMessages,
                                            throwOnError);
            retVal &= atmostonerequestparambound;

            bool hasLessThanEqual1CancellationToken = interfaceMethod.GetParameters().Count(p => p.ParameterType == typeof(CancellationToken)) <= 1;

            WriteErrorMessageToList(hasLessThanEqual1CancellationToken,
                HttpRestInterfaceValidationErrorCode.MethodHasMoreThanOneCancellationToken,
                string.Format("The method '{0}' has more than one cancellation token specified in its parameter list", interfaceMethod.Name),
                validationErrorMessages, throwOnError);
            retVal &= hasLessThanEqual1CancellationToken;

            return retVal;
        }

        /// <summary>
        /// Validates the interface method.
        /// </summary>
        /// <param name="methodInfo">The method info.</param>
        /// <param name="validationErrorMessages">The validation error messages.</param>
        /// <param name="throwOnError">If set to <c>true</c> [throw on error].</param>
        /// <returns>True if the method is valid.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Not localized", MessageId = "System.String.Format(System.String,System.Object)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Validated by method", MessageId = "0"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", Justification = "Test code", MessageId = "2#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Test code", MessageId = "1#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Avoids repetition")]
        public static bool ValidateInterfaceMethod(MethodInfo methodInfo, out List<string> validationErrorMessages, bool throwOnError = false)
        {
            bool retVal = true;
            validationErrorMessages = new List<string>();
            bool isNotGeneric = !methodInfo.GetGenericArguments().Any();
            retVal &= isNotGeneric;
            string methodName = methodInfo.Name;
            WriteErrorMessageToList(isNotGeneric, HttpRestInterfaceValidationErrorCode.MethodContainsGenericTypeArguments, string.Format("The method '{0}' contains generic type arguments. This is not allowed!", methodInfo.Name), validationErrorMessages, throwOnError);

            bool hasExactlyOneRestInvokeAttribute = methodInfo.GetCustomAttributes<HttpRestInvoke>(true).Count() == 1;
            WriteErrorMessageToList(hasExactlyOneRestInvokeAttribute, HttpRestInterfaceValidationErrorCode.MethodDoesNotHaveARestInvokeAttribute,  string.Format("The method '{0}' has no HttpRestInvoke attribute applied to it!", methodName), validationErrorMessages, throwOnError);
            retVal &= hasExactlyOneRestInvokeAttribute;
            
            if (retVal)
            {
                var httpRestInvoke = methodInfo.GetCustomAttribute<HttpRestInvoke>();

                bool httpMethodIsNotNull = !String.IsNullOrEmpty(httpRestInvoke.HttpMethod);
                WriteErrorMessageToList(httpMethodIsNotNull, HttpRestInterfaceValidationErrorCode.RestInvokeAttributeHasANullOrEmptyForHttpMethod,  string.Format("HttpMethod argument on HttpRestInvokeAttribute on method '{0}' is null or empty . This is not allowed!", methodInfo.Name), validationErrorMessages, throwOnError);
                retVal &= httpMethodIsNotNull;
                if (httpMethodIsNotNull)
                {
                    bool hasValidUritemplate = httpRestInvoke.UriTemplate != null &&
                                               ValidateUriTemplate(new UriTemplate(httpRestInvoke.UriTemplate), httpRestInvoke.HttpMethod,
                                                                   methodInfo, validationErrorMessages, throwOnError);
                    retVal &= hasValidUritemplate;
                }
            }

            bool hasRequestSerializer = methodInfo.GetCustomAttributes(false).OfType<IRequestFormatter>().Any() ||
                                        methodInfo.DeclaringType.GetCustomAttributes(false)
                                                  .OfType<IRequestFormatter>()
                                                  .Any();

            bool hasResponseSerializer = methodInfo.GetCustomAttributes(false).OfType<IResponseFormatter>().Any() ||
                                       methodInfo.DeclaringType.GetCustomAttributes(false)
                                                 .OfType<IResponseFormatter>()
                                                 .Any();

            bool hasAtMost1RequestFormatterAtMethodLevel = methodInfo.GetCustomAttributes(false).OfType<IRequestFormatter>()
                                                           .Count() <= 1;

            bool hasExactlyOneResponseFormatter = methodInfo.GetCustomAttributes(false).OfType<IResponseFormatter>()
                                                            .Count() <= 1;

            WriteErrorMessageToList(hasRequestSerializer, HttpRestInterfaceValidationErrorCode.MethodHasNoRequestFormatter,  string.Format("The method '{0}' does not have a request formatter attached to it. Either declare one globally at the interface level or for this method!", methodName), validationErrorMessages, throwOnError);
            retVal &= hasRequestSerializer;

            WriteErrorMessageToList(hasResponseSerializer, HttpRestInterfaceValidationErrorCode.MethodHasNoResponseFormatter,  string.Format("The method '{0}' does not have a request formatter attached to it. Either declare one globally at the interface level or for this method!", methodName), validationErrorMessages, throwOnError);
            retVal &= hasResponseSerializer;

            WriteErrorMessageToList(hasAtMost1RequestFormatterAtMethodLevel, HttpRestInterfaceValidationErrorCode.MethodHasMoreThaneOneRequestFormatter, string.Format("The method '{0}' has more than one IRequestFormatter attached to it", methodName), validationErrorMessages, throwOnError);
            retVal &= hasAtMost1RequestFormatterAtMethodLevel;

            WriteErrorMessageToList(hasExactlyOneResponseFormatter, HttpRestInterfaceValidationErrorCode.MethodHasMoreThanOneResponseFormatter, string.Format("The method '{0}' has more than one IResponseFormatter attached to it", methodName), validationErrorMessages, throwOnError);
            retVal &= hasExactlyOneResponseFormatter;

            foreach (var parameterInfo in methodInfo.GetParameters())
            {
                retVal &= ValidateParameter(methodInfo, parameterInfo, validationErrorMessages, throwOnError);
            }

            return retVal;
        }

        /// <summary>
        /// Returns true if the Interface method is proxy genration compliant.
        /// </summary>
        /// <param name="methodInfo">The method info.</param>
        /// <param name="throwOnError">If set to <c>true</c> [throw on error].</param>
        /// <returns>True if the interface method is valid.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Avoids too much repetition")]
        public static bool ValidateInterfaceMethod(MethodInfo methodInfo, bool throwOnError = false)
        {
            List<string> errorMessages;
            return ValidateInterfaceMethod(methodInfo, out errorMessages, throwOnError);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Avoids too much repetition", MessageId = "System.String.Format(System.String,System.Object,System.Object)")]
        private static bool ValidateParameter(MethodInfo methodInfo, ParameterInfo parameterInfo, List<string> validationErrorMessages, bool throwOnError = false)
        {
            bool retVal = true;
            bool notOptional = !parameterInfo.IsOptional;
            retVal &= notOptional;
            WriteErrorMessageToList(notOptional, HttpRestInterfaceValidationErrorCode.MethodContainsOptParameter,  string.Format("The method '{0}' contains an optional parameter '{1}' . This is not allowed!", methodInfo.Name, parameterInfo.Name), validationErrorMessages, throwOnError);
            bool notOut = !parameterInfo.IsOut;
            retVal &= notOut;
            WriteErrorMessageToList(notOut, HttpRestInterfaceValidationErrorCode.MethodContainsOutParameter,  string.Format("The method '{0}' contains an out parameter '{1}' . This is not allowed!", methodInfo.Name, parameterInfo.Name), validationErrorMessages, throwOnError);

            bool notRef = !parameterInfo.ParameterType.IsByRef;
            WriteErrorMessageToList(notRef, HttpRestInterfaceValidationErrorCode.MethodContainsRefParameter,  string.Format("The method '{0}' contains a ref parameter '{1}' . This is not allowed!", methodInfo.Name, parameterInfo.Name), validationErrorMessages, throwOnError);
            retVal &= notRef;
            return retVal;
        }

        /// <summary>
        /// Validates the interface to be conformant to automatic proxy generation.
        /// </summary>
        /// <typeparam name="T">An interface type.</typeparam>
        /// <param name="validationErrors">The validation errors.</param>
        /// <param name="throwOnError">If set to <c>true</c> [throw on error].</param>
        /// <returns>A boolean indicating whether the interface is valid.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", Justification = "Avoids too much repetition of code.", MessageId = "0#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Test code", MessageId = "2#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "HttpVerb")]
        public static bool ValidateInterface<T>(out List<string> validationErrors, bool throwOnError = false)
        {
            return ValidateInterface(typeof(T), out validationErrors, throwOnError);
        }

        /// <summary>
        /// Validates the interface to be conformant to automatic proxy generation.
        /// </summary>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <param name="validationErrors">The validation errors.</param>
        /// <param name="throwOnError">If set to <c>true</c> [throw on error].</param>
        /// <returns>Returns true if the interface is valid.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Correct", MessageId = "System.String.Format(System.String,System.Object,System.Object)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "correct")]
        public static bool ValidateInterface(Type interfaceType, out List<string> validationErrors, bool throwOnError = false)
        {
            Contract.Requires<ArgumentNullException>(interfaceType != null);

            bool retVal = true;
            validationErrors = new List<string>();
            string typeName = interfaceType.Name;

            bool isInterface = interfaceType.IsInterface;
            retVal &= isInterface;
            WriteErrorMessageToList(isInterface, HttpRestInterfaceValidationErrorCode.IsNotInterfaceType,  string.Format("The type '{0}' is not an interface", typeName), validationErrors, throwOnError);

            bool hasHttpDefinitionAttribute = interfaceType.GetCustomAttributes(typeof(HttpRestDefinitionAttribute), false).Any();
            WriteErrorMessageToList(hasHttpDefinitionAttribute, HttpRestInterfaceValidationErrorCode.InterfaceDoesNotHaveRestDefinitionAttribute,  string.Format("The interface '{0}' does not have an HttpRestDefinitionAttribute attribute applied to it", typeName), validationErrors, throwOnError);
            retVal &= hasHttpDefinitionAttribute;

            bool doesNotInheritsFromOthers = !(interfaceType.GetInterfaces().Any() || interfaceType.BaseType != null);
            WriteErrorMessageToList(doesNotInheritsFromOthers, HttpRestInterfaceValidationErrorCode.InterfaceInheritsFromOthers,  String.Format("The type '{0}' inherits from other types. This not allowed", typeName), validationErrors, throwOnError);
            retVal &= doesNotInheritsFromOthers;

            bool doesNotContainProperties = !interfaceType.GetProperties().Any();
            WriteErrorMessageToList(doesNotContainProperties, HttpRestInterfaceValidationErrorCode.InterfaceContainsPropertyDefinitions, String.Format("The type '{0}' contains property definitions. This not allowed", typeName), validationErrors, throwOnError);
            retVal &= doesNotContainProperties;

            HashSet<string> methodNamesSoFar = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var method in interfaceType.GetMethods().Where(meth => !meth.IsSpecialName))
            {
                bool interfaceDoesNotContainOverloadsForTheSameMethod = methodNamesSoFar.Add(method.Name);
                WriteErrorMessageToList(interfaceDoesNotContainOverloadsForTheSameMethod, HttpRestInterfaceValidationErrorCode.InterfaceContainersOverloads, 
                    string.Format("The interface '{0}' contains at least one overload for the following method '{1}'. This is not permitted", interfaceType.Name, method.Name), validationErrors, throwOnError);
                retVal &= interfaceDoesNotContainOverloadsForTheSameMethod;

                List<string> methodValidationErrors = new List<string>();
                retVal &= ValidateInterfaceMethod(method, out methodValidationErrors, throwOnError);
                validationErrors.AddRange(methodValidationErrors);
            }
            
            return retVal;
        }

        /// <summary>
        /// Validates the interface.
        /// </summary>
        /// <typeparam name="T">Interface type.</typeparam>
        /// <param name="throwOnError">If set to <c>true</c> [throw on error].</param>
        /// <returns>True if the interface is valid.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Avoids repetition")]
        public static bool ValidateInterface<T>(bool throwOnError = false)
        {
            List<string> errors = new List<string>();
            return ValidateInterface<T>(out errors, throwOnError);
        }

        /// <summary>
        /// Validates the interface.
        /// </summary>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <param name="throwOnError">If set to <c>true</c> [throw on error].</param>
        /// <returns>Bool indicating whether the validation succeeded.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Design choice")]
        public static bool ValidateInterface(Type interfaceType, bool throwOnError = false)
        {
            List<string> validationErrors = new List<string>();
            return ValidateInterface(interfaceType, out validationErrors, throwOnError);
        }
    }
}
