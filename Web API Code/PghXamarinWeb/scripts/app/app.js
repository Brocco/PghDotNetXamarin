var app = angular.module('pghX', ['ngResource']);

app.controller('ToDoCtrl', function ($scope, todoService) {
    $scope.todos = [];

    todoService
        .todos
        .query({}, function (data) {
            $scope.todos = data;
        });

    $scope.addTodo = function () {
        var todo = {
            text: $scope.newTodo
        };
        todoService.todos
            .save(todo, function (data) {
                $scope.todos.push(data);
                $scope.newTodo = '';
            });
    };

    $scope.saveTodo = function (todo) {
        todoService.todos
            .save(todo)
            .then(function (data) {
                todo = data;
            });
    }
    $scope.deleteTodo = function(todo) {
        todoService.todos
            .delete(todo, function() {
                var index = $scope.todos.indexOf(todo);
                $scope.todos.splice(index, 1);
            });
    }
});

app.service('todoServiceHTTP', function ($http) {
    function add(todo) {
        return $http
            .post('api/todo', { data: todo })
            .then(function (response) {
                return response.data;
            });
    }

    function update(todo) {
        $http
            .put('api/todo/' + todo.id, { data: todo })
            .then(function (response) {
                return response.data;
            });
    }

    this.add = add;
    this.update = update;
});

app.service('todoService', function ($resource) {
    this.todos = $resource('api/todo/:id', { id: '@id' });
});

