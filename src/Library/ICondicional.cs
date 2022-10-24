using System;
namespace CompAndDel
{
    public interface ICondicional : IFilter
    {
        new IPicture Filter(IPicture image);
        bool ContieneCara();

    }
}