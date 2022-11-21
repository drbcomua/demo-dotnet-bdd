pipeline {
    agent any
    stages {
        stage('Git') {
            steps {
                git branch: 'main', url: 'https://github.com/drbcomua/demo-dotnet-bdd/'
            }
        }
        stage('Clean') {
            steps {
                dotnetClean()
            }
        }
        stage('Run Tests') {
            steps {
                catchError {
                    dotnetTest sdk: 'net60'
                }
                echo currentBuild.result
            }
        }
        stage('Reports') {
            steps {
                script {
                    allure includeProperties: false, jdk: '', results: [[path: 'UITestProject/bin/Debug/net6.0/allure-results'], [path: 'APITestProject/bin/Debug/net6.0/allure-results'], [path: 'MessageTestProject/bin/Debug/net6.0/allure-results']]
                }
            }
        }
    }
}