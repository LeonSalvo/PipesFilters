using System;
using TwitterUCU;
namespace CompAndDel
{
    public class FilterTwitter : IFilter
    {
        public string Mensaje{get;set;}
        public string Path{get;set;}

        public FilterTwitter(string mensaje, string path)
        {
            this.Mensaje = mensaje;
            this.Path = path;
        }
        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter(this.Mensaje, this.Path));

            return image;
        }

    }
}