// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Docker.DotNet;
using Docker.DotNet.X509;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Docker.DotNet.Models;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Management.Samples.Common
{
    /**
     * Syncronous extension wrappers class for Docker.DotNet async methods.
     */
    public static class DockerExtensions
    {
        public static Stream PullImage(this IImageOperations operations, ImagesPullParameters parameters, AuthConfig authConfig)
        {
            return operations.PullImageAsync(parameters, authConfig).Result;
        }

        public static Stream PushImage(this IImageOperations operations, string name, ImagePushParameters parameters, AuthConfig authConfig)
        {
            return operations.PushImageAsync(name, parameters, authConfig).Result;
        }

        public static CreateContainerResponse CreateContainer(this IContainerOperations operations, CreateContainerParameters parameters)
        {
            return operations.CreateContainerAsync(parameters).Result;
        }

        public static IList<ImagesListResponse> ListImages(this IImageOperations operations, ImagesListParameters parameters)
        {
            return operations.ListImagesAsync(parameters).Result;
        }

        public static IList<ContainerListResponse> ListContainers(this IContainerOperations operations, ContainersListParameters parameters)
        {
            return operations.ListContainersAsync(parameters).Result;
        }

        public static void RemoveContainer(this IContainerOperations operations, string name, ContainerRemoveParameters parameters)
        {
            operations.RemoveContainerAsync(name, parameters).Wait();
        }

        public static void DeleteImage(this IImageOperations operations, string name, ImageDeleteParameters parameters)
        {
            operations.DeleteImageAsync(name, parameters).Wait();
        }

        public static CommitContainerChangesResponse CommitContainerChanges(this IMiscellaneousOperations operations, CommitContainerChangesParameters parameters)
        {
            return operations.CommitContainerChangesAsync(parameters).Result;
        }
    }

    /**
     * Utility class to be used by Azure Container Registry sample.
     * - Creates "in memory" SSL configuration to be used by the Java Docker client
     * - Builds a Docker client config object
     * - Creates a new Azure virtual machine and installs Docker
     * - Creates a Java DockerClient to be used for communicating with a Docker host/engine
     */
    public class DockerUtils
    {
        /**
         * Instantiate a Docker client that will be used for Docker client related operations.
         * @param azure - instance of Azure
         * @param rgName - name of the Azure resource group to be used when creating a virtual machine
         * @param region - region to be used when creating a virtual machine
         * @return an instance of DockerClient
         */
        public static DockerClient CreateDockerClient(IAzure azure, String rgName, Region region)
        {
            string envDockerHost = Environment.GetEnvironmentVariable("DOCKER_HOST");
            string envDockerCertPath = Environment.GetEnvironmentVariable("DOCKER_CERT_PATH");
            string dockerHostUrl;
            DockerClient dockerClient;

            if (String.IsNullOrWhiteSpace(envDockerHost))
            {
                // Could not find a Docker environment; presume that there is no local Docker engine running and
                //    attempt to configure a Docker engine running inside a new    Azure virtual machine
                dockerClient = FromNewDockerVM(azure, rgName, region);
            }
            else
            {
                dockerHostUrl = envDockerHost;
                Utilities.Log("Using local settings to connect to a Docker service: " + dockerHostUrl);

                if (String.IsNullOrWhiteSpace(envDockerCertPath) || !File.Exists(envDockerCertPath + "/key.pfx"))
                {
                    // Could not find a Docker environment variable that is used to set the path to the certificate files
                    //    which are required when authenticating to a secured Docker service.
                    // Presume that no authentication is required to connect with this Docker service
                    dockerClient = new DockerClientConfiguration(new Uri(dockerHostUrl)).CreateClient();
                }
                else
                {
                    // Found environment variable pointing at the folder containing the certificate files required to
                    //    establish a secured connection to this Docker service.
                    // "key.pfx" file is required when connecting using the .Net client; to generate this certificate file
                    //    from standard .PEM certificate file execute the following command:
                    //
                    //    openssl pkcs12 -export -inkey key.pem -in cert.pem -out key.pfx -passout pass: -CAfile ca.pem
                    //
                    var credentials = new CertificateCredentials(new X509Certificate2(envDockerCertPath + "/key.pfx"));
                    credentials.ServerCertificateValidationCallback += (o, c, ch, er) => true;
                    dockerClient = new DockerClientConfiguration(new Uri(dockerHostUrl), credentials).CreateClient();
                }
            }
            Utilities.Log("List Docker host info");
            Utilities.Log("\tFound Docker version: " + dockerClient.Miscellaneous.GetVersionAsync().Result.Version);
            Utilities.Log("\tFound Docker server version: " + dockerClient.Miscellaneous.GetSystemInfoAsync().Result.ServerVersion);

            return dockerClient;
        }


        /**
         * It creates a new Azure virtual machine and it instantiate a Java Docker client.
         * @param azure - instance of Azure
         * @param rgName - name of the Azure resource group to be used when creating a virtual machine
         * @param region - region to be used when creating a virtual machine
         * @return an instance of DockerClient
         */
        public static DockerClient FromNewDockerVM(IAzure azure, String rgName, Region region)
        {
            string dockerVMName = SdkContext.RandomResourceName("dockervm", 15);
            string publicIPDnsLabel = SdkContext.RandomResourceName("pip", 10);
            string vmUserName = "dockerUser";
            string vmPassword = "12NewPA$$w0rd!";

            // Could not find a Docker environment; presume that there is no local Docker engine running and
            //    attempt to configure a Docker engine running inside a new Azure virtual machine
            Utilities.Log("Creating an Azure virtual machine running Docker");

            IVirtualMachine dockerVM = azure.VirtualMachines.Define(dockerVMName)
                .WithRegion(region)
                .WithExistingResourceGroup(rgName)
                .WithNewPrimaryNetwork("10.0.0.0/28")
                .WithPrimaryPrivateIPAddressDynamic()
                .WithNewPrimaryPublicIPAddress(publicIPDnsLabel)
                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                .WithRootUsername(vmUserName)
                .WithRootPassword(vmPassword)
                .WithSize(VirtualMachineSizeTypes.StandardD2V2)
                .Create();

            Utilities.Log("Created Azure Virtual Machine: " + dockerVM.Id);

            // Get the IP of the Docker host
            INicIPConfiguration nicIPConfiguration = dockerVM.GetPrimaryNetworkInterface().PrimaryIPConfiguration;
            IPublicIPAddress publicIp = nicIPConfiguration.GetPublicIPAddress();
            string dockerHostIP = publicIp.IPAddress;

            DockerClient dockerClient = InstallDocker(dockerHostIP, vmUserName, vmPassword);

            return dockerClient;
        }

        /**
         * Install Docker on a given virtual machine and return a DockerClient.
         * @param dockerHostIP - address (IP) of the Docker host machine
         * @param vmUserName - user name to connect with to the Docker host machine
         * @param vmPassword - password to connect with to the Docker host machine
         * @return an instance of DockerClient
         */
        public static DockerClient InstallDocker(string dockerHostIP, string vmUserName, string vmPassword)
        {
            int keyPfxBuffLength = 10000;
            byte[] keyPfxContent = new byte[keyPfxBuffLength]; // it stores the content of the key.pfx certificate file
            bool dockerHostTlsEnabled = false;
            string dockerHostUrl = "tcp://" + dockerHostIP + ":2376";
            SSHShell sshShell = null;

            try
            {
                using (sshShell = SSHShell.Open(dockerHostIP, 22, vmUserName, vmPassword))
                {

                    Utilities.Log("Copy Docker setup scripts to remote host: " + dockerHostIP);
                    sshShell.Upload(Encoding.ASCII.GetBytes(INSTALL_DOCKER_FOR_UBUNTU_SERVER_16_04_LTS),
                        "INSTALL_DOCKER_FOR_UBUNTU_SERVER_16_04_LTS.sh",
                        ".azuredocker",
                        true);

                    sshShell.Upload(Encoding.ASCII.GetBytes(CREATE_OPENSSL_TLS_CERTS_FOR_UBUNTU.Replace("HOST_IP", dockerHostIP)),
                            "CREATE_OPENSSL_TLS_CERTS_FOR_UBUNTU.sh",
                            ".azuredocker",
                            true);
                    sshShell.Upload(Encoding.ASCII.GetBytes(INSTALL_DOCKER_TLS_CERTS_FOR_UBUNTU),
                            "INSTALL_DOCKER_TLS_CERTS_FOR_UBUNTU.sh",
                            ".azuredocker",
                            true);
                    sshShell.Upload(Encoding.ASCII.GetBytes(DEFAULT_DOCKERD_CONFIG_TLS_ENABLED),
                            "dockerd_tls.config",
                            ".azuredocker",
                            true);
                    sshShell.Upload(Encoding.ASCII.GetBytes(CREATE_DEFAULT_DOCKERD_OPTS_TLS_ENABLED),
                            "CREATE_DEFAULT_DOCKERD_OPTS_TLS_ENABLED.sh",
                            ".azuredocker",
                            true);
                    sshShell.Upload(Encoding.ASCII.GetBytes(DEFAULT_DOCKERD_CONFIG_TLS_DISABLED),
                            "dockerd_notls.config",
                            ".azuredocker",
                            true);
                    sshShell.Upload(Encoding.ASCII.GetBytes(CREATE_DEFAULT_DOCKERD_OPTS_TLS_DISABLED),
                            "CREATE_DEFAULT_DOCKERD_OPTS_TLS_DISABLED.sh",
                            ".azuredocker",
                            true);

                    Utilities.Log("Trying to install Docker host at: " + dockerHostIP);
                    string output = sshShell.ExecuteCommand("chmod +x ~/.azuredocker/INSTALL_DOCKER_FOR_UBUNTU_SERVER_16_04_LTS.sh");
                    Utilities.Log(output);
                    output = sshShell.ExecuteCommand("bash -c ~/.azuredocker/INSTALL_DOCKER_FOR_UBUNTU_SERVER_16_04_LTS.sh");
                    Utilities.Log(output);

                    Utilities.Log("Trying to create OPENSSL certificates");
                    output = sshShell.ExecuteCommand("chmod +x ~/.azuredocker/CREATE_OPENSSL_TLS_CERTS_FOR_UBUNTU.sh");
                    Utilities.Log(output);
                    output = sshShell.ExecuteCommand("bash -c ~/.azuredocker/CREATE_OPENSSL_TLS_CERTS_FOR_UBUNTU.sh");
                    Utilities.Log(output);

                    Utilities.Log("Trying to install TLS certificates");

                    output = sshShell.ExecuteCommand("chmod +x ~/.azuredocker/INSTALL_DOCKER_TLS_CERTS_FOR_UBUNTU.sh");
                    Utilities.Log(output);
                    output = sshShell.ExecuteCommand("bash -c ~/.azuredocker/INSTALL_DOCKER_TLS_CERTS_FOR_UBUNTU.sh");
                    Utilities.Log(output);
                    Utilities.Log("Download Docker client TLS certificates from: " + dockerHostIP);
                    sshShell.Download(keyPfxContent, keyPfxBuffLength, "key.pfx", ".azuredocker/tls", true);

                    Utilities.Log("Trying to setup Docker config: " + dockerHostIP);

                    //// Setup Docker daemon to allow connection from any Docker clients
                    //output = sshShell.ExecuteCommand("bash -c ~/.azuredocker/CREATE_DEFAULT_DOCKERD_OPTS_TLS_DISABLED.sh");
                    //Utilities.Log(output);
                    //string dockerHostPort = "2375"; // Default Docker port when secured connection is disabled
                    //dockerHostTlsEnabled = false;

                    // Setup Docker daemon to allow connection from authorized Docker clients only
                    output = sshShell.ExecuteCommand("chmod +x ~/.azuredocker/CREATE_DEFAULT_DOCKERD_OPTS_TLS_ENABLED.sh");
                    output = sshShell.ExecuteCommand("bash -c ~/.azuredocker/CREATE_DEFAULT_DOCKERD_OPTS_TLS_ENABLED.sh");
                    Utilities.Log(output);
                    string dockerHostPort = "2376"; // Default Docker port when secured connection is enabled
                    dockerHostTlsEnabled = true;

                    dockerHostUrl = "tcp://" + dockerHostIP + ":" + dockerHostPort;
                }
            }
            catch (Exception exception)
            {
                Utilities.Log(exception);
                return null;
            }

            if (dockerHostTlsEnabled)
            {
                var credentials = new CertificateCredentials(new X509Certificate2(keyPfxContent));
                credentials.ServerCertificateValidationCallback += (o, c, ch, er) => true;
                return new DockerClientConfiguration(new Uri(dockerHostUrl), credentials).CreateClient();
            }
            else
            {
                return new DockerClientConfiguration(new Uri(dockerHostUrl)).CreateClient();
            }
        }



        /**
         * Installs Docker Engine and tools and adds current user to the docker group.
         */
        public static string INSTALL_DOCKER_FOR_UBUNTU_SERVER_16_04_LTS = ""
            + "echo Running: \"if [ ! -d ~/.azuredocker/tls ]; then mkdir -p ~/.azuredocker/tls ; fi\" \n"
            + "if [ ! -d ~/.azuredocker/tls ]; then mkdir -p ~/.azuredocker/tls ; fi \n"
            + "echo Running: sudo apt-get update \n"
            + "sudo apt-get update \n"
            + "echo Running: sudo apt-get install -y --no-install-recommends apt-transport-https ca-certificates curl software-properties-common \n"
            + "sudo apt-get install -y --no-install-recommends apt-transport-https ca-certificates curl software-properties-common \n"
            + "echo Running: curl -fsSL https://apt.dockerproject.org/gpg | sudo apt-key add - \n"
            + "curl -fsSL https://apt.dockerproject.org/gpg | sudo apt-key add - \n"
            + "echo Running: sudo add-apt-repository \"deb https://apt.dockerproject.org/repo/ ubuntu-$(lsb_release -cs) main\" \n"
            + "sudo add-apt-repository \"deb https://apt.dockerproject.org/repo/ ubuntu-xenial main\" \n"
            + "echo Running: sudo apt-get update \n"
            + "sudo apt-get update \n"
            + "echo Running: sudo apt-get -y install docker-engine \n"
            + "sudo apt-get -y install docker-engine \n"
            + "echo Running: sudo groupadd docker \n"
            + "sudo groupadd docker \n"
            + "echo Running: sudo usermod -aG docker $USER \n"
            + "sudo usermod -aG docker $USER \n";

        /**
         * Linux bash script that creates the TLS certificates for a secured Docker connection.
         */
        public static string CREATE_OPENSSL_TLS_CERTS_FOR_UBUNTU = ""
                + "echo Running: \"if [ ! -d ~/.azuredocker/tls ]; then rm -f -r ~/.azuredocker/tls ; fi\" \n"
                + "if [ ! -d ~/.azuredocker/tls ]; then rm -f -r ~/.azuredocker/tls ; fi \n"
                + "echo Running: mkdir -p ~/.azuredocker/tls \n"
                + "mkdir -p ~/.azuredocker/tls \n"
                + "echo Running: cd ~/.azuredocker/tls \n"
                + "cd ~/.azuredocker/tls \n"
                // Generate CA certificate
                + "echo Running: openssl genrsa -passout pass:$CERT_CA_PWD_PARAM$ -aes256 -out ca-key.pem 2048 \n"
                + "openssl genrsa -passout pass:$CERT_CA_PWD_PARAM$ -aes256 -out ca-key.pem 2048 \n"
                // Generate Server certificates
                + "echo Running: openssl req -passin pass:$CERT_CA_PWD_PARAM$ -subj '/CN=Docker Host CA/C=US' -new -x509 -days 365 -key ca-key.pem -sha256 -out ca.pem \n"
                + "openssl req -passin pass:$CERT_CA_PWD_PARAM$ -subj '/CN=Docker Host CA/C=US' -new -x509 -days 365 -key ca-key.pem -sha256 -out ca.pem \n"
                + "echo Running: openssl genrsa -out server-key.pem 2048 \n"
                + "openssl genrsa -out server-key.pem 2048 \n"
                + "echo Running: openssl req -subj '/CN=HOST_IP' -sha256 -new -key server-key.pem -out server.csr \n"
                + "openssl req -subj '/CN=HOST_IP' -sha256 -new -key server-key.pem -out server.csr \n"
                + "echo Running: \"echo subjectAltName = DNS:HOST_IP IP:127.0.0.1 > extfile.cnf \" \n"
                + "echo subjectAltName = DNS:HOST_IP IP:127.0.0.1 > extfile.cnf \n"
                + "echo Running: openssl x509 -req -passin pass:$CERT_CA_PWD_PARAM$ -days 365 -sha256 -in server.csr -CA ca.pem -CAkey ca-key.pem -CAcreateserial -out server.pem -extfile extfile.cnf \n"
                + "openssl x509 -req -passin pass:$CERT_CA_PWD_PARAM$ -days 365 -sha256 -in server.csr -CA ca.pem -CAkey ca-key.pem -CAcreateserial -out server.pem -extfile extfile.cnf \n"
                // Generate Client certificates
                + "echo Running: openssl genrsa -passout pass:$CERT_CA_PWD_PARAM$ -out key.pem \n"
                + "openssl genrsa -passout pass:$CERT_CA_PWD_PARAM$ -out key.pem \n"
                + "echo Running: openssl req -passin pass:$CERT_CA_PWD_PARAM$ -subj '/CN=client' -new -key key.pem -out client.csr \n"
                + "openssl req -passin pass:$CERT_CA_PWD_PARAM$ -subj '/CN=client' -new -key key.pem -out client.csr \n"
                + "echo Running: \"echo extendedKeyUsage = clientAuth,serverAuth > extfile.cnf \" \n"
                + "echo extendedKeyUsage = clientAuth,serverAuth > extfile.cnf \n"
                + "echo Running: openssl x509 -req -passin pass:$CERT_CA_PWD_PARAM$ -days 365 -sha256 -in client.csr -CA ca.pem -CAkey ca-key.pem -CAcreateserial -out cert.pem -extfile extfile.cnf \n"
                + "openssl x509 -req -passin pass:$CERT_CA_PWD_PARAM$ -days 365 -sha256 -in client.csr -CA ca.pem -CAkey ca-key.pem -CAcreateserial -out cert.pem -extfile extfile.cnf \n"
                // Generate .PFX key file to be used when connecting with the .Net Docker client
                + "echo Running: openssl pkcs12 -export -inkey key.pem -in cert.pem -out key.pfx -passout pass: -CAfile ca.pem \n"
                + "openssl pkcs12 -export -inkey key.pem -in cert.pem -out key.pfx -passout pass: -CAfile ca.pem \n"
                + "echo Running: cd ~ \n"
                + "cd ~ \n";

        /**
         * Bash script that sets up the TLS certificates to be used in a secured Docker configuration file; must be run on the Docker dockerHostUrl after the VM is provisioned.
         */
        public static string INSTALL_DOCKER_TLS_CERTS_FOR_UBUNTU = ""
                + "echo \"if [ ! -d /etc/docker/tls ]; then sudo mkdir -p /etc/docker/tls ; fi\" \n"
                + "if [ ! -d /etc/docker/tls ]; then sudo mkdir -p /etc/docker/tls ; fi \n"
                + "echo sudo cp -f ~/.azuredocker/tls/ca.pem /etc/docker/tls/ca.pem \n"
                + "sudo cp -f ~/.azuredocker/tls/ca.pem /etc/docker/tls/ca.pem \n"
                + "echo sudo cp -f ~/.azuredocker/tls/server.pem /etc/docker/tls/server.pem \n"
                + "sudo cp -f ~/.azuredocker/tls/server.pem /etc/docker/tls/server.pem \n"
                + "echo sudo cp -f ~/.azuredocker/tls/server-key.pem /etc/docker/tls/server-key.pem \n"
                + "sudo cp -f ~/.azuredocker/tls/server-key.pem /etc/docker/tls/server-key.pem \n"
                + "echo sudo chmod -R 755 /etc/docker \n"
                + "sudo chmod -R 755 /etc/docker \n";

        /**
         * Docker daemon config file allowing connections from any Docker client.
         */
        public static string DEFAULT_DOCKERD_CONFIG_TLS_ENABLED = ""
                + "[Service]\n"
                + "ExecStart=\n"
                + "ExecStart=/usr/bin/dockerd --tlsverify --tlscacert=/etc/docker/tls/ca.pem --tlscert=/etc/docker/tls/server.pem --tlskey=/etc/docker/tls/server-key.pem -H tcp://0.0.0.0:2376 -H unix:///var/run/docker.sock\n";

        /**
         * Bash script that creates a default TLS secured Docker configuration file; must be run on the Docker dockerHostUrl after the VM is provisioned.
         */
        public static string CREATE_DEFAULT_DOCKERD_OPTS_TLS_ENABLED = ""
                + "echo Running: sudo service docker stop \n"
                + "sudo service docker stop \n"
                + "echo \"if [ ! -d /etc/systemd/system/docker.service.d ]; then sudo mkdir -p /etc/systemd/system/docker.service.d ; fi\" \n"
                + "if [ ! -d /etc/systemd/system/docker.service.d ]; then sudo mkdir -p /etc/systemd/system/docker.service.d ; fi \n"
                + "echo sudo cp -f ~/.azuredocker/dockerd_tls.config /etc/systemd/system/docker.service.d/custom.conf \n"
                + "sudo cp -f ~/.azuredocker/dockerd_tls.config /etc/systemd/system/docker.service.d/custom.conf \n"
                + "echo Running: sudo systemctl daemon-reload \n"
                + "sudo systemctl daemon-reload \n"
                + "echo Running: sudo service docker start \n"
                + "sudo service docker start \n";

        /**
         * Docker daemon config file allowing connections from any Docker client.
         */
        public static string DEFAULT_DOCKERD_CONFIG_TLS_DISABLED = ""
                + "[Service]\n"
                + "ExecStart=\n"
                + "ExecStart=/usr/bin/dockerd --tls=false -H tcp://0.0.0.0:2375 -H unix:///var/run/docker.sock\n";

        /**
         * Bash script that creates a default unsecured Docker configuration file; must be run on the Docker dockerHostUrl after the VM is provisioned.
         */
        public static string CREATE_DEFAULT_DOCKERD_OPTS_TLS_DISABLED = ""
                + "echo Running: sudo service docker stop\n"
                + "sudo service docker stop\n"
                + "echo \"if [ ! -d /etc/systemd/system/docker.service.d ]; then sudo mkdir -p /etc/systemd/system/docker.service.d ; fi\" \n"
                + "if [ ! -d /etc/systemd/system/docker.service.d ]; then sudo mkdir -p /etc/systemd/system/docker.service.d ; fi \n"
                + "echo sudo cp -f ~/.azuredocker/dockerd_notls.config /etc/systemd/system/docker.service.d/custom.conf \n"
                + "sudo cp -f ~/.azuredocker/dockerd_notls.config /etc/systemd/system/docker.service.d/custom.conf \n"
                + "echo Running: sudo systemctl daemon-reload \n"
                + "sudo systemctl daemon-reload \n"
                + "echo Running: sudo service docker start \n"
                + "sudo service docker start \n";

    }
}
