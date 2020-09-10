using System;

namespace EnumType
{
    class Program
    {
        [Flags]
        public enum Disk
        {
            Disk_Init = 0x0,
            Disk_Inserted = 0x2,
            Disk_Formatted = 0x4,
            Disk_Ejected = 0x8
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Disk disk_status = Disk.Disk_Init | Disk.Disk_Inserted | Disk.Disk_Formatted;
            Console.WriteLine("Disk Status " + disk_status);
            Console.ReadLine();
        }


    }
}
