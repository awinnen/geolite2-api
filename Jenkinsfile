pipeline {
    agent any
	
	environment {
		IMAGE_NAME = "geolite2-api"
	}
	
    stages {
        stage('build') {
			steps {
				sh 'docker build -f Geolite2-Api\Dockerfile -t geolite2-api .'
			}
        }
		stage('deploy') {
			when {
				branch 'master'
			}
			steps {
				withCredentials([usernamePassword(credentialsId: 'cluster-docker-registry', usernameVariable: 'DOCKER_USERNAME', passwordVariable: 'DOCKER_PASSWORD')]) {
					sh "docker login ${DOCKER_REPO} -u ${DOCKER_USERNAME} -p ${DOCKER_PASSWORD}";
					sh "docker tag geolite2-api ${DOCKER_REPO}/geolite2-api:latest"
					sh "docker push ${DOCKER_REPO}/geolite2-api:latest"
				}
			}
		}
    }
}