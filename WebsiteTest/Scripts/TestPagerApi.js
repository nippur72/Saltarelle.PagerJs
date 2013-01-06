////////////////////////////////////////////////////////////////////////////////
// TestPagerApi.PageAccordionItem
var $PageAccordionItem = function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
	this.$pageAccordionItemHidden = false;
	pager.Page.call(this, element, valueAccessor, allBindingsAccessor, viewModel, bindingContext);
};
$PageAccordionItem.prototype = {
	getAccordionBody: function() {
		return $(this.element).children()[1];
	},
	hideElement: function(callback) {
		// use hide if it is the first time the page is hidden
		if (!this.$pageAccordionItemHidden) {
			this.$pageAccordionItemHidden = true;
			$(this.getAccordionBody()).hide();
			if (ss.isValue(callback)) {
				callback();
			}
		}
		else {
			// else use a slideUp animation
			$(this.getAccordionBody()).slideUp();
			if (ss.isValue(callback)) {
				callback();
			}
		}
	},
	showElement: function(callback) {
		$(this.getAccordionBody()).slideDown();
		if (ss.isValue(callback)) {
			callback();
		}
	}
};
////////////////////////////////////////////////////////////////////////////////
// TestPagerApi.PageAccordionItemBindingHandler
var $PageAccordionItemBindingHandler = function() {
	Object.call(this);
};
$PageAccordionItemBindingHandler.prototype = {
	init: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
		var pageAccordionItem = new $PageAccordionItem(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext);
		pageAccordionItem.init();
	},
	update: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
	}
};
////////////////////////////////////////////////////////////////////////////////
// TestPagerApi.MyViewModel
var $TestPagerApi_MyViewModel = function() {
};
////////////////////////////////////////////////////////////////////////////////
// TestPagerApi.Program
var $TestPagerApi_Program = function() {
};
$TestPagerApi_Program.$main = function() {
	window.addEventListener('load', $TestPagerApi_Program.$onLoaded);
};
$TestPagerApi_Program.$onLoaded = function(e) {
	ko.bindingHandlers['page-accordion-item'] = new $PageAccordionItemBindingHandler();
	var mod = new $TestPagerApi_MyViewModel();
	pager.useHTML5history = true;
	pager.Href5.History = window.history;
	pager.extendWithPage(mod);
	ko.applyBindings(mod);
	pager.start();
};
Type.registerClass(global, 'PageAccordionItem', $PageAccordionItem, pager.Page);
Type.registerClass(global, 'PageAccordionItemBindingHandler', $PageAccordionItemBindingHandler);
Type.registerClass(global, 'TestPagerApi.MyViewModel', $TestPagerApi_MyViewModel, Object);
Type.registerClass(global, 'TestPagerApi.Program', $TestPagerApi_Program, Object);
