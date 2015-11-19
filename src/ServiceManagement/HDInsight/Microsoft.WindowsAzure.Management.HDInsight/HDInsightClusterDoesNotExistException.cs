namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// Thrown when an operation is performed on a cluster that does not exist.
    /// </summary>
    [Serializable]
    public class HDInsightClusterDoesNotExistException : Exception
    {
        private const string DnsNameSerializationKey = "DNSNAME";

        private readonly string dnsName;

        /// <summary>
        /// Initializes a new instance of the <see cref="HDInsightClusterDoesNotExistException"/> class.
        /// </summary>
        public HDInsightClusterDoesNotExistException() 
            : this(string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HDInsightClusterDoesNotExistException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Taken care of by .net runtime.")]
        protected HDInsightClusterDoesNotExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.dnsName = info.GetString(DnsNameSerializationKey);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HDInsightClusterDoesNotExistException"/> class.
        /// </summary>
        /// <param name="dnsName">Name of the DNS.</param>
        public HDInsightClusterDoesNotExistException(string dnsName)
            : this(dnsName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HDInsightClusterDoesNotExistException"/> class.
        /// </summary>
        /// <param name="dnsName">Name of the DNS.</param>
        /// <param name="innerException">The inner exception.</param>
        public HDInsightClusterDoesNotExistException(string dnsName, Exception innerException)
            : base(string.Format(CultureInfo.InvariantCulture, "Cluster does not exist '{0}'", dnsName ?? string.Empty), innerException)
        {
            this.dnsName = dnsName;
        }

        /// <summary>
        /// Gets the name of the cluster that doesn't exist.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return this.dnsName; }
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue(DnsNameSerializationKey, this.dnsName ?? string.Empty);

            // MUST call through to the base class to let it save its own state
            base.GetObjectData(info, context);
        }
    }
}
