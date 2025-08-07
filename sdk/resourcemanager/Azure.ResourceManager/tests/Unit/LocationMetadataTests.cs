using System;
using System.ClientModel.Primitives;
using System.Globalization;
using System.Threading;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class LocationMetadataTests
    {
        private const double _longitude = -122.1215;
        private const double _latitude = 47.6740;
        private static readonly string _payload = $@"{{""longitude"":""{_longitude}"",""latitude"":""{_latitude}""}}";

        [TestCase("en-US")] // English (United States) - uses a dot as the decimal separator
        [TestCase("fr-FR")] // French (France) - uses a comma as the decimal separator
        [TestCase("de-DE")] // German (Germany) - uses a comma as the decimal separator
        [TestCase("es-ES")] // Spanish (Spain) - uses a comma as the decimal separator
        [TestCase("it-IT")] // Italian (Italy) - uses a comma as the decimal separator
        [TestCase("ja-JP")] // Japanese (Japan) - uses a dot as the decimal separator
        [TestCase("zh-CN")] // Chinese (China) - uses a dot as the decimal separator
        [TestCase("ru-RU")] // Russian (Russia) - uses a comma as the decimal separator
        [TestCase("pt-BR")] // Portuguese (Brazil) - uses a comma as the decimal separator
        [TestCase("ar-SA")] // Arabic (Saudi Arabia) - uses a dot as the decimal separator
        public void ValidateLocationMetadataInCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var location = ModelReaderWriter.Read<LocationMetadata>(new BinaryData(_payload));

            Assert.AreEqual(_longitude, location.Longitude);
            Assert.AreEqual(_latitude, location.Latitude);

            var json = ModelReaderWriter.Write(location);
            Assert.AreEqual(_payload, json.ToString());
        }
    }
}
