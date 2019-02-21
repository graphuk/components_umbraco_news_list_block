using UmbracoGridConfigLoader.Models;
using UmbracoGridConfigLoader.Attributes;

namespace Graph.Components.NewsListBlock
{
	public class NewsListBlock : IGridConfigLoader
	{
		[GridLayoutProperty(Label = "News List Block", AllowedEditors = new[] { "newsListBlock" }, MaxItems = 1)]
		public IGridLayout Layout { get; set; }
	}
}
