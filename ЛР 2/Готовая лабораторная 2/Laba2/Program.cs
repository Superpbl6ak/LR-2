using Laba2;

using (ApplicationContext db = new ApplicationContext())
{
    //----------------------------------------------------------------------------
    /*var stocks = new List<Stock>
    {
        new() { Town = "Белокуриха" },
        new() { Town = "Калининград" },
        new() { Town = "с. Петропавловское" },
        new() { Town = "Москва" }
    };
    var cars = CarGenerator.GetCars(stocks);

    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    db.Cars.AddRange(cars);
    db.Stocks.AddRange(stocks);
    db.SaveChanges();*/
    //----------------------------------------------------------------------------

    // Запрос 1:
    WriteLine("Запрос 1: Alfa Romeo");
    var z1 = db.Cars.Where(p => p.Name == "Alfa Romeo").Where(p => p.IsStock == true).ToList();
    foreach (var z in z1)
    {
        WriteLine($"{z.Name} {z.Cost}$ ");
    }

    WriteLine();

    // Запрос 2:
    WriteLine("Запрос 2: BMW:");
    var z2 = db.Cars.Where(p => p.Name.Contains("BMW")).Select(p => p.Stock).Distinct().ToList();
    foreach (var z in z2)
    {
        WriteLine($"{z.Town}");
    }

    WriteLine();

    // Запрос 3:
    WriteLine("Запрос 3: Машины дешевле 10000$:");
    var z3 = db.Cars.Where(p => p.Cost < 10000).ToList();
    foreach (var z in z3)
    {
        WriteLine($"{z.Name} {z.Cost}$ {z.DataRelease} года.");
    }

    WriteLine();

    // Запрос 4:
    WriteLine("Запрос 4: Remark:");
    var z4 = db.Cars.Where(p => p.Remark != "").OrderBy(p => p.Name).ToList();
    foreach (var z in z4)
    {
        WriteLine($"{z.Name} {z.Cost}$ {z.DataRelease} года. Пометка: {z.Remark}");
    }

    WriteLine();

    // Запрос 5:
    WriteLine("Запрос 5: Склады с машинами 2000-2005 г.:");
    var z5 = db.Cars.Where(p => p.DataRelease >= 2000 && p.DataRelease <= 2005).GroupBy(c => c.Stock.Town)
        .Select(g => new { Name = g.Key, Count = g.Count() }).ToList();
    foreach (var z in z5)
    {
        WriteLine(z.Name + " " + z.Count);
    }

    WriteLine();

    // Запрос 6
    WriteLine("Запрос 6: Машины года выпуска до 2000 г.:");
    var z6 = db.Cars.Where(p => p.DataRelease < 2000).OrderBy(p => p.DataRelease).ToList();
    foreach (var z in z6)
    {
        WriteLine($"{z.Name} {z.Cost}$ {z.DataRelease} года");
    }

    WriteLine();

    // Запрос 7-8
    DbReport DBRep = new DbReport() { DateBase = db };
    DBRep.WriteAllReport();
}