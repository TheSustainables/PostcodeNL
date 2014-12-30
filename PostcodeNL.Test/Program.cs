using System;

namespace PostcodeNL.Test {
    class Program {
        static void Main(string[] args) {
            var api = new AddressApi(apiKey: "<your key>", apiSecret: "<your secret>");

            var result = api.LookupAsync("2012ES", 30).Result;

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}