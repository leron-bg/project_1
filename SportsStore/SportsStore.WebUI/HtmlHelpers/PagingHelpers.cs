namespace SportsStore.WebUI.HtmlHelpers
{
	using SportsStore.WebUI.Models;
	using System;
	using System.Text;
	using System.Web.Mvc;

	public static class PagingHelpers
	{
		public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
		{
			var result = new StringBuilder();
			for (int i = 1; i <= pagingInfo.TotalPages; i++)
			{
				TagBuilder tag = new TagBuilder("a");
				tag.MergeAttribute("href", pageUrl(i));
				tag.InnerHtml = i.ToString();

				if (i == pagingInfo.CurrentPage)
				{
					tag.AddCssClass("selected");
					tag.AddCssClass("btn-primary");
				}
				tag.AddCssClass("btn btn-default");

				result.Append(tag.ToString());
			}

			return MvcHtmlString.Create(result.ToString());
		}
	}
}