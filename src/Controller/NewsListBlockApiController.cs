using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace Graph.Components.NewsListBlock
{
	[PluginController("NewsListBlock")]
	public class NewsListBlockApiController : UmbracoAuthorizedJsonController
	{
		public EditorConfig GetEditorConfig()
		{
			return new EditorConfig
			{
				NewsListAlias = NewsListBlockConfig.NewsListPageAlias
			};
		}
	}

	public class EditorConfig
	{
		public string NewsListAlias { get; set; }
	}
}
