using System;
using System.Globalization;

namespace Azure.Security.KeyVault.Secrets
{
    internal struct ObjectId
    {
        Uri _id;

        public Uri Id => _id;

        public Uri Vault { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public void ParseId(string collection, string id)
        {
            _id = new Uri(id, UriKind.Absolute); ;

            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (_id.Segments.Length != 3 && _id.Segments.Length != 4)
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", id, _id.Segments.Length));

            if (!string.Equals(_id.Segments[1], collection + "/", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be '{1}/', found '{2}'", id, collection, _id.Segments[1]));

            Vault = new Uri($"{_id.Scheme}://{_id.Authority}");
            Name = _id.Segments[2].Trim('/');
            Version = (_id.Segments.Length == 4) ? _id.Segments[3].TrimEnd('/') : null;
        }
    }
}
