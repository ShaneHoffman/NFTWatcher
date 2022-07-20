using System;
using Microsoft.JSInterop;

namespace NFTWatcherV1.Client.Services.BrowserService
{
    public class BrowserService : IBrowserServcie
    {
        private readonly IJSRuntime _js;

        public BrowserService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<BrowserDimensions> GetDimensions()
        {
            var result = await _js.InvokeAsync<BrowserDimensions>("getDimensions");
            Console.WriteLine($"rwidth: {result.Width} and height: {result.Height}");
            return result;
        }
    }

    public class BrowserDimensions
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
