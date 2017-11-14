﻿(function () {
    'use strict';
    angular.module('app')
        .controller('userController', userController);

    userController.$inject = ['dataService', 'configService', '$state', '$scope'];
    function userController(dataService, configService, $state, $scope) {
        var apiUrl = configService.getApiUrl();
        var vm = this;

        //Propiedades
        vm.user = {};
        vm.userList = [];
        vm.modalButtonTitle = '';
        vm.readOnly = false;
        vm.isDelete = false;
        vm.modalTitle = '';
        vm.showCreate = false;
        vm.totalRecords = 0;
        vm.currentPage = 1;
        vm.maxSize = 10;
        vm.itemsPerPage = 30;
        //Funciones
        vm.getUser = getUser;
        vm.create = create;
        vm.edit = edit;
        vm.delete = userDelete;
        vm.pageChanged = pageChanged;
        vm.closeModal = closeModal;
        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            configurePagination()
        }

        function configurePagination() {
            //In case mobile just show 5 pages
            var widthScreen = (window.innerWidth > 0) ? window.innerWidth : screen.width;

            if (widthScreen < 420) vm.maxSize = 5;

            totalRecords();
        }

        function pageChanged() {
            getPageRecords(vm.currentPage);
        }

        function totalRecords() {
            dataService.getData(apiUrl + '/user/count')
                .then(function (result) {
                    vm.totalRecords = result.data;
                    getPageRecords(vm.currentPage);
                }
                , function (error) {
                    console.log(error);
                });
        }

        function getPageRecords(page) {
            dataService.getData(apiUrl + '/user/list/' + page + '/' + vm.itemsPerPage)
                .then(function (result) {
                    vm.userList = result.data;
                },
                function (error) {
                    vm.userList = [];
                    console.log(error);
                });
        }

        function getUser(id) {
            vm.user = null;
            dataService.getData(apiUrl + '/user/' + id)
                .then(function (result) {
                    vm.user = result.data;
                },
                function (error) {
                    vm.supplier = null;
                    console.log(error);
                });
        }

        function updateUser() {
            if (!vm.user) return;

            var oldPassword = document.getElementById("oldPassword").value;
            dataService.putData(apiUrl + '/user', vm.user)
                .then(function (result) {
                    vm.user = {};
                    getPageRecords(vm.currentPage);
                    closeModal();
                },
                function (error) {
                    vm.user = {};
                    console.log(error);
                });
        }

        function createUser() {
            if (!vm.user) return;
            dataService.postData(apiUrl + '/user', vm.user)
                .then(function (result) {
                    getUser(result.data);
                    detail();
                    getPageRecords(1);
                    vm.currentPage = 1;
                    vm.showCreate = true;
                },
                function (error) {
                    console.log(error);
                    closeModal();
                });
        }

        function deleteUser() {
            dataService.deleteData(apiUrl + '/user/' + vm.user.id)
                .then(function (result) {
                    getPageRecords(vm.currentPage);
                    closeModal();
                },
                function (error) {
                    console.log(error);
                });
        }

        function create() {
            vm.user = {};
            vm.modalTitle = 'Create User';
            vm.modalButtonTitle = 'Create';
            vm.readOnly = false;
            vm.modalFunction = createUser;
            vm.isDelete = false;
        }

        function edit() {
            vm.showCreate = false;
            vm.modalTitle = 'Edit User';
            vm.modalButtonTitle = 'Update';
            vm.readOnly = false;
            vm.modalFunction = updateUser;
            vm.isDelete = false;
        }

        function detail() {
            vm.modalTitle = 'The New User Created';
            vm.modalButtonTitle = '';
            vm.readOnly = true;
            vm.modalFunction = null;
            vm.isDelete = false;
        }

        function userDelete() {
            vm.showCreate = false;
            vm.modalTitle = 'Delete User';
            vm.modalButtonTitle = 'Delete';
            vm.readOnly = false;
            vm.modalFunction = deleteUser;
            vm.isDelete = true;
        }

        function closeModal() {
            angular.element('#modal-container').modal('hide');
        }
    }
})();