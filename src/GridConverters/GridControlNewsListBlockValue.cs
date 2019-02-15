using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Values;

namespace Graph.Components.NewsListBlock
{
	public class GridControlNewsListBlockValue : GridControlValueBase
	{
		public GridControlNewsListDataSourceItem[] NewsListDataSources { get; }

		public GridControlNewsListBlockValue(GridControl control, JToken obj) : base(control, obj as JObject)
		{
			NewsListDataSources = new GridControlNewsListDataSourceItem[]{};
			if (obj != null)
			{
				var newsListDataSource = JsonConvert.DeserializeObject<GridControlNewsListDataSource>(obj.ToString());
				if (newsListDataSource != null)
				{
					NewsListDataSources = newsListDataSource.DataSources;
				}
			}
		}

		public static GridControlNewsListBlockValue Parse(GridControl control, JToken obj)
		{
			return obj != null ? new GridControlNewsListBlockValue(control, obj) : null;
		}
	}
}
