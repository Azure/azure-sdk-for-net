using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Test;
using Microsoft.Azure.Management.SiteRecovery;
using Xunit;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure;

namespace SiteRecovery.Tests
{
    public class VCenterTests : SiteRecoveryTestsBase
    {
        private string vCenterName = "vcenter";
        private string newVCenterName = "bcdr-vcenter-1";
        private string ipAddress = "10.150.208.248";
        private string runAsAccountName = "vcenter";
        private string port = "443";

        
        public void GetVCenters()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var inMageFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(inMageFabric);

                var vCenterResponse =
                    client.VCenters.List(inMageFabric.Name, RequestHeaders);

                Assert.NotEmpty(vCenterResponse.VCenters);
            }
        }

        
        public void GetAllVCenters()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var vCenterResponse =
                    client.VCenters.ListAll(RequestHeaders);

                Assert.NotEmpty(vCenterResponse.VCenters);
            }
        }

        
        public void GetVCenter()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(vmWareFabric);

                var vmWareDetails =
                   vmWareFabric.Properties.CustomDetails as VMwareFabricDetails;
                Assert.NotNull(vmWareDetails);
                Assert.NotEmpty(vmWareDetails.VCenters);

                var vCenterResponse = client.VCenters.Get(
                    vmWareFabric.Name,
                    vmWareDetails.VCenters[0].Name,
                    RequestHeaders);

                Assert.NotNull(vCenterResponse.VCenter);
                Assert.NotNull(vCenterResponse.VCenter.Name);
                Assert.NotNull(vCenterResponse.VCenter.Id);
                Assert.NotNull(vCenterResponse.VCenter.Properties.DiscoveryStatus);
                Assert.NotNull(vCenterResponse.VCenter.Properties.FriendlyName);
                Assert.NotNull(vCenterResponse.VCenter.Properties.InfrastructureId);
                Assert.NotNull(vCenterResponse.VCenter.Properties.IpAddress);
                Assert.NotNull(vCenterResponse.VCenter.Properties.LastHeartbeat);
                Assert.NotNull(vCenterResponse.VCenter.Properties.Port);
                Assert.NotNull(vCenterResponse.VCenter.Properties.ProcessServerId);
                Assert.NotNull(vCenterResponse.VCenter.Properties.FabricArmResourceName);
            }
        }

        
        public void DeleteVCenter()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var inMageFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(inMageFabric);

                var vmWareDetails =
                   inMageFabric.Properties.CustomDetails as VMwareFabricDetails;
                Assert.NotNull(vmWareDetails);
                Assert.NotEmpty(vmWareDetails.VCenters);

                var vCenterResponse = client.VCenters.Delete(
                    inMageFabric.Name,
                    vmWareDetails.VCenters[0].Name,
                    RequestHeaders);

                Assert.Equal(OperationStatus.Succeeded, vCenterResponse.Status);
            }
        }

        
        public void UpdateVCenter()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var inMageFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(inMageFabric);

                var vmWareDetails =
                   inMageFabric.Properties.CustomDetails as VMwareFabricDetails;
                Assert.NotNull(vmWareDetails);
                Assert.NotEmpty(vmWareDetails.VCenters);

                 var runAsAccount = vmWareDetails.RunAsAccounts.First(
                    account => account.AccountName.Equals(
                        this.runAsAccountName,
                        StringComparison.InvariantCultureIgnoreCase));
                Assert.NotNull(runAsAccount);

                var response = client.VCenters.Update(
                    inMageFabric.Name,
                    vmWareDetails.VCenters[0].Name,
                    new UpdateVCenterInput
                    {
                        Properties = new UpdateVCenterProperties
                        {
                            FriendlyName = this.newVCenterName,
                            IpAddress = vmWareDetails.VCenters[0].Properties.IpAddress,
                            Port = vmWareDetails.VCenters[0].Properties.Port,
                            ProcessServerId = vmWareDetails.VCenters[0].Properties.ProcessServerId,
                            RunAsAccountId = runAsAccount.AccountId
                        }
                    },
                    RequestHeaders);

                Assert.Equal(OperationStatus.Succeeded, response.Status);

                var vCenterResponse = response as UpdateVCenterOperationResponse;
                Assert.NotNull(vCenterResponse);
                Assert.NotNull(vCenterResponse.VCenter);
                Assert.Equal(
                    vCenterResponse.VCenter.Properties.FriendlyName,
                    this.newVCenterName);
            }
        }

        public void AddVCenter()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var inMageFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(inMageFabric);

                var vmWareDetails =
                    inMageFabric.Properties.CustomDetails as VMwareFabricDetails;
                Assert.NotNull(vmWareDetails);
                
                Assert.NotEmpty(vmWareDetails.ProcessServers);
                var processServer = vmWareDetails.ProcessServers[0];

                var runAsAccount = vmWareDetails.RunAsAccounts.First(
                    account => account.AccountName.Equals(
                        "vm",
                        StringComparison.InvariantCultureIgnoreCase));
                Assert.NotNull(runAsAccount);

                var response = client.VCenters.Create(
                    inMageFabric.Name,
                    this.vCenterName,
                    new CreateVCenterInput
                    {
                        Properties = new CreateVCenterProperties
                        {
                            FriendlyName = this.vCenterName,
                            IpAddress = this.ipAddress,
                            Port = this.port,
                            ProcessServerId = processServer.Id,
                            RunAsAccountId = runAsAccount.AccountId
                        }
                    },
                    RequestHeaders);

                Assert.Equal(OperationStatus.Succeeded, response.Status);

                var vCenterResponse = response as CreateVCenterOperationResponse;
                Assert.NotNull(vCenterResponse);
                Assert.NotNull(vCenterResponse.VCenter);
                Assert.Equal(this.vCenterName, vCenterResponse.VCenter.Name);
            }
        }
    }
}
