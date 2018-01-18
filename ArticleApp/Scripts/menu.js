var menu = function (pageTitle) {
    this.pageTitle = pageTitle;
    this.bindEvents(); // binding events as soon as the object is instantiated
    this.additionalEvents(); // additional events such as DOM manipulation etc
};
var menu.prototype.bindEvents = function () {
    $('ul.menu').on('click', 'li.has-submenu', $.proxy(this.toggleSubMenu, this));
    $('input#e-mail').on('click', $.proxy(this.openEmail, this));
};
var menu.prototype.toggleSubMenu = function (e) {
    //Toggle submenu. 'this' is the current context.
};
