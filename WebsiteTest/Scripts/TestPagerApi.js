(function() {
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
				if (!ss.staticEquals(callback, null)) {
					callback();
				}
			}
			else {
				// else use a slideUp animation
				$(this.getAccordionBody()).slideUp();
				if (!ss.staticEquals(callback, null)) {
					callback();
				}
			}
		},
		showElement: function(callback) {
			$(this.getAccordionBody()).slideDown();
			if (!ss.staticEquals(callback, null)) {
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
			return pageAccordionItem.init();
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
		$(function() {
			$TestPagerApi_Program.$documentReady();
		});
	};
	$TestPagerApi_Program.$documentReady = function() {
		ko.bindingHandlers['page-accordion-item'] = new $PageAccordionItemBindingHandler();
		var mod = new $TestPagerApi_MyViewModel();
		// if using History.js
		//Pager.UseHTML5history = true;
		//Pager.UseHistoryJsInHref5();
		pager.extendWithPage(mod);
		ko.applyBindings(mod);
		// if using History.js
		//Pager.StartHistoryJs();
		// if using HashChange
		//Pager.StartHashChange();
		// if using HTML5 native history
		pager.start();
	};
	ss.registerClass(global, 'PageAccordionItem', $PageAccordionItem, pager.Page);
	ss.registerClass(global, 'PageAccordionItemBindingHandler', $PageAccordionItemBindingHandler, Object);
	ss.registerClass(global, 'TestPagerApi.MyViewModel', $TestPagerApi_MyViewModel);
	ss.registerClass(global, 'TestPagerApi.Program', $TestPagerApi_Program);
	$TestPagerApi_Program.$main();
})();
