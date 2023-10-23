// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// TBD
    /// </summary>
    public class RequestContentExtensions
    {
        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a <see cref="IModel{T}"/>.
        /// </summary>
        /// <param name="model">The <see cref="IModel{T}"/> to write.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a a <see cref="IModel{T}"/>.</returns>
        public static RequestContent Create(IModel<object> model, ModelReaderWriterOptions? options = default)
            => new PipelineContentContent(PipelineContent.CreateContent(model, options ?? ModelReaderWriterOptions.DefaultWireOptions));

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a <see cref="IJsonModel{T}"/>.
        /// </summary>
        /// <param name="model">The <see cref="IJsonModel{T}"/> to write.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a <see cref="IJsonModel{T}"/>.</returns>
        public static RequestContent Create(IJsonModel<object> model, ModelReaderWriterOptions? options = default)
            => new PipelineContentContent(PipelineContent.CreateContent(model, options ?? ModelReaderWriterOptions.DefaultWireOptions));

        private sealed class PipelineContentContent : RequestContent
        {
            private readonly PipelineContent _content;
            public PipelineContentContent(PipelineContent content)
            {
                _content = content;
            }

            public override void Dispose()
            {
                _content?.Dispose();
            }

            public override bool TryComputeLength(out long length)
            {
                return _content.TryComputeLength(out length);
            }

            public override void WriteTo(Stream stream, CancellationToken cancellationToken)
            {
                _content.WriteTo(stream, cancellationToken);
            }
            public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
            {
                await _content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
