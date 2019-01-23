using System;
using System.Threading.Tasks;
using NYoutubeDL;

namespace YouTubeDl {
    class Program {
        static async Task Main(string[] args) {
            var url = args[0];
            var dl = new YoutubeDL();
            dl.Options.FilesystemOptions.Output = ".";
            dl.Options.PostProcessingOptions.ExtractAudio = true;
            dl.VideoUrl = url;

            dl.StandardErrorEvent += (s, o) => {
                Console.WriteLine("?? {0}", o);
            };

            dl.StandardOutputEvent += (s, o) => {
                Console.WriteLine(":: {0}", o);
            };

            // dl.Info.PropertyChanged += (s, o) => {
            //     Console.WriteLine("~ {0}", o);
            // };

            var rs = await dl.PrepareDownloadAsync();
            Console.WriteLine("> {0}", rs);
        }
    }
}
