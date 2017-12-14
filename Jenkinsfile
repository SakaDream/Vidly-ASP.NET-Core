node {
    docker.withRegistry('registry.heroku.com', 'Heroku_Access_Token') {

        stage "build"
        def app = docker.build "Vidly-ASP"
    
        stage "publish"
        app.push 'master'
        app.push "${commit_id}"
    }
}