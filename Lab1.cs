using System;
using System.Collections.Generic;

enum CihazTuru
{
    Lamba,
    Klima,
    GuvenlikSistemi
}

class Cihaz
{
    public int Kimlik { get; set; }
    public string Ad { get; set; }
    public CihazTuru Tur { get; set; }
    public bool AcikMi { get; set; } = false;

    public Cihaz(int kimlik, string ad, CihazTuru tur)
    {
        Kimlik = kimlik;
        Ad = ad;
        Tur = tur;
    }

    public void Ac()
    {
        if (AcikMi == true)
        {
            Console.WriteLine(Ad + " zaten acik.");
        }
        else
        {
            AcikMi = true;
            Console.WriteLine(Ad + " acildi.");
        }
    }

    public void Kapat()
    {
        if (AcikMi == false)
        {
            Console.WriteLine(Ad + " zaten kapali.");
        }
        else
        {
            AcikMi = false;
            Console.WriteLine(Ad + " kapatildi.");
        }
    }

    public void BilgileriGoster()
    {
        Console.WriteLine("Kimlik: " + Kimlik);
        Console.WriteLine("Ad: " + Ad);
        Console.WriteLine("Tur: " + Tur);

        if (AcikMi)
            Console.WriteLine("Durum: Acik");
        else
            Console.WriteLine("Durum: Kapali");
    }
}

class Program
{
    static void Main()
    {
        List<Cihaz> cihazlar = new List<Cihaz>();
        cihazlar.Add(new Cihaz(1, "Salon Lambasi", CihazTuru.Lamba));
        cihazlar.Add(new Cihaz(2, "Salon Klimasi", CihazTuru.Klima));
        cihazlar.Add(new Cihaz(3, "Kapi Alarmi", CihazTuru.GuvenlikSistemi));

        string secim = "";

        while (secim != "0")
        {
            Console.WriteLine();
            Console.WriteLine("--- AKILLI EV ---");
            Console.WriteLine("1. Cihazlari listele");
            Console.WriteLine("2. Yeni cihaz ekle");
            Console.WriteLine("3. Cihaz ac");
            Console.WriteLine("4. Cihaz kapat");
            Console.WriteLine("0. Cikis");
            Console.Write("Secim: ");
            secim = Console.ReadLine();
            Console.WriteLine();

            if (secim == "1")
                CihazlariListele(cihazlar);
            else if (secim == "2")
                CihazEkle(cihazlar);
            else if (secim == "3")
                CihazAc(cihazlar);
            else if (secim == "4")
                CihazKapat(cihazlar);
            else if (secim != "0")
                Console.WriteLine("Boyle bir secenek yok.");
        }
    }

    static Cihaz CihazBul(List<Cihaz> cihazlar, int kimlik)
    {
        foreach (Cihaz cihaz in cihazlar)
        {
            if (cihaz.Kimlik == kimlik)
                return cihaz;
        }
        return null;
    }

    static void CihazlariListele(List<Cihaz> cihazlar)
    {
        if (cihazlar.Count == 0)
        {
            Console.WriteLine("Sistemde hic cihaz yok.");
            return;
        }

        foreach (Cihaz cihaz in cihazlar)
        {
            cihaz.BilgileriGoster();
            Console.WriteLine("-----------");
        }
    }

    static void CihazEkle(List<Cihaz> cihazlar)
    {
        Console.Write("Kimlik: ");
        int kimlik;
        if (!int.TryParse(Console.ReadLine(), out kimlik))
        {
            Console.WriteLine("Kimlik sayi olmali.");
            return;
        }

        if (CihazBul(cihazlar, kimlik) != null)
        {
            Console.WriteLine("Bu kimlik baska bir cihazda kullaniliyor!");
            return;
        }

        Console.Write("Ad: ");
        string ad = Console.ReadLine();

        Console.WriteLine("1 - Lamba");
        Console.WriteLine("2 - Klima");
        Console.WriteLine("3 - Guvenlik Sistemi");
        Console.Write("Tur: ");
        string turSecim = Console.ReadLine();

        CihazTuru tur;
        if (turSecim == "1")
            tur = CihazTuru.Lamba;
        else if (turSecim == "2")
            tur = CihazTuru.Klima;
        else if (turSecim == "3")
            tur = CihazTuru.GuvenlikSistemi;
        else
        {
            Console.WriteLine("Gecersiz tur secildi.");
            return;
        }

        cihazlar.Add(new Cihaz(kimlik, ad, tur));
        Console.WriteLine(ad + " eklendi.");
    }

    static void CihazAc(List<Cihaz> cihazlar)
    {
        Console.Write("Acmak istediginiz cihazin kimligi: ");
        int kimlik;
        if (!int.TryParse(Console.ReadLine(), out kimlik))
        {
            Console.WriteLine("Lutfen sayi girin.");
            return;
        }

        Cihaz cihaz = CihazBul(cihazlar, kimlik);
        if (cihaz == null)
            Console.WriteLine(kimlik + " kimlikli bir cihaz bulunamadi.");
        else
            cihaz.Ac();
    }

    static void CihazKapat(List<Cihaz> cihazlar)
    {
        Console.Write("Kapatmak istediginiz cihazin kimligi: ");
        int kimlik;
        if (!int.TryParse(Console.ReadLine(), out kimlik))
        {
            Console.WriteLine("Lutfen sayi girin.");
            return;
        }

        Cihaz cihaz = CihazBul(cihazlar, kimlik);
        if (cihaz == null)
            Console.WriteLine(kimlik + " kimlikli bir cihaz bulunamadi.");
        else
            cihaz.Kapat();
    }
}
