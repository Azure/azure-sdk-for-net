// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    public class AvailabilitySetDataListTests
    {
        private static readonly string _payload = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataList.json")).TrimEnd();
        private static readonly BinaryData _data = new BinaryData(Encoding.UTF8.GetBytes(_payload));
        private static readonly IList<AvailabilitySetData> _availabilitySets = ModelReaderWriter.Read<List<AvailabilitySetData>>(_data)!;
        private static readonly string _collapsedPayload = GetCollapsedPayload();

        private static string GetCollapsedPayload()
        {
            var jsonObject = JsonSerializer.Deserialize<object>(_payload);
            return JsonSerializer.Serialize(jsonObject);
        }

        private class AvailabilitySetDataComparer : IComparer<AvailabilitySetData>
        {
            public int Compare(AvailabilitySetData? x, AvailabilitySetData? y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                else if (x == null)
                {
                    return -1;
                }
                else if (y == null)
                {
                    return 1;
                }
                else
                {
                    return x.Id.CompareTo(y.Id);
                }
            }
        }

        private static List<object> Collections = new List<object>
        {
            new List<AvailabilitySetData>(_availabilitySets),
            new AvailabilitySetData[] { _availabilitySets[0], _availabilitySets[1] },
            new Collection<AvailabilitySetData> (_availabilitySets),
            new ObservableCollection<AvailabilitySetData> (_availabilitySets),
            new HashSet<AvailabilitySetData> (_availabilitySets),
            new Queue<AvailabilitySetData> (_availabilitySets),
            new Stack<AvailabilitySetData> (_availabilitySets.Reverse()), //stack has the order flipped
            new LinkedList<AvailabilitySetData> (_availabilitySets),
            new SortedSet<AvailabilitySetData> (_availabilitySets, new AvailabilitySetDataComparer()),
            new ArrayList (new Collection<AvailabilitySetData>(_availabilitySets)),
        };

        [Test]
        public void ReadListGeneric()
        {
            var asetList = ModelReaderWriter.Read<List<AvailabilitySetData>>(_data);
            Assert.IsNotNull(asetList);

            Assert.AreEqual(2, asetList!.Count);
            Assert.IsTrue(asetList[0].Id.Contains("testAS-3375"));
            Assert.IsTrue(asetList[1].Id.Contains("testAS-3376"));
        }

        [Test]
        public void ReadList()
        {
            var asetList = ModelReaderWriter.Read(_data, typeof(List<AvailabilitySetData>));
            Assert.IsNotNull(asetList);

            List<AvailabilitySetData>? asetList2 = asetList! as List<AvailabilitySetData>;
            Assert.IsNotNull(asetList2);

            Assert.AreEqual(2, asetList2!.Count);
            Assert.IsTrue(asetList2[0].Id.Contains("testAS-3375"));
            Assert.IsTrue(asetList2[1].Id.Contains("testAS-3376"));
        }

        [TestCaseSource("Collections")]
        public void WriteCollection(object collection)
        {
            BinaryData data = ModelReaderWriter.Write(collection);
            Assert.IsNotNull(data);
            Assert.AreEqual(_collapsedPayload, data.ToString());
        }
    }
}
