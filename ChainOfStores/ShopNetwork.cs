using System;
using System.Collections.Generic;
using System.Linq;
namespace ChainOfStores
//Рыжков ПР-24 ПР-24 29.05.2023 0:23
//    ╭━╮----┈╭━╮ 
//┃╭╯┈┃┊┗━━━━━┛┊┃
//┃╰┳┳┫┏━▅╮┊╭━▅┓┃
//┃┫┫┫┫┃┊▉┃┊┃┊▉┃┃ 
//┃┫┫┫╋╰━━┛▅┗━━╯╋
//┃┫┫┫╋┊┊┊┣┻┫┊┊┊╋
//┃┊┊┊╰┈┈┈┈┈┈┈┳━╯
//┃┣┳┳━━┫┣━━┳╭╯
{
    internal class ShopNetwork //Название класса
    {
        private List<Shop> shops; //Коллекция хранения объектов типа 'Shop'
        private Dictionary<string, Shop> shopsByName; //Словарь, где ключ: 'string' тип: 'Shop'. Используется для быстрого доступа к магазинам по их имени.
        public ShopNetwork() //Консткрутор
        {
            shops = new List<Shop>(); //Создаёт список с элементами типа 'Shop'
            shopsByName = new Dictionary<string, Shop>(); //Создаёт словарь, где ключ: 'string' тип: 'Shop'. Используется для быстрого доступа к магазинам по их имени.
        }
        public void AddShop(Shop shop) //Добавляет магазин
        {
            shops.Add(shop); 
            shopsByName.Add(shop.Name, shop);
        }
        public void RemoveShop(Shop shop) //Удаляет магазин
        {
            shops.Remove(shop);
            shopsByName.Remove(shop.Name);
        }
        public List<Shop> GetShops() //Возвращает список всех магазинов, хранящихся в объекте класса 
        {
            return shops;
        }
        public Shop GetShopByName(string name) //Возвращает магазин по заданному имени из списка магазинов "ListBox"
        {
            return shops.FirstOrDefault(shop => string.Equals(shop.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
