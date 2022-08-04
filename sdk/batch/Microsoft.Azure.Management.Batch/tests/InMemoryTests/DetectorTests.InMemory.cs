using Batch.Tests.Helpers;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Batch.Tests
{
    public class InMemoryDetectorTests
    {
        [Fact]
        public void GetDetectorValidateResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'type': 'Microsoft.Batch/batchAccounts/detectors',
                    'id': '/subscriptions/subid/resourceGroups/default-azurebatch-japaneast/providers/Microsoft.Batch/batchAccounts/sampleacct/detectors/poolsAndNodes',
                    'name': 'poolsAndNodes',
                    'properties': {
                        'value': 'ew0KICAibWV0YWRhdGEiOiB7DQogICAgImlkIjogInBvb2xzQW5kTm9kZXMiLA0KICAgICJuYW1lIjogIlBvb2xzIGFuZCBOb2RlcyIsDQogICAgImRlc2NyaXB0aW9uIjogbnVsbCwNCiAgICAiYXV0aG9yIjogIiIsDQogICAgImNhdGVnb3J5IjogbnVsbCwNCiAgICAic3VwcG9ydFRvcGljTGlzdCI6IFsNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDc3IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDYxIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDY1IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDY2IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDY5IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDcyIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDc5IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDgyIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDkxIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDkzIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDk0IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfQ0KICAgIF0sDQogICAgImFuYWx5c2lzVHlwZXMiOiBudWxsLA0KICAgICJ0eXBlIjogIkFuYWx5c2lzIiwNCiAgICAic2NvcmUiOiAwLjANCiAgfSwNCiAgImRhdGFzZXQiOiBbXSwNCiAgInN0YXR1cyI6IHsNCiAgICAibWVzc2FnZSI6IG51bGwsDQogICAgInN0YXR1c0lkIjogNA0KICB9LA0KICAiZGF0YVByb3ZpZGVyc01ldGFkYXRhIjogbnVsbCwNCiAgInN1Z2dlc3RlZFV0dGVyYW5jZXMiOiBudWxsDQp9'
                    }
                }"
            )};

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            BatchManagementClient client = BatchTestHelper.GetBatchManagementClient(handler);

            DetectorResponse result = client.BatchAccount.GetDetector("default-azurebatch-japaneast", "sampleacct", "poolsAndNodes");

            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            Assert.Equal("poolsAndNodes", result.Name);
            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public void ListDetectorsValidateResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': [
                        {
                            'type': 'Microsoft.Batch/batchAccounts/detectors',
                            'id': '/subscriptions/subid/resourceGroups/default-azurebatch-japaneast/providers/Microsoft.Batch/batchAccounts/sampleacct/detectors/poolsAndNodes',
                            'name': 'poolsAndNodes',
                            'properties': {
                                'value': 'ew0KICAibWV0YWRhdGEiOiB7DQogICAgImlkIjogInBvb2xzQW5kTm9kZXMiLA0KICAgICJuYW1lIjogIlBvb2xzIGFuZCBOb2RlcyIsDQogICAgImRlc2NyaXB0aW9uIjogbnVsbCwNCiAgICAiYXV0aG9yIjogIiIsDQogICAgImNhdGVnb3J5IjogbnVsbCwNCiAgICAic3VwcG9ydFRvcGljTGlzdCI6IFsNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDc3IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDYxIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDY1IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDY2IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDY5IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDcyIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDc5IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDgyIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDkxIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDkzIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDk0IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfQ0KICAgIF0sDQogICAgImFuYWx5c2lzVHlwZXMiOiBudWxsLA0KICAgICJ0eXBlIjogIkFuYWx5c2lzIiwNCiAgICAic2NvcmUiOiAwLjANCiAgfSwNCiAgImRhdGFzZXQiOiBbXSwNCiAgInN0YXR1cyI6IHsNCiAgICAibWVzc2FnZSI6IG51bGwsDQogICAgInN0YXR1c0lkIjogNA0KICB9LA0KICAiZGF0YVByb3ZpZGVyc01ldGFkYXRhIjogbnVsbCwNCiAgInN1Z2dlc3RlZFV0dGVyYW5jZXMiOiBudWxsDQp9'
                            }
                        },
                        {
                            'type': 'Microsoft.Batch/batchAccounts/detectors',
                            'id': '/subscriptions/subid/resourceGroups/default-azurebatch-japaneast/providers/Microsoft.Batch/batchAccounts/sampleacct/detectors/anotherDetector',
                            'name': 'otherDetector',
                            'properties': {
                                'value': 'ew0KICAibWV0YWRhdGEiOiB7DQogICAgImlkIjogInBvb2xzQW5kTm9kZXMiLA0KICAgICJuYW1lIjogIlBvb2xzIGFuZCBOb2RlcyIsDQogICAgImRlc2NyaXB0aW9uIjogbnVsbCwNCiAgICAiYXV0aG9yIjogIiIsDQogICAgImNhdGVnb3J5IjogbnVsbCwNCiAgICAic3VwcG9ydFRvcGljTGlzdCI6IFsNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDc3IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDYxIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDY1IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDY2IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDY5IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDcyIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDc5IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDgyIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDkxIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDkzIiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImlkIjogIjMyNjM1MDk0IiwNCiAgICAgICAgInBlc0lkIjogIjE1NjE0IiwNCiAgICAgICAgInR5cGVJZCI6ICJEaWFnbm9zdGljcy5Nb2RlbHNBbmRVdGlscy5BdHRyaWJ1dGVzLlN1cHBvcnRUb3BpYywgRGlhZ25vc3RpY3MuTW9kZWxzQW5kVXRpbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsIg0KICAgICAgfQ0KICAgIF0sDQogICAgImFuYWx5c2lzVHlwZXMiOiBudWxsLA0KICAgICJ0eXBlIjogIkFuYWx5c2lzIiwNCiAgICAic2NvcmUiOiAwLjANCiAgfSwNCiAgImRhdGFzZXQiOiBbXSwNCiAgInN0YXR1cyI6IHsNCiAgICAibWVzc2FnZSI6IG51bGwsDQogICAgInN0YXR1c0lkIjogNA0KICB9LA0KICAiZGF0YVByb3ZpZGVyc01ldGFkYXRhIjogbnVsbCwNCiAgInN1Z2dlc3RlZFV0dGVyYW5jZXMiOiBudWxsDQp9'
                            }
                        }
                    ]
                }"
            )};

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            BatchManagementClient client = BatchTestHelper.GetBatchManagementClient(handler);

            IPage<DetectorResponse> result = client.BatchAccount.ListDetectors("default-azurebatch-japaneast", "sampleacct");

            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            Assert.Equal(2, result.Count());

            DetectorResponse response1 = result.ElementAt(0);
            Assert.Equal("poolsAndNodes", response1.Name);

            DetectorResponse response2 = result.ElementAt(1);
            Assert.Equal("otherDetector", response2.Name);
        }
    }
}
