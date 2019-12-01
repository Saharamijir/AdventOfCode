using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstPuzzle
{
    static class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine(await LoadData()
                .GetIntValues()
                .CalculateFuelNeededForModules()
                .ReduceResult());
        }

        private async static Task<string[]> LoadData() => await File.ReadAllLinesAsync("input.txt");
        private async static Task<IEnumerable<int>> GetIntValues(this Task<string[]> input) => (await input).Select(i => int.Parse(i));
        private async static Task<IEnumerable<int>> CalculateFuelNeededForModules(this Task<IEnumerable<int>> input) =>
            (await input).Select(i => (i / 3) - 2);
        private async static Task<int> ReduceResult(this Task<IEnumerable<int>> input) => (await input).Sum();
    }
    
}
