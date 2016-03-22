namespace Security.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    }

    export class AboutController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }

}
