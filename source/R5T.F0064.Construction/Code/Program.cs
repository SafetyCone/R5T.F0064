using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;


namespace R5T.F0064.Construction
{
    partial class Program
    {
        private ILogger Logger { get; }


        public Program(
            ILogger<Program> logger)
        {
            this.Logger = logger;
        }

        public Task Run()
        {
            this.Logger.LogInformation("Hello world!");

            Console.WriteLine("Hello world!");

            return Task.CompletedTask;
        }
    }
}