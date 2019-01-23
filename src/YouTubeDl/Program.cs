using System;
using NYoutubeDL;

namespace YouTubeDl {
    class Program {
        static void Main(string[] args) {
            var dl = new YoutubeDL();
            dl.Options.FilesystemOptions.Output = ".";
            dl.Options.PostProcessingOptions.ExtractAudio = true;
            dl.VideoUrl = args[0];

            dl.StandardErrorEvent += (s, o) => {
                Console.WriteLine("?? {0}", o);
            };

            dl.StandardOutputEvent += (s, o) => {
                Console.WriteLine(":: {0}", o);
            };

            dl.Download();
        }
    }
}
