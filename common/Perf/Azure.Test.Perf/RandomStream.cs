using System;
using System.IO;

namespace Azure.Test.PerfStress
{
    public static class RandomStream
    {
        private static readonly Lazy<byte[]> _randomBytes = new Lazy<byte[]>(() =>
        {
            var randomData = new byte[1024 * 1024];
            (new Random(0)).NextBytes(randomData);
            return randomData;
        });

        public static Stream Create(long size) => new CircularStream(new MemoryStream(_randomBytes.Value, writable: false), size);
    }
}
