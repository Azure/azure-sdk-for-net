using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    public abstract class Model
    {
        internal void Deserialize(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content, default))
            {
                this.ReadProperties(json.RootElement);
            }
        }

        internal ReadOnlyMemory<byte> Serialize()
        {
            byte[] buffer = CreateSerializationBuffer();

            var writer = new FixedSizedBufferWriter(buffer);

            var json = new Utf8JsonWriter(writer);

            json.WriteStartObject();

            WriteProperties(ref json);

            json.WriteEndObject();

            return buffer.AsMemory(0, (int)json.BytesWritten);
        }

        internal abstract void WriteProperties(ref Utf8JsonWriter json);

        internal abstract void ReadProperties(JsonElement json);

        protected virtual byte[] CreateSerializationBuffer()
        {
            return new byte[1024];
        }

        // TODO (pri 3): CoreFx will soon have a type like this. We should remove this one then.
        internal class FixedSizedBufferWriter : IBufferWriter<byte>
        {
            private readonly byte[] _buffer;
            private int _count;

            public FixedSizedBufferWriter(byte[] buffer)
            {
                _buffer = buffer;
            }

            public Memory<byte> GetMemory(int minimumLength = 0) => _buffer.AsMemory(_count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Span<byte> GetSpan(int minimumLength = 0) => _buffer.AsSpan(_count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Advance(int bytes)
            {
                _count += bytes;
                if (_count > _buffer.Length)
                {
                    throw new InvalidOperationException("Cannot advance past the end of the buffer.");
                }
            }
        }
    }
}
