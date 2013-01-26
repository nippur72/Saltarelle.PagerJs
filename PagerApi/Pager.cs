using System;
using System.Html;
using System.Runtime.CompilerServices;


namespace PagerApi
{		
    [Imported(IsRealType=true)]
    [IgnoreNamespace]
	 [ScriptName("pager")]
    public static class Pager
    {
        /// <summary>
        /// if using History.js, tell page-href to use page-href5
        /// </summary>
        public static bool UseHTML5history;

        /*
        /// <summary>
        /// tell page-href5 to use History.js instead of history
        /// </summary>
        public static object Href5History
        {
            [InlineCode("pager.Href5.History")]
            get 
            { 
                return null;
            }
            [InlineCode("pager.Href5.History = {value}")]
            set 
            {
            }            
        }
        */

        /// <summary>
        /// tell page-href5 to use History.js instead of history
        /// </summary>
        [InlineCode("pager.Href5.history = History;")]
        public static void UseHistoryJsInHref5()
        {
        }

        public static void ExtendWithPage(object ViewModel) { }
        /// <summary>
        ///    Used if you are using neither jQuery hashchange nor History.js. This method does not work for IE7 and can give unexpected results for IE8!
        /// </summary>
        public static void Start() { }

        /// <summary>
        ///    Used if you are using neither jQuery hashchange nor History.js. This method does not work for IE7 and can give unexpected results for IE8!
        /// </summary>
        public static void Start(string page_id) {}

        /// <summary>
        ///    Used if you are using jQuery hashchange.
        /// </summary>
        public static void StartHashChange() {}

        /// <summary>
        ///    Used if you are using jQuery hashchange.
        /// </summary>
        public static void StartHashChange(string page_id) {}

        /// <summary>
        ///    Used if you are using History.js. 
        /// </summary>
        public static void StartHistoryJs() {}

        /// <summary>
        ///    Used if you are using History.js. 
        /// </summary>
        public static void StartHistoryJs(string page_id) {}

        /// <summary>
        ///    Display the pages matching the route (String-array) without changing the location.
        ///    This method is called by pager.start, pager.startHashChange and pager.startHistoryJS. 
        ///    If you plan to implement your own start-method you'll need to call this method with the calculated route. 
        /// </summary>
        public static void ShowChild(String[] page_ids) {}        
    }    
}


