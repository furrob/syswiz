using System.IO;
using System.Windows.Forms;

namespace checkerboard
{
    class FrameReader
    {
        string filePath;
        
        private int width;
        private int height;
        private int frameYCounter = 0;
        private int frameUCounter = 0;
        private int frameVCounter = 0;
       // public BinaryReader yuvBitStream { get; set; }

        public FrameReader(string filepath, int Width, int Height)
        {
            filePath = filepath;
             
            width = Width;
            height = Height;
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
            int Ystart = ((frameYCounter * width * height)) * 3 / 2; //begin
            int Yend = Ystart + width * height   ; ///end
            ++frameYCounter;
            return readBitsFromFile(Ystart, Yend);
        }

        public byte[] getNextFrameU()
        {
            int Ustart = width * height + (width * height + (width * height) / 2) * frameUCounter;
            int Uend = Ustart + (width * height * 1 / 4);
            ++frameUCounter;
            return readBitsFromFile(Ustart, Uend); 
        }

        public byte[] getNextFrameV()
        {
            int Vstart = width * height + (width * height / 4) + (width * height + (width * height) / 2) * frameVCounter;
            int Vend = Vstart + (width * height * 1 / 4);
            ++frameVCounter;
            return readBitsFromFile(Vstart, Vend); 
        }
        
        ////////////////////////////////////////// Michał się skichał  hyhyhyhyhyhyhyhyyhyhyhyhyhyhy
         
        public byte[] GetFrameY(int index)
        {
            int Ystart = (index * width * height) * 3 / 2;
            int Yend = Ystart + width * height   ;
            return readBitsFromFile(Ystart, Yend);
        }

        public byte[] GetFrameU(int index)
        {
            int Ustart = width * height + (width * height + (width * height) / 2) * index;
            int Uend = Ustart + (width * height * 1 / 4) ;
            return readBitsFromFile(Ustart, Uend);
        }
        public byte[] GetFrameV(int index)
        {
            int Vstart = width * height + (width * height / 4) + (width * height + (width * height) / 2) * index;
            int Vend = Vstart + (width * height * 1 / 4);
            return readBitsFromFile(Vstart, Vend);
        }
    }
}
