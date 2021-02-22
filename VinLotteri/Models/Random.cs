using System.Collections.Generic;

namespace VinLotteri.Models
{
    public class Response
    {
        public string jsonrpc { get; set; }
        public Result result { get; set; }
        public string id { get; set; }
    }

    public class Result
    {
        public Random random { get; set; }
        public string bitsUsed { get; set; }
        public string bitsLeft { get; set; }
        public string requestsLeft { get; set; }
        public string advisoryDelay { get; set; }
    }

    public class Random
    {
        public List<string> data { get; set; }
        public string completionTime { get; set; }
    }
}