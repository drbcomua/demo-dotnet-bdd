pipeline {
    agent any
    stages {
        stage('Run Tests') {
            steps {
                script {
                    docker.image('mcr.microsoft.com/dotnet/sdk:6.0').inside('-v ${WORKSPACE}:/src -v /var/nuget/:/tmp/nuget/ -e NUGET_PACKAGES=/tmp/nuget/packages -e DOTNET_CLI_HOME=/tmp/dotnet') { c -> 
                        sh 'cd /src; dotnet publish -c Release '
                    }
                }
            }
        }
    }
}
