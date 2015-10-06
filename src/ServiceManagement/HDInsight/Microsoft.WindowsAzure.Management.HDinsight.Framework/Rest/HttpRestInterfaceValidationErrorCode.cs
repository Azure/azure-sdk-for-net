namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    /// <summary>
    /// These are the validation error codes associated with validating an interface used to generate 
    /// the rest client for.
    /// </summary>
    public enum HttpRestInterfaceValidationErrorCode
    {
        /// <summary>
        /// The type is not interface type.
        /// </summary>
        IsNotInterfaceType,

        /// <summary>
        /// The variable is not bound.
        /// </summary>
        VariableIsNotBound,

        /// <summary>
        /// The method contains generic type arguments.
        /// </summary>
        MethodContainsGenericTypeArguments,

        /// <summary>
        /// The method does not have a rest invoke attribute.
        /// </summary>
        MethodDoesNotHaveARestInvokeAttribute,

        /// <summary>
        /// The rest invoke attribute has a null or emty for HTTP method.
        /// </summary>
        RestInvokeAttributeHasANullOrEmptyForHttpMethod,
        
        /// <summary>
        /// The method has an unbound URI parameter in template.
        /// </summary>
        MethodHasAnUnboundUriParameterInTemplate,

        /// <summary>
        /// The rest invoke attribute has a non string parameter used for URI binding.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Spelled correctly", MessageId = "ANon")]
        RestInvokeAttributeHasANonStringParamUsedForUriBinding,
        
        /// <summary>
        /// The method has no request formatter.
        /// </summary>
        MethodHasNoRequestFormatter,

        /// <summary>
        /// The method has no response formatter.
        /// </summary>
        MethodHasNoResponseFormatter,
        
        /// <summary>
        /// The method contains optional parameter.
        /// </summary>
        MethodContainsOptParameter,
        
        /// <summary>
        /// The method contains out parameter.
        /// </summary>
        MethodContainsOutParameter,
        
        /// <summary>
        /// The method contains reference parameter.
        /// </summary>
        MethodContainsRefParameter,
        
        /// <summary>
        /// The interface does not have rest definition attribute.
        /// </summary>
        InterfaceDoesNotHaveRestDefinitionAttribute,
        
        /// <summary>
        /// The interface inherits from others.
        /// </summary>
        InterfaceInheritsFromOthers,
        
        /// <summary>
        /// The interface contains property definitions.
        /// </summary>
        InterfaceContainsPropertyDefinitions,
        
        /// <summary>
        /// The method has more than one response formatter.
        /// </summary>
        MethodHasMoreThanOneResponseFormatter,
        
        /// <summary>
        /// The method has more thane one request formatter.
        /// </summary>
        MethodHasMoreThaneOneRequestFormatter,
        
        /// <summary>
        /// The method has more than one cancellation token.
        /// </summary>
        MethodHasMoreThanOneCancellationToken,

        /// <summary>
        /// The method has unbound parameters.
        /// </summary>
        MethodHasUnboundParameters,

        /// <summary>
        /// The interface containers overloads.
        /// </summary>
        InterfaceContainersOverloads
    }
}