using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            
            PictureProvider provider2 = new PictureProvider();
            IPicture picture2 = provider.GetPicture(@"beer.jpg");

            PipeNull nulo = new PipeNull();

            FilterGreyscale filtroGris = new FilterGreyscale();
            FilterNegative filtroNegativo = new FilterNegative();
            FilterSave filtroGuardado1 = new FilterSave(@"lukeGuardado1.jpg");
            FilterSave filtroGuardado2 = new FilterSave(@"lukeGuardado2.jpg");
            FilterTwitter filtroTwitter = new FilterTwitter("Imagen transformada2.",@"lukeGuardado2.jpg");

            /*PipeSerial serial1 = new PipeSerial(filtroTwitter, nulo);
            PipeSerial guardado2 = new PipeSerial(filtroGuardado2, serial1);
            PipeSerial serial2 = new PipeSerial(filtroNegativo, guardado2);
            PipeSerial guardado1 = new PipeSerial(filtroGuardado1, serial2);
            PipeSerial serial3 = new PipeSerial(filtroGris, guardado1);

            serial3.Send(picture); */
            FilterSave filtroGuardado3 = new FilterSave(@"lukeGuardado3.jpg");
            FilterSave filtroGuardado4 = new FilterSave(@"beerGuardada.jpg");
            FilterConditional condicional = new FilterConditional(@"luke.jpg");
            FilterConditional condicional2 = new FilterConditional(@"beer.jpg");



            PipeSerial guardado2 = new PipeSerial(filtroGuardado3, nulo);
            PipeSerial serial2 = new PipeSerial(filtroNegativo, guardado2);

            PipeSerial guardado1 = new PipeSerial(filtroGuardado4, nulo);
            PipeSerial serial3 = new PipeSerial(filtroGris, guardado1);

            PipeFork pipefork = new PipeFork(condicional, serial3, serial2);
            PipeFork pipefork2 = new PipeFork(condicional2, serial3, serial2);
            

            pipefork.Send(picture);
            pipefork2.Send(picture2);


        }
    }
}
