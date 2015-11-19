namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Reflection;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CodeGen;

    /// <summary>
    /// A factory class to create and instantiate Concrete proxy implementations based off of a service interface at runtime.
    /// </summary>
    internal static class HttpRestClientFactory
    {
        /// <summary>
        /// We keep a cache of generated interface implemenations in this dictionary so that we don't have to regenerate them.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, Type> generatedImplemenationCache = new ConcurrentDictionary<Type, Type>();

        private static Type CreateConreteProxyImplementation<T>()
        {
            return generatedImplemenationCache.GetOrAdd(typeof(T), 
                requestedType =>
                {
                    var codeGenerator = new HttpRestClientCodeGenerator(requestedType);
                    string className = typeof(T).Name + "Implementation";
                    Assembly assembly = codeGenerator.GenerateAssembly(string.Empty, className);
                    Type runtimeType = assembly.GetTypes().Single(type => type.Name.Equals(className));
                    return runtimeType;
                });
        }

        /// <summary>
        /// Creates the Rest Client associated with the interface.
        /// </summary>
        /// <typeparam name="T">The REST interface.</typeparam>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>An instance of the rest client.</returns>
        public static T CreateClient<T>(Uri baseUri, HttpRestClientConfiguration configuration)
        {
            Type runtimeType = CreateConreteProxyImplementation<T>();
            //Call the constructor RestProxy(Uri, X509Certificate2, IWebProxy, Timespan)
            return (T)Activator.CreateInstance(runtimeType, new object[] { baseUri, configuration });
        }
    }
}
