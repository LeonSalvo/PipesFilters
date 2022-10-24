using System;
using CognitiveCoreUCU;

namespace CompAndDel
{
    public class FilterConditional : ICondicional
    {
        public string Path {get;set;}
        public FilterConditional(string path)
        {
            this.Path = path;
        }
        public IPicture Filter(IPicture image)
        {
            return image;
        }
        
        public bool ContieneCara()
        {
            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(this.Path);
            if (cog.FaceFound)
            {
                if (cog.SmileFound)
                {
                    return true;
                }
                else
                {
                    return false;;
                }
            }
            else
            {
                return false;
            }
        }
    }
}