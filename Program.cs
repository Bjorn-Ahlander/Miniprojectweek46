//namespace Week46CompsandPhones

using System;
using System.Diagnostics;

List<Device> devices = new List<Device>();
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Inventarie-register");
Console.WriteLine();

//goto Found;

Found:

while (true)
{
    // Get Type of Device
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Input Comp or Phone (or p to show list): ");
    //Console.WriteLine("Enter p to show list");

    string devInput = Console.ReadLine();
    if (devInput.ToLower().Trim() == "p")
    {
        break;
    }

    // Get Purchase Date
    Console.Write("Input Date of Purchase yyyy-mm-dd: ");
    string dtInput = Console.ReadLine();
    if (dtInput.ToLower().Trim() == "p")
    {
        break;
    }

    //DateTime.TryParse(dtInput, out DateTime dx);
    //DateTime dt2 = DateTime.Now;
    //Console.WriteLine(dt2);
    //TimeSpan diff = dt2 - dx;
    //int xyz = Convert.ToInt32(diff.TotalDays);
    //Console.WriteLine(xyz);

    // Get Pris
    Console.Write("Input Pris i Dollar: ");
    string prisInput = Console.ReadLine();
    if (prisInput.ToLower().Trim() == "p")
    {
        break;
    }

    // Get Modelname
    Console.Write("Input Modelname: ");
    string modelname = Console.ReadLine();
    if (modelname.ToLower().Trim() == "p")
    {
        break;
    }

    // Get Kontor
    Console.Write("Plats: Stockholm type STH, New York type NYC, i Boston type BOS: ");
    string plats = Console.ReadLine();
    if (plats.ToLower().Trim() == "p")
    {
        break;
    }

    bool isTrue = DateTime.TryParse(dtInput, out DateTime dt);
    if (isTrue)
    {
        Console.WriteLine("Datum korrekt");
    }

    bool isValid = int.TryParse(prisInput, out int pris);
    if (isValid)
        if (plats == "STH")
        {
            int prisse = pris * 11;
            string prissek = prisse.ToString();
            Console.WriteLine("Pris i svenska kronor är " + prissek + " kr");
            Device device = new Device(devInput, dt, pris, modelname, plats, prissek);
            devices.Add(device);
            Console.WriteLine("Devicen är tillagd på listan");
        }

        else if (plats != "STH")
        {
            string prissek = "";
            Device device = new Device(devInput, dt, pris, modelname, plats, prissek);
            devices.Add(device);
            Console.WriteLine("Devicen är tillagd på listan");
        }
}

Console.WriteLine();
Console.WriteLine("---------------");
Console.WriteLine();
Console.WriteLine("Lista sorterad på Inköpsdatum");
Console.WriteLine();

//Console.WriteLine(Device.dt);

List<Device> sorterad = devices.OrderBy(device => device.DevInput).ThenBy(device => device.DT).ToList();
//Console.ForegroundColor(Device.DT)= ConsoleColor.White;
Console.WriteLine("Hårdvara".PadRight(13) + "Purchase-date".PadRight(12)
     + "   Modellnamn".PadRight(10) + "     Pris USD" + "  Plats" + "    Pris SEK");
//if (xyz > 15)
//{
//    Console.WriteLine("diffen är mer än 15 dagar");
//}

//TimeSpan diff = dt2.Subtract(dt1); 

foreach (var device in sorterad)
{
    //Console.ForegroundColor = ConsoleColor.Red;
    //Console.WriteLine(device.DevInput.PadRight(13) + device.DT + 
    //    "    " + device.Modelname.PadRight(16) + device.Pris + "       " + device.Plats
    //    + "        " + device.PrisSEK);
    Console.Write(device.DevInput.PadRight(13));
    
    DateTime dt2 = DateTime.Now;
    TimeSpan diff = dt2 - device.DT;
    int xyz = Convert.ToInt32(diff.TotalDays);

    if (xyz > 1005)
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    if (xyz > 910)
      {
        if (xyz < 1005) 
        { 
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }

    Console.Write(device.DT.ToString("yyyy-MM-dd").PadRight(16));
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(device.Modelname.PadRight(17));
    Console.Write(device.Pris.ToString().PadRight(8));
    Console.Write(device.Plats.PadRight(12));
    Console.WriteLine(device.PrisSEK);
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Vill registrera mer?: j/n");
string xx = Console.ReadLine();

if (xx == "j")
{
    goto Found;
}

else
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("hejdå! - programmet avslutas");
}

class Device
{
    public Device(string devInput, DateTime dt, int pris, string modelname, string plats, string prissek)
    {
        DevInput = devInput;
        DT = dt;
        Pris = pris;
        Modelname = modelname;
        Plats = plats;
        PrisSEK = prissek;
    }

    public string DevInput { get; set; }
    public DateTime DT { get; set; }
    public int Pris { get; set; }
    public string Modelname { get; set; }
    public string Plats { get; set; }
    public string PrisSEK { get; set; }
}