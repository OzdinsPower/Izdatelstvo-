//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Izdatelstvo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Manuscripts
    {
        public Manuscripts(string title, byte[] soderjanie, DateTime data_otpravki, int iD_writers)
        {
            Title = title;
            Soderjanie = soderjanie;
            Data_otpravki = data_otpravki;
            ID_writers = iD_writers;
            ID_sotrudnik = 1;
        }

        public Manuscripts(string title, byte[] soderjanie, DateTime data_otpravki, int iD_writers, int iD_sotrudnik)
        {
            Title = title;
            Soderjanie = soderjanie;
            Data_otpravki = data_otpravki;
            ID_writers = iD_writers;
            ID_sotrudnik = iD_sotrudnik;
        }

        public Manuscripts()
        {
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public byte[] Soderjanie { get; set; }
        public System.DateTime Data_otpravki { get; set; }
        public int ID_writers { get; set; }
        public int ID_sotrudnik { get; set; }
    }
}
