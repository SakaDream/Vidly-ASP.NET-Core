pipeline {
  agent { dockerfile true }
  stages {
    stage('Build') {
      steps {
        sh 'docker build -t Vidly .'
      }
    }
    stage('Run') {
      steps {
        sh 'docker run -d -p 8081 --name Vidly'
      }
    }
  }
}