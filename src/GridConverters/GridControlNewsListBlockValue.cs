using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Values;

namespace Graph.Components.NewsListBlock
{
	public class GridControlNewsListBlockValue : GridControlValueBase
	{
		public GridControlNewsListBlockItem GridControlMabBlockItem { get; protected set; }

		public GridControlNewsListBlockValue(GridControl control, JToken obj) : base(control, obj as JObject)
		{
			GridControlMabBlockItem = JsonConvert.DeserializeObject<GridControlNewsListBlockItem>(obj.ToString());
		}

		public static GridControlNewsListBlockValue Parse(GridControl control, JToken obj)
		{
			if (obj != null)
				return new GridControlNewsListBlockValue(control, obj);
			return (GridControlNewsListBlockValue)null;
		}
	}
}
