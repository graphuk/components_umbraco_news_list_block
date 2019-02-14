using UmbracoGridConfigLoader.Models;
using UmbracoGridConfigLoader.Attributes;

namespace Graph.Components.NewsListBlock
{
	public class NewsListBlock : IGridConfigLoader
	{
		[GridLayoutProperty(Label = "News List Block", AllowedEditors = new[] { "newsListBlock" })]
		public IGridLayout Layout { get; set; }
	}
}
