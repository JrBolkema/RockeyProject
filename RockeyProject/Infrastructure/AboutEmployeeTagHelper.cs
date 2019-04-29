using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Razor.Runtime;
using RockeyProject.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace RockeyProject.Infrastructure
{
	
	[HtmlTargetElement("AboutEmployee")]
	public class AboutEmployeeTagHelper : TagHelper
	{
		
		public Employee Employee { get; set; }

		// creates html for an about section of an employee
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{

	
			output.Content.AppendHtml("<div class='col-2 d-inline-block'>");
			output.Content.AppendHtml($"<img src=/lib/Photos/{Employee.Photo} alt='{Employee.FullName}' height='140' width='180'>");
			output.Content.AppendHtml($"<p class='m-0'>{Employee.FullName}</p>");
            output.Content.AppendHtml($"<p class='m-0'>{Employee.Position}</p>");
            output.Content.AppendHtml($"<p class='m-0'>{Employee.Email}</p>");
			output.Content.AppendHtml($"<p class='m-0'>{Employee.PhoneNumber}</p>");
			output.Content.AppendHtml("</div>");

		}
}
}
