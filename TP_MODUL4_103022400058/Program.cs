using System;
using System.Collections.Generic;

class KodePos
{
    public string getKodePos(string kelurahan)
    {
        Dictionary<string, string> tabelKodePos = new Dictionary<string, string>()
        {
            {"Batununggal", "40266"},
            {"Kujangsari", "40287"},
            {"Mengger", "40267"},
            {"Wates", "40256"},
            {"Cijaura", "40287"},
            {"Jatisari", "40286"},
            {"Margasari", "40286"},
            {"Sekejati", "40286"},
            {"Kebonwaru", "40272"},
            {"Maleer", "40274"}
        };

        if (tabelKodePos.ContainsKey(kelurahan))
        {
            return tabelKodePos[kelurahan];
        }

        return "Kelurahan tidak ditemukan";
    }
}

class DoorMachine
{
    public enum State { Terkunci, Terbuka }
    public enum Trigger { KunciPintu, BukaPintu }

    private State currentState;

    public DoorMachine()
    {
        currentState = State.Terkunci;
        Console.WriteLine("Pintu terkunci");
    }

    public void UbahState(Trigger trigger)
    {
        switch (currentState)
        {
            case State.Terkunci:
                if (trigger == Trigger.BukaPintu)
                {
                    currentState = State.Terbuka;
                    Console.WriteLine("Pintu tidak terkunci");
                }
                else if (trigger == Trigger.KunciPintu)
                {
                    currentState = State.Terkunci;
                    Console.WriteLine("Pintu terkunci");
                }
                break;

            case State.Terbuka:
                if (trigger == Trigger.KunciPintu)
                {
                    currentState = State.Terkunci;
                    Console.WriteLine("Pintu terkunci");
                }
                else if (trigger == Trigger.BukaPintu)
                {
                    currentState = State.Terbuka;
                    Console.WriteLine("Pintu tidak terkunci");
                }
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        KodePos pencariKode = new KodePos();
        Console.WriteLine("Batununggal : " + pencariKode.getKodePos("Batununggal"));
        Console.WriteLine("Margasari : " + pencariKode.getKodePos("Margasari"));

        Console.WriteLine();

        DoorMachine pintu = new DoorMachine();
        pintu.UbahState(DoorMachine.Trigger.BukaPintu);
        pintu.UbahState(DoorMachine.Trigger.BukaPintu);
        pintu.UbahState(DoorMachine.Trigger.KunciPintu);
        pintu.UbahState(DoorMachine.Trigger.KunciPintu);
    }
}