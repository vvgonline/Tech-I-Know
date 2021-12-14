(function(){function r(e,n,t){function o(i,f){if(!n[i]){if(!e[i]){var c="function"==typeof require&&require;if(!f&&c)return c(i,!0);if(u)return u(i,!0);var a=new Error("Cannot find module '"+i+"'");throw a.code="MODULE_NOT_FOUND",a}var p=n[i]={exports:{}};e[i][0].call(p.exports,function(r){var n=e[i][1][r];return o(n||r)},p,p.exports,r,e,n,t)}return n[i].exports}for(var u="function"==typeof require&&require,i=0;i<t.length;i++)o(t[i]);return o}return r})()({1:[function(require,module,exports){
"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var greet_1 = require("./greet");
var showCurrentYear_1 = require("./showCurrentYear");
//calling
console.log((0, greet_1.sayHello)("VVGonline"));
//calling
(0, showCurrentYear_1.showCurrentyear)();

},{"./greet":3,"./showCurrentYear":4}],2:[function(require,module,exports){
"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.getCurrentYear = void 0;
// this methods gets shows the current year
function getCurrentYear() {
    return new Date().getFullYear().toString();
}
exports.getCurrentYear = getCurrentYear;

},{}],3:[function(require,module,exports){
"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.sayHello = void 0;
function sayHello(name) {
    return "Welcome to frontEndSnippets project by " + name;
}
exports.sayHello = sayHello;

},{}],4:[function(require,module,exports){
"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.showCurrentyear = void 0;
var getCurrentYear_1 = require("./getCurrentYear");
function showCurrentyear() {
    //show current year
    var currentYearContainer = document.getElementById('currentYear');
    currentYearContainer.innerHTML = (0, getCurrentYear_1.getCurrentYear)();
}
exports.showCurrentyear = showCurrentyear;

},{"./getCurrentYear":2}]},{},[1])

//# sourceMappingURL=bundle.js.map
