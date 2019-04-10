using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Razor.Runtime;
using RockeyProject.Models;

namespace RockeyProject.Infrastructure
{
	// You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
	[HtmlTargetElement("AboutEmployee")]
	public class AboutEmployeeTagHelper : TagHelper
	{
		public Employee Employee { get; set; }
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{

			output.Content.AppendHtml("<div class='col-2 d-inline-block'>");
			output.Content.AppendHtml($"<img src='{Employee.Photo}' alt='{Employee.FullName}' height='150' width='150'>");
			output.Content.AppendHtml($"<p class='m-0'>{Employee.FullName}</p>");
            output.Content.AppendHtml($"<p class='m-0'>{Employee.Position}</p>");
            output.Content.AppendHtml($"<p class='m-0'>{Employee.Email}</p>");
			output.Content.AppendHtml($"<p class='m-0'>{Employee.PhoneNumber}</p>");
			output.Content.AppendHtml("</div>");

		}
}
}
