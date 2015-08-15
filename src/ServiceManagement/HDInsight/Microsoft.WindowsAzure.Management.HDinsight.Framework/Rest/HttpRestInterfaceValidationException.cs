namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System;

    /// <summary>
    /// An exception thrown when interface validation fails.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "Not Serialized"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly", Justification = "Not serialized"), Serializable]
    public class HttpRestInterfaceValidationException : Exception
    {
        /// <summary>
        /// The error code.
        /// </summary>
        private readonly HttpRestInterfaceValidationErrorCode _errorCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRestInterfaceValidationException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="message">The message.</param>
        public HttpRestInterfaceValidationException(HttpRestInterfaceValidationErrorCode errorCode, string message)
            : base(message)
        {
            this._errorCode = errorCode;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        public HttpRestInterfaceValidationErrorCode ErrorCode
        {
            get { return this._errorCode; }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*" />
        /// </PermissionSet>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Not localized", MessageId = "System.String.Format(System.String,System.Object,System.Object)")]
        public override string ToString()
        {
            return string.Format("Error code: {0}, Message = {1}", this._errorCode, this.Message);
        }
    }
}