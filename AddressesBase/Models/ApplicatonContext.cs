using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace Addresses.Model;

public class ApplicationContext : DbContext
{
    
    public DbSet<StreetPrefix> StreetPrefixes { get; set; } = null!;
    public DbSet<Street> Streets { get; set; } = null!;
    public DbSet<LocalityPrefix> LocalityPrefixes { get; set; } = null!;
    public DbSet<Locality> Localities { get; set; } = null!;
    public DbSet<Building> Buildings { get; set; } = null!;
    public DbSet<Apartment> Apartments { get; set; } = null!;
    public DbSet<Owner> Owners { get; set; } = null!;
    //public DbSet<ApartmentOwner> ApartmentOwners { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        bool isCreated = Database.EnsureCreated();
        
        // Заполняем БД тестовыми данными
        
        if (isCreated)
        {
            Random rnd = new Random();
            
            //
            // DISCLAIMER: Возможно топорно, но для "красоты" нужно больше времени.
            //
            
            // Заполняем таблицы: Префиксы населённых пунктов / LocalityPrefix, Нас.пункты / Locality 
            LocalityPrefixes.Add(new LocalityPrefix
            {
                LocalityPrefixName = "г.", Description = "Город",
                Localities = new List<Locality>()
                {
                    new Locality { LocalityName = "Красноярск"},
                    new Locality { LocalityName = "Ачинск"},
                    new Locality { LocalityName = "Лесосибирск"},
                    new Locality{ LocalityName = "Шарыпово"},
                    new Locality { LocalityName = "Дивногорск"},
                    new Locality { LocalityName = "Сосновоборск"}
                }
            });
            LocalityPrefixes.Add(new LocalityPrefix
            {
                LocalityPrefixName = "пгт.", Description = "Посёлок городского типа",
                Localities = new List<Locality>()
                {
                    new Locality { LocalityName = "Берёзовка" }
                }
            });
            LocalityPrefixes.Add(new LocalityPrefix
            {
                LocalityPrefixName = "п.", Description = "Посёлок",
                Localities = new List<Locality>()
                {
                    new Locality { LocalityName = "Солонцы" }
                }
            });
            LocalityPrefixes.Add(new LocalityPrefix
            {
                LocalityPrefixName = "д.", Description = "Деревня",
                Localities = new List<Locality>()
                {
                    new Locality { LocalityName = "Минино" }
                }
            });
            LocalityPrefixes.Add(new LocalityPrefix { LocalityPrefixName = "ж/д ст.", Description = "Железнодорожная станция" });
            LocalityPrefixes.Add(new LocalityPrefix
            {
                LocalityPrefixName = "с.", Description = "Село",
                Localities = new List<Locality>()
                {
                    new Locality { LocalityName = "Дорокино" }
                }
            });
            LocalityPrefixes.Add(new LocalityPrefix { LocalityPrefixName = "ст.", Description = "Станция" });
            LocalityPrefixes.Add(new LocalityPrefix { LocalityPrefixName = "ст-ца", Description = "Станица" });
            LocalityPrefixes.Add(new LocalityPrefix { LocalityPrefixName = "у.", Description = "Улус" });
            LocalityPrefixes.Add(new LocalityPrefix { LocalityPrefixName = "х.", Description = "Хутор" });
            LocalityPrefixes.Add(new LocalityPrefix { LocalityPrefixName = "рзд.", Description = "Разъезд" });
            SaveChanges();
                        
            // Заполняем таблицу Префиксы улиц / StreetPrefix 
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "ал.", Description = "Аллея" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "б-р", Description = "Бульвар" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "км", Description = "Километр" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "пер-д", Description = "Переезд" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "пер.", Description = "Переулок" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "пл.", Description = "Площадь" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "пр-д", Description = "Проезд" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "пр-кт", Description = "Проспект" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "рзд.", Description = "Разъезд" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "сзд.", Description = "Съезд" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "тракт", Description = "Тракт" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "туп.", Description = "Тупик" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "ул.", Description = "Улица" });
            StreetPrefixes.Add(new StreetPrefix { StreetPrefixName = "ш.", Description = "Шоссе" });
            SaveChanges();
            
            // Заполняем таблицу Улицы / Streets
            string[] street_names = 
            {
                "Дмитрия Мартынова", "Котельникова", "Чернышевского", "Калинина", "9 мая",
                "Кравченко", "Ленина", "Декабристов", "Свободы", "Советская", "Гагарина", "Назарова",
                "Фурманова", "Академика Киренского", "имени газеты Красноярский рабочий", "Маерчака",
                "Школьная", "Карла Маркса", "Маршала Жукова", "Перенсона", "Взлётная", "Авиаторов"
            };
            //int streetPrefCount = StreetPrefixes.Count(sp => !string.IsNullOrEmpty(sp.StreetPrefixName));
            //int localitiesCount = Localities.Count((l => l.LocalityPrefixId > 0));
            int streetPrefCount = StreetPrefixes.Count();
            foreach (var l in Localities)
            {
                int n = rnd.Next(5, 10);    // по ТЗ от 5 до 10 улиц (с разными префиксами)
                for (int i = 0; i < n; i++)
                {
                    //StreetPrefix? streetPrefix = StreetPrefixes.FirstOrDefault(sp => sp.Id == rnd.Next(1, streetPrefCount));
                    l.Streets.Add(new Street
                    {
                        StreetName = street_names[rnd.Next(0, street_names.Length - 1)],
                        //StreetPrefix = streetPrefix
                        StreetPrefixId = rnd.Next(1, streetPrefCount)
                    });
                }
            }
            SaveChanges();
            
            // Заполняем таблицу Здания / Buildings
            string[] houseNumberSuffixes = { "А", "Б", "В", "Г", "Д" }; // буквы номеров домов, столько хватит
            foreach (var s in Streets)
            {
                int n = rnd.Next(10, 20);   // по ТЗ от 10 до 20 домов на улицу
                for (int i = 0; i < n; i++)
                {
                    s.Buildings.Add(new Building
                    {
                        ApartmentsAmount = rnd.Next(1, 100), // по ТЗ макс. 100 кв здании
                        HouseNumber = string.Concat(        
                            rnd.Next(1, 200).ToString(),    // номера домов
                            // буквы у номеров домов будут у 1/3 - для разнообразия:
                            (rnd.Next(0,300)>100) ? string.Empty : houseNumberSuffixes[rnd.Next(0, houseNumberSuffixes.Length)]
                        )
                    });
                }
            }
            SaveChanges();
            
            // Заполняем таблицы: Квартиры / Apartments, Владельцы / Owners,
            // талбица Владельцы квартир / ApartmentOwners заполняется автоматически  
            string[][] ownerName =
            {
                new string[] { "Анна", "Алла", "Алёна", "Вероника", "Елена", "Милана", "Людмила", "Укатерина", "Мария",
                    "Василиса", "Валентина", "Виктория", "Яна", "Юлия", "Надежа", "Любовь", "Валерия", "Милана", 
                    "Оксана", "Ксения", "Зоя", "Клавдия", "Елизавета", "Даздраперма" },
                new string[] { "Алексей", "Александр", "Валерий", "Пётр", "Василий", "Евгений", "Михаил", "Максим", 
                    "Андрей", "Прокопий", "Виктор", "Валентин", "Николай", "Никита", "Матвей", "Руслан", "Сергей",
                    "Эдуард", "Дмитрий", "Фёдор", "Акакий", "Енакентий" }
            } ;
            string[] ownerSurname = { "Агафонов", "Микачев", "Быков", "Васильев", "Пушкарёв", "Никитин", "Лебедев", 
                "Петров", "Николаев", "Рудников", "Суренков", "Лопатин", "Максимов", "Лалетин", "Мухамедшин", 
                "Деревягин", "Сидоров", "Иванов", "Лопухов", "Вольнов", "Убегаев", "Догоняев" };
            string[] ownerPatronymicSuffix = { "на", "ич" };
            string[] ownerPatronymic = { "Алексеев", "Александров", "Валерьев", "Петров", "Васильев", "Евгеньев", 
                "Михайлов", "Максимов", "Андреев", "Прокопьев", "Викторов", "Валентинов", "Николев", "Никитов", 
                "Матвеев", "Русланов", "Сергеев", "Эдуардов", "Дмитрие", "Фёдоров", "Акакиев", "Енакентье" };

            foreach (var b in Buildings)
            {
                int apartmentsCount = b.ApartmentsAmount;
                while (apartmentsCount > 0)
                {
                    // Определимся с кол-вом владельцев и создадим их список,
                    // у 90% - 1, у 10% - от 1 до 3х владельцев (новых) - это для разноообразия данных
                    List<Owner> ownersList = new List<Owner>();
                    int newOwnersCount = (rnd.Next(0, 1000) > 900) ? rnd.Next(0, 29999) / 10000 : 0;
                    do
                    {
                        int sex = rnd.Next(0, 1000) % 2;
                        ownersList.Add(new Owner
                        {
                            Name = ownerName[sex][rnd.Next(0, ownerName[sex].Length - 1)],
                            Surname = string.Concat(ownerSurname[rnd.Next(0, ownerSurname.Length - 1)], (sex>0) ? "" : "а"),
                            Patronymic = string.Concat(ownerPatronymic[rnd.Next(0, ownerPatronymic.Length - 1)],
                                ownerPatronymicSuffix[sex])
                        });
                    } while (newOwnersCount-- > 0);    // При изначальном newOwnersCount == 0 создадим только 1 владельца.
                    
                    // Добавим квартиру со списком владельцев в здание
                    b.Apartments.Add(new Apartment
                    {
                        ApartmentNumber = apartmentsCount,
                        Owners = ownersList
                    });
                    apartmentsCount--;
                }
            }
            SaveChanges();
            
/*            // Добавим 10% квартир от 1 до 3х владельцев из числа уже существующих
            foreach (var a in Apartments)
            {
                if (rnd.Next(0, 1000) > 900)
                {
                    List<Owner> ownersList = new List<Owner>();
                    int addOwnersCount = rnd.Next(0, 29999) / 10000 +1;
                    while (addOwnersCount-- > 0)
                    {
                        int tries = 10;   // попыток найти еще одного владельца, не владеющего этой квартирой
                        while (tries-- > 0)
                        {
                            int id = rnd.Next(1, Owners.Count());
                            Owner? owner = Owners.FirstOrDefault(o => o.Id == id);
                            if ((owner != null) && !a.Owners.Contains(owner))
                            {
                                a.Owners.Add(owner);
                                tries = 0;
                            }
                        }
                    } 
                }
            }
            SaveChanges();
*/            
            MessageBox.Show("DB was created!");
        }
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Apartment>().HasAlternateKey(a => new { a.BuildingId, a.ApartmentNumber });
        modelBuilder.Entity<Apartment>()
            .HasMany(a => a.Owners)
            .WithMany(o => o.Apartments)
            .UsingEntity<ApartmentOwner>(
                ao => ao
                    .HasOne(ao => ao.Owner)
                    .WithMany(o => o.ApartmentOwners)
                    .HasForeignKey(ao => ao.OwnerId),
                ao => ao
                    .HasOne(ao => ao.Apartment)
                    .WithMany(a => a.ApartmentOwners)
                    .HasForeignKey(ao => ao.ApartmentId),
                ao => ao
                    .HasKey(ao => new { ao.ApartmentId, ao.OwnerId }));
    }
}