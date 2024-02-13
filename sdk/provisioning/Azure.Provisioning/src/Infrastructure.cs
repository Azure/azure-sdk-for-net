// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;

namespace Azure.Provisioning
{
    /// <summary>
    /// A class representing a set of <see cref="IConstruct"/> that make up the Azure infrastructure.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Infrastructure : Construct
#pragma warning restore AZC0012 // Avoid single word type names
    {
        internal static readonly string Seed = Environment.GetEnvironmentVariable("AZURE_ENV_NAME") ?? throw new Exception("No environment variable found named 'AZURE_ENV_NAME'");

        /// <summary>
        /// Initializes a new instance of the <see cref="Infrastructure"/> class.
        /// </summary>
        /// <param name="constructScope">The <see cref="ConstructScope"/> to use for the root <see cref="IConstruct"/>.</param>
        /// <param name="tenantId">The tenant id to use.  If not passed in will try to load from AZURE_TENANT_ID environment variable.</param>
        /// <param name="subscriptionId">The subscription id to use.  If not passed in will try to load from AZURE_SUBSCRIPTION_ID environment variable.</param>
        public Infrastructure(ConstructScope constructScope = ConstructScope.Subscription, Guid? tenantId = null, Guid? subscriptionId = null)
            : base(null, "default", constructScope, tenantId, subscriptionId)
        {
        }

        /// <summary>
        /// Converts the infrastructure to Bicep files.
        /// </summary>
        /// <param name="outputPath">Path to put the files.</param>
        public void Build(string? outputPath = null)
        {
            outputPath ??= $".\\{GetType().Name}";
            outputPath = Path.GetFullPath(outputPath);

            WriteBicepFile(this, outputPath);

            var queue = new Queue<IConstruct>();
            queue.Enqueue(this);
            WriteConstructsByLevel(queue, outputPath);
        }

        private void WriteConstructsByLevel(Queue<IConstruct> constructs, string outputPath)
        {
            while (constructs.Count > 0)
            {
                var construct = constructs.Dequeue();
                foreach (var child in construct.GetConstructs(false))
                {
                    constructs.Enqueue(child);
                }
                WriteBicepFile(construct, outputPath);
            }
        }

        private string GetFilePath(IConstruct construct, string outputPath)
        {
            string fileName = object.ReferenceEquals(construct, this) ? Path.Combine(outputPath, "main.bicep") : Path.Combine(outputPath, "resources", construct.Name, $"{construct.Name}.bicep");
            Directory.CreateDirectory(Path.GetDirectoryName(fileName)!);
            return fileName;
        }

        private void WriteBicepFile(IConstruct construct, string outputPath)
        {
            using var stream = new FileStream(GetFilePath(construct, outputPath), FileMode.Create);
#if NET6_0_OR_GREATER
            stream.Write(ModelReaderWriter.Write(construct, new ModelReaderWriterOptions("bicep")));
#else
            BinaryData data = ModelReaderWriter.Write(construct, new ModelReaderWriterOptions("bicep"));
            var buffer = data.ToArray();
            stream.Write(buffer, 0, buffer.Length);
#endif
        }
    }
}
