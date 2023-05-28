using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
//Рыжков ПР-24 ПР-24 29.05.2023 0:23
//    ╭━╮----┈╭━╮ 
//┃╭╯┈┃┊┗━━━━━┛┊┃
//┃╰┳┳┫┏━▅╮┊╭━▅┓┃
//┃┫┫┫┫┃┊▉┃┊┃┊▉┃┃ 
//┃┫┫┫╋╰━━┛▅┗━━╯╋
//┃┫┫┫╋┊┊┊┣┻┫┊┊┊╋
//┃┊┊┊╰┈┈┈┈┈┈┈┳━╯
//┃┣┳┳━━┫┣━━┳╭╯
namespace ChainOfStores
{
    public partial class Form1 : Form
    {
        private ShopNetwork shopNetwork; //Объявление приватного поля в нутри класса 'ShopNetwork'
        public Form1() //Форма "Сеть магазинов"
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //При запуске формы, ей нельзя менять границы.
            shopNetwork = new ShopNetwork(); //Cоздает новый объект типа.
        }
        private void UpdateShopList() //Обновляет ListBox при добавление или удалении магазина .
        {
            //listBox1.Items.Clear(); //Очистка айтомов в ListBox
            List<Shop> shops = shopNetwork.GetShops(); //Получает список магазинов из 'shopNetwork' с помощью вызова метода 'GetShops()'.

            foreach (Shop shop in shops.Distinct()) //Использование Linq 
            {
                listBox1.Items.Add(shop.GetInfo()); //Добавлаяет строку с магазином, и выводить всю информацию о нём.
            }
        }
        private void AddShop_Click(object sender, EventArgs e) //Добавление магазина в ListBox1.
        {
            string name = textBox1.Text; //Название магазина берётся из TextBoxa.
            int salesCount; //Количество продаж.
            int monthlyRevenue; //Выручка за месяц.
            int customerCount; //Количество покупателей.
            if (string.IsNullOrEmpty(name)) //Проверка ввода. Название магазина не может быть пустым.
            {
                MessageBox.Show("Название магазина не может быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (shopNetwork.GetShopByName(name) != null) //Проверка ввода. Не может быть две одинаковых сети магазинов.
            {
                MessageBox.Show("Такая сеть магазина уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBox2.Text, out monthlyRevenue) || monthlyRevenue < 0) //Проверка ввода. Число не можеть быть отрицательным.
            {
                MessageBox.Show("Выручка за месяц не может быть отрицательной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBox3.Text, out salesCount) || salesCount < 0) //Проверка ввода. Число не можеть быть отрицательным.
            {
                MessageBox.Show("Количество продаж не может быть отрицательной", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBox4.Text, out customerCount) || customerCount < 0) //Проверка ввода. Число не можеть быть отрицательным.
            {
                MessageBox.Show("Количество покупателей не может быть отрицательной", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }                    
            Shop shop = new Shop(name, salesCount, monthlyRevenue, customerCount); //Создает объект с параметрами: name, salesCount, monthlyRevenue, customerCount.
            shopNetwork.AddShop(shop); //добавляет созданный объект 'shop' в 'shopNetwork'.
            UpdateShopList(); //Обновляет ListBox.
        }
        private void RemoveShop_Click(object sender, EventArgs e) //Удаление магазина из ListBox1.
        {
            if (listBox1.SelectedItem != null) //Магазин не выбран, то ошибка.
            {
                string selectedShopText = listBox1.SelectedItem.ToString(); //Получаем выбранный эелемент из ListBox
                Shop selectedShop = shopNetwork.GetShops().FirstOrDefault(shop => shop.GetInfo() == selectedShopText); //Выполняет поиск магазина в 'shopNetwork' + Linq
                shopNetwork.RemoveShop(selectedShop); //Удаляет магазин
                UpdateShopList();  //Обновляет ListBox
            }
            else ////Ошибка, если магазин не выбран
            {
                MessageBox.Show("Выберите магазин для удаления.", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error); //Ошибка
            }
        }
        private void ClearListBox_Click(object sender, EventArgs e) //Очищает спикок магазинов.
        {
            listBox1.Items.Clear();  //Очистка
        }
        private void Q_Click(object sender, EventArgs e) //Q = выручка/ количество продаж за месяц;.
        {
            if (listBox1.SelectedItem != null) //Магазин не выбран, то ошибка.
            {
                int selectedIndex = listBox1.SelectedIndex; //Индекс магазина из ListBox.
                Shop selectedShop = shopNetwork.GetShops()[selectedIndex]; 
                double Q = selectedShop.MonthlyRevenue / selectedShop.MonthlyRevenue; //Берёт из класса 'Shop' параметры 'MonthlyRevenue' и 'MonthlyRevenue'
                double Qp;
                if (selectedShop.CustomerCount > 50000)  //Покупателей больше 50000.
                {
                    Qp = 2 * Q;
                    Qp = Math.Round(Qp, 2);
                    MessageBox.Show($"Значение Qp находим по формуле 2*Q. Qp= {Qp}","Результат", MessageBoxButtons.OK,MessageBoxIcon.Error); //Ответ
                }
                else //Покупателей меньше 50000.
                {
                    Qp = 0.5 * Q;
                    Qp = Math.Round(Qp, 2);
                    MessageBox.Show($"Значение Qp находим по формуле 0.5*Q. Qp= {Qp}","Результат", MessageBoxButtons.OK,MessageBoxIcon.Error); //Ответ
                }
            }
            else  //Ошибка, если магазин не выбран.
            {
                MessageBox.Show("Пожалуйста, выберите магазин для расчета Q.", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error); //Магазин не выбран!
            }
        }
        private void Exit_Click(object sender, EventArgs e) //Выход из приложения.
        {
            Application.Exit(); //Выход 
        }
        private void LinkToECTS_Click(object sender, EventArgs e) //Переход по ссылке 
        {
            Process.Start("https://www.ects.ru/"); //Cсылочка
        }

        private void button6_Click(object sender, EventArgs e) //Меняет на случайный цвет форме
        {
            Random color = new Random(); //Рандом
            this.BackColor = Color.FromArgb(color.Next(255), color.Next(255), color.Next(255)); //Меняет у формы цвет. 255, это количетсво цветов которые могут выпасть
        }
        private void button7_Click(object sender, EventArgs e) //Меняет цвет на белый
        {
            this.BackColor = Color.White;
        }
    }
}
