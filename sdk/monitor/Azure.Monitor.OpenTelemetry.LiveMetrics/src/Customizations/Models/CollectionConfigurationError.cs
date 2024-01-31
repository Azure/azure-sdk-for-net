namespace Microsoft.ApplicationInsights.Extensibility.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents an error while parsing and applying an instance of <see cref="CollectionConfigurationInfo"/>.
    /// </summary>
    [DataContract]
    internal class CollectionConfigurationError
    {
        [DataMember(Name = "CollectionConfigurationErrorType")]
        public string CollectionConfigurationErrorTypeForSerialization
        {
            get
            {
                return this.ErrorType.ToString();
            }

            set
            {
                CollectionConfigurationErrorType errorType;
                if (!Enum.TryParse(value, out errorType))
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        string.Format(CultureInfo.InvariantCulture, "Unsupported CollectionConfigurationErrorType value: {0}", value));
                }

                this.ErrorType = errorType;
            }
        }

        public CollectionConfigurationErrorType ErrorType { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string FullException { get; set; }

        [DataMember]
        public Dictionary<string, string> Data { get; set; }

        public static CollectionConfigurationError CreateError(
            CollectionConfigurationErrorType errorType,
            string message,
            Exception exception,
            params Tuple<string, string>[] data)
        {
            return new CollectionConfigurationError()
            {
                ErrorType = errorType,
                Message = message,
                FullException = exception?.ToString() ?? string.Empty,
                Data = data.ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2),
            };
        }
    }
}