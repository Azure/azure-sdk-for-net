namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest
{
    using System.Security.Cryptography.X509Certificates;

    internal abstract class HttpClientAbstractionFactoryBase : IHttpClientAbstractionFactory
    {
        /// <inheritdoc />
        public IHttpClientAbstraction Create(X509Certificate2 cert)
        {
            return this.Create(cert, false);
        }

        /// <inheritdoc />
        public IHttpClientAbstraction Create(X509Certificate2 cert, IAbstractionContext context)
        {
            return this.Create(cert, context, false);
        }

        /// <inheritdoc />
        public IHttpClientAbstraction Create(string token)
        {
            return this.Create(token, false);
        }

        /// <inheritdoc />
        public IHttpClientAbstraction Create(string token, IAbstractionContext context)
        {
            return this.Create(token, context, false);
        }

        /// <inheritdoc />
        public IHttpClientAbstraction Create()
        {
            return this.Create(false);
        }

        /// <inheritdoc />
        public IHttpClientAbstraction Create(IAbstractionContext context)
        {
            return this.Create(context, false);
        }

        /// <inheritdoc />
        public abstract IHttpClientAbstraction Create(X509Certificate2 cert, bool ignoreSslErrors);

        /// <inheritdoc />
        public abstract IHttpClientAbstraction Create(X509Certificate2 cert, IAbstractionContext context, bool ignoreSslErrors);

        /// <inheritdoc />
        public abstract IHttpClientAbstraction Create(string token, bool ignoreSslErrors);

        /// <inheritdoc />
        public abstract IHttpClientAbstraction Create(string token, IAbstractionContext context, bool ignoreSslErrors);

        /// <inheritdoc />
        public abstract IHttpClientAbstraction Create(bool ignoreSslErrors);

        /// <inheritdoc />
        public abstract IHttpClientAbstraction Create(bool ignoreSslErrors, bool allowAutoRedirect);

        /// <inheritdoc />
        public abstract IHttpClientAbstraction Create(IAbstractionContext context, bool ignoreSslErrors);
    }
}
