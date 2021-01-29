using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    public class DynamicContent : RequestContent
    {
        private DynamicJson _body;
        private readonly Encoding Utf8NoBom = new UTF8Encoding(false);

        internal DynamicContent(DynamicJson body)
        {
            _body = body;
        }

        internal static RequestContent Create(DynamicJson body)
            => new DynamicContent(body);

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            // TODO: this method must be optimized, i.e. DynamicJson writes directly to stream
            var json = _body.ToString();
            var utf8 = Utf8NoBom.GetBytes(json);
            await stream.WriteAsync(utf8, 0, utf8.Length).ConfigureAwait(false);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="cancellation"></param>
        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            // TODO: this method must be optimized, i.e. DynamicJson writes directly to stream
            var json = _body.ToString();
            var utf8 = Utf8NoBom.GetBytes(json);
            stream.Write(utf8, 0, utf8.Length);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public override bool TryComputeLength(out long length)
        {
            // TODO: This is quite bad, but we need to return a value here so we don't get chunked encoding, which was breaking Anomaly Detector?
            var json = _body.ToString();
            length = Utf8NoBom.GetBytes(json).Length;
            return true;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public override void Dispose()
        {
        }
    }
}
