using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private const string allowedCharacters = "0123456789+-/*.";
        private string RemoveUnwantedChar(string input)
        {

            StringBuilder builder = new StringBuilder(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (allowedCharacters.Contains(input[i]))
                {
                    builder.Append(input[i]);
                }
            }
            return builder.ToString();
        }

        [HttpPost("DoCalculation")] //works in postman body json mode in url http://localhost:49937/api/DoCalculation
        public string DoCalculation([FromBody] string content)
        {
            content = RemoveUnwantedChar(content);

            bool match = Regex.IsMatch(content, "^(-|)(\\d+|\\d+\\.\\d+)(-|\\+|\\/|\\*)(-|)(\\d+|\\d+\\.\\d+)$");
            if (match == true)
            {
                if (content.Contains("/"))
                {
                    string[] final_list = content.Split('/');
                    return (float.Parse(final_list[0])/float.Parse(final_list[1])).ToString();
                }
                else if (content.Contains("*"))
                {
                    string[] final_list = content.Split('*');
                    return (float.Parse(final_list[0]) * float.Parse(final_list[1])).ToString();
                }
                else if (content.Contains("+"))
                {
                    string[] final_list = content.Split('+');
                    return (float.Parse(final_list[0]) + float.Parse(final_list[1])).ToString();
                }
                else
                {
                    var positionList = new List<int>();

                    for (int i = 0; i < content.Length; i++)
                    {
                        if (content[i] == '-')
                        {
                            positionList.Add(i);
                        }
                    }

                    if (positionList.Count == 1)
                    {
                        //x-x
                        string[] final_list = content.Split('-');
                        return (float.Parse(final_list[0]) - float.Parse(final_list[1])).ToString();
                    }
                    else if (positionList.Count == 3)
                    {
                        //-x--x
                        string[] final_list = content.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        return (float.Parse("-"+final_list[0]) - float.Parse("-"+final_list[1])).ToString();
                    }
                    else if (content.StartsWith("-"))
                    {
                        //-x-x
                        string[] final_list = content.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        return (float.Parse("-" + final_list[0]) - float.Parse(final_list[1])).ToString();
                    }
                    else
                    {
                        //x--x
                        string[] final_list = content.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        return (float.Parse(final_list[0]) - float.Parse("-"+final_list[1])).ToString();
                    }




                }

            }

            return "regex fail";

        }
    }

}
