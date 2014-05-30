var exec = require('cordova/exec');

var ViewportHeight = {
    get: function (success, err) {
        exec(success, err, "ViewportHeight", "get", []);
    }
};

module.exports = ViewportHeight;