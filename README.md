# PostcodeNL .NET client
 
PostcodeNL provides an async .NET wrapper around the Postcode.NL Address API.
 
## Installation
 
Install the package using NuGet: `postcodenl    `
 
## Usage
 
```
var api = new AddressApi(apiKey: "<your key>", apiSecret: "<your secret>");
var result = await api.LookupAsync("2012ES", 30);
if (result.IsSuccess) { ... }
```
 
## Contributing
 
1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request