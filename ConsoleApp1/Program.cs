// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Net;

Console.WriteLine("Hello, World!");

static IPAddressPart stringToIPAdressPart(string ip)
{
    var ipSplitStr = ip.Split(".").ToList();
    return new IPAddressPart()
    {
        num1 = Int32.Parse(ipSplitStr[0]),
        num2 = Int32.Parse(ipSplitStr[1]),
        num3 = Int32.Parse(ipSplitStr[2]),
        num4 = Int32.Parse(ipSplitStr[3])
    };
}

static string getIpRange(List<string> IPs)
{
    string ipRange = "";
    
    if (IPs.Count == 1)
    {
        var part = stringToIPAdressPart(IPs.First());
        if (part.num4 > 1 && part.num4 < 255)
        {
            ipRange = 
        }
        ipRange = $"0.0.0.0-{part[0]}.{part[1]}"
    }

    
    if (ipSplit[3] > 1 && ipSplit[3] < 255)
    {

    }
}

List<string> vs = new List<string>() { "1.52.45.246", "55.11.26.54"};
Console.WriteLine(getIpRangeExclude(vs));