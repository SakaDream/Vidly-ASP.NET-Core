node {
    docker.withRegistry('https://registry.heroku.com', 'Heroku_Access_Token') {

        stage "build"
        def app = docker.build "vidly7162"
    
        stage "publish"
        app.push 'registry.heroku.com/vidly7162/web'
        app.push "${commit_id}"
    }
}