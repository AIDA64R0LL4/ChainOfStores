namespace ChainOfStores
//Рыжков ПР-24 29.05.2023 0:23
//    ╭━╮----┈╭━╮ 
//┃╭╯┈┃┊┗━━━━━┛┊┃
//┃╰┳┳┫┏━▅╮┊╭━▅┓┃
//┃┫┫┫┫┃┊▉┃┊┃┊▉┃┃ 
//┃┫┫┫╋╰━━┛▅┗━━╯╋
//┃┫┫┫╋┊┊┊┣┻┫┊┊┊╋
//┃┊┊┊╰┈┈┈┈┈┈┈┳━╯
//┃┣┳┳━━┫┣━━┳╭╯
{
    internal class Shop //Название класса
    {
        public string Name { get; set; } //Имя магазина
        public int SalesCount { get; set; } //Количество продаж у магазина
        public int MonthlyRevenue { get; set; } //Выручка за месяц у магазина
        public int CustomerCount { get; set; } //Количество покупателей у магаина
        public Shop(string name, int salesCount, int monthlyRevenue, int customerCount) //Консткрутор 
        {
            Name = name; //Имя магазина
            SalesCount = salesCount; //Количетсво продаж у магазина
            MonthlyRevenue = monthlyRevenue; //Выручка магазина
            CustomerCount = customerCount; //Количество покупателей у магазина
        }
        public string GetInfo() //Информация о магазине
        {
            return $"Магазин - {Name}.  Количество продаж: {SalesCount}.  Выручка за месяц: {MonthlyRevenue}.  Количество покупателей: {CustomerCount}.";
        }
    }
}
