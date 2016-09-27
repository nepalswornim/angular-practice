// <reference path="angular.js" />
var myApp = angular.module("myApp", []);
myApp.controller("userCtrl", function ($scope, $http) {
    $scope.users = "";
    $http.get("/Home/GetAllUsers")
    .success(function (result) {
        $scope.users = result;
    })
.error(function (result) {
    console.log(result);
})

    $scope.saveuser = function (user) {
        debugger;
        $http.post("/Home/AddUser", { _tbl: user })
        .success(function (result) {
            debugger;
            $scope.users = result;

            $scope.user = "";
            $scope.message = "Inserted Successfully";
        })
        .error(function (result) {
            console.log(result);
        })
    }

    $scope.user = "";
    $scope.getbyid = function (id) {
        debugger;
        $http.post("/Home/GetById", { id: id })
        .success(function (result) {
            debugger;
            $scope.user = result;
        })
        .error(function (result) {
            console.log(error)
        })
    }

    $scope.updateuser = function (user) {
        debugger;
        $http.post("/Home/UpdateUser/", { _tbl: user })
        //this is the name in the public son result tablename object
        .success(function (result) {
            $scope.users = result;

            $scope.message = "Updated Successfully";
        })
        .error(function (result) {
            console.log(result);
        })
    }

    $scope.deleteuser = function (id) {
        debugger;
        varIsConf = confirm(' Are you sure Want to delete ?');
        if (varIsConf) {
            debugger;
            $http.post("/Home/DeleteUser/", { id: id })

            .success(function (result) {
                $scope.users = result;
                alert(" Deleted Successfully!!!");
            })
            .error(function (result) {
                alert(result);
            })
        }
    }
});