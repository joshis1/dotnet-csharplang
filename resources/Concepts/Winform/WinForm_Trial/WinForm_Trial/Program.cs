using System;

namespace WinForm_Trial
{
    class Program
    {
        static void Main(string[] args)
        {
            var but = new Button();
            var form = new Form();
            form.control.Add(but);

            form.show();
            ApplicationException.Run();
        }
    }
}
