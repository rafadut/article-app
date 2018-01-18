//var Contact = function (pageTitle) {
//    this.pageTitle = pageTitle;
//    this.bindEvents(); // binding events as soon as the object is instantiated
//    this.additionalEvents(); // additional events such as DOM manipulation etc
//};

var Contact = function (pageTitle) {
    this.pageTitle = pageTitle;
    new menu(pageTitle);
    // binding events as soon as the object is instantiated
    this.bindEvents();
};

var Contact.prototype.bindEvents = function () {
    $('ul.menu').on('click', 'li.email, $.proxy(this.toggleEmail, this));
            };

var Contact.prototype.toggleEmail = function (e) {
    //Toggle the email feature on the page
};