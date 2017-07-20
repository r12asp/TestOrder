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

            int span = 5;
            int currentPage = pagingInfo.CurrntPage;
            StringBuilder result = new StringBuilder();
            for (int index = 1; index <= pagingInfo.TotalPages; index++)
            {
                if( currentPage>1 && index==currentPage-1)
                {
                    TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                    tag.MergeAttribute("href", pageUrl(index));
                    tag.Attributes.Add("OnClick", "NextPage(" + index + ")");
                    tag.InnerHtml = @"<<";
                    if (index == pagingInfo.CurrntPage)
                        tag.AddCssClass("active");
                    result.Append(@"<span style='margin - right:8px; padding: 3px'>" + tag.ToString() + @"</span>");
                    continue;

                }
                if ( index == currentPage+span  )
                {
                    TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                    tag.MergeAttribute("href", pageUrl(index));
                    tag.Attributes.Add("OnClick", "ccc(" + index + ")");
                    tag.InnerHtml = @">>";
                    if (index == pagingInfo.CurrntPage)
                        tag.AddCssClass("active");
                    result.Append(@"<span style='margin - right:8px; padding: 3px'>" + tag.ToString() + @"</span>");
                    continue;
                }
                if(index > currentPage+span)
                {
                    continue;
                }
                if (currentPage>2 && index < currentPage -1)
                {
                    continue;
                }

                TagBuilder tagNew = new TagBuilder("a"); // Construct an <a> tag
                tagNew.MergeAttribute("href", pageUrl(index));
                tagNew.Attributes.Add("OnClick", "ccc(" + index + ")");
                tagNew.InnerHtml = (index).ToString();
                if (index == pagingInfo.CurrntPage)
                    tagNew.AddCssClass("active");
                result.Append(@"<span style='margin - right:8px; padding: 3px'>" + tagNew.ToString() + @"</span>");
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}
