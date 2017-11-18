describe('dataService', function() {
    beforeEach(module('app'));

    it('Should be ok',
        inject(
            function (dataService, $httpBackend) {
                $httpBackend
                    .expectGET('/test')
                    .respond(200, 'ok');
                
                dataService.getData('/test').then(function(response) {
                        expect(response.data).toEqual('ok');
                });
            }
        )
    );

    it('Should be error',
        inject(
            function (dataService, $httpBackend) {
                $httpBackend
                    .expectGET('/error')
                    .respond(400, 'error');
                
                dataService.getData('/error').then(function(response) {
                        expect(response.status).toEqual('400');
                        expect(response.data).toEqual('Error');
                });
            }
        )
    );
})