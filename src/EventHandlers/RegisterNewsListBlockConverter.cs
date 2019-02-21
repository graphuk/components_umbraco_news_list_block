using Umbraco.Core;
using Umbraco.Web.UI.JavaScript;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Web;

namespace Graph.Components.NewsListBlock
{
	public class RegisterNewsListBlockConverter : IApplicationEventHandler
	{
		public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
		}

		public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
		}

		public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			Skybrud.Umbraco.GridData.GridContext.Current.Converters.Add(new NewsListBlockGridConverter());
			ServerVariablesParser.Parsing += Parsing;
		}

		private void Parsing(object sender, Dictionary<string, object> dictionary)
		{
			if (HttpContext.Current == null) throw new InvalidOperationException("HttpContext is null");
			var urlHelper = new UrlHelper(new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData()));
			if (dictionary.ContainsKey("umbracoUrls"))
				((Dictionary<string, object>) dictionary["umbracoUrls"]).Add("newsListBlockApi",
					urlHelper.GetUmbracoApiServiceBaseUrl<NewsListBlockApiController>(controller => controller.GetEditorConfig()));
		}
	}
}
