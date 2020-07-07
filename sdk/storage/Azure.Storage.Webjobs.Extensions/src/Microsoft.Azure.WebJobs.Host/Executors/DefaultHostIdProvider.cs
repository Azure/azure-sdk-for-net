// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Indexers;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    /// <summary>
    /// Provides a stable hash based Host ID calculation.
    /// </summary>
    internal class DefaultHostIdProvider : IHostIdProvider
    {
        private readonly ITypeLocator _typeLocator;
        private string _hostId;

        public DefaultHostIdProvider(ITypeLocator typeLocator)
        {
            _typeLocator = typeLocator;
        }

        public Task<string> GetHostIdAsync(CancellationToken cancellationToken)
        {
            if (_hostId == null)
            {
                _hostId = ComputeHostId();
            }
            return Task.FromResult(_hostId);
        }

        private string ComputeHostId()
        {
            // Search through all types for the first job method.
            // The reason we have to do this rather than attempt to use the entry assembly
            // (Assembly.GetEntryAssembly) is because that doesn't work for WebApps, and the
            // SDK supports both WebApp and Console app hosts.
            MethodInfo firstJobMethod = null;
            foreach (var type in _typeLocator.GetTypes())
            {
                firstJobMethod = FunctionIndexer.GetJobMethods(type).FirstOrDefault();
                if (firstJobMethod != null)
                {
                    break;
                }
            }

            // Compute hash and map to Guid
            // If the job host doesn't yet have any job methods (e.g. it's a new project)
            // then a default ID is generated
            string hostName = firstJobMethod?.DeclaringType.Assembly.FullName ?? "Unknown";
            Guid id;
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(hostName));
                id = new Guid(hash);
            }

            return id.ToString("N");
        }
    }
}
