namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries
{
    using System;
    using System.Reflection;

    internal sealed class ExceptionDispatchInfo
    {
        private readonly Exception exception;
        private readonly object source;
        private readonly string stackTrace;

        private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
        private static readonly FieldInfo RemoteStackTrace = typeof(Exception).GetField("_remoteStackTraceString", PrivateInstance);
        private static readonly FieldInfo Source = typeof(Exception).GetField("_source", PrivateInstance);
        private static readonly MethodInfo InternalPreserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace", PrivateInstance);

        private ExceptionDispatchInfo(Exception source)
        {
            this.exception = source;
            this.stackTrace = this.exception.StackTrace + Environment.NewLine;
            this.source = Source.GetValue(this.exception);
        }

        public Exception SourceException
        {
            get
            {
                return this.exception;
            }
        }

        public static ExceptionDispatchInfo Capture(Exception source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return new ExceptionDispatchInfo(source);
        }

        public void Throw()
        {
            try
            {
                throw this.exception;
            }
            catch
            {
                InternalPreserveStackTrace.Invoke(this.exception, new object[0]);
                RemoteStackTrace.SetValue(this.exception, this.stackTrace);
                Source.SetValue(this.exception, this.source);
                throw;
            }
        }
    }
}