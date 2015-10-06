namespace AzureLogTool
{
    using System;

    // Details on azure log formats, enumerations, etc:
    // http://blogs.msdn.com/b/windowsazurestorage/archive/2011/08/03/windows-azure-storage-logging-using-logs-to-track-storage-requests.aspx
    // Azure logs are currently v1.

    internal enum AzureOperationTypeV1
    {
        AcquireLease,
        BreakLease,
        ClearPage,
        CopyBlob,
        CopyBlobSource,
        CopyBlobDestination,
        CreateContainer,
        DeleteBlob,
        DeleteContainer,
        GetBlob,
        GetBlobMetadata,
        GetBlobProperties,
        GetBlockList,
        GetContainerACL,
        GetContainerMetadata,
        GetContainerProperties,
        GetLeaseInfo,
        GetPageRegions,
        LeaseBlob,
        ListBlobs,
        ListContainers,
        PutBlob,
        PutBlockList,
        PutBlock,
        PutPage,
        ReleaseLease,
        RenewLease,
        SetBlobMetadata,
        SetBlobProperties,
        SetContainerACL,
        SetContainerMetadata,
        SnapshotBlob,
        SetBlobServiceProperties,
        GetBlobServiceProperties,
        // These weren't mentioned.
        SetContainerProperties,
        GetBlock,
    }

    internal enum AzureRequestStatusV1
    {
        Success,
        AnonymousSuccess,
        SASSuccess,
        ThrottlingError,
        AnonymousThrottlingError,
        SASThrottlingError,
        ClientTimeoutError,
        AnonymousClientTimeoutError,
        SASClientTimeoutError,
        ServerTimeoutError,
        AnonymousServerTimeoutError,
        SASServerTimeoutError,
        ClientOtherError,
        SASClientOtherError,
        AnonymousClientOtherError,
        ServerOtherError,
        AnonymousServerOtherError,
        SASServerOtherError,
        AuthorizationError,
        SASAuthorizationError,
        NetworkError,
        AnonymousNetworkError,
        SASNetworkError
    }

    internal struct AzureBlobLogRecordV1
    {
        internal const string ExpectedLogEntryVersion = "1.0";

        //<version-number>;<request-start-time>;<operation-type>;<request-status>;
        //<http-status-code>;<end-to-end-latency-in-ms>;<server-latency-in-ms>;
        //<authentication-type>;<requester-account-name>;<owner-account-name>;
        //<service-type>;<request-url>;<requested-object-key>;<request-id-header>;
        //<operation-count>;<requester-ip-address>;<request-version-header>;
        //<request-header-size>;<request-packet-size>;<response-header-size>;
        //<response-packet-size>;<request-content-length>;<request-md5>;
        //<server-md5>;<etag-identifier>;<last-modified-time>;<conditions-used>;
        //<user-agent-header>;<referrer-header>;<client-request-id>

        //<version-number>;                          //[0]
        internal DateTime RequestStartTimeUTC;       //[1]
        internal AzureOperationTypeV1 OperationType; //[2]
        internal AzureRequestStatusV1 RequestStatus; //[3]
        internal int HttpStatusCode;                 //[4]
        internal int EndToEndLatencyMilliseconds;    //[5]
        internal int ServerLatencyMilliseconds;      //[6]
        //<authentication-type>;                     //[7]
        //<requester-account-name>;                  //[8]
        //<owner-account-name>;                      //[9]
        //<service-type>;                            //[10]  //blob etc.
        //<request-url>;                             //[11]
        //<requested-object-key>;                    //[12]
        //<request-id-header>;                       //[13]
        //<operation-count>;                         //[14]
        //<requester-ip-address>;                    //[15]
        //<request-version-header>;                  //[16]
        //<request-header-size>;                     //[17]
        internal long RequestPacketSize;             //[18]
        //<response-header-size>;                    //[19]
        internal long ResponsePacketSize;            //[20]
        internal long RequestContentLength;          //[21]
        //<request-md5>;                             //[22]
        //<server-md5>;                              //[23]
        //<etag-identifier>;                         //[24]
        //<last-modified-time>;                      //[25]
        //<conditions-used>;                         //[26]
        //<user-agent-header>;                       //[27]
        //<referrer-header>;                         //[28]
        //<client-request-id>                        //[29]

        internal long DataSize
        {
            get
            {
                if (this.IsThrottle && this.IsRead)
                {
                    //assume 4MB for throttle-error-reads. this is the likely size value that Azure was using when it decided to reject.
                    //This is appropriate for WASB driver, but is likely not appropriate for other clients of Azure Blob Store
                    return 4 * 1024 * 1024;
                }
                else
                {
                    // treat the datasize as the larger of the main values.
                    return Math.Max(this.RequestPacketSize, Math.Max(this.ResponsePacketSize, this.RequestContentLength));
                }
            }
        }

        internal bool IsError
        {
            get { return this.RequestStatus != AzureRequestStatusV1.Success && this.RequestStatus != AzureRequestStatusV1.ThrottlingError; }
        }

        internal bool IsRead
        {
            get { return this.OperationType == AzureOperationTypeV1.GetBlob || this.OperationType == AzureOperationTypeV1.GetBlock; }
        }

        internal bool IsSuccess
        {
            get { return this.RequestStatus == AzureRequestStatusV1.Success; }
        }

        internal bool IsThrottle
        {
            get { return this.RequestStatus == AzureRequestStatusV1.ThrottlingError; }
        }
    }
}
