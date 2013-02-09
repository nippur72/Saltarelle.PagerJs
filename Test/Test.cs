using System;
using System.Html;
using System.Collections;
using System.Runtime.CompilerServices;

using jQueryApi;
using KnockoutApi;

using PagerApi;

namespace TestPagerApi
{                                
    [IgnoreNamespace]   
    public class PageAccordionItem : Page
    {        
        public PageAccordionItem(Element element, Func<object> valueAccessor, Func<JsDictionary> allBindingsAccessor, object viewModel, object bindingContext) : base(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext)
        {
               
        }  
        
        private bool pageAccordionItemHidden = false;

        // get second child
        public Element GetAccordionBody()
        {
            return jQuery.FromElement(this.Element).Children()[1];
        }

        // hide second child
        public override void HideElement(Action callback)
        {
            // use hide if it is the first time the page is hidden
            if(!this.pageAccordionItemHidden) 
            {
               this.pageAccordionItemHidden = true;
               jQuery.FromElement(this.GetAccordionBody()).Hide();
               if(callback!=null) callback();
            } 
            else 
            { 
               // else use a slideUp animation
               jQuery.FromElement(this.GetAccordionBody()).SlideUp();
               if(callback!=null) callback();
            }
        }

        // show the second child using a slideDown animation
        public override void ShowElement(Action callback)
        {
            jQuery.FromElement(this.GetAccordionBody()).SlideDown();
            if(callback!=null) callback();
        }
    } 

    [IgnoreNamespace]
    public class PageAccordionItemBindingHandler : PageBindingHandler
    {
        public override object Init(Element element, Func<object> valueAccessor, Func<JsDictionary> allBindingsAccessor, object viewModel, object bindingContext)
        {
           var pageAccordionItem = new PageAccordionItem(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext);
           return pageAccordionItem.Init();           
        }
        
        /*
        public override void Update(Element element, Func<object> valueAccessor, Func<JsDictionary> allBindingsAccessor, object viewModel, object bindingContext)
        {
           
        }
        */ 
    }                

    public class MyViewModel
    {
    }            

    public class Program
    {
        static void Main()
        {            
           jQuery.OnDocumentReady(()=>DocumentReady());                      
        }
               
        static void DocumentReady()
        {                                                                                        
           Knockout.BindingHandlers["page-accordion-item"] = (dynamic) new PageAccordionItemBindingHandler();                                          

           MyViewModel mod = new MyViewModel();

           // if using History.js
           //Pager.UseHTML5history = true;
           //Pager.UseHistoryJsInHref5();

           Pager.ExtendWithPage(mod);                    

           Knockout.ApplyBindings(mod);
           
           // if using History.js
           //Pager.StartHistoryJs();

           // if using HashChange
           //Pager.StartHashChange();

           // if using HTML5 native history
           Pager.Start();                     
        }            
    }     
}
