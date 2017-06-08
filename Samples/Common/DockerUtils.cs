using Docker.DotNet;
using System;
using System.Text;

namespace Microsoft.Azure.Management.Samples.Common
{
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
         * Install Docker on a given virtual machine and return a DockerClient.
         * @param dockerHostIP - address (IP) of the Docker host machine
         * @param vmUserName - user name to connect with to the Docker host machine
         * @param vmPassword - password to connect with to the Docker host machine
         * @param registryServerUrl - address of the private container registry
         * @param username - user name to connect with to the private container registry
         * @param password - password to connect with to the private container registry
         * @return an instance of DockerClient
         */
        public static DockerClient installDocker(string dockerHostIP, string vmUserName, string vmPassword,
                                                 string registryServerUrl, string username, string password)
        {
            String keyPemContent = ""; // it stores the content of the key.pem certificate file
            String certPemContent = ""; // it stores the content of the cert.pem certificate file
            String caPemContent = ""; // it stores the content of the ca.pem certificate file
            bool dockerHostTlsEnabled = false;
            String dockerHostUrl = "tcp://" + dockerHostIP + ":2375";
            SSHShell sshShell = null;

            try
            {
                Utilities.Log("Copy Docker setup scripts to remote host: " + dockerHostIP);
                sshShell = SSHShell.Open(dockerHostIP, 22, vmUserName, vmPassword);

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
                string output = sshShell.ExecuteCommand("bash -c ~/.azuredocker/INSTALL_DOCKER_FOR_UBUNTU_SERVER_16_04_LTS.sh");
                Utilities.Log(output);

                Utilities.Log("Trying to create OPENSSL certificates");
                output = sshShell.ExecuteCommand("bash -c ~/.azuredocker/CREATE_OPENSSL_TLS_CERTS_FOR_UBUNTU.sh");
                Utilities.Log(output);

                Utilities.Log("Trying to install TLS certificates");

                output = sshShell.ExecuteCommand("bash -c ~/.azuredocker/INSTALL_DOCKER_TLS_CERTS_FOR_UBUNTU.sh");
                Utilities.Log(output);
                Utilities.Log("Download Docker client TLS certificates from: " + dockerHostIP);
                keyPemContent = sshShell.Download("key.pem", ".azuredocker/tls", true);
                certPemContent = sshShell.Download("cert.pem", ".azuredocker/tls", true);
                caPemContent = sshShell.Download("ca.pem", ".azuredocker/tls", true);

                Utilities.Log("Trying to setup Docker config: " + dockerHostIP);

                //// Setup Docker daemon to allow connection from any Docker clients
                //output = sshShell.ExecuteCommand("bash -c ~/.azuredocker/CREATE_DEFAULT_DOCKERD_OPTS_TLS_DISABLED.sh");
                //Utilities.Log(output);
                //dockerHostPort = "2375"; // Default Docker port when secured connection is disabled
                //dockerHostTlsEnabled = false;

                // Setup Docker daemon to allow connection from authorized Docker clients only
                output = sshShell.ExecuteCommand("bash -c ~/.azuredocker/CREATE_DEFAULT_DOCKERD_OPTS_TLS_ENABLED.sh");
                Utilities.Log(output);
                String dockerHostPort = "2376"; // Default Docker port when secured connection is enabled
                dockerHostTlsEnabled = true;

                dockerHostUrl = "tcp://" + dockerHostIP + ":" + dockerHostPort;
            }
            catch (Exception exception)
            {
                Utilities.Log(exception);
                return null;
            }

            DockerClientConfiguration dockerClientConfig;

            if (dockerHostTlsEnabled)
            {
                dockerClientConfig = new DockerClientConfiguration(new Uri(""));
                //dockerClientConfig = createDockerClientConfig(dockerHostUrl, registryServerUrl, username, password,
                //        caPemContent, keyPemContent, certPemContent);
            }
            else
            {
                dockerClientConfig = new DockerClientConfiguration(new Uri(""));
                //dockerClientConfig = createDockerClientConfig(dockerHostUrl, registryServerUrl, username, password);
            }

            //return DockerClientBuilder.getInstance(dockerClientConfig).build();
            return dockerClientConfig.CreateClient();
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
