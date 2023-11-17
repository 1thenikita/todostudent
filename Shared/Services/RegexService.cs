using System.Text.RegularExpressions;

namespace TodoStudent.Shared.Services;

public static class RegexService
{
    public static string GetClearPhone(this string input)
    {
        var res = input;
        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }
        
        res = res.Replace("+", string.Empty).Trim();
        res = res.Replace("+7", "7").Trim();
        if (input.Length > 2)
        {
            if (input[0] == '8')
            {
                res = res.Remove(0, 1);
                res = res.Insert(0, "7");
            }
        }
        res = Regex.Replace(res, @"[^\d]", "");
        input = res;
        return res;
        // return Regex.Replace(input, @"/\D/g", "$1");
    }
}