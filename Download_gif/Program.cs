using System.Net;

namespace Download_gif
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            if (args.Length == 2)
            {
                var fileName = (DateTime.Now).ToFileTime() + ".gif";


                if (!Directory.Exists(args[1]))
                {
                    Directory.CreateDirectory(args[1]);
                }

                try
                {
                    Task<Stream> httpResponseStream = client.GetStreamAsync(args[0]);
                    
                        Stream response = await httpResponseStream;

                        int bufferSize = 1024;
                        byte[] buffer = new byte[bufferSize];
                        int bytesRead = 0;


                        FileStream fileStream = File.Create(args[1] + fileName);
                        while ((bytesRead = response.Read(buffer, 0, bufferSize)) != 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}