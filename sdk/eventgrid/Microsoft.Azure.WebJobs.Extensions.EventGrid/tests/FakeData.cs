// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests.Common
{
    public static class FakeData
    {
        public const string eventGridEvents = @"[{
  'topic': '/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/canaryeh/providers/Microsoft.EventHub/namespaces/canaryeh',
  'subject': 'eventhubs/test',
  'eventType': 'captureFileCreated',
  'eventTime': '2017-07-14T23:10:27.7689666Z',
  'id': '7b11c4ce-1c34-4416-848b-1730e766f126',
  'data': {
    'fileUrl': 'https://shunsouthcentralus.blob.core.windows.net/debugging/shunBlob.txt',
    'fileType': 'AzureBlockBlob',
    'partitionId': '1',
    'sizeInBytes': 0,
    'eventCount': 0,
    'firstSequenceNumber': -1,
    'lastSequenceNumber': -1,
    'firstEnqueueTime': '0001-01-01T00:00:00',
    'lastEnqueueTime': '0001-01-01T00:00:00'
  },
  'dataVersion': '',
  'metadataVersion': '1'
}]";

        public const string multipleEventGridEvents = @"[{
  'topic': '/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/canaryeh/providers/Microsoft.EventHub/namespaces/canaryeh',
  'subject': 'eventhubs/test/event1',
  'eventType': 'captureFileCreated',
  'eventTime': '2017-07-14T23:10:27.7689666Z',
  'id': '7b11c4ce-1c34-4416-848b-1730e766f126',
  'data': {
    'fileUrl': 'https://trustmethisisarealurl.fake',
    'fileType': 'AzureBlockBlob',
    'partitionId': '1',
    'sizeInBytes': 13,
    'eventCount': 0,
    'firstSequenceNumber': -1,
    'lastSequenceNumber': -1,
    'firstEnqueueTime': '0001-01-01T00:00:00',
    'lastEnqueueTime': '0001-01-01T00:00:00'
  },
  'dataVersion': '',
  'metadataVersion': '1'
},
{
  'topic': '/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/canaryeh/providers/Microsoft.EventHub/namespaces/canaryeh',
  'subject': 'eventhubs/test/event2',
  'eventType': 'captureFileCreated',
  'eventTime': '2017-07-14T23:10:27.7689666Z',
  'id': '7b11c4ce-1c34-4416-848b-1730e766f126',
  'data': {
    'fileUrl': 'https://nofilehere.file',
    'fileType': 'AzureBlockBlob',
    'partitionId': '1',
    'sizeInBytes': 26,
    'eventCount': 0,
    'firstSequenceNumber': -1,
    'lastSequenceNumber': -1,
    'firstEnqueueTime': '0001-01-01T00:00:00',
    'lastEnqueueTime': '0001-01-01T00:00:00'
  },
  'dataVersion': '',
  'metadataVersion': '1'
}]";

        public const string eventGridEvent = @"{
  'topic': '/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/canaryeh/providers/Microsoft.EventHub/namespaces/canaryeh',
  'subject': 'eventhubs/test',
  'eventType': 'captureFileCreated',
  'eventTime': '2017-07-14T23:10:27.7689666Z',
  'id': '7b11c4ce-1c34-4416-848b-1730e766f126',
  'data': {
    'fileUrl': 'https://shunsouthcentralus.blob.core.windows.net/debugging/shunBlob.txt',
    'fileType': 'AzureBlockBlob',
    'partitionId': '1',
    'sizeInBytes': 0,
    'eventCount': 0,
    'firstSequenceNumber': -1,
    'lastSequenceNumber': -1,
    'firstEnqueueTime': '0001-01-01T00:00:00',
    'lastEnqueueTime': '0001-01-01T00:00:00'
  },
  'dataVersion': '',
  'metadataVersion': '1'
}";

        // https://github.com/MicrosoftDocs/azure-docs/blob/master/articles/event-grid/cloudevents-schema.md#cloudevent-schema

        public const string cloudEvent = @"{
    'cloudEventsVersion' : '0.1',
    'eventType' : 'Microsoft.Storage.BlobCreated',
    'eventTypeVersion' : '',
    'source' : '/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.Storage/storageAccounts/{storage-account}#blobServices/default/containers/{storage-container}/blobs/{new-file}',
    'eventID' : '173d9985-401e-0075-2497-de268c06ff25',
    'eventTime' : '2018-04-28T02:18:47.1281675Z',
    'data' : {
      'api': 'PutBlockList',
      'clientRequestId': '6d79dbfb-0e37-4fc4-981f-442c9ca65760',
      'requestId': '831e1650-001e-001b-66ab-eeb76e000000',
      'eTag': '0x8D4BCC2E4835CD0',
      'contentType': 'application/octet-stream',
      'contentLength': 524288,
      'blobType': 'BlockBlob',
      'url': 'https://oc2d2817345i60006.blob.core.windows.net/oc2d2817345i200097container/oc2d2817345i20002296blob',
      'sequencer': '00000000000004420000000000028963',
      'storageDiagnostics': {
        'batchId': 'b68529f3-68cd-4744-baa4-3c0498ec19f0'
      }
    }
}";

        public const string stringDataEvent = @"{
  'topic': '/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/canaryeh/providers/Microsoft.EventHub/namespaces/canaryeh',
  'subject': 'eventhubs/test',
  'eventType': 'captureFileCreated',
  'eventTime': '2017-07-14T23:10:27.7689666Z',
  'id': '7b11c4ce-1c34-4416-848b-1730e766f126',
  'data': 'goodBye world',
  'dataVersion': '',
  'metadataVersion': '1'
}";

        public const string stringDataEvents = @"[{
  'topic': '/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/canaryeh/providers/Microsoft.EventHub/namespaces/canaryeh',
  'subject': 'eventhubs/test',
  'eventType': 'captureFileCreated',
  'eventTime': '2017-07-14T23:10:27.7689666Z',
  'id': '7b11c4ce-1c34-4416-848b-1730e766f126',
  'data': 'Perfectly balanced',
  'dataVersion': '',
  'metadataVersion': '1'
},
{
  'topic': '/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/canaryeh/providers/Microsoft.EventHub/namespaces/canaryeh',
  'subject': 'eventhubs/test',
  'eventType': 'captureFileCreated',
  'eventTime': '2017-07-14T23:10:27.7689666Z',
  'id': '7b11c4ce-1c34-4416-848b-1730e766f126',
  'data': 'as all things should be',
  'dataVersion': '',
  'metadataVersion': '1'
}]";
        // JArray
        public const string arrayDataEvent = @"{
  'topic': '/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/canaryeh/providers/Microsoft.EventHub/namespaces/canaryeh',
  'subject': 'eventhubs/test',
  'eventType': 'captureFileCreated',
  'eventTime': '2017-07-14T23:10:27.7689666Z',
  'id': '7b11c4ce-1c34-4416-848b-1730e766f126',
  'data': ['ConfusedDev', 123, true],
  'dataVersion': '',
  'metadataVersion': '1'
}";

        public const string primitiveDataEvent = @"{
  'topic': '/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/canaryeh/providers/Microsoft.EventHub/namespaces/canaryeh',
  'subject': 'eventhubs/test',
  'eventType': 'captureFileCreated',
  'eventTime': '2017-07-14T23:10:27.7689666Z',
  'id': '7b11c4ce-1c34-4416-848b-1730e766f126',
  'data': 123,
  'dataVersion': '',
  'metadataVersion': '1'
}";

        public const string missingDataEvent = @"{
  'topic': '/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/canaryeh/providers/Microsoft.EventHub/namespaces/canaryeh',
  'subject': 'eventhubs/test',
  'eventType': 'captureFileCreated',
  'eventTime': '2017-07-14T23:10:27.7689666Z',
  'id': '7b11c4ce-1c34-4416-848b-1730e766f126',
  'dataVersion': '',
  'metadataVersion': '1'
}";
    }
}