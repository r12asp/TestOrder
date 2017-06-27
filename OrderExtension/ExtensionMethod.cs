using DomainModelOrder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OrderExtension
{
    public static class extensionmethods
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string SortField, bool Ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, SortField);
            var exp = Expression.Lambda(prop, param);
            string method = Ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }

        public static MvcHtmlString PageLinks(this HtmlHelper html,
                 PaginationViewModel pagingInfo, Func<int, string> pageUrl)
        {
            if (pagingInfo.TotalPages == 1)
                return MvcHtmlString.Create(String.Empty);

            StringBuilder result = new StringBuilder();
            for (int index = 1; index <= pagingInfo.TotalPages; index++)
            {
                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", pageUrl(index));
                tag.Attributes.Add("OnClick", "ccc(" + index + ")");
                tag.InnerHtml = (index).ToString();
                if (index == pagingInfo.CurrntPage)
                    tag.AddCssClass("selected");
                result.Append(@"<span style='margin - right:8px; padding: 3px'>" + tag.ToString() + @"</span>");
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}
