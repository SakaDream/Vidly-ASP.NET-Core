pipeline {
  agent none
  stages {
    stage('Build') {
      steps {
        sh 'docker build -t Vidly .'
      }
    }
    stage('Run') {
      steps {
        sh 'docker run -d -p 8080:80 --name Vidly'
      }
    }
  }
}