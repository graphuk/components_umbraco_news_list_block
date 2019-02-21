using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Graph.Components.NewsListBlock
{
	public class NewsListBlockSurfaceController : SurfaceController
	{
		public ActionResult NewsList(GridControlNewsListDataSourceItem[] dataSources, int page = 1)
		{
			var allNews = new List<NewsListItem>();
			var totalNewsCount = 0;
			if (dataSources != null && dataSources.Length > 0)
			{
				foreach (var dataSourceItem in dataSources)
				{
					var dataSourceContent = new UmbracoHelper(UmbracoContext.Current).TypedContent(dataSourceItem.Id);

					allNews.AddRange(dataSourceContent.Descendants(NewsListBlockConfig.NewsPageAlias)
						.Where(newsPage => newsPage.IsVisible())
						.Select(newsPage => new NewsListItem
						{
							Url = newsPage.Url,
							Title = newsPage.GetPropertyValue<string>(NewsListBlockConfig.Title),
							Description = newsPage.GetPropertyValue<string>(NewsListBlockConfig.Description),
							Date = newsPage.GetPropertyValue<DateTime>(NewsListBlockConfig.Date),
							Image = newsPage.GetPropertyValue<IPublishedContent>(NewsListBlockConfig.Image)?.Url
						}));
				}

				totalNewsCount = allNews.Count;
			}

			return View("/App_Plugins/NewsListBlock/Views/NewsList.cshtml", new NewsListBlockModel
			{
				News = allNews.OrderByDescending(x => x.Date).Skip((page - 1) * NewsListBlockConfig.PageSize).Take(NewsListBlockConfig.PageSize),
				PageNavigationModel = new PageNavigationModel(page, (int)Math.Ceiling((decimal)totalNewsCount / NewsListBlockConfig.PageSize), totalNewsCount, NewsListBlockConfig.PageSize)
			});
		}
	}
}
