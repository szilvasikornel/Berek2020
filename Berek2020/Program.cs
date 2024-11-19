using Berek2020;
//kezdes 9:48


List<Ber> berek = new();

using (StreamReader sr = new StreamReader(@"..\..\..\src\berek2020.txt", System.Text.Encoding.UTF8))
{
    sr.ReadLine();
    while (!sr.EndOfStream) berek.Add(new Ber(sr.ReadLine()));
}

//3.Határozza meg és írja ki a képernyőre, hogy hány dolgozó adatai találhatók a forrásállományban!
Console.WriteLine("1. feladat:");
var f01 = berek.Count();
Console.WriteLine($"Ennyi dolgozó van: {f01}\n");

//4. Határozza meg és írja ki a képernyőre a 2020-as átlagbéreket! Az eredményt ezer forintban, egy tizedesjegyre kerekítve jelenítse meg!
Console.WriteLine("2. feladat:");
var f02 = berek.Where(b => b.Belepes <= 2020).Average(b => b.Penz);
Console.WriteLine($"2020-as átlagbérek: {f02:00.0}\n");

//5. Kérje be egy részleg nevét a felhasználótól a minta szerint! (kiiratásra kerül az ezen a részlegen dolgozók adatai)
Console.WriteLine("3. feladat:");
Console.Write("Add megy egy részleg nevét (karbantartás, szerelőműhely, pénzügy stb...): ");
string reszleg = Console.ReadLine();
bool letezik = false;

foreach (var item in berek)
{
    if (item.Reszleg == reszleg)
    {
        letezik = true;
    }
}

if (letezik) {
    Console.WriteLine("Ezen a részlegen dolgozó emberek: ");
    var f03 = berek.Where(x => x.Reszleg == reszleg).ToList();
    foreach (var ber in f03) Console.WriteLine($"{ber}");
}else {
    Console.WriteLine("Nincs ilyen részleg!");
}

//6. Az előző feladatban megadott részlegen keresse meg és írja ki a legnagyobb bérrel (fizetéssel) rendelkező dolgozó adatait! Ha a megadott részleg nem létezik a cégnél, akkor a „A megadott részleg nem létezik a cégnél!” feliratot jelenítse meg! Feltételezheti, hogy nem alakult ki „holtverseny” egy-egy részlegen dolgozók fizetése között!
Console.WriteLine("\n4. feladat: ");
if (letezik) { 
    var f04 = berek.Where(b => b.Reszleg == reszleg).OrderByDescending(x => x.Penz).FirstOrDefault();
    Console.WriteLine($"Legnagyobb bérrel rendelkező dolgozó ezen a részlegen: {f04}");
} else{
    Console.WriteLine("Nem létező részleget adtál meg.");
}

//7. Készítsen statisztikát az egyes részlegeken dolgozók számáról! A részlegek kiírásának sorrendje tetszőleges!
Console.WriteLine("\n5. feladat:");
var f05 = berek.GroupBy(x => x.Reszleg).Select(group => new { 
Reszleg = group.Key,
Count = group.Count()
});

foreach (var group in f05) Console.WriteLine($"{group.Reszleg}: {group.Count} dolgozó");
//Befejezve: 10:25