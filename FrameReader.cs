using System.IO;

namespace checkerboard
{
    class FrameReader
    {
        string filePath;
        
        private int width;
        private int heigth;
        private int frameYCounter = 0;
        private int frameUCounter = 0;
        private int frameVCounter = 0;
       // public BinaryReader yuvBitStream { get; set; }

        public FrameReader(string filepath, int bitsPerpixel, int Width, int Heigth)
        {
            filePath = filepath;
             
            width = Width;
            heigth = Heigth;
            //BinaryReader yuvBitStream = new BinaryReader(File.Open(filepath, FileMode.Open));
        }
       
        //////////////////////////////////////////Ystart = (Yindex * w * h * bps) * 1.5   Yend = Ystart + w * h * bps
        /// Ustart = w * h * bps * (1 + (Uindex * 1.5))
        /// 


        private byte[] readBitsFromFile(int begin,int end)
        {
            using (BinaryReader yuvBitstream = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                yuvBitstream.BaseStream.Position = begin;
                return yuvBitstream.ReadBytes(end - begin);
            }
        }

        public byte[] getNextFrameY()
        {
            int Ystart = ((frameYCounter * width * heigth )) * 3 / 2; //begin
            int Yend = Ystart + width * heigth   ; ///end
            ++frameYCounter;
            return readBitsFromFile(Ystart, Yend);
        }

        public byte[] getNextFrameU()
        {
            int Ustart = width * heigth * (1 + (frameUCounter * 3 / 2));
            int Uend = Ustart + (width * heigth *   1/4) ;
            ++frameUCounter;
            return readBitsFromFile(Ustart, Uend); 
        }

        public byte[] getNextFrameV()
        {
            int Vstart = width * heigth *   (1 + (frameVCounter * 3 / 2)) + (width * heigth *   1 / 4);
            int Vend = Vstart + (width * heigth *   1 / 4) ;
            ++frameVCounter;
            return readBitsFromFile(Vstart, Vend); 
        }
        
        ////////////////////////////////////////// Michał się skichał  hyhyhyhyhyhyhyhyyhyhyhyhyhyhy
         
        public byte[] GetFrameY(int index)
        {
            int Ystart = (index * width * heigth   ) * 3/2;
            int Yend = Ystart + width * heigth   ;
            return readBitsFromFile(Ystart, Yend);
        }

        public byte[] GetFrameU(int index)
        {
            int Ustart = width * heigth * (1 + (index * 3 / 2));
            int Uend = Ustart + (width * heigth * 1 / 4) ;
            return readBitsFromFile(Ustart, Uend);
        }
            public byte[] GetFrameV(int index)
        {
            int Vstart = width * heigth *   (1 + (index * 3 / 2)) + (width * heigth *   1 / 4);
            int Vend = Vstart + (width * heigth *   1 / 4) ;
                return readBitsFromFile(Vstart, Vend);
            }
    }
}
